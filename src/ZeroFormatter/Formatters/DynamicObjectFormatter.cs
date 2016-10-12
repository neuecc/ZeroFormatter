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
            var isZeroFormattable = type.GetCustomAttributes(typeof(ZeroFormattableAttribute), true).Any();

            if (!isZeroFormattable)
            {
                throw new InvalidOperationException(typeof(T).Name + " is not marked ZeroFormattableAttirbute.");
            }

            this.lastIndex = -1;

            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => !x.GetCustomAttributes(typeof(IgnoreFormatAttribute), true).Any())
                .Select(x => new { PropInfo = x, IndexAttr = x.GetCustomAttributes(typeof(IndexAttribute), true).Cast<IndexAttribute>().FirstOrDefault() })
                .Where(x => x.IndexAttr != null)
                .OrderBy(x => x.IndexAttr.Index);

            var list = new List<Tuple<int, PropertyDeserializer>>();

            //BinaryUtil.WriteInt32(ref bytes, startOffset + (8 + 4 * 1), offset);
            //offset += Formatter<string>.Default.Serialize(ref bytes, offset, value.LastName);
            foreach (var p in props)
            {
                var propInfo = p.PropInfo;
                var index = p.IndexAttr.Index;

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