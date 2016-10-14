using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Layout: [int byteSize][lastIndex][indexOffset:int...][t format...], byteSize == -1 is null.

    internal static class DynamicObjectDescriptor
    {
        public static Tuple<int, PropertyInfo>[] GetProperties(Type type)
        {
            if (!type.IsClass)
            {
                throw new InvalidOperationException("Type must be class. " + type.Name);
            }

            if (type.GetCustomAttributes(typeof(ZeroFormattableAttribute), true).FirstOrDefault() == null)
            {
                throw new InvalidOperationException("Type must mark ZeroFormattableAttribute. " + type.Name);
            }

            var dict = new Dictionary<int, PropertyInfo>();
            foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
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

                if (!getMethod.IsVirtual || !setMethod.IsVirtual)
                {
                    throw new InvalidOperationException("Public property's accessor must be virtual. " + type.Name + "." + item.Name);
                }

                if (dict.ContainsKey(index.Index))
                {
                    throw new InvalidOperationException("IndexAttribute can not allow duplicate. " + type.Name + "." + item.Name + ", Index:" + index.Index);
                }

                dict[index.Index] = item;
            }

            return dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).ToArray();
        }

        static void VerifyProeprtyType(PropertyInfo property)
        {
            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                throw new InvalidOperationException("Dictionary does not support in ZeroFormatter because Dictionary have to deserialize all objects. You can use IDictionary<TK, TV> instead of Dictionary. " + property.DeclaringType.Name + "." + property.PropertyType.Name);
            }
            else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                throw new InvalidOperationException("List does not support in ZeroFormatter because List have to deserialize all objects. You can use IList<T> instead of List. " + property.DeclaringType.Name + "." + property.PropertyType.Name);
            }
            else if (property.PropertyType.IsArray && property.PropertyType != typeof(byte[]))
            {
                throw new InvalidOperationException("Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[]. " + property.DeclaringType.Name + "." + property.PropertyType.Name);
            }

            var formatter = typeof(Formatter<>).MakeGenericType(property.PropertyType).GetProperty("Default").GetValue(null, null);
            var error = formatter as IErrorFormatter;
            if (error != null)
            {
                throw error.GetException();
            }

            // OK, Can Serialzie.
        }
    }

    public class DynamicObjectFormatter<T> : Formatter<T>
    {
        internal delegate int PropertyDeserializer(ref byte[] bytes, int startOffset, int currentOffset, int index, T self);
        internal delegate T FactoryFunc(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize);

        readonly int lastIndex;
        readonly Tuple<int, PropertyDeserializer>[] deserializers;
        readonly FactoryFunc factory;

        public DynamicObjectFormatter()
        {
            // Create descriptor.
            var type = typeof(T);

            this.lastIndex = -1;
            var list = new List<Tuple<int, PropertyDeserializer>>();

            //BinaryUtil.WriteInt32(ref bytes, startOffset + (8 + 4 * 1), offset);
            //offset += Formatter<string>.Default.Serialize(ref bytes, offset, value.LastName);
            foreach (var p in DynamicObjectDescriptor.GetProperties(type))
            {
                var propInfo = p.Item2;
                var index = p.Item1;

                var propType = propInfo.PropertyType;
                var formatterType = typeof(Formatter<>).MakeGenericType(propType);
                var formatterGet = formatterType.GetProperty("Default").GetGetMethod();
                var serializeMethod = formatterType.GetMethod("Serialize");

                var headerSize = Expression.Constant(8, typeof(int));
                var intSize = Expression.Constant(4, typeof(int));
                var arg1 = Expression.Parameter(typeof(byte[]).MakeByRefType(), "bytes");
                var arg2 = Expression.Parameter(typeof(int), "startOffset");
                var arg3 = Expression.Parameter(typeof(int), "currentOffset");
                var arg4 = Expression.Parameter(typeof(int), "index");
                var arg5 = Expression.Parameter(type, "self");

                var writeInt32 = Expression.Call(typeof(BinaryUtil).GetMethod("WriteInt32"),
                    arg1,
                    Expression.Add(arg2, Expression.Add(headerSize, Expression.Multiply(intSize, arg4))),
                    arg3);

                var formatterSerialize = Expression.Call(Expression.Call(formatterGet), serializeMethod, arg1, arg3, Expression.Property(arg5, propInfo));

                var body = Expression.Block(writeInt32, formatterSerialize);
                var lambda = Expression.Lambda<PropertyDeserializer>(body, arg1, arg2, arg3, arg4, arg5);
                var deserializerFunc = lambda.Compile();

                list.Add(Tuple.Create(index, deserializerFunc));

                this.lastIndex = index;
            }

            this.deserializers = list.ToArray();

            // create factory
            // new MyClass_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
            {
                var objectSegment = DynamicObjectSegmentBuilder<T>.GetProxyType();
                var ctorInfo = objectSegment.GetConstructor(new[] { typeof(DirtyTracker), typeof(ArraySegment<byte>) });
                var arraySegmentCtor = typeof(ArraySegment<byte>).GetConstructor(new[] { typeof(byte[]), typeof(int), typeof(int) });

                var arg1 = Expression.Parameter(typeof(byte[]).MakeByRefType(), "bytes");
                var arg2 = Expression.Parameter(typeof(int), "offset");
                var arg3 = Expression.Parameter(typeof(DirtyTracker), "tracker");
                var arg4 = Expression.Parameter(typeof(int).MakeByRefType(), "byteSize");

                var newArraySegment = Expression.New(arraySegmentCtor, arg1, arg2, arg4);

                var lambda = Expression.Lambda<FactoryFunc>(Expression.New(ctorInfo, arg3, newArraySegment), arg1, arg2, arg3, arg4);
                this.factory = lambda.Compile();
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;
                offset += (8 + 4 * (lastIndex + 1));

                for (int i = 0; i < deserializers.Length; i++)
                {
                    offset += deserializers[i].Item2(ref bytes, startOffset, offset, deserializers[i].Item1, value);
                }

                var writeSize = offset - startOffset;
                BinaryUtil.WriteInt32(ref bytes, startOffset, writeSize);
                BinaryUtil.WriteInt32(ref bytes, startOffset + 4, lastIndex);

                return writeSize;
            }
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            if (offset == -1)
            {
                byteSize = 0;
                return default(T);
            }

            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return default(T); // T is class so default(T) is null.
            }
            return factory(ref bytes, offset, tracker, out byteSize);
        }
    }
}