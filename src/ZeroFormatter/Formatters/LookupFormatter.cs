using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Comparers;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    internal class LookupFormatter<TKey, TValue> : Formatter<ILookup<TKey, TValue>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ILookup<TKey, TValue> value)
        {
            var lookup = value as LookupSegment<TKey, TValue>;
            if (lookup == null)
            {
                lookup = new LookupSegment<TKey, TValue>(value);
            }

            return lookup.Serialize(ref bytes, offset);
        }

        public override ILookup<TKey, TValue> Deserialize(ref byte[] bytes, int offset, out int byteSize)
        {
            return LookupSegment<TKey, TValue>.Create(new ArraySegment<byte>(bytes, offset, 0), out byteSize);
        }
    }

    internal class GroupingSegmentFormatter<TKey, TValue> : Formatter<GroupingSegment<TKey, TValue>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, GroupingSegment<TKey, TValue> value)
        {
            return value.Serialize(ref bytes, offset);
        }

        public override GroupingSegment<TKey, TValue> Deserialize(ref byte[] bytes, int offset, out int byteSize)
        {
            return GroupingSegment<TKey, TValue>.Create(new ArraySegment<byte>(bytes, offset, 0), out byteSize);
        }
    }
}
