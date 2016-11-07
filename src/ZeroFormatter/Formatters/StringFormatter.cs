using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
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

            // Optimize for strict size
            if (bytes == null && offset == 0)
            {
                var stringBytes = StringEncoding.UTF8.GetBytes(value);
                var newBytes = new byte[stringBytes.Length + 4];
                BinaryUtil.WriteInt32Unsafe(ref newBytes, 0, stringBytes.Length);
                System.Buffer.BlockCopy(stringBytes, 0, newBytes, 4, stringBytes.Length);
                bytes = newBytes;
                return newBytes.Length;
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