using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Layout: FixedSize -> [count:int][t format...]
    // Layout: VariableSize -> [int byteSize][count:int][elementOffset:int...][t format...]
    internal class ListFormatter<T> : Formatter<IList<T>>
    {
        public override int? GetLength()
        {
            return null;
        }

        // TODO:value == null?
        public override int Serialize(ref byte[] bytes, int offset, IList<T> value)
        {
            var formatter = Formatter<T>.Default;
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
                var startoffset = offset;

                var count = 0;
                offset = (startoffset + 8) + (value.Count * 4);
                foreach (var item in value)
                {
                    var size = formatter.Serialize(ref bytes, offset, item);
                    BinaryUtil.WriteInt32(ref bytes, (startoffset + 8) + count * 4, offset);
                    offset += size;
                    count++;
                }
                BinaryUtil.WriteInt32(ref bytes, startoffset + 4, value.Count);

                var totalBytes = offset - startoffset;
                BinaryUtil.WriteInt32(ref bytes, startoffset, totalBytes);

                return totalBytes;
            }
        }

        public override IList<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var formatter = Formatter<T>.Default;
            var length = formatter.GetLength();
            if (length != null)
            {
                return FixedListSegment<T>.Create(tracker, bytes, offset, out byteSize);
            }
            else
            {
                return VariableListSegment<T>.Create(tracker, bytes, offset, out byteSize);
            }
        }
    }
}
