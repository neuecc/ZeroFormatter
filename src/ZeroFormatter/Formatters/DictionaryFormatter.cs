using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    internal class DictionaryFormatter<TKey, TValue> : Formatter<IDictionary<TKey, TValue>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IDictionary<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var dictionary = value as DictionarySegment<TKey, TValue>;
            if (dictionary == null)
            {
                dictionary = new DictionarySegment<TKey, TValue>(new DirtyTracker(), value.Count);
                foreach (var item in value)
                {
                    dictionary.Add(item.Key, item.Value);
                }
            }

            return dictionary.Serialize(ref bytes, offset);
        }

        public override IDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionarySegment<TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }

#if !UNITY

    internal class ReadOnlyDictionaryFormatter<TKey, TValue> : Formatter<IReadOnlyDictionary<TKey, TValue>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IReadOnlyDictionary<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var dictionary = value as DictionarySegment<TKey, TValue>;
            if (dictionary == null)
            {
                dictionary = new DictionarySegment<TKey, TValue>(new DirtyTracker(), value.Count);
                foreach (var item in value)
                {
                    dictionary.Add(item.Key, item.Value);
                }
            }

            return dictionary.Serialize(ref bytes, offset);
        }

        public override IReadOnlyDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionarySegment<TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }

#endif

    internal class DictionaryEntryFormatter<TKey, TValue> : Formatter<DictionaryEntry<TKey, TValue>>
    {
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