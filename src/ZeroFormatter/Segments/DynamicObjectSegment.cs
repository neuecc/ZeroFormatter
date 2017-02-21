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
        // Dirty Helpers...

        public static int GetByteSize(ArraySegment<byte> originalBytes)
        {
            var array = originalBytes.Array;
            return BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
        }

        public static int GetOffset(ArraySegment<byte> originalBytes, int index, int lastIndex, DirtyTracker tracker)
        {
            if (index > lastIndex)
            {
                return -1;
            }
            var array = originalBytes.Array;
            var readOffset = BinaryUtil.ReadInt32(ref array, originalBytes.Offset + 8 + 4 * index);
            if (readOffset == 0) return -1;
            return originalBytes.Offset + readOffset;
        }

        public static ArraySegment<byte> GetSegment(ArraySegment<byte> originalBytes, int index, int lastIndex, DirtyTracker tracker)
        {
            var offset = GetOffset(originalBytes, index, lastIndex, tracker);
            if (offset == -1)
            {
                return default(ArraySegment<byte>); // note:very very dangerous.
            }

            var sliceLength = originalBytes.Offset + originalBytes.Count;
            return new ArraySegment<byte>(originalBytes.Array, offset, (sliceLength - offset));
        }

        public static T DeserializeSegment<TTypeResolver, T>(ArraySegment<byte> originalBytes, int index, int lastIndex, DirtyTracker tracker)
            where TTypeResolver : ITypeResolver, new()
        {
            var offset = ObjectSegmentHelper.GetOffset(originalBytes, index, lastIndex, tracker);
            if (offset == -1) return default(T);

            int size;
            var array = originalBytes.Array;
            return Formatter<TTypeResolver, T>.Default.Deserialize(ref array, offset, tracker, out size);
        }

        public static int SerializeFixedLength<TTypeResolver, T>(ref byte[] targetBytes, int startOffset, int offset, int index, int lastIndex, ArraySegment<byte> originalBytes, byte[] extraBytes, DirtyTracker tracker)
            where TTypeResolver : ITypeResolver, new()
        {
            BinaryUtil.WriteInt32(ref targetBytes, startOffset + (8 + 4 * index), offset - startOffset);

            var formatter = global::ZeroFormatter.Formatters.Formatter<TTypeResolver, T>.Default;
            var len = formatter.GetLength();

            BinaryUtil.EnsureCapacity(ref targetBytes, offset, len.Value);
            var readOffset = GetOffset(originalBytes, index, lastIndex, tracker);
            if (readOffset != -1)
            {
                Buffer.BlockCopy(originalBytes.Array, readOffset, targetBytes, offset, len.Value);
            }
            else
            {
                var extraOffset = GetExtraBytesOffset(extraBytes, lastIndex, index);
                Buffer.BlockCopy(extraBytes, extraOffset, targetBytes, offset, len.Value);
            }

            return len.Value;
        }

        public static int SerializeSegment<TTypeResolver, T>(ref byte[] targetBytes, int startOffset, int offset, int index, T segment)
            where TTypeResolver : ITypeResolver, new()
        {
            BinaryUtil.WriteInt32(ref targetBytes, startOffset + (8 + 4 * index), offset - startOffset);

            var formatter = global::ZeroFormatter.Formatters.Formatter<TTypeResolver, T>.Default;
            return formatter.Serialize(ref targetBytes, offset, segment);
        }

        public static int SerializeCacheSegment<TTypeResolver, T>(ref byte[] targetBytes, int startOffset, int offset, int index, ref CacheSegment<TTypeResolver, T> segment)
            where TTypeResolver : ITypeResolver, new()
        {
            BinaryUtil.WriteInt32(ref targetBytes, startOffset + (8 + 4 * index), offset - startOffset);

            return segment.Serialize(ref targetBytes, offset);
        }

        public static T GetFixedProperty<TTypeResolver, T>(ArraySegment<byte> bytes, int index, int lastIndex, byte[] extraBytes, DirtyTracker tracker)
            where TTypeResolver : ITypeResolver, new()
        {
            if (index <= lastIndex)
            {
                var array = bytes.Array;
                int _;
                return Formatter<TTypeResolver, T>.Default.Deserialize(ref array, ObjectSegmentHelper.GetOffset(bytes, index, lastIndex, tracker), tracker, out _);
            }
            else
            {
                // from extraBytes
                var offset = GetExtraBytesOffset(extraBytes, lastIndex, index);
                int _;
                return Formatter<TTypeResolver, T>.Default.Deserialize(ref extraBytes, offset, tracker, out _);
            }
        }

        public static void SetFixedProperty<TTypeResolver, T>(ArraySegment<byte> bytes, int index, int lastIndex, byte[] extraBytes, T value, DirtyTracker tracker)
            where TTypeResolver : ITypeResolver, new()
        {
            if (index <= lastIndex)
            {
                var array = bytes.Array;
                Formatter<TTypeResolver, T>.Default.Serialize(ref array, ObjectSegmentHelper.GetOffset(bytes, index, lastIndex, tracker), value);
            }
            else
            {
                // from extraBytes
                var offset = GetExtraBytesOffset(extraBytes, lastIndex, index);
                Formatter<TTypeResolver, T>.Default.Serialize(ref extraBytes, offset, value);
            }
        }

        public static int WriteSize(ref byte[] targetBytes, int startOffset, int lastOffset, int lastIndex)
        {
            BinaryUtil.WriteInt32(ref targetBytes, startOffset + 4, lastIndex);
            var writeSize = lastOffset - startOffset;
            BinaryUtil.WriteInt32Unsafe(ref targetBytes, startOffset, writeSize); // okay for use Unsafe.
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

        static int GetExtraBytesOffset(byte[] extraBytes, int binaryLastIndex, int index)
        {
            var offset = (index - binaryLastIndex - 1) * 4;
            return BinaryUtil.ReadInt32(ref extraBytes, offset);
        }

        public static byte[] CreateExtraFixedBytes(int binaryLastIndex, int schemaLastIndex, int[] elementSizes)
        {
            if (binaryLastIndex < schemaLastIndex)
            {
                // [header offsets] + [elements]
                var headerLength = (schemaLastIndex - binaryLastIndex) * 4;
                var elementSizeSum = elementSizes.Sum();
                var bytes = new byte[headerLength + elementSizeSum];
                var offset = headerLength + 4;
                for (int i = (binaryLastIndex + 1); i < elementSizes.Length; i++)
                {
                    if (elementSizes[i] != 0)
                    {
                        BinaryUtil.WriteInt32(ref bytes, (i - binaryLastIndex - 1) * 4, offset);
                        offset += elementSizes[i];
                    }
                }

                return bytes;
            }
            else
            {
                return null;
            }
        }

        public static int SerializeFromFormatter<TTypeResolver, T>(ref byte[] bytes, int startOffset, int offset, int index, T value)
        where TTypeResolver : ITypeResolver, new()
        {
            BinaryUtil.WriteInt32(ref bytes, startOffset + (8 + 4 * index), offset - startOffset);
            return Formatter<TTypeResolver, T>.Default.Serialize(ref bytes, offset, value);
        }

        public static Exception GetException1(string msgFormat, object o)
        {
            return new Exception(string.Format(msgFormat, o));
        }

#if !UNITY

        public static bool IsLazySegment(Type type)
        {
            var ti = type.GetTypeInfo();
            // ObjectSegment
            if (ti.IsClass && ti.GetCustomAttributes<ZeroFormattableAttribute>().Any())
            {
                return true;
            }
            if (ti.IsGenericType)
            {
                var genType = ti.GetGenericTypeDefinition();
                // ListSegment
                if (genType == typeof(IList<>))
                {
                    return true;
                }
                else if (genType == typeof(ILazyLookup<,>))
                {
                    return true;
                }
                else if (genType == typeof(ILazyDictionary<,>))
                {
                    return true;
                }
                else if (genType == typeof(ILazyReadOnlyDictionary<,>))
                {
                    return true;
                }
            }

            return false;
        }

#endif
    }

