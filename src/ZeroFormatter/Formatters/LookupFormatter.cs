using System;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // ImmediateLookup
    // [int count][(Key, Value[])...], count == -1 is null
    [Preserve(AllMembers = true)]
    public class LookupFormatter<TKey, TValue> : Formatter<ILookup<TKey, TValue>>
    {
        readonly Formatter<TKey> keyFormatter;
        readonly Formatter<IList<TValue>> valuesFormatter;

        [Preserve]
        public LookupFormatter()
        {
            keyFormatter = Formatter<TKey>.Default;
            valuesFormatter = Formatter<IList<TValue>>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ILookup<TKey, TValue> value)
        {
            var startOffset = offset;
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var lookup = value as LookupSegment<TKey, TValue>;
            if (lookup != null && lookup.mode == LookupSegmentMode.Immediate)
            {
                return lookup.Serialize(ref bytes, offset);
            }
            else
            {
                offset += ZeroFormatter.Internal.BinaryUtil.WriteInt32(ref bytes, offset, value.Count);
            }

            foreach (var item in value)
            {
                var list = item as IList<TValue>;
                if (list == null)
                {
                    list = item.ToArray();
                }

                offset += keyFormatter.Serialize(ref bytes, offset, item.Key);
                offset += valuesFormatter.Serialize(ref bytes, offset, list);
            }

            return offset - startOffset;
        }

        public override ILookup<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return LookupSegment<TKey, TValue>.Create(tracker, bytes, offset, LookupSegmentMode.Immediate, out byteSize);
        }
    }

    [Preserve(AllMembers = true)]
    public class LazyLookupFormatter<TKey, TValue> : Formatter<ILazyLookup<TKey, TValue>>
    {
        [Preserve]
        public LazyLookupFormatter()
        {

        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ILazyLookup<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var lookup = value as LookupSegment<TKey, TValue>;
            if (lookup == null || lookup.mode == LookupSegmentMode.Immediate)
            {
                lookup = new LookupSegment<TKey, TValue>(value);
            }

            return lookup.Serialize(ref bytes, offset);
        }

        public override ILazyLookup<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return LookupSegment<TKey, TValue>.Create(tracker, bytes, offset, LookupSegmentMode.LazyAll, out byteSize);
        }
    }

    [Preserve(AllMembers = true)]
    public class GroupingSegmentFormatter<TKey, TValue> : Formatter<GroupingSegment<TKey, TValue>>
    {
        [Preserve]
        public GroupingSegmentFormatter()
        {

        }

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
