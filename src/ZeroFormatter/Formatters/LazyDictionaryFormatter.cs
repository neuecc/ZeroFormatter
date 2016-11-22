using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    [Preserve(AllMembers = true)]
    internal class LazyDictionaryFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, ILazyDictionary<TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
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

            var dictionary = value as DictionarySegment<TTypeResolver, TKey, TValue>;
            if (dictionary == null)
            {
                dictionary = new DictionarySegment<TTypeResolver, TKey, TValue>(new DirtyTracker(), value.Count);
                foreach (var item in value)
                {
                    dictionary.Add(item.Key, item.Value);
                }
            }

            return dictionary.Serialize(ref bytes, offset);
        }

        public override ILazyDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionarySegment<TTypeResolver, TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }

#if !UNITY

    [Preserve(AllMembers = true)]
    internal class LazyReadOnlyDictionaryFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, ILazyReadOnlyDictionary<TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
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

            var dictionary = value as DictionarySegment<TTypeResolver, TKey, TValue>;
            if (dictionary == null)
            {
                dictionary = new DictionarySegment<TTypeResolver, TKey, TValue>(new DirtyTracker(), value.Count);
                foreach (var item in value)
                {
                    dictionary.Add(item.Key, item.Value);
                }
            }

            return dictionary.Serialize(ref bytes, offset);
        }

        public override ILazyReadOnlyDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionarySegment<TTypeResolver, TKey, TValue>.Create(tracker, bytes, offset, out byteSize);
        }
    }

#endif

    [Preserve(AllMembers = true)]
    internal class DictionaryEntryFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, DictionaryEntry<TTypeResolver, TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
    {
        [Preserve]
        public DictionaryEntryFormatter()
        {

        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, DictionaryEntry<TTypeResolver, TKey, TValue> value)
        {
            return value.Serialize(ref bytes, offset);
        }

        public override DictionaryEntry<TTypeResolver, TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            return DictionaryEntry.Create<TTypeResolver, TKey, TValue>(bytes, offset, tracker, out byteSize);
        }
    }
}