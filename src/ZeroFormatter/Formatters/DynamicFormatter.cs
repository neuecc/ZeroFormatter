using System;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

#if !UNITY
using System.Reflection;
using System.Reflection.Emit;
#endif

namespace ZeroFormatter.Formatters
{
    // Layout: [int byteSize][lastIndex][indexOffset:int...][t format...], byteSize == -1 is null.

#if !UNITY

    internal class EmittableMemberInfo
    {
        readonly PropertyInfo propertyInfo;
        readonly FieldInfo fieldInfo;

        public bool IsProperty { get { return propertyInfo != null; } }
        public bool IsField { get { return fieldInfo != null; } }

        public PropertyInfo PropertyInfoUnsafe
        {
            get
            {
                if (!IsProperty) throw new InvalidOperationException();
                return propertyInfo;
            }
        }

        public string Name
        {
            get
            {
                return (IsProperty) ? propertyInfo.Name : fieldInfo.Name;
            }
        }

        public Type MemberType
        {
            get
            {
                return (IsProperty) ? propertyInfo.PropertyType : fieldInfo.FieldType;
            }
        }

        public EmittableMemberInfo(PropertyInfo propertyInfo)
        {
            this.propertyInfo = propertyInfo;
        }

        public EmittableMemberInfo(FieldInfo fieldInfo)
        {
            this.fieldInfo = fieldInfo;
        }

        public void EmitLoadValue(ILGenerator il)
        {
            if (IsProperty)
            {
                il.Emit(OpCodes.Callvirt, propertyInfo.GetGetMethod());
            }
            else
            {
                il.Emit(OpCodes.Ldfld, fieldInfo);
            }
        }
    }

    internal static class DynamicObjectDescriptor
    {
        public static Tuple<int, EmittableMemberInfo>[] GetMembers(Type resolverType, Type type, bool isClass)
        {
            if (isClass)
            {
                if (!type.GetTypeInfo().IsClass)
                {
                    throw new InvalidOperationException("Type must be class. " + type.Name);
                }
            }
            else
            {
                if (!type.GetTypeInfo().IsValueType)
                {
                    throw new InvalidOperationException("Type must be class. " + type.Name);
                }
            }

            if (type.GetTypeInfo().GetCustomAttributes(typeof(ZeroFormattableAttribute), true).FirstOrDefault() == null)
            {
                throw new InvalidOperationException("Type must be marked with ZeroFormattableAttribute. " + type.Name);
            }

            if (isClass)
            {
                if (!type.GetTypeInfo().GetConstructors().Any(x => x.GetParameters().Length == 0))
                {
                    throw new InvalidOperationException("Type must needs parameterless constructor. " + type.Name);
                }
            }

            var dict = new Dictionary<int, EmittableMemberInfo>();
            foreach (var item in type.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (item.GetCustomAttributes(typeof(IgnoreFormatAttribute), true).Any()) continue;
                // If base property type marked UnionKey, okay.
                var foundUnionKey = false;
                var propInfo = item;
                do
                {
                    if (propInfo.GetCustomAttributes(typeof(UnionKeyAttribute), true).Any())
                    {
                        foundUnionKey = true;
                        break;
                    }
                    propInfo = null;

                    var baseType = item.DeclaringType.GetTypeInfo().BaseType;
                    if (baseType != null)
                    {
                        var basePropInfo = baseType.GetTypeInfo().GetProperty(item.Name);
                        if (basePropInfo != null)
                        {
                            propInfo = basePropInfo;
                        }
                    }
                } while (propInfo != null);
                if (foundUnionKey)
                {
                    continue;
                }

                var index = item.GetCustomAttributes(typeof(IndexAttribute), true).Cast<IndexAttribute>().FirstOrDefault();
                if (index == null)
                {
                    throw new InvalidOperationException("Public property must be marked with IndexAttribute or IgnoreFormatAttribute. " + type.Name + "." + item.Name);
                }

                var getMethod = item.GetGetMethod(true);
                var setMethod = item.GetSetMethod(true);

                if (isClass)
                {
                    if (getMethod == null || setMethod == null || getMethod.IsPrivate || setMethod.IsPrivate)
                    {
                        throw new InvalidOperationException("Public property must needs both public/protected get and set accessor." + type.Name + "." + item.Name);
                    }
                }

                if (isClass)
                {
                    if (!getMethod.IsVirtual || !setMethod.IsVirtual)
                    {
                        throw new InvalidOperationException("Public property's accessor must be virtual. " + type.Name + "." + item.Name);
                    }
                }

                if (dict.ContainsKey(index.Index))
                {
                    throw new InvalidOperationException("IndexAttribute is not allow duplicate number. " + type.Name + "." + item.Name + ", Index:" + index.Index);
                }

                var info = new EmittableMemberInfo(item);
                VerifyMember(resolverType, info);
                dict[index.Index] = info;
            }

            foreach (var item in type.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (item.GetCustomAttributes(typeof(IgnoreFormatAttribute), true).Any()) continue;

                var index = item.GetCustomAttributes(typeof(IndexAttribute), true).Cast<IndexAttribute>().FirstOrDefault();
                if (index == null)
                {
                    throw new InvalidOperationException("Public field must mark IndexAttribute or IgnoreFormatAttribute. " + type.Name + "." + item.Name);
                }
                else if (isClass)
                {
                    throw new InvalidOperationException("Class does not allow that field marks IndexAttribute. " + type.Name + "." + item.Name);
                }

                if (dict.ContainsKey(index.Index))
                {
                    throw new InvalidOperationException("IndexAttribute is not allow duplicate number. " + type.Name + "." + item.Name + ", Index:" + index.Index);
                }

                var info = new EmittableMemberInfo(item);
                VerifyMember(resolverType, info);
                dict[index.Index] = info;
            }

            return dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).ToArray();
        }

