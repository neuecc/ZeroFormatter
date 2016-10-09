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

        int freeCount;
        int freeList;

        DirtyTracker tracker;
        IEqualityComparer<TKey> comparer;

        internal DictionarySegment(DirtyTracker tracker, int size)
        {
            this.tracker = tracker;

            this.count = 0;

            if (size == 0)
            {
                size = HashHelpers.GetPrime(size);
            }

            this.buckets = new FixedListSegment<int>(tracker, size);
            for (int i = 0; i < buckets.Count; i++) buckets[i] = -1;

            this.entriesHashCode = new FixedListSegment<int>(tracker, size);
            this.entriesNext = new FixedListSegment<int>(tracker, size);
            this.entriesKey = (Formatter<TKey>.Default.GetLength() == null)
                ? (IList<TKey>)new VariableListSegment<TKey>(tracker, size)
                : (IList<TKey>)new FixedListSegment<TKey>(tracker, size);
            this.entriesValue = (Formatter<TValue>.Default.GetLength() == null)
                ? (IList<TValue>)new VariableListSegment<TValue>(tracker, size)
                : (IList<TValue>)new FixedListSegment<TValue>(tracker, size);

            this.comparer = ZeroFormatterEqualityComparer.GetDefault<TKey>();

            this.freeList = -1;
            this.freeCount = 0;
        }

        public DictionarySegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
        {
            this.tracker = tracker;

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

            // new size
            if (buckets.Count == 0)
            {
                var size = HashHelpers.GetPrime(0);
                Resize(size);
            }

            this.comparer = ZeroFormatterEqualityComparer.GetDefault<TKey>();

            this.freeList = -1;
            this.freeCount = 0;
        }

        public int Count
        {
            get { return count - freeCount; }
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
                Insert(key, value, false);
            }
        }

        public void Add(TKey key, TValue value)
        {
            Insert(key, value, true);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
        {
            Add(keyValuePair.Key, keyValuePair.Value);
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
            int i = FindEntry(keyValuePair.Key);
            if (i >= 0 && EqualityComparer<TValue>.Default.Equals(entriesValue[i], keyValuePair.Value))
            {
                Remove(keyValuePair.Key);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            if (count > 0)
            {
                for (int i = 0; i < buckets.Count; i++) buckets[i] = -1;
                entriesHashCode.Clear();
                entriesKey.Clear();
                entriesNext.Clear();
                entriesValue.Clear();

                freeList = -1;
                count = 0;
                freeCount = 0;
            }
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
            if (key == null) throw new ArgumentNullException("key");

            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                int bucket = hashCode % buckets.Count;
                int last = -1;
                for (int i = buckets[bucket]; i >= 0; last = i, i = entriesNext[i])
                {
                    if (entriesHashCode[i] == hashCode && comparer.Equals(entriesKey[i], key))
                    {
                        if (last < 0)
                        {
                            buckets[bucket] = entriesNext[i];
                        }
                        else
                        {
                            entriesNext[last] = entriesNext[i];
                        }
                        entriesHashCode[i] = -1;
                        entriesNext[i] = freeList;
                        entriesKey[i] = default(TKey);
                        entriesValue[i] = default(TValue);
                        freeList = i;
                        freeCount++;
                        return true;
                    }
                }
            }
            return false;
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

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            var index = 0;
            while ((uint)index < (uint)count)
            {
                if (entriesHashCode[index] >= 0)
                {
                    yield return new KeyValuePair<TKey, TValue>(entriesKey[index], entriesValue[index]);
                    index++;
                }
                else
                {
                    index++;
                }
            }
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // mutate impl

        void Insert(TKey key, TValue value, bool add)
        {
            if (key == null) throw new ArgumentNullException("key");

            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Count;

            for (int i = buckets[targetBucket]; i >= 0; i = entriesNext[i])
            {
                if (entriesHashCode[i] == hashCode && comparer.Equals(entriesKey[i], key))
                {
                    if (add)
                    {
                        throw new ArgumentException(SR.Format(SR.Argument_AddingDuplicate, key));
                    }
                    entriesValue[i] = value;
                    return;
                }
            }

            int index;

            if (freeCount > 0)
            {
                index = freeList;
                freeList = entriesNext[index];
                freeCount--;
            }
            else
            {
                if (count == entriesHashCode.Count)
                {
                    Resize();
                    targetBucket = hashCode % buckets.Count;
                }
                index = count;
                count++;
            }

            entriesHashCode[index] = hashCode;
            entriesNext[index] = buckets[targetBucket];
            entriesKey[index] = key;
            entriesValue[index] = value;
            buckets[targetBucket] = index;
        }

        void Resize()
        {
            Resize(HashHelpers.ExpandPrime(count));
        }

        void Resize(int newSize)
        {
            IList<int> newBuckets = new FixedListSegment<int>(tracker, newSize);
            for (int i = 0; i < newBuckets.Count; i++) newBuckets[i] = -1;

            var newEntriesKey = (entriesKey as ListSegment<TKey>).Clone(tracker, newSize);
            var newEntriesValue = (entriesValue as ListSegment<TValue>).Clone(tracker, newSize);
            var newEntriesHashCode = (entriesHashCode as ListSegment<int>).Clone(tracker, newSize);
            var newEntriesNext = (entriesNext as ListSegment<int>).Clone(tracker, newSize);

            for (int i = 0; i < count; i++)
            {
                if (newEntriesHashCode[i] >= 0)
                {
                    int bucket = newEntriesHashCode[i] % newSize;
                    newEntriesNext[i] = newBuckets[bucket];
                    newBuckets[bucket] = i;
                }
            }

            buckets = newBuckets;

            entriesKey = newEntriesKey;
            entriesValue = newEntriesValue;
            entriesHashCode = newEntriesHashCode;
            entriesNext = newEntriesNext;
        }

        public int Serialize(ref byte[] bytes, int offset)
        {
            Resize(count);

            var intListFormatter = Formatter<IList<int>>.Default;
            var keyListFormatter = Formatter<IList<TKey>>.Default;
            var valueListFormatter = Formatter<IList<TValue>>.Default;

            var startOffset = offset;

            offset += BinaryUtil.WriteInt32(ref bytes, offset, count);

            offset += (5 * 4); // index size

            {
                var bucketsSize = intListFormatter.Serialize(ref bytes, offset, buckets);
                BinaryUtil.WriteInt32(ref bytes, startOffset + 4 + (4 * 0), offset);
                offset += bucketsSize;
            }
            {
                var entriesHashCodeSize = intListFormatter.Serialize(ref bytes, offset, entriesHashCode);
                BinaryUtil.WriteInt32(ref bytes, startOffset + 4 + (4 * 1), offset);
                offset += entriesHashCodeSize;
            }
            {
                var entriesNextSize = intListFormatter.Serialize(ref bytes, offset, entriesNext);
                BinaryUtil.WriteInt32(ref bytes, startOffset + 4 + (4 * 2), offset);
                offset += entriesNextSize;
            }
            {
                var entriesKeySizes = keyListFormatter.Serialize(ref bytes, offset, entriesKey);
                BinaryUtil.WriteInt32(ref bytes, startOffset + 4 + (4 * 3), offset);
                offset += entriesKeySizes;
            }
            {
                var entriesValueSize = valueListFormatter.Serialize(ref bytes, offset, entriesValue);
                BinaryUtil.WriteInt32(ref bytes, startOffset + 4 + (4 * 4), offset);
                offset += entriesValueSize;
            }

            return offset - startOffset;
        }
    }
}
