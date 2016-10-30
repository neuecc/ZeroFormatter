#if !UNITY

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Layout: [int byteSize][lastIndex][indexOffset:int...][t format...], byteSize == -1 is null.

    internal static class DynamicObjectDescriptor
    {
        public static Tuple<int, PropertyInfo>[] GetProperties(Type type, bool isClass)
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
                throw new InvalidOperationException("Type must mark ZeroFormattableAttribute. " + type.Name);
            }

            if (isClass)
            {
                if (!type.GetTypeInfo().GetConstructors().Any(x => x.GetParameters().Length == 0))
                {
                    throw new InvalidOperationException("Type must needs parameterless constructor. " + type.Name);
                }
            }

            var dict = new Dictionary<int, PropertyInfo>();
            foreach (var item in type.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (item.GetCustomAttributes(typeof(IgnoreFormatAttribute), true).Any()) continue;

                var index = item.GetCustomAttributes(typeof(IndexAttribute), true).Cast<IndexAttribute>().FirstOrDefault();
                if (index == null)
                {
                    throw new InvalidOperationException("Public property must mark IndexAttribute or IgnoreFormatAttribute. " + type.Name + "." + item.Name);
                }

                var getMethod = item.GetGetMethod(true);
                var setMethod = item.GetSetMethod(true);

                if (getMethod == null || setMethod == null || getMethod.IsPrivate || setMethod.IsPrivate)
                {
                    throw new InvalidOperationException("Public property's accessor must needs both public/protected get and set." + type.Name + "." + item.Name);
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
                    throw new InvalidOperationException("IndexAttribute can not allow duplicate. " + type.Name + "." + item.Name + ", Index:" + index.Index);
                }

                VerifyProeprtyType(item);
                dict[index.Index] = item;
            }

            return dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).ToArray();
        }

        static void VerifyProeprtyType(PropertyInfo property)
        {
            if (property.PropertyType.GetTypeInfo().IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                throw new InvalidOperationException("Dictionary does not support in ZeroFormatter because Dictionary have to deserialize all objects. You can use IDictionary<TK, TV> instead of Dictionary. " + property.DeclaringType.Name + "." + property.PropertyType.Name);
            }
            else if (property.PropertyType.GetTypeInfo().IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                throw new InvalidOperationException("List does not support in ZeroFormatter because List have to deserialize all objects. You can use IList<T> instead of List. " + property.DeclaringType.Name + "." + property.PropertyType.Name);
            }
            else if (property.PropertyType.IsArray && property.PropertyType != typeof(byte[]))
            {
                throw new InvalidOperationException("Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[]. " + property.DeclaringType.Name + "." + property.PropertyType.Name);
            }

            var formatter = typeof(Formatter<>).MakeGenericType(property.PropertyType).GetTypeInfo().GetProperty("Default").GetValue(null, null);
            var error = formatter as IErrorFormatter;
            if (error != null)
            {
                throw error.GetException();
            }

            // OK, Can Serialzie.
        }
    }

    internal static class DynamicObjectFormatter
    {
        public static object Create<T>()
        {
            var t = typeof(T);
            var ti = t.GetTypeInfo();
            if (ti.IsValueType) throw new InvalidOperationException("Type must be Class. " + t.Name);

            var properties = DynamicObjectDescriptor.GetProperties(t, true);
            var generateTypeInfo = BuildFormatter(ZeroFormatter.Segments.DynamicAssemblyHolder.Module, t, properties);
            var formatter = Activator.CreateInstance(generateTypeInfo.AsType());

            return formatter;
        }

        static TypeInfo BuildFormatter(ModuleBuilder builder, Type elementType, Tuple<int, PropertyInfo>[] propertyInfos)
        {
            var typeBuilder = builder.DefineType(
               DynamicAssemblyHolder.ModuleName + "." + elementType.FullName + "$Formatter",
               TypeAttributes.Public,
               typeof(Formatter<>).MakeGenericType(elementType));

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

                    var schemaLastIndex = propertyInfos.Select(x => x.Item1).LastOrDefault();
                    var calcedBeginOffset = 8 + (4 * (schemaLastIndex + 1));

                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Stloc_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldc_I4, calcedBeginOffset);
                    il.Emit(OpCodes.Add);
                    il.Emit(OpCodes.Starg_S, (byte)2);
                    foreach (var item in propertyInfos)
                    {
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldloc_1);
                        il.Emit(OpCodes.Ldarg_2);
                        il.Emit(OpCodes.Ldc_I4, item.Item1);
                        il.Emit(OpCodes.Ldarg_3);
                        il.Emit(OpCodes.Callvirt, item.Item2.GetGetMethod());
                        il.Emit(OpCodes.Call, typeof(ObjectSegmentHelper).GetTypeInfo().GetMethod("SerializeFromFormatter").MakeGenericMethod(item.Item2.PropertyType));
                        il.Emit(OpCodes.Add);
                        il.Emit(OpCodes.Starg_S, (byte)2);
                    }
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldloc_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldc_I4, schemaLastIndex);
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
                    var ti = typeof(DynamicObjectSegmentBuilder<>).MakeGenericType(elementType).GetTypeInfo().GetMethod("GetProxyType").Invoke(null, null) as TypeInfo;
                    il.Emit(OpCodes.Newobj, ti.GetConstructor(new[] { typeof(DirtyTracker), typeof(ArraySegment<byte>) }));
                    il.Emit(OpCodes.Ret);
                }
            }

            return typeBuilder.CreateTypeInfo();
        }
    }

    public static class DynamicStructFormatter
    {
        // create dynamic struct Formatter<T>
        public static object Create<T>()
        {
            var t = typeof(T);
            var ti = t.GetTypeInfo();
            if (!ti.IsValueType) throw new InvalidOperationException("Type must be ValueType. " + t.Name);

            var elementType = ti.IsNullable() ? ti.GetGenericArguments()[0] : t;

            var properties = DynamicObjectDescriptor.GetProperties(elementType, false);
            var length = ValidateAndCalculateLength(elementType, properties);
            var generateTypeInfo = BuildFormatter(ZeroFormatter.Segments.DynamicAssemblyHolder.Module, elementType, length, properties.Select(x => x.Item2).ToArray());
            var formatter = Activator.CreateInstance(generateTypeInfo.AsType());

            if (ti.IsNullable())
            {
                return Activator.CreateInstance(typeof(DynamicNullableStructFormatter<>).MakeGenericType(elementType), new[] { formatter });
            }
            else
            {
                return formatter;
            }
        }

        static int? ValidateAndCalculateLength(Type t, IEnumerable<Tuple<int, PropertyInfo>> source)
        {
            var isNullable = false;
            var lengthSum = 0;

            var constructorTypes = new List<Type>();
            var expected = 0;
            foreach (var item in source)
            {
                if (item.Item1 != expected) throw new InvalidOperationException("Struct index must be started with 0 and be sequential. Type: " + t.FullName + " InvalidIndex:" + item.Item1);
                expected++;

                var formatter = typeof(Formatter<>).MakeGenericType(item.Item2.PropertyType).GetTypeInfo().GetProperty("Default");
                var len = (formatter.GetGetMethod().Invoke(null, Type.EmptyTypes) as IFormatter).GetLength();
                if (len != null)
                {
                    lengthSum += len.Value;
                }
                else
                {
                    isNullable = true;
                }

                constructorTypes.Add(item.Item2.PropertyType);
            }

            var info = t.GetTypeInfo().GetConstructor(constructorTypes.ToArray());
            if (info == null)
            {
                throw new InvalidOperationException("Struct needs full parameter constructor of index property types. Type:" + t.FullName);
            }

            return isNullable ? (int?)null : lengthSum;
        }

        static TypeInfo BuildFormatter(ModuleBuilder builder, Type elementType, int? length, PropertyInfo[] propertyInfos)
        {
            var typeBuilder = builder.DefineType(
                DynamicAssemblyHolder.ModuleName + "." + elementType.FullName + "$Formatter",
                TypeAttributes.Public,
                typeof(Formatter<>).MakeGenericType(elementType));

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
                    il.Emit(OpCodes.Ldc_I4, length.Value);
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

                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Stloc_0);
                foreach (var item in propertyInfos)
                {
                    var formatter = typeof(Formatter<>).MakeGenericType(item.PropertyType);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Call, formatter.GetTypeInfo().GetProperty("Default").GetGetMethod());
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldarga_S, (byte)3);
                    il.Emit(OpCodes.Call, item.GetGetMethod());
                    il.Emit(OpCodes.Callvirt, formatter.GetTypeInfo().GetMethod("Serialize"));
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

                il.DeclareLocal(typeof(int)); // size
                foreach (var item in propertyInfos)
                {
                    il.DeclareLocal(item.PropertyType); // item1, item2...
                }
                il.DeclareLocal(elementType); // result

                il.Emit(OpCodes.Ldarg_S, (byte)4);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Stind_I4);
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    var item = propertyInfos[i];

                    var formatter = typeof(Formatter<>).MakeGenericType(item.PropertyType);
                    il.Emit(OpCodes.Call, formatter.GetTypeInfo().GetProperty("Default").GetGetMethod());
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(OpCodes.Ldarg_3);
                    il.Emit(OpCodes.Ldloca_S, (byte)0);
                    il.Emit(OpCodes.Callvirt, formatter.GetTypeInfo().GetMethod("Deserialize"));
                    il.Emit(OpCodes.Stloc, i + 1);
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

                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    il.Emit(OpCodes.Ldloc, i);
                }

                var constructor = elementType.GetTypeInfo().GetConstructor(propertyInfos.Select(x => x.PropertyType).ToArray());
                il.Emit(OpCodes.Newobj, constructor);
                il.Emit(OpCodes.Ret);
            }

            return typeBuilder.CreateTypeInfo();
        }
    }

    internal class DynamicNullableStructFormatter<T> : Formatter<T?>
        where T : struct
    {
        readonly Formatter<T> innerFormatter;

        public DynamicNullableStructFormatter(Formatter<T> innerFormatter)
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

#endif