        static void VerifyMember(Type resolverType, EmittableMemberInfo info)
        {
            var formatter = typeof(Formatter<,>).MakeGenericType(resolverType, info.MemberType).GetTypeInfo().GetProperty("Default").GetValue(null, null);
            var error = formatter as IErrorFormatter;
            if (error != null)
            {
                throw error.GetException();
            }

            // OK, Can Serialzie.
        }
    }

    internal static class DynamicFormatter
    {
        public static object Create<TTypeResolver, T>()
            where TTypeResolver : ITypeResolver, new()
        {
            var resolverType = typeof(TTypeResolver);
            var t = typeof(T);
            var ti = t.GetTypeInfo();
            if (ti.IsValueType) throw new InvalidOperationException("Type must be Class. " + t.Name);

            var members = DynamicObjectDescriptor.GetMembers(resolverType, t, true);
            var generateTypeInfo = BuildFormatter(ZeroFormatter.Segments.DynamicAssemblyHolder.Module, resolverType, t, members);
            var formatter = Activator.CreateInstance(generateTypeInfo.AsType());

            return formatter;
        }

        static TypeInfo BuildFormatter(ModuleBuilder builder, Type resolverType, Type elementType, Tuple<int, EmittableMemberInfo>[] memberInfos)
        {
            var typeBuilder = builder.DefineType(
               DynamicAssemblyHolder.ModuleName + "." + resolverType.FullName.Replace(".", "_") + "." + elementType.FullName + "$Formatter",
               TypeAttributes.Public,
               typeof(Formatter<,>).MakeGenericType(resolverType, elementType));

            // field
            var formattersInField = new List<Tuple<int, EmittableMemberInfo, FieldBuilder>>();
            foreach (var item in memberInfos)
            {
                var field = typeBuilder.DefineField("<>" + item.Item2.Name + "Formatter", typeof(Formatter<,>).MakeGenericType(resolverType, item.Item2.MemberType), FieldAttributes.Private | FieldAttributes.InitOnly);
                formattersInField.Add(Tuple.Create(item.Item1, item.Item2, field));
            }

            // .ctor
            {
                var method = typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig, CallingConventions.Standard, Type.EmptyTypes);

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Call, typeof(Formatter<,>).MakeGenericType(resolverType, elementType).GetTypeInfo().GetConstructor(Type.EmptyTypes));

                foreach (var item in formattersInField)
                {
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Call, item.Item3.FieldType.GetTypeInfo().GetProperty("Default").GetGetMethod());
                    il.Emit(OpCodes.Stfld, item.Item3);
                }
                il.Emit(OpCodes.Ret);
            }

            // public override int? GetLength()
            {
                var method = typeBuilder.DefineMethod("GetLength", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    typeof(int?),
                    Type.EmptyTypes);

                var il = method.GetILGenerator();

                il.DeclareLocal(typeof(int?));

                il.Emit(OpCodes.Ldloca_S, (byte)0);
                il.Emit(OpCodes.Initobj, typeof(int?));
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ret);
            }
            // public override int Serialize(ref byte[] bytes, int offset, T value)
            {
                var method = typeBuilder.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    typeof(int),
                    new Type[] { typeof(byte[]).MakeByRefType(), typeof(int), elementType });

                var il = method.GetILGenerator();

                var labelA = il.DefineLabel();
                var labelB = il.DefineLabel();
                il.DeclareLocal(typeof(IZeroFormatterSegment));
                il.DeclareLocal(typeof(int));

                il.Emit(OpCodes.Ldarg_3);
                il.Emit(OpCodes.Isinst, typeof(IZeroFormatterSegment));
                il.Emit(OpCodes.Stloc_0);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Brfalse, labelA);

                // if(segment != null)
                {
                    il.Emit(OpCodes.Ldloc_0);
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Call, typeof(IZeroFormatterSegment).GetTypeInfo().GetMethod("Serialize"));
                    il.Emit(OpCodes.Ret);
                }
                // else if(value == null)
                {
                    il.MarkLabel(labelA);
                    il.Emit(OpCodes.Ldarg_3);
                    il.Emit(OpCodes.Brtrue, labelB);

                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldc_I4_M1);
                    il.Emit(OpCodes.Call, typeof(BinaryUtil).GetTypeInfo().GetMethod("WriteInt32"));
                    il.Emit(OpCodes.Pop);
                    il.Emit(OpCodes.Ldc_I4_4);
                    il.Emit(OpCodes.Ret);
                }
                // else
                {
                    il.MarkLabel(labelB);

                    var schemaLastIndex = memberInfos.Select(x => x.Item1).LastOrDefault();
                    var calcedBeginOffset = 8 + (4 * (schemaLastIndex + 1));

                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Stloc_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.EmitLdc_I4(calcedBeginOffset);
                    il.Emit(OpCodes.Add);
                    il.Emit(OpCodes.Starg_S, (byte)2);
                    for (int i = 0; i < formattersInField.Count; i++)
                    {
                        var item = formattersInField[i];

                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldloc_1);
                        il.EmitLdc_I4(8 + (4 * item.Item1)); // 8 + 4 * index
                        il.Emit(OpCodes.Add);
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldloc_1);
                        il.Emit(OpCodes.Sub);
                        if (i == 0)
                        {
                            il.Emit(OpCodes.Call, typeof(BinaryUtil).GetTypeInfo().GetMethod("WriteInt32"));
                            il.Emit(OpCodes.Pop);
                        }
                        else
                        {
                            il.Emit(OpCodes.Call, typeof(BinaryUtil).GetTypeInfo().GetMethod("WriteInt32Unsafe"));
                        }
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldfld, item.Item3);
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldarg_3);
                        item.Item2.EmitLoadValue(il);
                        il.Emit(OpCodes.Callvirt, item.Item3.FieldType.GetTypeInfo().GetMethod("Serialize"));
                        il.Emit(OpCodes.Add);
                        il.Emit(OpCodes.Starg_S, (byte)2);
                    }

                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldloc_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.EmitLdc_I4(schemaLastIndex);
                    il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("WriteSize"));
                    il.Emit(OpCodes.Ret);
                }
            }
            // public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
            {
                var method = typeBuilder.DefineMethod("Deserialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    elementType,
                    new[] { typeof(byte[]).MakeByRefType(), typeof(int), typeof(DirtyTracker), typeof(int).MakeByRefType() });

                var il = method.GetILGenerator();

                il.DeclareLocal(typeof(ArraySegment<byte>));
                var labelA = il.DefineLabel();

                il.Emit(OpCodes.Ldarg_S, (byte)4);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Call, typeof(BinaryUtil).GetTypeInfo().GetMethod("ReadInt32"));
                il.Emit(OpCodes.Stind_I4);

                il.Emit(OpCodes.Ldarg_S, (byte)4);
                il.Emit(OpCodes.Ldind_I4);
                il.Emit(OpCodes.Ldc_I4_M1);
                il.Emit(OpCodes.Bne_Un_S, labelA);

                // if...
                {
                    il.Emit(OpCodes.Ldarg_S, (byte)4);
                    il.Emit(OpCodes.Ldc_I4_4);
                    il.Emit(OpCodes.Stind_I4);
                    il.Emit(OpCodes.Ldnull);
                    il.Emit(OpCodes.Ret);
                }
                // else...
                {
                    il.MarkLabel(labelA);

                    il.Emit(OpCodes.Ldloca_S, (byte)0);
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldind_Ref);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldarg_S, (byte)4);
                    il.Emit(OpCodes.Ldind_I4);
                    il.Emit(OpCodes.Call, typeof(ArraySegment<byte>).GetTypeInfo().GetConstructor(new[] { typeof(byte[]), typeof(int), typeof(int) }));

                    il.Emit(OpCodes.Ldarg_3);
                    il.Emit(OpCodes.Ldloc_0);
                    var ti = typeof(DynamicObjectSegmentBuilder<,>).MakeGenericType(resolverType, elementType).GetTypeInfo().GetMethod("GetProxyType").Invoke(null, null) as TypeInfo;
                    il.Emit(OpCodes.Newobj, ti.GetConstructor(new[] { typeof(DirtyTracker), typeof(ArraySegment<byte>) }));
                    il.Emit(OpCodes.Ret);
                }
            }

            return typeBuilder.CreateTypeInfo();
        }
    }

    internal static class DynamicStructFormatter
    {
        // create dynamic struct Formatter<T>
        public static object Create<TTypeResolver, T>()
            where TTypeResolver : ITypeResolver, new()
        {
            var resolverType = typeof(TTypeResolver);
            var t = typeof(T);
            var ti = t.GetTypeInfo();
            if (!ti.IsValueType) throw new InvalidOperationException("Type must be ValueType. " + t.Name);

            if (ti.IsNullable())
            {
                var elementType = ti.GetGenericArguments()[0];
                var formatter = typeof(Formatter<,>).MakeGenericType(resolverType, elementType).GetTypeInfo().GetProperty("Default").GetGetMethod().Invoke(null, null);
                return Activator.CreateInstance(typeof(NullableStructFormatter<,>).MakeGenericType(resolverType, elementType), new[] { formatter });
            }
            else
            {
                var elementType = t;

                var members = DynamicObjectDescriptor.GetMembers(resolverType, elementType, false);
                var length = ValidateAndCalculateLength(resolverType, elementType, members);
                var generateTypeInfo = BuildFormatter(ZeroFormatter.Segments.DynamicAssemblyHolder.Module, resolverType, elementType, length, members);
                var formatter = Activator.CreateInstance(generateTypeInfo.AsType());

                return formatter;
            }
        }

        static int? ValidateAndCalculateLength(Type resolverType, Type t, IEnumerable<Tuple<int, EmittableMemberInfo>> source)
        {
            var isNullable = false;
            var lengthSum = 0;

            var constructorTypes = new List<Type>();
            var expected = 0;
            foreach (var item in source)
            {
                if (item.Item1 != expected) throw new InvalidOperationException("Struct index must be started with 0 and be sequential. Type: " + t.FullName + " InvalidIndex:" + item.Item1);
                expected++;

                var formatter = typeof(Formatter<,>).MakeGenericType(resolverType, item.Item2.MemberType).GetTypeInfo().GetProperty("Default");
                var len = (formatter.GetGetMethod().Invoke(null, Type.EmptyTypes) as IFormatter).GetLength();
                if (len != null)
                {
                    lengthSum += len.Value;
                }
                else
                {
                    isNullable = true;
                }

                constructorTypes.Add(item.Item2.MemberType);
            }

            if (expected != 0)
            {
                var info = t.GetTypeInfo().GetConstructor(constructorTypes.ToArray());
                if (info == null)
                {
                    throw new InvalidOperationException("Struct needs full parameter constructor of index property types. Type:" + t.FullName);
                }
            }

            return isNullable ? (int?)null : lengthSum;
        }

        static TypeInfo BuildFormatter(ModuleBuilder builder, Type resolverType, Type elementType, int? length, Tuple<int, EmittableMemberInfo>[] memberInfos)
        {
            var typeBuilder = builder.DefineType(
                DynamicAssemblyHolder.ModuleName + "." + resolverType.FullName.Replace(".", "_") + "." + elementType.FullName + "$Formatter",
                TypeAttributes.Public,
                typeof(Formatter<,>).MakeGenericType(resolverType, elementType));

            // field
            var formattersInField = new List<Tuple<int, EmittableMemberInfo, FieldBuilder>>();
            foreach (var item in memberInfos)
            {
                var field = typeBuilder.DefineField("<>" + item.Item2.Name + "Formatter", typeof(Formatter<,>).MakeGenericType(resolverType, item.Item2.MemberType), FieldAttributes.Private | FieldAttributes.InitOnly);
                formattersInField.Add(Tuple.Create(item.Item1, item.Item2, field));
            }
            // .ctor
            {
                var method = typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig, CallingConventions.Standard, Type.EmptyTypes);

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Call, typeof(Formatter<,>).MakeGenericType(resolverType, elementType).GetTypeInfo().GetConstructor(Type.EmptyTypes));

                foreach (var item in formattersInField)
                {
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Call, item.Item3.FieldType.GetTypeInfo().GetProperty("Default").GetGetMethod());
                    il.Emit(OpCodes.Stfld, item.Item3);
                }
                il.Emit(OpCodes.Ret);
            }
            // public override bool NoUseDirtyTracker
            {
                var method = typeBuilder.DefineMethod("get_NoUseDirtyTracker", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    typeof(bool),
                    Type.EmptyTypes);

                var il = method.GetILGenerator();

                if (formattersInField.Count == 0)
                {
                    il.Emit(OpCodes.Ldc_I4_1);
                    il.Emit(OpCodes.Ret);
                }
                else
                {
                    var label = il.DefineLabel();
                    for (int i = 0; i < formattersInField.Count; i++)
                    {
                        var field = formattersInField[i];
                        if (i != 0) il.Emit(OpCodes.Brfalse, label);

                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldfld, field.Item3);
                        il.Emit(OpCodes.Callvirt, field.Item3.FieldType.GetTypeInfo().GetProperty("NoUseDirtyTracker").GetGetMethod());
                    }

                    il.Emit(OpCodes.Ret);
                    il.MarkLabel(label);
                    il.Emit(OpCodes.Ldc_I4_0);
                    il.Emit(OpCodes.Ret);
                }

                var props = typeBuilder.DefineProperty("NoUseDirtyTracker", PropertyAttributes.None,
                    typeof(bool),
                    Type.EmptyTypes);
                props.SetGetMethod(method);
            }
            // public override int? GetLength()
            {
                var method = typeBuilder.DefineMethod("GetLength", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    typeof(int?),
                    Type.EmptyTypes);

                var il = method.GetILGenerator();
                if (length == null)
                {
                    il.DeclareLocal(typeof(int?));

                    il.Emit(OpCodes.Ldloca_S, (byte)0);
                    il.Emit(OpCodes.Initobj, typeof(int?));
                    il.Emit(OpCodes.Ldloc_0);
                    il.Emit(OpCodes.Ret);
                }
                else
                {
                    il.EmitLdc_I4(length.Value);
                    il.Emit(OpCodes.Newobj, typeof(int?).GetTypeInfo().GetConstructor(new[] { typeof(int) }));
                    il.Emit(OpCodes.Ret);
                }
            }
            // public override int Serialize(ref byte[] bytes, int offset, T value)
            {
                var method = typeBuilder.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    typeof(int),
                    new Type[] { typeof(byte[]).MakeByRefType(), typeof(int), elementType });

                var il = method.GetILGenerator();

                il.DeclareLocal(typeof(int)); // startOffset

                if (length != null)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.EmitLdc_I4(length.Value);
                    il.Emit(OpCodes.Call, typeof(BinaryUtil).GetTypeInfo().GetMethod("EnsureCapacity"));
                }

                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Stloc_0);

                foreach (var item in formattersInField)
                {
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, item.Item3);
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldarga_S, (byte)3);
                    item.Item2.EmitLoadValue(il);
                    il.Emit(OpCodes.Callvirt, item.Item3.FieldType.GetTypeInfo().GetMethod("Serialize"));
                    il.Emit(OpCodes.Add);
                    il.Emit(OpCodes.Starg_S, (byte)2);
                }

                // offset - startOffset;
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Sub);
                il.Emit(OpCodes.Ret);
            }
            //// public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
            {
                var method = typeBuilder.DefineMethod("Deserialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    elementType,
                    new[] { typeof(byte[]).MakeByRefType(), typeof(int), typeof(DirtyTracker), typeof(int).MakeByRefType() });

                var il = method.GetILGenerator();

                if (memberInfos.Length != 0)
                {
                    il.DeclareLocal(typeof(int)); // size
                    foreach (var item in formattersInField)
                    {
                        il.DeclareLocal(item.Item2.MemberType); // item1, item2...
                    }
                    il.DeclareLocal(elementType); // result

                    il.Emit(OpCodes.Ldarg_S, (byte)4);
                    il.Emit(OpCodes.Ldc_I4_0);
                    il.Emit(OpCodes.Stind_I4);
                    foreach (var item in formattersInField)
                    {
                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldfld, item.Item3);
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldarg_3);
                        il.Emit(OpCodes.Ldloca_S, (byte)0);
                        il.Emit(OpCodes.Callvirt, item.Item3.FieldType.GetTypeInfo().GetMethod("Deserialize"));
                        il.Emit(OpCodes.Stloc, item.Item1 + 1);
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldloc_0);
                        il.Emit(OpCodes.Add);
                        il.Emit(OpCodes.Starg_S, (byte)2);
                        il.Emit(OpCodes.Ldarg_S, (byte)4);
                        il.Emit(OpCodes.Dup);
                        il.Emit(OpCodes.Ldind_I4);
                        il.Emit(OpCodes.Ldloc_0);
                        il.Emit(OpCodes.Add);
                        il.Emit(OpCodes.Stind_I4);
                    }

                    for (int i = 0; i < memberInfos.Length; i++)
                    {
                        il.Emit(OpCodes.Ldloc, i + 1);
                    }

                    var constructor = elementType.GetTypeInfo().GetConstructor(memberInfos.Select(x => x.Item2.MemberType).ToArray());
                    il.Emit(OpCodes.Newobj, constructor);
                }
                else
                {
                    il.DeclareLocal(elementType);
                    il.Emit(OpCodes.Ldloca_S, (byte)0);
                    il.Emit(OpCodes.Initobj, elementType);
                    il.Emit(OpCodes.Ldloc_0);
                }
                il.Emit(OpCodes.Ret);
            }

            return typeBuilder.CreateTypeInfo();
        }
    }

    internal static class DynamicUnionFormatter
    {
        // create dynamic union Formatter<T>
        public static object Create<TTypeResolver, T>()
            where TTypeResolver : ITypeResolver, new()
        {
            var t = typeof(T);
            var ti = t.GetTypeInfo();

            var unionKeys = ti.GetProperties().Where(x => x.GetCustomAttributes(typeof(UnionKeyAttribute)).Any()).ToArray();
            if (unionKeys.Length == 0)
            {
                throw new InvalidOperationException("Union class requires abstract [UnionKey]property. " + ti.FullName);
            }
            else if (unionKeys.Length != 1)
            {
                throw new InvalidOperationException("[UnionKey]property does not allow multiple key. " + ti.FullName);
            }

            var unionKeyProperty = unionKeys[0];
            if (!ti.IsInterface && !unionKeyProperty.GetGetMethod().IsAbstract)
            {
                throw new InvalidOperationException("Union class requires abstract [UnionKey]property. " + ti.FullName);
            }
            var unionAttr = (ti.GetCustomAttribute(typeof(UnionAttribute)) as UnionAttribute);
            var subTypes = unionAttr.SubTypes;

            ValidateTypes(t, subTypes, unionAttr.FallbackType);

            var generateTypeInfo = BuildFormatter(typeof(TTypeResolver), t, unionKeyProperty, unionKeyProperty.PropertyType, subTypes, unionAttr.FallbackType);
            var formatter = Activator.CreateInstance(generateTypeInfo.AsType());

            return formatter;
        }

        public static object CreateRuntimeUnion<TTypeResolver, T>(DynamicUnionResolver resolver)
          where TTypeResolver : ITypeResolver, new()
        {
            var t = typeof(T);
            var ti = t.GetTypeInfo();

            if (resolver.unionKeyType == null) throw new InvalidOperationException("DynamicUnion needs RegisterUnionKeyType");
            ValidateTypes(t, resolver.subTypes.Select(x => x.Item2).ToArray(), resolver.fallbackType);
            var set = new HashSet<object>();
            foreach (var item in resolver.subTypes)
            {
                if (!set.Add(item.Item1)) throw new InvalidOperationException("DynamicUnion does not allow duplicate key. key:" + item);
                if (item.Item1.GetType() != resolver.unionKeyType) throw new InvalidOperationException(string.Format("UnionKeyType must be same type. unionKeyType: {0} key: {1}", resolver.unionKeyType.Name, item.Item1.GetType().Name));
            }

            var generateTypeInfo = BuildFormatter(typeof(TTypeResolver), t, null, resolver.unionKeyType, resolver.subTypes.Select(x => x.Item2).ToArray(), resolver.fallbackType);
            var formatter = Activator.CreateInstance(generateTypeInfo.AsType(), new[] { resolver.subTypes.Select(x => x.Item1).ToList() });

            return formatter;
        }

        static void ValidateTypes(Type t, Type[] subTypes, Type fallbackType)
        {
            if (t.GetTypeInfo().IsInterface)
            {
                foreach (var item in subTypes.Concat(new[] { fallbackType }).Where(x => x != null))
                {
                    if (!item.GetTypeInfo().GetInterfaces().Any(x => x == t))
                    {
                        throw new InvalidOperationException("All Union subTypes must be inherited type. Type:" + t.FullName + ", SubType:" + item.Name);
                    }
                }
            }
            else
            {
                foreach (var item in subTypes.Concat(new[] { fallbackType }).Where(x => x != null))
                {
                    var baseType = item.GetTypeInfo().BaseType;
                    var found = false;
                    while (baseType != null)
                    {
                        if (baseType == t)
                        {
                            found = true;
                            break;
                        }
                        baseType = baseType.GetTypeInfo().BaseType;
                    }
                    if (!found)
                    {
                        throw new InvalidOperationException("All Union subTypes must be inherited type. Type:" + t.FullName + ", SubType:" + item.Name);
                    }
                }
            }
            if (fallbackType != null)
            {
                if (fallbackType.GetTypeInfo().GetConstructor(Type.EmptyTypes) == null)
                {
                    throw new InvalidOperationException("Fallback type must have parameterless constructor.");
                }
            }
        }

        static TypeInfo BuildFormatter(Type resolverType, Type buildType, PropertyInfo unionKeyPropertyInfo, Type unionKeyType, Type[] subTypes, Type fallbackType)
        {
            var moduleBuilder = ZeroFormatter.Segments.DynamicAssemblyHolder.Module;

            var typeBuilder = moduleBuilder.DefineType(
                DynamicAssemblyHolder.ModuleName + "." + resolverType.FullName.Replace(".", "_") + "." + buildType.FullName + "$Formatter",
                TypeAttributes.Public,
                typeof(Formatter<,>).MakeGenericType(resolverType, buildType));

            // field
            var unionKeysField = typeBuilder.DefineField("<>" + "unionKeys", unionKeyType.MakeArrayType(), FieldAttributes.Private | FieldAttributes.InitOnly);
            var comparer = typeBuilder.DefineField("<>" + "comparer", typeof(EqualityComparer<>).MakeGenericType(unionKeyType), FieldAttributes.Private | FieldAttributes.InitOnly);

            // .ctor
            {
                var method = (unionKeyPropertyInfo != null)
                    ? typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig, CallingConventions.Standard, Type.EmptyTypes)
                    : typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig, CallingConventions.Standard, new[] { typeof(List<object>) });

                var il = method.GetILGenerator();

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Call, typeof(Formatter<,>).MakeGenericType(resolverType, buildType).GetTypeInfo().GetConstructor(Type.EmptyTypes));


                if (unionKeyPropertyInfo != null)
                {
                    il.Emit(OpCodes.Ldarg_0);
                    il.EmitLdc_I4(subTypes.Length);
                    il.Emit(OpCodes.Newarr, unionKeyType);
                    il.Emit(OpCodes.Stfld, unionKeysField);
                    for (int i = 0; i < subTypes.Length; i++)
                    {
                        var subType = subTypes[i];

                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldfld, unionKeysField);
                        il.EmitLdc_I4(i);
                        il.Emit(OpCodes.Newobj, subType.GetTypeInfo().GetConstructor(Type.EmptyTypes));
                        il.Emit(OpCodes.Callvirt, unionKeyPropertyInfo.GetGetMethod());
                        il.Emit(OpCodes.Stelem_I4);
                    }
                }
                else
                {
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Call, typeof(System.Linq.Enumerable).GetTypeInfo().GetMethod("Cast").MakeGenericMethod(unionKeyType));
                    il.Emit(OpCodes.Call, typeof(System.Linq.Enumerable).GetTypeInfo().GetMethod("ToArray").MakeGenericMethod(unionKeyType));
                    il.Emit(OpCodes.Stfld, unionKeysField);
                }

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Call, comparer.FieldType.GetTypeInfo().GetProperty("Default").GetGetMethod());
                il.Emit(OpCodes.Stfld, comparer);

                il.Emit(OpCodes.Ret);
            }

            // public override int? GetLength()
            {
                var method = typeBuilder.DefineMethod("GetLength", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    typeof(int?),
                    Type.EmptyTypes);

                var il = method.GetILGenerator();

                il.DeclareLocal(typeof(int?));

                il.Emit(OpCodes.Ldloca_S, (byte)0);
                il.Emit(OpCodes.Initobj, typeof(int?));
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ret);
            }

            // public override int Serialize(ref byte[] bytes, int offset, T value)
            {
                var method = typeBuilder.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    typeof(int),
                    new Type[] { typeof(byte[]).MakeByRefType(), typeof(int), buildType });

                var il = method.GetILGenerator();

                il.DeclareLocal(typeof(int)); // startOffset
                il.DeclareLocal(typeof(int)); // writeSize

                var labelA = il.DefineLabel();

                il.Emit(OpCodes.Ldarg_3);        // value
                il.Emit(OpCodes.Brtrue_S, labelA);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldc_I4_M1);
                il.Emit(OpCodes.Call, typeof(BinaryUtil).GetTypeInfo().GetMethod("WriteInt32"));
                il.Emit(OpCodes.Ret);

                il.MarkLabel(labelA);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Stloc_0);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldc_I4_4);
                il.Emit(OpCodes.Add);
                il.Emit(OpCodes.Starg_S, (byte)2);

                // if(value is ...)
                var endLabel = il.DefineLabel();
                var ifElseLabels = new Label[subTypes.Length + 1];
                for (int i = 1; i < subTypes.Length + 1; i++)
                {
                    ifElseLabels[i] = il.DefineLabel();
                }

                for (int i = 0; i < subTypes.Length; i++)
                {
                    var subType = subTypes[i];
                    var formatterType = typeof(Formatter<,>).MakeGenericType(resolverType, subType).GetTypeInfo();

                    if (i != 0) il.MarkLabel(ifElseLabels[i]);
                    il.Emit(OpCodes.Ldarg_3);
                    il.Emit(OpCodes.Isinst, subType);
                    il.Emit(OpCodes.Brfalse_S, ifElseLabels[i + 1]);

                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Call, typeof(Formatter<,>).MakeGenericType(resolverType, unionKeyType).GetTypeInfo().GetProperty("Default").GetGetMethod());
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, unionKeysField);
                    il.EmitLdc_I4(i);
                    il.Emit(OpCodes.Ldelem, unionKeyType);
                    il.Emit(OpCodes.Callvirt, typeof(Formatter<,>).MakeGenericType(resolverType, unionKeyType).GetTypeInfo().GetMethod("Serialize"));
                    il.Emit(OpCodes.Add);
                    il.Emit(OpCodes.Starg_S, (byte)2);

                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Call, formatterType.GetProperty("Default").GetGetMethod());
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldarg_3);
                    il.Emit(OpCodes.Castclass, subType);
                    il.Emit(OpCodes.Callvirt, formatterType.GetMethod("Serialize"));
                    il.Emit(OpCodes.Add);
                    il.Emit(OpCodes.Starg_S, (byte)2);
                    il.Emit(OpCodes.Br, endLabel);
                }
                // else....
                {
                    il.MarkLabel(ifElseLabels.Last());
                    il.Emit(OpCodes.Ldstr, "Unknown subtype of Union: ");
                    il.Emit(OpCodes.Ldarg_3);
                    il.Emit(OpCodes.Callvirt, typeof(Object).GetTypeInfo().GetMethod("GetType"));
                    il.Emit(OpCodes.Callvirt, typeof(Type).GetTypeInfo().GetProperty("FullName").GetGetMethod());
                    il.Emit(OpCodes.Call, typeof(string).GetTypeInfo().GetMethods().First(x => x.GetParameters().Length == 2 && x.GetParameters().All(y => y.ParameterType == typeof(string))));
                    il.Emit(OpCodes.Newobj, typeof(Exception).GetTypeInfo().GetConstructors().First(x => x.GetParameters().Length == 1));
                    il.Emit(OpCodes.Throw);
                }

                // return offset - startOffset;
                il.MarkLabel(endLabel);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Sub);
                il.Emit(OpCodes.Stloc_1); // writeSize
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ldloc_1);
                il.Emit(OpCodes.Call, typeof(BinaryUtil).GetTypeInfo().GetMethod("WriteInt32"));
                il.Emit(OpCodes.Pop);
                il.Emit(OpCodes.Ldloc_1);
                il.Emit(OpCodes.Ret);
            }

            // public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
            {
                var method = typeBuilder.DefineMethod("Deserialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual,
                    buildType,
                    new[] { typeof(byte[]).MakeByRefType(), typeof(int), typeof(DirtyTracker), typeof(int).MakeByRefType() });

                var il = method.GetILGenerator();

                il.DeclareLocal(typeof(int)); // size
                il.DeclareLocal(unionKeyType); // unionKey
                il.DeclareLocal(buildType);   // T

                var labelA = il.DefineLabel();

                il.Emit(OpCodes.Ldarg_S, (byte)4);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Call, typeof(BinaryUtil).GetTypeInfo().GetMethod("ReadInt32"));
                il.Emit(OpCodes.Dup);
                il.Emit(OpCodes.Stloc_1);
                il.Emit(OpCodes.Stind_I4);
                il.Emit(OpCodes.Ldloc_1);
                il.Emit(OpCodes.Ldc_I4_M1);

                il.Emit(OpCodes.Bne_Un, labelA);
                il.Emit(OpCodes.Ldarg_S, (byte)4);
                il.Emit(OpCodes.Ldc_I4_4);
                il.Emit(OpCodes.Stind_I4);
                il.Emit(OpCodes.Ldnull);
                il.Emit(OpCodes.Ret);

                il.MarkLabel(labelA);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldc_I4_4);
                il.Emit(OpCodes.Add);
                il.Emit(OpCodes.Starg_S, (byte)2);
                il.Emit(OpCodes.Call, typeof(Formatter<,>).MakeGenericType(resolverType, unionKeyType).GetTypeInfo().GetProperty("Default").GetGetMethod());
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldarg_3);
                il.Emit(OpCodes.Ldloca_S, (byte)0);
                il.Emit(OpCodes.Callvirt, typeof(Formatter<,>).MakeGenericType(resolverType, unionKeyType).GetTypeInfo().GetMethod("Deserialize"));

                il.Emit(OpCodes.Stloc_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Add);
                il.Emit(OpCodes.Starg_S, (byte)2);

                // if(value is ...)
                var endLabel = il.DefineLabel();
                var ifElseLabels = new Label[subTypes.Length + 1];
                for (int i = 1; i < subTypes.Length + 1; i++)
                {
                    ifElseLabels[i] = il.DefineLabel();
                }

                for (int i = 0; i < subTypes.Length; i++)
                {
                    var subType = subTypes[i];
                    var formatterType = typeof(Formatter<,>).MakeGenericType(resolverType, subType).GetTypeInfo();

                    if (i != 0) il.MarkLabel(ifElseLabels[i]);

                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, comparer);
                    il.Emit(OpCodes.Ldloc_1);
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, unionKeysField);
                    il.EmitLdc_I4(i);
                    il.Emit(OpCodes.Ldelem, unionKeyType);

                    il.Emit(OpCodes.Callvirt, comparer.FieldType.GetTypeInfo().GetMethods().First(x => x.Name == "Equals" && x.DeclaringType == comparer.FieldType));
                    il.Emit(OpCodes.Brfalse_S, ifElseLabels[i + 1]);

                    il.Emit(OpCodes.Call, formatterType.GetProperty("Default").GetGetMethod());
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldarg_3);
                    il.Emit(OpCodes.Ldloca_S, (byte)0);
                    il.Emit(OpCodes.Callvirt, formatterType.GetMethod("Deserialize"));
                    il.Emit(OpCodes.Stloc_2);
                    il.Emit(OpCodes.Br, endLabel);
                }
                // else....
                {
                    il.MarkLabel(ifElseLabels.Last());

                    if (fallbackType == null)
                    {
                        il.Emit(OpCodes.Ldstr, "Unknown unionKey type of Union, unionKey: {0}");
                        il.Emit(OpCodes.Ldloc_1);
                        if (unionKeyType.GetTypeInfo().IsValueType)
                        {
                            il.Emit(OpCodes.Box, unionKeyType);
                        }
                        il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("GetException1", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public));
                        il.Emit(OpCodes.Throw);
                    }
                    else
                    {
                        il.Emit(OpCodes.Newobj, fallbackType.GetTypeInfo().GetConstructor(Type.EmptyTypes));
                        il.Emit(OpCodes.Stloc_2);
                    }
                }

                il.MarkLabel(endLabel);
                il.Emit(OpCodes.Ldloc_2);
                il.Emit(OpCodes.Ret);
            }

            return typeBuilder.CreateTypeInfo();
        }
    }

#endif

    // public! because used from generated code.
    public class NullableStructFormatter<TTypeResolver, T> : Formatter<TTypeResolver, T?>
        where T : struct
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> innerFormatter;

        public NullableStructFormatter(Formatter<TTypeResolver, T> innerFormatter)
        {
            this.innerFormatter = innerFormatter;
        }

        public override int? GetLength()
        {
            var len = innerFormatter.GetLength();
            return (len == null) ? null : len + 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            var len = GetLength();
            if (len != null)
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, len.Value);
            }

            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += innerFormatter.Serialize(ref bytes, offset, value.Value);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            offset += 1;

            int size;
            var v = innerFormatter.Deserialize(ref bytes, offset, tracker, out size);
            byteSize += size;

            return new Nullable<T>(v);
        }
    }
}

