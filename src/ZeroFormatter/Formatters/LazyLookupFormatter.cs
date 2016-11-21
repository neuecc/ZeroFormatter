using System;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    [Preserve(AllMembers = true)]
    internal class LazyLookupFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, ILazyLookup<TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
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

            var lookup = value as LookupSegment<TTypeResolver, TKey, TValue>;
            if (lookup == null)
            {
                lookup = new LookupSegment<TTypeResolver, TKey, TValue>(value);
            }

            return lookup.Serialize(ref bytes, offset);
        }

        public override ILazyLookup<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return LookupSegment<TTypeResolver, TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }

    [Preserve(AllMembers = true)]
    internal class GroupingSegmentFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, GroupingSegment<TTypeResolver, TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
    {
        [Preserve]
        public GroupingSegmentFormatter()
        {

        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, GroupingSegment<TTypeResolver, TKey, TValue> value)
        {
            return value.Serialize(ref bytes, offset);
        }

        public override GroupingSegment<TTypeResolver, TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return GroupingSegment<TTypeResolver, TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }
}
