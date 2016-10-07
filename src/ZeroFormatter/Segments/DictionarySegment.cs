using System;
using System.Collections;
using System.Collections.Generic;
using ZeroFormatter.Collections;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // [int count]
    // [offset of buckets][offset of entriesHashCode][offset of entriesNext][offset of entriesKey][offset of entriesValue]
    // [IList<int> buckets][List<int> entriesHashCode][IList<int> entriesNext][IList<TKey> entriesKey][IList<TValue> entriesValue]

    // TODO:ReadOnlyDictionary?
    public sealed class DictionarySegment<TKey, TValue> : IDictionary<TKey, TValue>
    {
        #region SerializableStates

        int count;
        IList<int> buckets; // link index of first entry. empty is -1.

        IList<int> entriesHashCode;
        IList<int> entriesNext;
        IList<TKey> entriesKey;
        IList<TValue> entriesValue;

        #endregion

        IEqualityComparer<TKey> comparer;

        public DictionarySegment(ArraySegment<byte> originalBytes)
        {
            var bytes = originalBytes.Array;
            this.count = BinaryUtil.ReadInt32(ref bytes, originalBytes.Offset);

            var bucketOffset = BinaryUtil.ReadInt32(ref bytes, originalBytes.Offset + 4);
            var hashOffset = BinaryUtil.ReadInt32(ref bytes, originalBytes.Offset + 8);
            var nextOffset = BinaryUtil.ReadInt32(ref bytes, originalBytes.Offset + 12);
            var keyOffset = BinaryUtil.ReadInt32(ref bytes, originalBytes.Offset + 16);
            var entriesOffset = BinaryUtil.ReadInt32(ref bytes, originalBytes.Offset + 20);

            var intListFormatter = Formatter<IList<int>>.Default;
            var keyListFormatter = Formatter<IList<TKey>>.Default;
            var valueListFormatter = Formatter<IList<TValue>>.Default;

            this.buckets = intListFormatter.Deserialize(ref bytes, bucketOffset);
            this.entriesHashCode = intListFormatter.Deserialize(ref bytes, hashOffset);
            this.entriesNext = intListFormatter.Deserialize(ref bytes, nextOffset);
            this.entriesKey = keyListFormatter.Deserialize(ref bytes, keyOffset);
            this.entriesValue = valueListFormatter.Deserialize(ref bytes, entriesOffset);

            this.comparer = ZeroFormatterEqualityComparer.GetDefault<TKey>();
        }

        public int Count
        {
            get { return count; }
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get
            {
                throw new NotSupportedException("ZeroFormatter Dictionary does not support Keys; use GetEnumerator instead.");
            }
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get
            {
                throw new NotSupportedException("ZeroFormatter Dictionary does not support Values; use GetEnumerator instead.");
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                int i = FindEntry(key);
                if (i >= 0) return entriesValue[i];
                throw new KeyNotFoundException();
            }
            set
            {
                throw new NotSupportedException("DictionarySegment only supports read.");
            }
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotSupportedException("DictionarySegment only supports read.");
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
        {
            throw new NotSupportedException("DictionarySegment only supports read.");
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
        {
            int i = FindEntry(keyValuePair.Key);
            if (i >= 0 && EqualityComparer<TValue>.Default.Equals(entriesValue[i], keyValuePair.Value))
            {
                return true;
            }
            return false;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
        {
            throw new NotSupportedException("DictionarySegment only supports read.");
        }

        public void Clear()
        {
            throw new NotSupportedException("DictionarySegment only supports read.");
        }

        public bool ContainsKey(TKey key)
        {
            return FindEntry(key) >= 0;
        }

        public bool ContainsValue(TValue value)
        {
            if (value == null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (entriesHashCode[i] >= 0 && entriesValue[i] == null) return true;
                }
            }
            else
            {
                EqualityComparer<TValue> c = EqualityComparer<TValue>.Default;
                for (int i = 0; i < count; i++)
                {
                    if (entriesHashCode[i] >= 0 && c.Equals(entriesValue[i], value)) return true;
                }
            }
            return false;
        }

        private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException("index", index, SR.ArgumentOutOfRange_Index);
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException(SR.Arg_ArrayPlusOffTooSmall);
            }

            int count = this.count;
            for (int i = 0; i < count; i++)
            {
                if (entriesHashCode[i] >= 0)
                {
                    array[index++] = new KeyValuePair<TKey, TValue>(entriesKey[i], entriesValue[i]);
                }
            }
        }

        int FindEntry(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Count]; i >= 0; i = entriesNext[i])
                {
                    if (entriesHashCode[i] == hashCode && comparer.Equals(entriesKey[i], key)) return i;
                }
            }

            return -1;
        }

        public bool Remove(TKey key)
        {
            throw new NotSupportedException("DictionarySegment only supports read.");
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int i = FindEntry(key);
            if (i >= 0)
            {
                value = entriesValue[i];
                return true;
            }
            value = default(TValue);
            return false;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return true; }
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            CopyTo(array, index);
        }


        IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            // TODO:Not Implemented
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}