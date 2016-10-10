using System;
using System.Collections;
using System.Collections.Generic;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // TODO: /* IReadOnlyList??? */
    public abstract class ListSegment<T> : IList<T>
    {
        protected readonly ArraySegment<byte> originalBytes;
        protected readonly Formatter<T> formatter;

        protected DirtyTracker tracker;
        protected SegmentState state;

        protected int length;
        protected T[] cache;        // if modified, use cache start
        protected bool[] isCached;  // if modified, isCached is smaller than cache.length; be careful
        protected bool isAllCached;

        internal ListSegment(DirtyTracker tracker, int length)
        {
            this.isAllCached = true;
            this.cache = new T[length];
            this.length = length;
            this.tracker = tracker;
            this.formatter = Formatters.Formatter<T>.Default;
        }

        public ListSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes, bool isFixed)
        {
            this.originalBytes = originalBytes;
            this.formatter = Formatters.Formatter<T>.Default;

            var array = originalBytes.Array;
            this.length = isFixed
                ? BinaryUtil.ReadInt32(ref array, originalBytes.Offset)
                : BinaryUtil.ReadInt32(ref array, originalBytes.Offset + 4);

            this.tracker = tracker;
            this.state = SegmentState.Original;
        }

        protected void CreateCacheWhenNotYet()
        {
            if (cache == null)
            {
                cache = new T[length];
                isCached = new bool[length];
            }
        }

        protected void CacheAllWhenNotYet()
        {
            CreateCacheWhenNotYet();
            if (!isAllCached)
            {
                var array = originalBytes.Array;
                for (int i = 0; i < length; i++)
                {
                    if (!isCached[i])
                    {
                        var offset = GetOffset(i);
                        int _;
                        cache[i] = formatter.Deserialize(ref array, offset, out _);
                        isCached[i] = true;
                    }
                }
                isAllCached = true;
            }
        }

        public abstract T this[int index] { get; set; }

        protected abstract int GetOffset(int index);

        public int Count
        {
            get
            {
                return length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            var comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < length; i++)
            {
                if (comparer.Equals(this[i], item)) return i;
            }
            return -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (!isAllCached)
            {
                for (int i = 0, j = arrayIndex; i < length; i++, j++)
                {
                    array[j] = this[i];
                }
            }
            else
            {
                Array.Copy(cache, 0, array, arrayIndex, length);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // If use mutable operation, cache all.

        public void Add(T item)
        {
            CacheAllWhenNotYet();

            if (cache.Length == length)
            {
                Array.Resize(ref cache, (length == 0) ? 4 : length * 2);
            }
            cache[length] = item;
            length++;
            state = SegmentState.Dirty;
        }

        public void Clear()
        {
            isAllCached = true; // cached:)
            if (cache != null)
            {
                Array.Clear(cache, 0, cache.Length);
            }
            else
            {
                cache = new T[0];
            }
            length = 0;
            state = SegmentState.Dirty;
        }

        public void Insert(int index, T item)
        {
            if (index > this.length)
            {
                throw new ArgumentOutOfRangeException("index is out of range:" + index);
            }

            CacheAllWhenNotYet();

            if (cache.Length == length)
            {
                Array.Resize(ref cache, (length == 0) ? 4 : length * 2);
            }

            if (index < this.length)
            {
                Array.Copy(this.cache, index, this.cache, index + 1, this.length - index);
            }
            cache[index] = item;
            length++;
            state = SegmentState.Dirty;
        }

        public bool Remove(T item)
        {
            CacheAllWhenNotYet();

            var i = IndexOf(item);
            if (i != -1)
            {
                RemoveAt(i);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= this.length)
            {
                throw new ArgumentOutOfRangeException("index is out of range:" + index);
            }
            CacheAllWhenNotYet();

            this.length--;
            if (index < this.length)
            {
                Array.Copy(this.cache, index + 1, this.cache, index, this.length - index);
            }
            this.cache[this.length] = default(T);
            state = SegmentState.Dirty;
        }

        internal ListSegment<T> Clone(DirtyTracker tracker, int newLength)
        {
            ListSegment<T> clone;
            if (formatter.GetLength() == null)
            {
                clone = new VariableListSegment<T>(tracker, newLength);
            }
            else
            {
                clone = new FixedListSegment<T>(tracker, newLength);
            }

            CacheAllWhenNotYet();
            Array.Copy(this.cache, 0, clone.cache, 0, Math.Min(length, newLength));
            return clone;
        }
    }

    // Layout: FixedSize -> [count:int][t format...]
    public class FixedListSegment<T> : ListSegment<T>
    {
        readonly int elementSize;

        internal FixedListSegment(DirtyTracker tracker, int length)
            : base(tracker, length)
        {
            var formatterLength = formatter.GetLength();
            if (formatterLength == null) throw new InvalidOperationException("T should be fixed length. Type: " + typeof(T).Name);

            elementSize = formatterLength.Value;
        }

        internal static FixedListSegment<T> Create(DirtyTracker tracker, ArraySegment<byte> originalBytes, out int byteSize)
        {
            var list = new FixedListSegment<T>(tracker, originalBytes);
            byteSize = list.elementSize * list.length + 4;
            return list;
        }

        public FixedListSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
            : base(tracker, originalBytes, true)
        {
            var formatterLength = formatter.GetLength();
            if (formatterLength == null) throw new InvalidOperationException("T should be fixed length. Type: " + typeof(T).Name);

            elementSize = formatterLength.Value;
        }

        protected override int GetOffset(int index)
        {
            return originalBytes.Offset + 4 + (elementSize * index);
        }

        public override T this[int index]
        {
            get
            {
                if (index > length)
                {
                    throw new ArgumentOutOfRangeException("index > Count");
                }

                if (!isAllCached)
                {
                    var array = originalBytes.Array;
                    var offset = GetOffset(index);
                    int _;
                    return formatter.Deserialize(ref array, offset, out _);
                }
                else
                {
                    return cache[index];
                }
            }

            set
            {
                if (index > Count)
                {
                    throw new ArgumentOutOfRangeException("index > Count");
                }

                if (!isAllCached)
                {
                    var array = originalBytes.Array;
                    var offset = 4 + (elementSize * index);
                    formatter.Serialize(ref array, originalBytes.Offset + offset, value);
                }
                else
                {
                    cache[index] = value;
                    state = SegmentState.Dirty;
                }
            }
        }
    }

    // Layout: VariableSize -> [int byteSize][count:int][elementOffset:int...][t format...]
    public class VariableListSegment<T> : ListSegment<T>
    {
        internal static VariableListSegment<T> Create(DirtyTracker tracker, ArraySegment<byte> originalBytes, out int byteSize)
        {
            var list = new VariableListSegment<T>(tracker, originalBytes);
            var array = originalBytes.Array;
            byteSize = BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
            return list;
        }

        internal VariableListSegment(DirtyTracker tracker, int length)
            : base(tracker, length)
        {
            var formatterLength = formatter.GetLength();
            if (formatterLength != null) throw new InvalidOperationException("T has fixed length, use FixedListSegement instead. Type: " + typeof(T).Name);
        }

        public VariableListSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
            : base(tracker, originalBytes, false)
        {
            var formatterLength = formatter.GetLength();
            if (formatterLength != null) throw new InvalidOperationException("T has fixed length, use FixedListSegement instead. Type: " + typeof(T).Name);
        }

        protected override int GetOffset(int index)
        {
            var array = originalBytes.Array;
            return BinaryUtil.ReadInt32(ref array, originalBytes.Offset + 8 + (4 * index));
        }

        public override T this[int index]
        {
            get
            {
                if (index > length)
                {
                    throw new ArgumentOutOfRangeException("index > Count");
                }
                CreateCacheWhenNotYet();

                if (!isAllCached && !isCached[index])
                {
                    var array = originalBytes.Array;
                    var offset = GetOffset(index);
                    int _;
                    cache[index] = formatter.Deserialize(ref array, offset, out _);
                    isCached[index] = true;
                }

                state = SegmentState.Cached;
                return cache[index];
            }

            set
            {
                if (index > Count)
                {
                    throw new ArgumentOutOfRangeException("index > Count");
                }
                CreateCacheWhenNotYet();

                cache[index] = value;
                if (!isAllCached)
                {
                    isCached[index] = true;
                }
                state = SegmentState.Dirty;
            }
        }
    }
}