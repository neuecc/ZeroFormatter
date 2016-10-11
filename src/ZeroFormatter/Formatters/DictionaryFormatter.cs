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
    internal class DictionaryFormatter<TKey, TValue> : Formatter<IDictionary<TKey, TValue>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IDictionary<TKey, TValue> value)
        {
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
            return DictionarySegment<TKey, TValue>.Create(tracker, new ArraySegment<byte>(bytes, offset, 0), out byteSize);
        }
    }

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
            return DictionaryEntry.Create<TKey, TValue>(new ArraySegment<byte>(bytes, offset, 0), tracker, out byteSize);
        }
    }
}