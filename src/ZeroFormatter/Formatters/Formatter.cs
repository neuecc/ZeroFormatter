using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    internal abstract class Formatter<T>
    {
        public static Formatter<T> Instance;

        static Formatter()
        {
            try
            {
                var t = typeof(T);
                if (t == typeof(int))
                {
                    Instance = (Formatter<T>)(object)new IntFormatter();
                }
                else if (t == typeof(String))
                {
                    Instance = (Formatter<T>)(object)new StringFormatter();
                }
                else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    var formatterType = typeof(ListFormatter<>).MakeGenericType(t.GetGenericArguments());
                    Instance = (Formatter<T>)Activator.CreateInstance(formatterType);
                }
            }
            catch
            {
                // TODO:should avoid exception in static constructor
            }
        }

        public abstract int? GetLength();

        public abstract int Serialize(ref byte[] bytes, int offset, T value);
        public abstract T Deserialize(ref byte[] bytes, int offset);
    }

    // Layout: [4]
    internal class IntFormatter : Formatter<int>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, int value)
        {
            if (bytes == null) bytes = new byte[4];

            return BinaryUtil.WriteInt32(ref bytes, offset, value);
        }

        public override int Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    // Layout: [size:int][utf8bytes...]
    internal class StringFormatter : Formatter<string>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, string value)
        {
            var size = StringEncoding.UTF8.GetByteCount(value);
            if (bytes == null)
            {
                bytes = new byte[size + 4];
            }

            offset += BinaryUtil.WriteInt32(ref bytes, offset, size);
            return BinaryUtil.WriteString(ref bytes, offset, value, size) + 4;
        }

        public override string Deserialize(ref byte[] bytes, int offset)
        {
            throw new NotImplementedException();
        }
    }

    // Layout: FixedSize -> [length:int][t format...]
    // Layout: VariableSize -> [length:int][(index:int, size:int)...][t format...]
    internal class ListFormatter<T> : Formatter<IList<T>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IList<T> value)
        {
            var formatter = Formatter<T>.Instance;
            var length = formatter.GetLength();
            if (length != null)
            {
                // FixedSize Array
                var writeSize = value.Count * length.Value + 4;
                if (bytes == null)
                {
                    bytes = new byte[writeSize];
                }

                offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);
                foreach (var item in value)
                {
                    offset += formatter.Serialize(ref bytes, offset, item);
                }
                return writeSize;
            }
            else
            {
                // TODO:Variable Size Array
                throw new NotImplementedException();
            }
        }

        public override IList<T> Deserialize(ref byte[] bytes, int offset)
        {
            var formatter = Formatter<T>.Instance;
            var length = formatter.GetLength();
            if (length != null)
            {
                var size = BinaryUtil.ReadInt32(ref bytes, offset);
                return new FixedListSegement<T>(new ArraySegment<byte>(bytes, offset, size));
            }
            else
            {
                // TODO:Variable Size Array
                throw new NotImplementedException();
            }
        }
    }
}
