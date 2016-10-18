using System.Linq;
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
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var lookup = value as LookupSegment<TKey, TValue>;
            if (lookup == null)
            {
                lookup = new LookupSegment<TKey, TValue>(value);
            }

            return lookup.Serialize(ref bytes, offset);
        }

        public override ILookup<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return LookupSegment<TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
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

        public override GroupingSegment<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return GroupingSegment<TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }
}
