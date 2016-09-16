using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    // Layout: [isNull:1][fixedElementSize]

    internal class NullableIntFormatter : Formatter<int?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, int? value)
        {
            BinaryUtil.WriteBool(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override int? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBool(ref bytes, offset);
            if (isNull) return default(int?);

            return BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }
}