#if !UNITY

    internal static class DynamicAssemblyHolder
    {
        public const string ModuleName = "ZeroFormatter.DynamicObjectSegments";

        readonly static DynamicAssembly assembly;

        public static ModuleBuilder Module { get { return assembly.ModuleBuilder; } }

        static DynamicAssemblyHolder()
        {
            assembly = new DynamicAssembly(ModuleName);
        }
    }

    internal static class DynamicObjectSegmentBuilder<TTypeResolver, T>
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly MethodInfo ArraySegmentArrayGet = typeof(ArraySegment<byte>).GetTypeInfo().GetProperty("Array").GetGetMethod();
        static readonly MethodInfo ArraySegmentOffsetGet = typeof(ArraySegment<byte>).GetTypeInfo().GetProperty("Offset").GetGetMethod();
        static readonly MethodInfo ReadInt32 = typeof(BinaryUtil).GetTypeInfo().GetMethod("ReadInt32");
        static readonly MethodInfo CreateChild = typeof(DirtyTracker).GetTypeInfo().GetMethod("CreateChild");
        static readonly MethodInfo Dirty = typeof(DirtyTracker).GetTypeInfo().GetMethod("Dirty");
        static readonly MethodInfo IsDirty = typeof(DirtyTracker).GetTypeInfo().GetProperty("IsDirty").GetGetMethod();
        static readonly MethodInfo GetSegment = typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("GetSegment");
        static readonly MethodInfo GetOffset = typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("GetOffset");

        static readonly Lazy<TypeInfo> lazyBuild = new Lazy<TypeInfo>(() => Build(), true);

        class PropertyTuple
        {
            public int Index;
            public PropertyInfo PropertyInfo;
            public FieldInfo SegmentField;
            public bool IsCacheSegment;
            public bool IsFixedSize;
            public int FixedSize;
        }

        public static TypeInfo GetProxyType()
        {
            return lazyBuild.Value;
        }

        static TypeInfo Build()
        {
            TypeInfo generatedType;
            var moduleBuilder = DynamicAssemblyHolder.Module;
            generatedType = GenerateObjectSegmentImplementation(moduleBuilder);
            return generatedType;
        }

        static TypeInfo GenerateObjectSegmentImplementation(ModuleBuilder moduleBuilder)
        {
            // public class DynamicObjectSegment.MyClass : MyClass, IZeroFormatterSegment
            var type = moduleBuilder.DefineType(
                DynamicAssemblyHolder.ModuleName + "." + typeof(TTypeResolver).FullName.Replace(".", "_") + "." + typeof(T).FullName,
                TypeAttributes.Public,
                typeof(T));

            var originalBytes = type.DefineField("<>_originalBytes", typeof(ArraySegment<byte>), FieldAttributes.Private | FieldAttributes.InitOnly);
            var tracker = type.DefineField("<>_tracker", typeof(DirtyTracker), FieldAttributes.Private | FieldAttributes.InitOnly);
            var binaryLastIndex = type.DefineField("<>_binaryLastIndex", typeof(int), FieldAttributes.Private | FieldAttributes.InitOnly);
            var extraFixedBytes = type.DefineField("<>_extraFixedBytes", typeof(byte[]), FieldAttributes.Private | FieldAttributes.InitOnly);

            var properties = GetPropertiesWithVerify(type);

            BuildConstructor(type, originalBytes, tracker, binaryLastIndex, extraFixedBytes, properties);

            foreach (var item in properties)
            {
                if (item.IsFixedSize)
                {
                    BuildFixedProperty(type, originalBytes, tracker, binaryLastIndex, extraFixedBytes, item);
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

            BuildInterfaceMethod(type, originalBytes, tracker, binaryLastIndex, extraFixedBytes, properties);

            return type.CreateTypeInfo();
        }

        static PropertyTuple[] GetPropertiesWithVerify(TypeBuilder typeBuilder)
        {
            var resolverType = typeof(TTypeResolver);
            var lastIndex = -1;

            var list = new List<PropertyTuple>();

            // getproperties contains verify.
            foreach (var p in DynamicObjectDescriptor.GetMembers(resolverType, typeof(T), true))
            {
                var propInfo = p.Item2;
                var index = p.Item1;

                var formatter = (IFormatter)typeof(Formatter<,>).MakeGenericType(resolverType, propInfo.MemberType).GetTypeInfo().GetProperty("Default").GetValue(null, Type.EmptyTypes);

                if (formatter == null)
                {
                    throw new InvalidOperationException("Circular reference does not supported. " + typeof(T).Name + "." + propInfo.Name);
                }

                if (formatter.GetLength() == null)
                {
                    if (!ObjectSegmentHelper.IsLazySegment(propInfo.MemberType))
                    {
                        // CacheSegment
                        var fieldBuilder = typeBuilder.DefineField("<>_" + propInfo.Name, typeof(CacheSegment<,>).MakeGenericType(resolverType, propInfo.MemberType), FieldAttributes.Private);
                        list.Add(new PropertyTuple { Index = index, PropertyInfo = propInfo.PropertyInfoUnsafe, IsFixedSize = false, SegmentField = fieldBuilder, IsCacheSegment = true });
                    }
                    else
                    {
                        var fieldBuilder = typeBuilder.DefineField("<>_" + propInfo.Name, propInfo.MemberType, FieldAttributes.Private);
                        list.Add(new PropertyTuple { Index = index, PropertyInfo = propInfo.PropertyInfoUnsafe, IsFixedSize = false, SegmentField = fieldBuilder });
                    }
                }
                else
                {
                    list.Add(new PropertyTuple { Index = index, PropertyInfo = propInfo.PropertyInfoUnsafe, IsFixedSize = true, FixedSize = formatter.GetLength().Value });
                }

                lastIndex = index;
            }

            return list.OrderBy(x => x.Index).ToArray();
        }

        static void BuildConstructor(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField, FieldInfo lastIndexField, FieldInfo extraFixedBytes, PropertyTuple[] properties)
        {
            var method = type.DefineMethod(".ctor", System.Reflection.MethodAttributes.Public | System.Reflection.MethodAttributes.HideBySig);

            var baseCtor = typeof(T).GetTypeInfo().GetConstructor(Type.EmptyTypes);

            method.SetReturnType(typeof(void));
            method.SetParameters(typeof(DirtyTracker), typeof(ArraySegment<byte>));

            var il = method.GetILGenerator();

            il.DeclareLocal(typeof(byte[]));
            il.DeclareLocal(typeof(int));
            il.DeclareLocal(typeof(int[]));

            // ctor
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, baseCtor);

            // Local Var( var array = originalBytes.Array; )
            il.Emit(OpCodes.Ldarga_S, (byte)2);
            il.Emit(OpCodes.Call, ArraySegmentArrayGet);
            il.Emit(OpCodes.Stloc_0);

            // Assign Field Common
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Stfld, originalBytesField);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Callvirt, CreateChild);
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Starg_S, (byte)1);
            il.Emit(OpCodes.Stfld, trackerField);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldloca_S, (byte)0);
            il.Emit(OpCodes.Ldarga_S, (byte)2);
            il.Emit(OpCodes.Call, ArraySegmentOffsetGet);
            il.Emit(OpCodes.Ldc_I4_4);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Call, ReadInt32);
            il.Emit(OpCodes.Stfld, lastIndexField);

            var schemaLastIndex = properties.Select(x => x.Index).LastOrDefault();
            var dict = properties.Where(x => x.IsFixedSize).ToDictionary(x => x.Index, x => x.FixedSize);
            var elementSizes = new int[schemaLastIndex + 1];
            for (int i = 0; i < schemaLastIndex + 1; i++)
            {
                if (!dict.TryGetValue(i, out elementSizes[i]))
                {
                    elementSizes[i] = 0;
                }
            }
            EmitNewArray(il, elementSizes);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, lastIndexField);
            il.Emit(OpCodes.Ldc_I4, schemaLastIndex);
            il.Emit(OpCodes.Ldloc_2);
            il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("CreateExtraFixedBytes"));
            il.Emit(OpCodes.Stfld, extraFixedBytes);

            foreach (var item in properties)
            {
                if (item.IsFixedSize) continue;

                if (item.IsCacheSegment)
                {
                    AssignCacheSegment(il, item.Index, trackerField, lastIndexField, item.SegmentField);
                }
                else
                {
                    AssignSegment(il, item.Index, trackerField, lastIndexField, item.SegmentField);
                }
            }

            il.Emit(OpCodes.Ret);
        }

        static void EmitNewArray(ILGenerator il, int[] array)
        {
            il.Emit(OpCodes.Ldc_I4, array.Length);
            il.Emit(OpCodes.Newarr, typeof(int));
            il.Emit(OpCodes.Stloc_2);
            for (int i = 0; i < array.Length; i++)
            {
                il.Emit(OpCodes.Ldloc_2);
                il.Emit(OpCodes.Ldc_I4, i);
                il.Emit(OpCodes.Ldc_I4, array[i]);
                il.Emit(OpCodes.Stelem_I4);
            }
        }

        static void AssignCacheSegment(ILGenerator il, int index, FieldInfo tracker, FieldInfo lastIndex, FieldInfo field)
        {
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, tracker);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Ldc_I4, index);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, lastIndex);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, tracker);
            il.Emit(OpCodes.Call, GetSegment);
            il.Emit(OpCodes.Newobj, field.FieldType.GetTypeInfo().GetConstructors().First());
            il.Emit(OpCodes.Stfld, field);
        }

        static void AssignSegment(ILGenerator il, int index, FieldInfo tracker, FieldInfo lastIndex, FieldInfo field)
        {
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Ldc_I4, index);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, lastIndex);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, tracker);
            il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("DeserializeSegment").MakeGenericMethod(typeof(TTypeResolver), field.FieldType));
            il.Emit(OpCodes.Stfld, field);
        }

        static void BuildFixedProperty(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField, FieldInfo binaryLastIndex, FieldInfo extraBytes, PropertyTuple property)
        {
            var prop = type.DefineProperty(property.PropertyInfo.Name, property.PropertyInfo.Attributes, property.PropertyInfo.PropertyType, Type.EmptyTypes);

            // build get
            var getMethod = property.PropertyInfo.GetGetMethod();
            if (getMethod != null)
            {
                var method = type.DefineMethod(getMethod.Name, getMethod.Attributes & ~MethodAttributes.NewSlot, getMethod.ReturnType, Type.EmptyTypes);

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, originalBytesField);
                il.Emit(OpCodes.Ldc_I4, property.Index);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, binaryLastIndex);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, extraBytes);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, trackerField);
                il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("GetFixedProperty").MakeGenericMethod(typeof(TTypeResolver), getMethod.ReturnType));
                il.Emit(OpCodes.Ret);

                prop.SetGetMethod(method);
            }

            // build set
            var setMethod = property.PropertyInfo.GetSetMethod();
            if (setMethod != null)
            {
                var method = type.DefineMethod(setMethod.Name, setMethod.Attributes & ~MethodAttributes.NewSlot, null, new[] { setMethod.GetParameters()[0].ParameterType });

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, originalBytesField);
                il.Emit(OpCodes.Ldc_I4, property.Index);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, binaryLastIndex);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, extraBytes);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, trackerField);
                il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("SetFixedProperty").MakeGenericMethod(typeof(TTypeResolver), getMethod.ReturnType));
                il.Emit(OpCodes.Ret);

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

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldflda, property.SegmentField);
                il.Emit(OpCodes.Call, property.SegmentField.FieldType.GetTypeInfo().GetProperty("Value").GetGetMethod());
                il.Emit(OpCodes.Ret);

                prop.SetGetMethod(method);
            }

            // build set
            var setMethod = property.PropertyInfo.GetSetMethod();
            if (setMethod != null)
            {
                var method = type.DefineMethod(setMethod.Name, setMethod.Attributes & ~MethodAttributes.NewSlot, null, new[] { setMethod.GetParameters()[0].ParameterType });

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldflda, property.SegmentField);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Call, property.SegmentField.FieldType.GetTypeInfo().GetProperty("Value").GetSetMethod());
                il.Emit(OpCodes.Ret);

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

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, property.SegmentField);
                il.Emit(OpCodes.Ret);

                prop.SetGetMethod(method);
            }

            // build set
            var setMethod = property.PropertyInfo.GetSetMethod();
            if (setMethod != null)
            {
                var method = type.DefineMethod(setMethod.Name, setMethod.Attributes & ~MethodAttributes.NewSlot, null, new[] { setMethod.GetParameters()[0].ParameterType });

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, trackerField);
                il.Emit(OpCodes.Callvirt, Dirty);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Stfld, property.SegmentField);
                il.Emit(OpCodes.Ret);

                prop.SetSetMethod(method);
            }
        }

        static void BuildInterfaceMethod(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField, FieldInfo binaryLastIndexField, FieldInfo extraBytes, PropertyTuple[] properties)
        {
            type.AddInterfaceImplementation(typeof(IZeroFormatterSegment));
            // CanDirectCopy
            {
                var method = type.DefineMethod("CanDirectCopy", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, typeof(bool), Type.EmptyTypes);
                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, trackerField);
                il.Emit(OpCodes.Callvirt, IsDirty);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Ceq);
                il.Emit(OpCodes.Ret);
            }
            // GetBufferReference
            {
                var method = type.DefineMethod("GetBufferReference", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, typeof(ArraySegment<byte>), Type.EmptyTypes);
                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, originalBytesField);
                il.Emit(OpCodes.Ret);
            }
            // Serialize
            {
                var method = type.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, typeof(int), new[] { typeof(byte[]).MakeByRefType(), typeof(int) });
                var il = method.GetILGenerator();

                il.DeclareLocal(typeof(int));
                var labelA = il.DefineLabel();
                var labelB = il.DefineLabel();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, extraBytes);
                il.Emit(OpCodes.Brtrue, labelA);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, trackerField);
                il.Emit(OpCodes.Callvirt, IsDirty);
                il.Emit(OpCodes.Brfalse, labelB);
                // if
                {
                    var schemaLastIndex = properties.Select(x => x.Index).LastOrDefault();
                    var calcedBeginOffset = 8 + (4 * (schemaLastIndex + 1));

                    il.MarkLabel(labelA);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Stloc_0); // startOffset
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldc_I4, calcedBeginOffset);
                    il.Emit(OpCodes.Add);

                    foreach (var prop in properties)
                    {
                        il.Emit(OpCodes.Starg_S, (byte)2);
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldloc_0);
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldc_I4, prop.Index);

                        // load field and call
                        if (prop.IsFixedSize)
                        {
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Ldfld, binaryLastIndexField);
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Ldfld, originalBytesField);
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Ldfld, extraBytes);
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Ldfld, trackerField);
                            il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("SerializeFixedLength").MakeGenericMethod(typeof(TTypeResolver), prop.PropertyInfo.PropertyType));
                        }
                        else if (prop.IsCacheSegment)
                        {
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Ldflda, prop.SegmentField);
                            il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("SerializeCacheSegment").MakeGenericMethod(typeof(TTypeResolver), prop.PropertyInfo.PropertyType));
                        }
                        else
                        {
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Ldfld, prop.SegmentField);
                            il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("SerializeSegment").MakeGenericMethod(typeof(TTypeResolver), prop.PropertyInfo.PropertyType));
                        }
                        il.Emit(OpCodes.Add);
                    }

                    il.Emit(OpCodes.Starg_S, (byte)2);
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldloc_0);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldc_I4, schemaLastIndex);
                    il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("WriteSize"));
                    il.Emit(OpCodes.Ret);
                }
                // else
                {
                    il.MarkLabel(labelB);
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, originalBytesField);
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("DirectCopyAll"));
                    il.Emit(OpCodes.Ret);
                }
            }
        }
    }

#endif
}
