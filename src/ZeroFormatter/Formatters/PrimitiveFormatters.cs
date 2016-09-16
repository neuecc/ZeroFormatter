using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    // Layout: [fixedElementSize]

    internal class IntFormatter : Formatter<int>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, int value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, value);
        }

        public override int Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }
}
