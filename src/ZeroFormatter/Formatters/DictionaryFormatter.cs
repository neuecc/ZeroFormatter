using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // ImmediateDictionary
    // [int count][(Key:Value)...], count == -1 is null
    [Preserve(AllMembers = true)]
    public class DictionaryFormatter<TKey, TValue> : Formatter<IDictionary<TKey, TValue>>
    {
        readonly Formatter<TKey> keyFormatter;
        readonly Formatter<TValue> valueFormatter;

        [Preserve]
        public DictionaryFormatter()
        {
            this.keyFormatter = Formatter<TKey>.Default;
            this.valueFormatter = Formatter<TValue>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IDictionary<TKey, TValue> value)
        {
            var startOffset = offset;
            if (value == null)
            {
                ZeroFormatter.Internal.BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else
            {
                offset += ZeroFormatter.Internal.BinaryUtil.WriteInt32(ref bytes, offset, value.Count);
            }

            foreach (var item in value)
            {
                offset += keyFormatter.Serialize(ref bytes, offset, item.Key);
                offset += valueFormatter.Serialize(ref bytes, offset, item.Value);
            }

            return offset - startOffset;
        }

        public override IDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionarySegment<TKey, TValue>.Create(tracker, bytes, offset, DictionarySegmentMode.Immediate, out byteSize);
        }
    }


    [Preserve(AllMembers = true)]
    public class LazyDictionaryFormatter<TKey, TValue> : Formatter<ILazyDictionary<TKey, TValue>>
    {
        [Preserve]
        public LazyDictionaryFormatter()
        {

        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ILazyDictionary<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var dictionary = value as DictionarySegment<TKey, TValue>;
            if (dictionary == null)
            {
                dictionary = new DictionarySegment<TKey, TValue>(new DirtyTracker(offset), value.Count);
                foreach (var item in value)
                {
                    dictionary.Add(item.Key, item.Value);
                }
            }

            return dictionary.Serialize(ref bytes, offset);
        }

        public override ILazyDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionarySegment<TKey, TValue>.Create(tracker, bytes, offset, DictionarySegmentMode.LazyAll, out byteSize);
        }
    }

#if !UNITY

    [Preserve(AllMembers = true)]
    public class ReadOnlyDictionaryFormatter<TKey, TValue> : Formatter<IReadOnlyDictionary<TKey, TValue>>
    {
        readonly Formatter<TKey> keyFormatter;
        readonly Formatter<TValue> valueFormatter;

        [Preserve]
        public ReadOnlyDictionaryFormatter()
        {
            this.keyFormatter = Formatter<TKey>.Default;
            this.valueFormatter = Formatter<TValue>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IReadOnlyDictionary<TKey, TValue> value)
        {
            var startOffset = offset;
            if (value == null)
            {
                ZeroFormatter.Internal.BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else
            {
                offset += ZeroFormatter.Internal.BinaryUtil.WriteInt32(ref bytes, offset, value.Count);
            }

            foreach (var item in value)
            {
                offset += keyFormatter.Serialize(ref bytes, offset, item.Key);
                offset += valueFormatter.Serialize(ref bytes, offset, item.Value);
            }

            return offset - startOffset;
        }

        public override IReadOnlyDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionarySegment<TKey, TValue>.Create(tracker, bytes, offset, DictionarySegmentMode.Immediate, out byteSize);
        }
    }


    [Preserve(AllMembers = true)]
    public class LazyReadOnlyDictionaryFormatter<TKey, TValue> : Formatter<ILazyReadOnlyDictionary<TKey, TValue>>
    {
        [Preserve]
        public LazyReadOnlyDictionaryFormatter()
        {

        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ILazyReadOnlyDictionary<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var dictionary = value as DictionarySegment<TKey, TValue>;
            if (dictionary == null)
            {
                dictionary = new DictionarySegment<TKey, TValue>(new DirtyTracker(offset), value.Count);
                foreach (var item in value)
                {
                    dictionary.Add(item.Key, item.Value);
                }
            }

            return dictionary.Serialize(ref bytes, offset);
        }

        public override ILazyReadOnlyDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionarySegment<TKey, TValue>.Create(tracker, bytes, offset, DictionarySegmentMode.LazyAll, out byteSize);
        }
    }

#endif

    [Preserve(AllMembers = true)]
    public class DictionaryEntryFormatter<TKey, TValue> : Formatter<DictionaryEntry<TKey, TValue>>
    {
        [Preserve]
        public DictionaryEntryFormatter()
        {

        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, DictionaryEntry<TKey, TValue> value)
        {
            return value.Serialize(ref bytes, offset);
        }

        public override DictionaryEntry<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionaryEntry.Create<TKey, TValue>(bytes, offset, tracker, out byteSize);
        }
    }
}