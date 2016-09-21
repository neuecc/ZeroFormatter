using System;
using System.Collections.Generic;
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
                    Instance = (Formatter<T>)(object)new Int32Formatter();
                }
                else if (t == typeof(float))
                {
                    Instance = (Formatter<T>)(object)new SingleFormatter();
                }

                else if (t == typeof(String))
                {
                    Instance = (Formatter<T>)(object)new StringFormatter();
                }




                else if (t == typeof(byte[]))
                {
                    Instance = (Formatter<T>)(object)new ByteArrayFormatter();
                }


                else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    var formatterType = typeof(ListFormatter<>).MakeGenericType(t.GetGenericArguments());
                    Instance = (Formatter<T>)Activator.CreateInstance(formatterType);
                }

                // TODO:....


                // TODO:make enum, nullable enum, and enum array...
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

    // Layout: [size:int][utf8bytes...], if size == -1 string is null.
    internal class StringFormatter : Formatter<string>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, string value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var stringSize = BinaryUtil.WriteString(ref bytes, offset + 4, value);
            BinaryUtil.WriteInt32(ref bytes, offset, stringSize); // write size after encode.
            return stringSize + 4;
        }

        public override string Deserialize(ref byte[] bytes, int offset)
        {
            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1) return null;
            return StringEncoding.UTF8.GetString(bytes, offset + 4, length);
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