using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    [Preserve(AllMembers = true)]
    internal class LazyDictionaryFormatter<TKey, TValue> : Formatter<ILazyDictionary<TKey, TValue>>
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
            return DictionarySegment<TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }

#if !UNITY

    [Preserve(AllMembers = true)]
    internal class LazyReadOnlyDictionaryFormatter<TKey, TValue> : Formatter<ILazyReadOnlyDictionary<TKey, TValue>>
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
            return DictionarySegment<TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }

#endif

    [Preserve(AllMembers = true)]
    internal class DictionaryEntryFormatter<TKey, TValue> : Formatter<DictionaryEntry<TKey, TValue>>
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