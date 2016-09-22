using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // TODO:not yet done.

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
                // TODO:Variable Size Array
                throw new NotImplementedException();
            }
        }

        public override IList<T> Deserialize(ref byte[] bytes, int offset)
        {
            var formatter = Formatter<T>.Default;
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
