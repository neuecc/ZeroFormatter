using System;
using System.Collections;
using System.Collections.Generic;
using ZeroFormatter.Comparers;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // [int byteSize][int count]
    // [IList<int> buckets][List<DictionaryEntry> entries]
    //  byteSize == -1 is null

    public sealed class DictionarySegment<TTypeResolver, TKey, TValue> : IDictionary<TKey, TValue>, IZeroFormatterSegment, ILazyDictionary<TKey, TValue>
#if !UNITY
        , IReadOnlyDictionary<TKey, TValue>, ILazyReadOnlyDictionary<TKey, TValue>
#endif
        where TTypeResolver : ITypeResolver, new()
    {
        #region SerializableStates

        int count;
        IList<int> buckets; // link index of first entry. empty is -1.
        IList<DictionaryEntry<TTypeResolver, TKey, TValue>> entries;

        #endregion

        int freeCount;
        int freeList;

        DirtyTracker tracker;
        ArraySegment<byte> originalBytes;
        readonly IEqualityComparer<TKey> comparer;

        internal DictionarySegment(DirtyTracker tracker, int size)
        {
            tracker = tracker.CreateChild();
            this.tracker = tracker;

            this.count = 0;

            if (size == 0)
            {
                size = HashHelpers.GetPrime(size);
            }

            var newBuckets = new int[size];
            for (int i = 0; i < newBuckets.Length; i++) newBuckets[i] = -1;
            this.buckets = newBuckets;

            this.entries = new DictionaryEntry<TTypeResolver, TKey, TValue>[size];
            this.comparer = ZeroFormatterEqualityComparer<TKey>.Default;

            this.freeList = -1;
            this.freeCount = 0;
        }

        internal static DictionarySegment<TTypeResolver, TKey, TValue> Create(DirtyTracker tracker, byte[] bytes, int offset, out int byteSize)
        {
            var byteSizeOrCount = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSizeOrCount == -1)
            {
                byteSize = 4;
                return null;
            }

            byteSize = byteSizeOrCount;
            return new DictionarySegment<TTypeResolver, TKey, TValue>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }

        DictionarySegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
        {
            tracker = tracker.CreateChild();
            this.tracker = tracker;
            this.originalBytes = originalBytes;

            var bytes = originalBytes.Array;
            var offset = originalBytes.Offset + 4;
            this.count = BinaryUtil.ReadInt32(ref bytes, offset);
            offset += 4;

            var intListFormatter = Formatter<TTypeResolver, IList<int>>.Default;
            var entryListFormatter = Formatter<TTypeResolver, IList<DictionaryEntry<TTypeResolver, TKey, TValue>>>.Default;

            int size;
            this.buckets = intListFormatter.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;

            this.entries = entryListFormatter.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;

            // new size
            if (buckets.Count == 0)
            {
                var capacity = HashHelpers.GetPrime(0);
                Resize(capacity);
            }

            this.comparer = ZeroFormatterEqualityComparer<TKey>.Default;

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

        public IEnumerable<TKey> Keys
        {
            get
            {
                throw new NotSupportedException("ZeroFormatter Dictionary does not support Keys; use GetEnumerator instead.");
            }
        }

        public IEnumerable<TValue> Values
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
                if (i >= 0) return entries[i].Value;
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
            if (i >= 0 && EqualityComparer<TValue>.Default.Equals(entries[i].Value, keyValuePair.Value))
            {
                return true;
            }
            return false;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
        {
            this.tracker.Dirty();
            int i = FindEntry(keyValuePair.Key);
            if (i >= 0 && EqualityComparer<TValue>.Default.Equals(entries[i].Value, keyValuePair.Value))
            {
                Remove(keyValuePair.Key);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            this.tracker.Dirty();
            if (count > 0)
            {
                for (int i = 0; i < buckets.Count; i++) buckets[i] = -1;

                var el = entries as ListSegment<TTypeResolver, DictionaryEntry<TTypeResolver, TKey, TValue>>;
                var ea = entries as DictionaryEntry<TTypeResolver, TKey, TValue>[];
                if (el != null)
                {
                    el.Clear();
                }
                else if (ea != null)
                {
                    Array.Clear(ea, 0, count);
                }
                else
                {
                    throw new InvalidOperationException("entries type is invalid. " + entries.GetType().Name);
                }

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
                    if (entries[i].HashCode >= 0 && entries[i].Value == null) return true;
                }
            }
            else
            {
                EqualityComparer<TValue> c = EqualityComparer<TValue>.Default;
                for (int i = 0; i < count; i++)
                {
                    if (entries[i].HashCode >= 0 && c.Equals(entries[i].Value, value)) return true;
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
                if (entries[i].HashCode >= 0)
                {
                    array[index++] = new KeyValuePair<TKey, TValue>(entries[i].Key, entries[i].Value);
                }
            }
        }

        int FindEntry(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Count]; i >= 0; i = entries[i].Next)
                {
                    if (entries[i].HashCode == hashCode && comparer.Equals(entries[i].Key, key)) return i;
                }
            }

            return -1;
        }

        public bool Remove(TKey key)
        {
            this.tracker.Dirty();
            if (key == null) throw new ArgumentNullException("key");

            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                int bucket = hashCode % buckets.Count;
                int last = -1;
                for (int i = buckets[bucket]; i >= 0; last = i, i = entries[i].Next)
                {
                    if (entries[i].HashCode == hashCode && comparer.Equals(entries[i].Key, key))
                    {
                        if (last < 0)
                        {
                            buckets[bucket] = entries[i].Next;
                        }
                        else
                        {
                            // entries[last].next = entries[i].next;
                            entries[last] = entries[last].WithNext(entries[i].Next);
                        }

                        entries[i] = new DictionaryEntry<TTypeResolver, TKey, TValue>(-1, freeList, default(TKey), default(TValue));
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
                value = entries[i].Value;
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
                if (entries[index].HashCode >= 0)
                {
                    yield return new KeyValuePair<TKey, TValue>(entries[index].Key, entries[index].Value);
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
            this.tracker.Dirty();
            if (key == null) throw new ArgumentNullException("key");

            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Count;

            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].Next)
            {
                if (entries[i].HashCode == hashCode && comparer.Equals(entries[i].Key, key))
                {
                    if (add)
                    {
                        throw new ArgumentException(SR.Format(SR.Argument_AddingDuplicate, key));
                    }
                    // entries[i].Value = value;
                    entries[i] = entries[i].WithValue(value);
                    return;
                }
            }

            int index;

            if (freeCount > 0)
            {
                index = freeList;
                freeList = entries[index].Next;
                freeCount--;
            }
            else
            {
                if (count == entries.Count)
                {
                    Resize();
                    targetBucket = hashCode % buckets.Count;
                }
                index = count;
                count++;
            }

            entries[index] = new DictionaryEntry<TTypeResolver, TKey, TValue>(hashCode, buckets[targetBucket], key, value);
            buckets[targetBucket] = index;
        }

        void Resize()
        {
            Resize(HashHelpers.ExpandPrime(count));
        }

        void Resize(int newSize)
        {
            this.tracker.Dirty();
            var newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++) newBuckets[i] = -1;

            var newEntries = new DictionaryEntry<TTypeResolver, TKey, TValue>[newSize];
            entries.CopyTo(newEntries, 0);

            for (int i = 0; i < count; i++)
            {
                if (newEntries[i].HashCode >= 0)
                {
                    int bucket = newEntries[i].HashCode % newSize;
                    newEntries[i] = newEntries[i].WithNext(newBuckets[bucket]);
                    newBuckets[bucket] = i;
                }
            }

            buckets = newBuckets;
            entries = newEntries;
        }

        public bool CanDirectCopy()
        {
            return (tracker == null) ? false : !tracker.IsDirty && (originalBytes.Array != null);
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return originalBytes;
        }

        public int Serialize(ref byte[] bytes, int offset)
        {
            if (CanDirectCopy())
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, originalBytes.Count);
                Buffer.BlockCopy(originalBytes.Array, originalBytes.Offset, bytes, offset, originalBytes.Count);
                return originalBytes.Count;
            }
            else
            {
                if (!(freeCount == 0 && freeList == -1))
                {
                    Resize(count);
                }

                var intListFormatter = Formatter<TTypeResolver, IList<int>>.Default;
                var entryListFormatter = Formatter<TTypeResolver, IList<DictionaryEntry<TTypeResolver, TKey, TValue>>>.Default;

                var startOffset = offset;

                offset += 4;
                BinaryUtil.WriteInt32(ref bytes, offset, count);
                offset += 4;

                offset += intListFormatter.Serialize(ref bytes, offset, buckets);
                offset += entryListFormatter.Serialize(ref bytes, offset, entries);

                var totalBytes = offset - startOffset;
                BinaryUtil.WriteInt32(ref bytes, startOffset, totalBytes);

                return totalBytes;
            }
        }
    }

    public static class DictionaryEntry
    {
        // deserialize immediate:)
        public static DictionaryEntry<TTypeResolver, TKey, TValue> Create<TTypeResolver, TKey, TValue>(byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
            where TTypeResolver : ITypeResolver, new()
        {
            byteSize = 0;

            var hashCode = BinaryUtil.ReadInt32(ref bytes, offset);
            offset += 4;
            byteSize += 4;

            var next = BinaryUtil.ReadInt32(ref bytes, offset);
            offset += 4;
            byteSize += 4;

            int size;
            var key = Formatter<TTypeResolver, TKey>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            var value = Formatter<TTypeResolver, TValue>.Default.Deserialize(ref bytes, offset, tracker, out size);
            byteSize += size;

            return new DictionaryEntry<TTypeResolver, TKey, TValue>(hashCode, next, key, value);
        }
    }

    public struct DictionaryEntry<TTypeResolver, TKey, TValue>
        where TTypeResolver : ITypeResolver, new()
    {
        public readonly int HashCode;
        public readonly int Next;
        public readonly TKey Key;
        public readonly TValue Value;

        public DictionaryEntry(int hashCode, int next, TKey key, TValue value)
        {
            this.HashCode = hashCode;
            this.Next = next;
            this.Key = key;
            this.Value = value;
        }

        public DictionaryEntry<TTypeResolver, TKey, TValue> WithNext(int next)
        {
            return new DictionaryEntry<TTypeResolver, TKey, TValue>(this.HashCode, next, this.Key, this.Value);
        }

        public DictionaryEntry<TTypeResolver, TKey, TValue> WithValue(TValue value)
        {
            return new DictionaryEntry<TTypeResolver, TKey, TValue>(this.HashCode, this.Next, this.Key, value);
        }

        public int Serialize(ref byte[] bytes, int offset)
        {
            var size = 0;
            size += BinaryUtil.WriteInt32(ref bytes, offset, HashCode);
            size += BinaryUtil.WriteInt32(ref bytes, offset + size, Next);
            size += Formatter<TTypeResolver, TKey>.Default.Serialize(ref bytes, offset + size, Key);
            size += Formatter<TTypeResolver, TValue>.Default.Serialize(ref bytes, offset + size, Value);
            return size;
        }
    }
}