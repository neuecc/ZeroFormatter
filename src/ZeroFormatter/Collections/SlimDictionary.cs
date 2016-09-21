using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using ZeroFormatter.Internal;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Collections
{
    /*
       this.buckets = newDict.buckets;
        this.count = newDict.count;
        this.entriesHashCode = newDict.entriesHashCode;
        this.entriesKey = newDict.entriesKey;
        this.entriesNext = newDict.entriesNext;
        this.entriesValue = newDict.entriesValue;
        this.freeCount = newDict.freeCount;
        this.freeList = newDict.freeList;
    */

    public sealed class SlimDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        #region SerializableStates

        int[] buckets; // link index of first entry. empty is -1.
        int count;

        // Entry[] entries;
        int[] entriesHashCode;
        int[] entriesNext;
        TKey[] entriesKey;
        TValue[] entriesValue;

        // when remove, mark slot to free
        int freeCount;
        int freeList;

        #endregion

        // does not serialize!

        int version; // version does not serialize

        object _syncRoot;

        IEqualityComparer<TKey> comparer { get; set; }

        public SlimDictionary()
            : this(ZeroFormatterEqualityComparer.GetDefault<TKey>())
        {
        }

        public SlimDictionary(int initialCapacity)
            : this(initialCapacity, ZeroFormatterEqualityComparer.GetDefault<TKey>())
        {
        }

        public SlimDictionary(IEqualityComparer<TKey> comparer)
        {
            this.comparer = comparer;
            Initialize(0);
        }

        public SlimDictionary(int initialCapacity, IEqualityComparer<TKey> comparer)
        {
            this.comparer = comparer;
            Initialize(initialCapacity);
        }

        SlimDictionary(int staticCapacity, bool forceSize, IEqualityComparer<TKey> comparer)
        {
            this.comparer = comparer;
            Initialize(staticCapacity, forceSize);
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
                for (int i = 0; i < buckets.Length; i++) buckets[i] = -1;
                Array.Clear(entriesHashCode, 0, count);
                Array.Clear(entriesKey, 0, count);
                Array.Clear(entriesNext, 0, count);
                Array.Clear(entriesValue, 0, count);

                freeList = -1;
                count = 0;
                freeCount = 0;
                version++;
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

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this, Enumerator.KeyValuePair);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return new Enumerator(this, Enumerator.KeyValuePair);
        }

        int FindEntry(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entriesNext[i])
                {
                    if (entriesHashCode[i] == hashCode && comparer.Equals(entriesKey[i], key)) return i;
                }
            }

            return -1;
        }

        void Initialize(int capacity)
        {
            Initialize(capacity, false);
        }

        void Initialize(int capacity, bool forceSize)
        {
            int size = forceSize ? capacity : HashHelpers.GetPrime(capacity);
            buckets = new int[size];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = -1;
            entriesHashCode = new int[size];
            entriesKey = new TKey[size];
            entriesNext = new int[size];
            entriesValue = new TValue[size];

            freeList = -1;
        }

        void Insert(TKey key, TValue value, bool add)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (buckets == null || buckets.Length == 0) Initialize(0);

            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length;

            for (int i = buckets[targetBucket]; i >= 0; i = entriesNext[i])
            {
                if (entriesHashCode[i] == hashCode && comparer.Equals(entriesKey[i], key))
                {
                    if (add)
                    {
                        throw new ArgumentException(SR.Format(SR.Argument_AddingDuplicate, key));
                    }
                    entriesValue[i] = value;
                    version++;
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
                if (count == entriesHashCode.Length)
                {
                    Resize();
                    targetBucket = hashCode % buckets.Length;
                }
                index = count;
                count++;
            }

            entriesHashCode[index] = hashCode;
            entriesNext[index] = buckets[targetBucket];
            entriesKey[index] = key;
            entriesValue[index] = value;
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
            var newEntriesValue = new TValue[newSize];
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
                        newEntriesHashCode[i] = (comparer.GetHashCode(newEntriesKey[i]) & 0x7FFFFFFF);
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


        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                int bucket = hashCode % buckets.Length;
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
                        version++;
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
            get { return false; }
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            CopyTo(array, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this, Enumerator.KeyValuePair);
        }

        public void TrimExcess()
        {
            var newDict = new SlimDictionary<TKey, TValue>(Count, true, comparer);

            // fast copy
            for (int i = 0; i < count; i++)
            {
                if (entriesHashCode[i] >= 0)
                {
                    newDict.Add(entriesKey[i], entriesValue[i]);
                }
            }

            // copy internal field to this
            this.buckets = newDict.buckets;
            this.count = newDict.count;
            this.entriesHashCode = newDict.entriesHashCode;
            this.entriesKey = newDict.entriesKey;
            this.entriesNext = newDict.entriesNext;
            this.entriesValue = newDict.entriesValue;
            this.freeCount = newDict.freeCount;
            this.freeList = newDict.freeList;
        }

        // TODO:not implemented yet
        public void Serialize()
        {
            /*
             *         int[] buckets; // link index of first entry. empty is -1.
        int count;

        // 
        int[] entriesHashCode;
        int[] entriesNext;
        TKey[] entriesKey;
        TValue[] entriesValue;

        // when remove, mark slot to free
        int freeCount;
        int freeList;
        */

            // use memorystreasm?

            //byte[] b = null;
            //var offset = Formatter<IList<int>>.Instance.Serialize(ref b, 0, entriesHashCode);


            //ZeroFormatter.Serialize(




        }

        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private SlimDictionary<TKey, TValue> dictionary;
            private int version;
            private int index;
            private KeyValuePair<TKey, TValue> current;
            private int getEnumeratorRetType;  // What should Enumerator.Current return?

            internal const int DictEntry = 1;
            internal const int KeyValuePair = 2;

            internal Enumerator(SlimDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
            {
                this.dictionary = dictionary;
                version = dictionary.version;
                index = 0;
                this.getEnumeratorRetType = getEnumeratorRetType;
                current = new KeyValuePair<TKey, TValue>();
            }

            public bool MoveNext()
            {
                if (version != dictionary.version)
                {
                    throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);
                }

                // Use unsigned comparison since we set index to dictionary.count+1 when the enumeration ends.
                // dictionary.count+1 could be negative if dictionary.count is Int32.MaxValue
                while ((uint)index < (uint)dictionary.count)
                {
                    if (dictionary.entriesHashCode[index] >= 0)
                    {
                        current = new KeyValuePair<TKey, TValue>(dictionary.entriesKey[index], dictionary.entriesValue[index]);
                        index++;
                        return true;
                    }
                    index++;
                }

                index = dictionary.count + 1;
                current = new KeyValuePair<TKey, TValue>();
                return false;
            }

            public KeyValuePair<TKey, TValue> Current
            {
                get { return current; }
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index == 0 || (index == dictionary.count + 1))
                    {
                        throw new InvalidOperationException(SR.InvalidOperation_EnumOpCantHappen);
                    }

                    if (getEnumeratorRetType == DictEntry)
                    {
                        return new System.Collections.DictionaryEntry(current.Key, current.Value);
                    }
                    else
                    {
                        return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                    }
                }
            }

            void IEnumerator.Reset()
            {
                if (version != dictionary.version)
                {
                    throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);
                }

                index = 0;
                current = new KeyValuePair<TKey, TValue>();
            }
        }
    }
}