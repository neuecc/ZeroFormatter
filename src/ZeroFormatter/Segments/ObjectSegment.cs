using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // ObjectSegment is inherit to target class directly or generate.

    // Layout: [int byteSize][indexOffset:int...][t format...]

    public static class ObjectSegmentHelper
    {
        public static int GetByteSize(ArraySegment<byte> originalBytes)
        {
            var array = originalBytes.Array;
            return BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
        }

        public static int GetOffset(ArraySegment<byte> originalBytes, int index)
        {
            var array = originalBytes.Array;
            return BinaryUtil.ReadInt32(ref array, originalBytes.Offset + 4 + 4 * index);
        }

        public static int SerializeFixedLength<T>(ref byte[] targetBytes, int offset, ArraySegment<byte> originalBytes, int index)
        {
            var formatter = global::ZeroFormatter.Formatters.Formatter<T>.Default;
            var len = formatter.GetLength();
            BinaryUtil.EnsureCapacity(ref targetBytes, offset, len.Value);
            Buffer.BlockCopy(originalBytes.Array, GetOffset(originalBytes, index), targetBytes, offset, len.Value);
            return len.Value;
        }

        public static int SerializeSegment<T>(ref byte[] targetBytes, int offset, IZeroFormatterSegment segment)
        {
            return segment.Serialize(ref targetBytes, offset);
        }
    }
}

