using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var stringSize = BinaryUtil.WriteString(ref bytes, offset + 4, value);
            BinaryUtil.WriteInt32(ref bytes, offset, stringSize); // write size after encode.
            return stringSize + 4;
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