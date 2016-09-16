using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    // Layout: [length:int][t format...]

    internal class ByteArrayFormatter : Formatter<byte[]>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, byte[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override byte[] Deserialize(ref byte[] bytes, int offset)
        {
            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1) return null;

            var result = new byte[length];
            Buffer.BlockCopy(bytes, offset, result, 0, length);

            return result;
        }
    }

    internal class IntArrayFormatter : Formatter<int[]>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, int[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 4;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);

            BinaryUtil.WriteInt32(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override int[] Deserialize(ref byte[] bytes, int offset)
        {
            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1) return null;

            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                offset += 4;
                result[i] = BinaryUtil.ReadInt32(ref bytes, offset);
            }

            return result;
        }
    }
}
