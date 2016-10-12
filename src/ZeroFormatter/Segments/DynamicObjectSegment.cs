using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // ObjectSegment is inherit to target class directly or generate.

    // Layout: [int byteSize][indexCount][indexOffset:int...][t format...]

    public static class ObjectSegmentHelper
    {
        public static int GetByteSize(ArraySegment<byte> originalBytes)
        {
            var array = originalBytes.Array;
            return BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
        }

        public static int GetOffset(ArraySegment<byte> originalBytes, int index)
        {
            var array = originalBytes.Array;
            return BinaryUtil.ReadInt32(ref array, originalBytes.Offset + 8 + 4 * index);
        }

        public static ArraySegment<byte> GetSegment(ArraySegment<byte> originalBytes, int index, int lastIndex)
        {
            var offset = GetOffset(originalBytes, index);
            if (index == lastIndex)
            {
                var sliceLength = originalBytes.Offset + originalBytes.Count;
                return new ArraySegment<byte>(originalBytes.Array, offset, (sliceLength - offset));
            }
            else
            {
                var nextOffset = GetOffset(originalBytes, index + 1);
                return new ArraySegment<byte>(originalBytes.Array, offset, (nextOffset - offset));
            }
        }

        public static int SerializeFixedLength<T>(ref byte[] targetBytes, int startOffset, int offset, int index, ArraySegment<byte> originalBytes)
        {
            BinaryUtil.WriteInt32(ref targetBytes, startOffset + (8 + 4 * index), offset);

            var formatter = global::ZeroFormatter.Formatters.Formatter<T>.Default;
            var len = formatter.GetLength();
            BinaryUtil.EnsureCapacity(ref targetBytes, offset, len.Value);
            Buffer.BlockCopy(originalBytes.Array, GetOffset(originalBytes, index), targetBytes, offset, len.Value);
            return len.Value;
        }

        public static int SerializeSegment<T>(ref byte[] targetBytes, int startOffset, int offset, int index, T segment)
        {
            BinaryUtil.WriteInt32(ref targetBytes, startOffset + (8 + 4 * index), offset);

            var formatter = global::ZeroFormatter.Formatters.Formatter<T>.Default;
            return formatter.Serialize(ref targetBytes, offset, segment);
        }

        public static int SerializeCacheSegment<T>(ref byte[] targetBytes, int startOffset, int offset, int index, CacheSegment<T> segment)
        {
            BinaryUtil.WriteInt32(ref targetBytes, startOffset + (8 + 4 * index), offset);

            return segment.Serialize(ref targetBytes, offset);
        }

        public static T GetFixedProperty<T>(ArraySegment<byte> bytes, int index, DirtyTracker tracker)
        {
            var array = bytes.Array;
            int _;
            return Formatter<T>.Default.Deserialize(ref array, ObjectSegmentHelper.GetOffset(bytes, index), tracker, out _);
        }

        public static void SetFixedProperty<T>(ArraySegment<byte> bytes, int index, T value)
        {
            var array = bytes.Array;
            Formatter<T>.Default.Serialize(ref array, ObjectSegmentHelper.GetOffset(bytes, index), value);
        }

        public static int WriteSize(ref byte[] targetBytes, int startOffset, int lastOffset, int lastIndex)
        {
            BinaryUtil.WriteInt32(ref targetBytes, startOffset + 4, lastIndex);
            var writeSize = lastOffset - startOffset;
            BinaryUtil.WriteInt32(ref targetBytes, startOffset, writeSize);
            return writeSize;
        }

        public static int DirectCopyAll(ArraySegment<byte> originalBytes, ref byte[] targetBytes, int targetOffset)
        {
            var array = originalBytes.Array;
            var copyCount = BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
            BinaryUtil.EnsureCapacity(ref targetBytes, targetOffset, copyCount);
            Buffer.BlockCopy(array, originalBytes.Offset, targetBytes, targetOffset, copyCount);
            return copyCount;
        }
    }

    internal static class DynamicAssemblyHolder
    {
        public const string ModuleName = "ZeroFormatter.DynamicObjectSegments";

        public static readonly Lazy<ModuleBuilder> Module = new Lazy<ModuleBuilder>(() => MakeDynamicAssembly(), true);

        public static object ModuleLock = new object(); // be careful!

        static ModuleBuilder MakeDynamicAssembly()
        {
            var assemblyName = new AssemblyName(ModuleName);
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(ModuleName);

            return moduleBuilder;
        }
    }

    internal static class DynamicObjectSegmentBuilder<T>
    {
        static readonly MethodInfo ArraySegmentArrayGet = typeof(ArraySegment<byte>).GetProperty("Array").GetGetMethod();
        static readonly MethodInfo ArraySegmentOffsetGet = typeof(ArraySegment<byte>).GetProperty("Offset").GetGetMethod();
        static readonly MethodInfo ReadInt32 = typeof(BinaryUtil).GetMethod("ReadInt32");
        static readonly MethodInfo CreateChild = typeof(DirtyTracker).GetMethod("CreateChild");
        static readonly MethodInfo Dirty = typeof(DirtyTracker).GetMethod("Dirty");
        static readonly MethodInfo IsDirty = typeof(DirtyTracker).GetProperty("IsDirty").GetGetMethod();
        static readonly MethodInfo GetSegment = typeof(ObjectSegmentHelper).GetMethod("GetSegment");
        static readonly MethodInfo GetOffset = typeof(ObjectSegmentHelper).GetMethod("GetOffset");

        static readonly Lazy<Type> lazyBuild = new Lazy<Type>(() => Build(), true);

        public static Type GetProxyType()
        {
            return lazyBuild.Value;
        }

        static Type Build()
        {
            Type generatedType;
            lock (DynamicAssemblyHolder.ModuleLock)
            {
                var moduleBuilder = DynamicAssemblyHolder.Module.Value;
                generatedType = GenerateObjectSegmentImplementation(moduleBuilder);
            }
            return generatedType;
        }

        static Type GenerateObjectSegmentImplementation(ModuleBuilder moduleBuilder)
        {
            // public class DynamicObjectSegment.MyClass : MyClass, IZeroFormatterSegment
            var type = moduleBuilder.DefineType(
                DynamicAssemblyHolder.ModuleName + "." + typeof(T).FullName,
                TypeAttributes.Public,
                typeof(T));

            // TODO:Change name to <>_
            var originalBytes = type.DefineField("_originalBytes", typeof(ArraySegment<byte>), FieldAttributes.Private | FieldAttributes.InitOnly);
            var tracker = type.DefineField("_tracker", typeof(DirtyTracker), FieldAttributes.Private | FieldAttributes.InitOnly);
            var lastIndex = type.DefineField("_lastIndex", typeof(int), FieldAttributes.Private | FieldAttributes.InitOnly);

            var properties = GetProperties(type);

            BuildConstructor(type, originalBytes, tracker, lastIndex, properties);

            foreach (var item in properties)
            {
                if (item.IsFixedSize)
                {
                    BuildFixedProperty(type, originalBytes, tracker, item);
                }
                else if (item.IsCacheSegment)
                {
                    BuildCacheSegmentProperty(type, originalBytes, tracker, item);
                }
                else
                {
                    BuildSegmentProperty(type, originalBytes, tracker, item);
                }
            }

            BuildInterfaceMethod(type, originalBytes, tracker, lastIndex, properties);

            return type.CreateType();
        }

        static List<PropertyTuple> GetProperties(TypeBuilder typeBuilder)
        {
            var lastIndex = -1;

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => !x.GetCustomAttributes(typeof(IgnoreFormatAttribute), true).Any())
                .Select(x => new { PropInfo = x, IndexAttr = x.GetCustomAttributes(typeof(IndexAttribute), true).Cast<IndexAttribute>().FirstOrDefault() })
                .Where(x => x.IndexAttr != null)
                .OrderBy(x => x.IndexAttr.Index);

            var list = new List<PropertyTuple>();

            foreach (var p in props)
            {
                var propInfo = p.PropInfo;
                var index = p.IndexAttr.Index;

                var formatter = (IFormatter)typeof(Formatter<>).MakeGenericType(propInfo.PropertyType).GetProperty("Default").GetValue(null, Type.EmptyTypes);

                if (formatter.GetLength() == null)
                {
                    // TODO:use <>
                    if (CacheSegment.CanAccept(propInfo.PropertyType))
                    {
                        var fieldBuilder = typeBuilder.DefineField("__" + propInfo.Name, typeof(CacheSegment<>).MakeGenericType(propInfo.PropertyType), FieldAttributes.Private);
                        list.Add(new PropertyTuple { Index = index, PropertyInfo = propInfo, IsFixedSize = false, SegmentField = fieldBuilder, IsCacheSegment = true });
                    }
                    else
                    {
                        var fieldBuilder = typeBuilder.DefineField("__" + propInfo.Name, propInfo.PropertyType, FieldAttributes.Private);
                        list.Add(new PropertyTuple { Index = index, PropertyInfo = propInfo, IsFixedSize = false, SegmentField = fieldBuilder });
                    }
                }
                else
                {
                    list.Add(new PropertyTuple { Index = index, PropertyInfo = propInfo, IsFixedSize = true });
                }

                lastIndex = index;
            }

            return list;
        }

        static void BuildConstructor(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField, FieldInfo lastIndexField, List<PropertyTuple> properties)
        {
            var method = type.DefineMethod(".ctor", System.Reflection.MethodAttributes.Public | System.Reflection.MethodAttributes.HideBySig);

            var baseCtor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, new Type[] { }, null);

            method.SetReturnType(typeof(void));
            method.SetParameters(typeof(DirtyTracker), typeof(ArraySegment<byte>));

            var generator = method.GetILGenerator();

            generator.DeclareLocal(typeof(byte[]));
            generator.DeclareLocal(typeof(int));

            // ctor
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Call, baseCtor);

            // Local Var( var array = originalBytes.Array; )
            generator.Emit(OpCodes.Ldarga_S, (byte)2);
            generator.Emit(OpCodes.Call, ArraySegmentArrayGet);
            generator.Emit(OpCodes.Stloc_0);

            // Assign Field Common
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Stfld, originalBytesField);

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Callvirt, CreateChild);
            generator.Emit(OpCodes.Dup);
            generator.Emit(OpCodes.Starg_S, (byte)1);
            generator.Emit(OpCodes.Stfld, trackerField);

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldloca_S, (byte)0);
            generator.Emit(OpCodes.Ldarga_S, (byte)2);
            generator.Emit(OpCodes.Call, ArraySegmentOffsetGet);
            generator.Emit(OpCodes.Ldc_I4_4);
            generator.Emit(OpCodes.Add);
            generator.Emit(OpCodes.Call, ReadInt32);
            generator.Emit(OpCodes.Stfld, lastIndexField);

            foreach (var item in properties)
            {
                if (item.IsFixedSize) continue;

                if (item.IsCacheSegment)
                {
                    AssignCacheSegment(generator, item.Index, trackerField, lastIndexField, item.SegmentField);
                }
                else
                {
                    AssignSegment(generator, item.Index, trackerField, lastIndexField, item.SegmentField);
                }
            }

            generator.Emit(OpCodes.Ret);
        }

        static void AssignCacheSegment(ILGenerator generator, int index, FieldInfo tracker, FieldInfo lastIndex, FieldInfo field)
        {
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, tracker);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Ldc_I4, index);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, lastIndex);
            generator.Emit(OpCodes.Call, GetSegment);
            generator.Emit(OpCodes.Newobj, field.FieldType.GetConstructors().First());
            generator.Emit(OpCodes.Stfld, field);
        }

        static void AssignSegment(ILGenerator generator, int index, FieldInfo tracker, FieldInfo lastIndex, FieldInfo field)
        {
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Call, typeof(Formatter<>).MakeGenericType(field.FieldType).GetProperty("Default").GetGetMethod());
            generator.Emit(OpCodes.Ldloca_S, (byte)0);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Ldc_I4, index);
            generator.Emit(OpCodes.Call, GetOffset);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, tracker);
            generator.Emit(OpCodes.Ldloca_S, (byte)1);
            generator.Emit(OpCodes.Callvirt, typeof(Formatter<>).MakeGenericType(field.FieldType).GetMethod("Deserialize"));
            generator.Emit(OpCodes.Stfld, field);
        }

        static void BuildFixedProperty(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField, PropertyTuple property)
        {
            var prop = type.DefineProperty(property.PropertyInfo.Name, property.PropertyInfo.Attributes, property.PropertyInfo.PropertyType, Type.EmptyTypes);

            // build get
            var getMethod = property.PropertyInfo.GetGetMethod();
            if (getMethod != null)
            {
                var method = type.DefineMethod(getMethod.Name, getMethod.Attributes & ~MethodAttributes.NewSlot, getMethod.ReturnType, Type.EmptyTypes);

                var generator = method.GetILGenerator();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, originalBytesField);
                generator.Emit(OpCodes.Ldc_I4, property.Index);
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, trackerField);
                generator.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetMethod("GetFixedProperty").MakeGenericMethod(getMethod.ReturnType));
                generator.Emit(OpCodes.Ret);

                prop.SetGetMethod(method);
            }

            // build set
            var setMethod = property.PropertyInfo.GetSetMethod();
            if (setMethod != null)
            {
                var method = type.DefineMethod(setMethod.Name, setMethod.Attributes & ~MethodAttributes.NewSlot, null, new[] { setMethod.GetParameters()[0].ParameterType });

                var generator = method.GetILGenerator();

                generator.DeclareLocal(typeof(byte[]));

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, originalBytesField);
                generator.Emit(OpCodes.Ldc_I4, property.Index);
                generator.Emit(OpCodes.Ldarg_1);
                generator.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetMethod("SetFixedProperty").MakeGenericMethod(getMethod.ReturnType));
                generator.Emit(OpCodes.Ret);

                prop.SetSetMethod(method);
            }
        }

        static void BuildCacheSegmentProperty(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField, PropertyTuple property)
        {
            var prop = type.DefineProperty(property.PropertyInfo.Name, property.PropertyInfo.Attributes, property.PropertyInfo.PropertyType, Type.EmptyTypes);

            // build get
            var getMethod = property.PropertyInfo.GetGetMethod();
            if (getMethod != null)
            {
                var method = type.DefineMethod(getMethod.Name, getMethod.Attributes & ~MethodAttributes.NewSlot, getMethod.ReturnType, Type.EmptyTypes);

                var generator = method.GetILGenerator();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, property.SegmentField);
                generator.Emit(OpCodes.Callvirt, property.SegmentField.FieldType.GetProperty("Value").GetGetMethod());
                generator.Emit(OpCodes.Ret);

                prop.SetGetMethod(method);
            }

            // build set
            var setMethod = property.PropertyInfo.GetSetMethod();
            if (setMethod != null)
            {
                var method = type.DefineMethod(setMethod.Name, setMethod.Attributes & ~MethodAttributes.NewSlot, null, new[] { setMethod.GetParameters()[0].ParameterType });

                var generator = method.GetILGenerator();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, property.SegmentField);
                generator.Emit(OpCodes.Ldarg_1);
                generator.Emit(OpCodes.Callvirt, property.SegmentField.FieldType.GetProperty("Value").GetSetMethod());
                generator.Emit(OpCodes.Ret);

                prop.SetSetMethod(method);
            }
        }

        static void BuildSegmentProperty(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField, PropertyTuple property)
        {
            var prop = type.DefineProperty(property.PropertyInfo.Name, property.PropertyInfo.Attributes, property.PropertyInfo.PropertyType, Type.EmptyTypes);

            // build get
            var getMethod = property.PropertyInfo.GetGetMethod();
            if (getMethod != null)
            {
                var method = type.DefineMethod(getMethod.Name, getMethod.Attributes & ~MethodAttributes.NewSlot, getMethod.ReturnType, Type.EmptyTypes);

                var generator = method.GetILGenerator();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, property.SegmentField);
                generator.Emit(OpCodes.Ret);

                prop.SetGetMethod(method);
            }

            // build set
            var setMethod = property.PropertyInfo.GetSetMethod();
            if (setMethod != null)
            {
                var method = type.DefineMethod(setMethod.Name, setMethod.Attributes & ~MethodAttributes.NewSlot, null, new[] { setMethod.GetParameters()[0].ParameterType });

                var generator = method.GetILGenerator();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, trackerField);
                generator.Emit(OpCodes.Callvirt, Dirty);
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldarg_1);
                generator.Emit(OpCodes.Stfld, property.SegmentField);
                generator.Emit(OpCodes.Ret);

                prop.SetSetMethod(method);
            }
        }

        static void BuildInterfaceMethod(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField, FieldInfo lastIndexField, List<PropertyTuple> properties)
        {
            type.AddInterfaceImplementation(typeof(IZeroFormatterSegment));

            // CanDirectCopy
            {
                var method = type.DefineMethod("CanDirectCopy", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, typeof(bool), Type.EmptyTypes);
                var generator = method.GetILGenerator();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, trackerField);
                generator.Emit(OpCodes.Callvirt, IsDirty);
                generator.Emit(OpCodes.Ldc_I4_0);
                generator.Emit(OpCodes.Ceq);
                generator.Emit(OpCodes.Ret);
            }
            // GetBufferReference
            {
                var method = type.DefineMethod("GetBufferReference", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, typeof(ArraySegment<byte>), Type.EmptyTypes);
                var generator = method.GetILGenerator();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, originalBytesField);
                generator.Emit(OpCodes.Ret);
            }
            // Serialize
            {
                var method = type.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, typeof(int), new[] { typeof(byte[]).MakeByRefType(), typeof(int) });
                var generator = method.GetILGenerator();

                generator.DeclareLocal(typeof(int));
                var label = generator.DefineLabel();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, trackerField);
                generator.Emit(OpCodes.Callvirt, IsDirty);
                // if
                {
                    generator.Emit(OpCodes.Brfalse, label);
                    generator.Emit(OpCodes.Ldarg_2);
                    generator.Emit(OpCodes.Ldc_I4_8);
                    generator.Emit(OpCodes.Ldc_I4_4);
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldfld, lastIndexField);
                    generator.Emit(OpCodes.Ldc_I4_1);
                    generator.Emit(OpCodes.Add);
                    generator.Emit(OpCodes.Mul);
                    generator.Emit(OpCodes.Add);
                    generator.Emit(OpCodes.Add);

                    foreach (var prop in properties)
                    {
                        generator.Emit(OpCodes.Starg_S, (byte)2);
                        generator.Emit(OpCodes.Ldarg_2);
                        generator.Emit(OpCodes.Ldarg_1);
                        generator.Emit(OpCodes.Ldloc_0);
                        generator.Emit(OpCodes.Ldarg_2);
                        generator.Emit(OpCodes.Ldc_I4, prop.Index);
                        generator.Emit(OpCodes.Ldarg_0);

                        // load field and call
                        if (prop.IsFixedSize)
                        {
                            generator.Emit(OpCodes.Ldfld, originalBytesField);
                            generator.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetMethod("SerializeFixedLength").MakeGenericMethod(prop.PropertyInfo.PropertyType));
                        }
                        else if (prop.IsCacheSegment)
                        {
                            generator.Emit(OpCodes.Ldfld, prop.SegmentField);
                            generator.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetMethod("SerializeCacheSegment").MakeGenericMethod(prop.PropertyInfo.PropertyType));
                        }
                        else
                        {
                            generator.Emit(OpCodes.Ldfld, prop.SegmentField);
                            generator.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetMethod("SerializeSegment").MakeGenericMethod(prop.PropertyInfo.PropertyType));
                        }
                        generator.Emit(OpCodes.Add);
                    }

                    generator.Emit(OpCodes.Starg_S, (byte)2);
                    generator.Emit(OpCodes.Ldarg_1);
                    generator.Emit(OpCodes.Ldloc_0);
                    generator.Emit(OpCodes.Ldarg_2);
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldfld, lastIndexField);
                    generator.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetMethod("WriteSize"));
                    generator.Emit(OpCodes.Ret);
                }
                // else
                {
                    generator.MarkLabel(label);
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldfld, originalBytesField);
                    generator.Emit(OpCodes.Ldarg_1);
                    generator.Emit(OpCodes.Ldarg_2);
                    generator.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetMethod("DirectCopyAll"));
                    generator.Emit(OpCodes.Ret);
                }
            }
        }


        //static void BuildMethod(TypeBuilder type, MethodInfo interfaceMethodInfo, FieldInfo contextField, FieldInfo targetPeerField)
        //{
        //    MethodAttributes methodAttributes =
        //          MethodAttributes.Public
        //        | MethodAttributes.Virtual
        //        | MethodAttributes.Final
        //        | MethodAttributes.HideBySig
        //        | MethodAttributes.NewSlot;

        //    ParameterInfo[] parameters = interfaceMethodInfo.GetParameters();
        //    Type[] paramTypes = parameters.Select(param => param.ParameterType).ToArray();

        //    MethodBuilder methodBuilder = type.DefineMethod(interfaceMethodInfo.Name, methodAttributes);

        //    // void BroadcastEvent(IEnumerable<IPhotonWirePeer> targetPeers, byte eventCode, params object[] args);
        //    MethodInfo invokeMethod = typeof(HubContext).GetMethod(
        //        "BroadcastEvent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null,
        //        new Type[] { typeof(IEnumerable<IPhotonWirePeer>), typeof(byte), typeof(object[]) }, null);

        //    methodBuilder.SetReturnType(interfaceMethodInfo.ReturnType);
        //    methodBuilder.SetParameters(paramTypes);

        //    ILGenerator generator = methodBuilder.GetILGenerator();

        //    generator.DeclareLocal(typeof(object[]));

        //    // Get Context and peer
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldfld, contextField); // context
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldfld, targetPeerField); // peer

        //    // OpCode
        //    var opCode = interfaceMethodInfo.GetCustomAttribute<OperationAttribute>().OperationCode;
        //    generator.Emit(OpCodes.Ldc_I4, (int)opCode);

        //    // new[]{ }
        //    generator.Emit(OpCodes.Ldc_I4, parameters.Length);
        //    generator.Emit(OpCodes.Newarr, typeof(object));
        //    generator.Emit(OpCodes.Stloc_0);

        //    // object[]
        //    for (int i = 0; i < paramTypes.Length; i++)
        //    {
        //        generator.Emit(OpCodes.Ldloc_0);
        //        generator.Emit(OpCodes.Ldc_I4, i);
        //        generator.Emit(OpCodes.Ldarg, i + 1);
        //        generator.Emit(OpCodes.Box, paramTypes[i]);
        //        generator.Emit(OpCodes.Stelem_Ref);
        //    }

        //    // Call BroadcastEvent
        //    generator.Emit(OpCodes.Ldloc_0);
        //    generator.Emit(OpCodes.Callvirt, invokeMethod);

        //    generator.Emit(OpCodes.Ret);
        //}

        //// Verify

        //// TODO:No Interface
        //static void VerifyInterface(Type interfaceType)
        //{
        //    if (!interfaceType.IsInterface)
        //    {
        //        throw new InvalidOperationException($"Hub<T>'s T must be interface : {interfaceType.Name}");
        //    }

        //    if (interfaceType.GetProperties().Length != 0)
        //    {
        //        throw new InvalidOperationException($"Client proxy type must not contains properties : {interfaceType.Name}");
        //    }

        //    if (interfaceType.GetEvents().Length != 0)
        //    {
        //        throw new InvalidOperationException($"Client proxy type must not contains events : {interfaceType.Name}");
        //    }

        //    foreach (var method in interfaceType.GetMethods())
        //    {
        //        VerifyMethod(interfaceType, method);
        //    }

        //    foreach (var parent in interfaceType.GetInterfaces())
        //    {
        //        VerifyInterface(parent);
        //    }
        //}

        //static void VerifyMethod(Type interfaceType, MethodInfo interfaceMethod)
        //{
        //    if (interfaceMethod.ReturnType != typeof(void))
        //    {
        //        throw new InvalidOperationException($"Client proxy's method must return void : {interfaceType.Name}.{interfaceMethod.Name}");
        //    }

        //    if (interfaceMethod.GetCustomAttributes<OperationAttribute>().FirstOrDefault() == null)
        //    {
        //        throw new InvalidOperationException($"Client proxy's method must put OperationAttribute : {interfaceType.Name}.{interfaceMethod.Name}");
        //    }

        //    foreach (var parameter in interfaceMethod.GetParameters())
        //    {
        //        VerifyParameter(interfaceType, interfaceMethod, parameter);
        //    }
        //}

        //static void VerifyParameter(Type interfaceType, MethodInfo interfaceMethod, ParameterInfo parameter)
        //{
        //    if (parameter.IsOut)
        //    {
        //        throw new InvalidOperationException($"Client proxy's method must not take out parameter : {interfaceType.Name}.{interfaceMethod.Name}({parameter.Name})");
        //    }

        //    if (parameter.ParameterType.IsByRef)
        //    {
        //        throw new InvalidOperationException($"Client proxy's method must not take ref parameter : {interfaceType.Name}.{interfaceMethod.Name}({parameter.Name})");
        //    }
        //}

        class PropertyTuple
        {
            public int Index;
            public PropertyInfo PropertyInfo;
            public FieldInfo SegmentField;
            public bool IsCacheSegment;
            public bool IsFixedSize;
        }
    }
}
