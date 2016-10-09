using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Collections;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // [int count]
    // [offset of buckets][offset of entriesHashCode][offset of entriesNext][offset of entriesKey][offset of entriesValue]
    // [IList<int> buckets][List<int> entriesHashCode][IList<int> entriesNext][IList<TKey> entriesKey][IList<TValue> entriesValue]

    public sealed class LookupSegment<TKey, TElement> : ILookup<TKey, TElement>
    {
        #region SerializableStates

        int count;
        IList<int> buckets; // link index of first entry. empty is -1.

        IList<int> entriesHashCode;
        IList<int> entriesNext;
        IList<TKey> entriesKey;
        IList<TElement> entriesValue;

        #endregion

        DirtyTracker tracker;
        IEqualityComparer<TKey> comparer;

        internal LookupSegment(DirtyTracker tracker, int size)
        {
            this.tracker = tracker;

            this.count = 0;

            if (size == 0)
            {
                size = HashHelpers.GetPrime(size);
            }

            this.buckets = new FixedListSegment<int>(tracker, size);

            this.entriesHashCode = new FixedListSegment<int>(tracker, size);
            this.entriesNext = new FixedListSegment<int>(tracker, size);
            this.entriesKey = (Formatter<TKey>.Default.GetLength() == null)
                ? (IList<TKey>)new VariableListSegment<TKey>(tracker, size)
                : (IList<TKey>)new FixedListSegment<TKey>(tracker, size);
            this.entriesValue = (Formatter<TElement>.Default.GetLength() == null)
                ? (IList<TElement>)new VariableListSegment<TElement>(tracker, size)
                : (IList<TElement>)new FixedListSegment<TElement>(tracker, size);

            this.comparer = ZeroFormatterEqualityComparer.GetDefault<TKey>();

            for (int i = 0; i < buckets.Count; i++)
            {
                buckets[i] = -1;
                entriesNext[i] = -1;
            }

        }

        public LookupSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
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
            var valueListFormatter = Formatter<IList<TElement>>.Default;

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
        }

        public int Count
        {
            get { return count; }
        }

        public IEnumerable<TElement> this[TKey key]
        {
            get
            {
                return new LookupCollection(this, key);
            }
        }

        public void Add(TKey key, TElement value)
        {
            Insert(key, value);
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

                count = 0;
            }
        }

        public bool Contains(TKey key)
        {
            return FindEntry(key) >= 0;
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

        IEnumerable<int> FindEntries(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Count]; i >= 0; i = entriesNext[i])
                {
                    if (entriesHashCode[i] == hashCode && comparer.Equals(entriesKey[i], key))
                    {
                        yield return i;
                    }
                }
            }
        }


        // mutate impl

        void Insert(TKey key, TElement value)
        {
            if (key == null) throw new ArgumentNullException("key");

            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Count;

            int index;
            if (count == entriesHashCode.Count)
            {
                Resize();
                targetBucket = hashCode % buckets.Count;
            }
            index = count;
            count++;

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
            var newEntriesValue = (entriesValue as ListSegment<TElement>).Clone(tracker, newSize);
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

        public bool TryGetValue(TKey key, out TElement value)
        {
            int i = FindEntry(key);
            if (i >= 0)
            {
                value = entriesValue[i];
                return true;
            }
            value = default(TElement);
            return false;
        }

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            foreach (var key in entriesKey.Distinct(comparer))
            {
                yield return new Grouping(this, key);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public int Serialize(ref byte[] bytes, int offset)
        {
            Resize(count);

            var intListFormatter = Formatter<IList<int>>.Default;
            var keyListFormatter = Formatter<IList<TKey>>.Default;
            var valueListFormatter = Formatter<IList<TElement>>.Default;

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

        class Grouping : IGrouping<TKey, TElement>
        {
            readonly LookupSegment<TKey, TElement> lookup;
            public TKey Key { get; private set; }

            public Grouping(LookupSegment<TKey, TElement> lookup, TKey key)
            {
                this.lookup = lookup;
                this.Key = key;
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                return lookup[Key].GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        class LookupCollection : ICollection<TElement>
        {
            readonly LookupSegment<TKey, TElement> lookup;
            readonly int version;
            readonly List<int> indexes;

            // TODO:this implements is very naive...
            public LookupCollection(LookupSegment<TKey, TElement> lookup, TKey key)
            {
                var indexes = new List<int>();
                foreach (var i in lookup.FindEntries(key))
                {
                    indexes.Add(i);
                }
                indexes.Reverse();

                this.indexes = indexes;
                this.lookup = lookup;
            }

            public int Count
            {
                get
                {
                    return indexes.Count;
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            public void Add(TElement item)
            {
                throw new NotSupportedException();
            }

            public void Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(TElement item)
            {
                var comparer = EqualityComparer<TElement>.Default;
                using (var e = this.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        if (comparer.Equals(e.Current, item)) return true;
                    }
                }
                return false;
            }

            public void CopyTo(TElement[] array, int arrayIndex)
            {
                for (int i = arrayIndex; i < indexes.Count; i++)
                {
                    array[i] = lookup.entriesValue[indexes[i]];
                }
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    yield return lookup.entriesValue[indexes[i]];
                }
            }

            public bool Remove(TElement item)
            {
                throw new NotSupportedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
