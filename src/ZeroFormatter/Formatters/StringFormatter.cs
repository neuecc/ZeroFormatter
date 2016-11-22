using System.Text;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Layout: [size:int][utf8bytes...], if size == -1 string is null.

    // C# string is always nullable currently
    internal class NullableStringFormatter<TTypeResolver> : Formatter<TTypeResolver, string>
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly Encoding encoding = StringEncoding.UTF8;

        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

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

            // Optimize for strict size
            if (bytes == null && offset == 0)
            {
                var byteCount = encoding.GetByteCount(value);
                bytes = new byte[byteCount + 4];
                BinaryUtil.WriteInt32Unsafe(ref bytes, 0, byteCount);
                encoding.GetBytes(value, 0, value.Length, bytes, 4);
                return bytes.Length;
            }
            else
            {
                var stringSize = BinaryUtil.WriteString(ref bytes, offset + 4, value);
                BinaryUtil.WriteInt32Unsafe(ref bytes, offset, stringSize); // write size after encode, already ensured.
                return stringSize + 4;
            }
        }

        public override string Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length + 4;
            }

            return BinaryUtil.ReadString(ref bytes, offset + 4, length);
        }
    }
}