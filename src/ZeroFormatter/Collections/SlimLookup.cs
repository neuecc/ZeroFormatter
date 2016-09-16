using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Collections
{
    // Mutable(Buildable) Serializable Lookup. Does not support remove.

    public class SerializableLookup<TKey, TElement> : ILookup<TKey, TElement>
    {
        #region serializable state.

        int[] buckets; // link index of first entry. empty is -1.
        int count;

        // Entry[] entries;
        int[] entriesHashCode;
        int[] entriesNext;
        TKey[] entriesKey;
        TElement[] entriesValue;

        #endregion

        int version; // version does not serialize

        // equality comparer is not serializable, use specified comparer.
        public virtual IEqualityComparer<TKey> Comparer
        {
            get
            {
                return EqualityComparer<TKey>.Default;
            }
        }

        protected SerializableLookup()
        {
            Initialize(0);
        }

        protected SerializableLookup(int initialCapacity)
        {
            Initialize(initialCapacity);
        }

        SerializableLookup(int staticCapacity, bool forceSize)
        {
            Initialize(staticCapacity, forceSize);
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
                for (int i = 0; i < buckets.Length; i++) buckets[i] = -1;
                Array.Clear(entriesHashCode, 0, count);
                Array.Clear(entriesKey, 0, count);
                Array.Clear(entriesNext, 0, count);
                Array.Clear(entriesValue, 0, count);

                count = 0;
                version++;
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
                int hashCode = Comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entriesNext[i])
                {
                    if (entriesHashCode[i] == hashCode && Comparer.Equals(entriesKey[i], key)) return i;
                }
            }

            return -1;
        }

        IEnumerable<int> FindEntries(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (buckets != null)
            {
                int hashCode = Comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entriesNext[i])
                {
                    if (entriesHashCode[i] == hashCode && Comparer.Equals(entriesKey[i], key))
                    {
                        yield return i;
                    }
                }
            }
        }

        void Initialize(int capacity)
        {
            Initialize(capacity, false);
        }

        void Initialize(int capacity, bool forceSize)
        {
            int size = forceSize ? capacity : HashHelpers.GetPrime(capacity);
            buckets = new int[size];
            entriesHashCode = new int[size];
            entriesKey = new TKey[size];
            entriesNext = new int[size];
            entriesValue = new TElement[size];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
                entriesNext[i] = -1;
            }
        }

        void Insert(TKey key, TElement value) // add only.
        {
            if (key == null) throw new ArgumentNullException("key");
            if (buckets == null || buckets.Length == 0) Initialize(0);

            int hashCode = Comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length;

            int index;
            if (count == entriesHashCode.Length)
            {
                Resize();
                targetBucket = hashCode % buckets.Length;
            }
            index = count;
            count++;

            entriesHashCode[index] = hashCode;
            entriesKey[index] = key;
            entriesValue[index] = value;
            entriesNext[index] = buckets[targetBucket];
            buckets[targetBucket] = index;
            version++;
        }

        void Resize()
        {
            Resize(HashHelpers.ExpandPrime(count), false);
        }

        void Resize(int newSize, bool forceNewHashCodes)
        {
            int[] newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++) newBuckets[i] = -1;

            var newEntriesKey = new TKey[newSize];
            var newEntriesValue = new TElement[newSize];
            var newEntriesHashCode = new int[newSize];
            var newEntriesNext = new int[newSize];
            Array.Copy(entriesKey, 0, newEntriesKey, 0, count);
            Array.Copy(entriesValue, 0, newEntriesValue, 0, count);
            Array.Copy(entriesHashCode, 0, newEntriesHashCode, 0, count);
            Array.Copy(entriesNext, 0, newEntriesNext, 0, count);

            if (forceNewHashCodes)
            {
                for (int i = 0; i < count; i++)
                {
                    if (newEntriesHashCode[i] != -1)
                    {
                        newEntriesHashCode[i] = (Comparer.GetHashCode(newEntriesKey[i]) & 0x7FFFFFFF);
                    }
                }
            }

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
            foreach (var key in entriesKey.Distinct(Comparer))
            {
                yield return new Grouping(this, key);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimExcess()
        {
            var newLookup = new SerializableLookup<TKey, TElement>(Count, true);
            foreach (var g in this)
            {
                foreach (var item in g)
                {
                    newLookup.Add(g.Key, item);
                }
            }

            // copy internal field to this
            this.buckets = newLookup.buckets;
            this.count = newLookup.count;
            this.entriesHashCode = newLookup.entriesHashCode;
            this.entriesKey = newLookup.entriesKey;
            this.entriesNext = newLookup.entriesNext;
            this.entriesValue = newLookup.entriesValue;
        }

        class Grouping : IGrouping<TKey, TElement>
        {
            readonly SerializableLookup<TKey, TElement> lookup;
            public TKey Key { get; private set; }

            public Grouping(SerializableLookup<TKey, TElement> lookup, TKey key)
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
            readonly SerializableLookup<TKey, TElement> lookup;
            readonly int version;
            readonly List<int> indexes;

            public LookupCollection(SerializableLookup<TKey, TElement> lookup, TKey key)
            {
                var indexes = new List<int>();
                foreach (var i in lookup.FindEntries(key))
                {
                    indexes.Add(i);
                }
                indexes.Reverse();

                this.version = lookup.version;
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
                if (version != lookup.version) throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);

                for (int i = arrayIndex; i < indexes.Count; i++)
                {
                    array[i] = lookup.entriesValue[indexes[i]];
                }
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (version != lookup.version) throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);
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
