using System;
using System.Collections;
using System.Collections.Generic;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // TODO: /* IReadOnlyList??? */

    // Layout: FixedSize -> [count:int][t format...]
    public class FixedListSegement<T> : IList<T>
    {
        readonly ArraySegment<byte> originalBytes; // ArraySegment.Count must not use...
        readonly int length;
        readonly int elementSize;
        readonly Formatter<T> formatter;

        public FixedListSegement(ArraySegment<byte> originalBytes)
        {
            this.originalBytes = originalBytes;
            this.formatter = Formatters.Formatter<T>.Default;
            var formatterLength = formatter.GetLength();
            if (formatterLength == null) throw new InvalidOperationException("T should be fixed length. Type: " + typeof(T).Name);
            elementSize = formatterLength.Value;

            var array = originalBytes.Array;
            this.length = BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
        }

        public T this[int index]
        {
            get
            {
                if (index > length)
                {
                    throw new ArgumentOutOfRangeException("index > Count");
                }

                var array = originalBytes.Array;
                var offset = 4 + (elementSize * index);
                return formatter.Deserialize(ref array, originalBytes.Offset + offset);
            }
            set
            {
                if (index > Count)
                {
                    throw new ArgumentOutOfRangeException("index > Count");
                }

                var array = originalBytes.Array;
                var offset = 4 + (elementSize * index);
                formatter.Serialize(ref array, originalBytes.Offset + offset, value);
            }
        }

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
            for (int i = arrayIndex; i < length; i++)
            {
                array[i] = this[i];
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

        public void Add(T item)
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }

        public void Clear()
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }
    }

    // TODO: /* IReadOnlyList??? */

    // Layout: VariableSize -> [count:int][elementOffset:int...][t format...]
    public class VariableListSegment<T> : IList<T>
    {
        readonly ArraySegment<byte> originalBytes;
        readonly int length;
        readonly Formatter<T> formatter;

        DirtyTracker tracker;
        SegmentState state;

        bool[] isCached;
        T[] cache;

        public VariableListSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
        {
            this.originalBytes = originalBytes;
            this.formatter = Formatters.Formatter<T>.Default;
            var formatterLength = formatter.GetLength();
            if (formatterLength != null) throw new InvalidOperationException("T has fixed length, use FixedListSegement instead. Type: " + typeof(T).Name);

            var array = originalBytes.Array;
            this.length = BinaryUtil.ReadInt32(ref array, originalBytes.Offset);

            this.tracker = tracker;
            this.state = SegmentState.Original;
        }

        void CreateCacheWhenNotYet()
        {
            if (cache == null)
            {
                cache = new T[length];
                isCached = new bool[length];
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > length)
                {
                    throw new ArgumentOutOfRangeException("index > Count");
                }
                CreateCacheWhenNotYet();

                if (!isCached[index])
                {
                    var array = originalBytes.Array;
                    var offset = BinaryUtil.ReadInt32(ref array, originalBytes.Offset + 4 + (4 * index));
                    cache[index] = formatter.Deserialize(ref array, offset);
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
                isCached[index] = true;
                state = SegmentState.Dirty;
            }
        }

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
            for (int i = arrayIndex; i < length; i++)
            {
                array[i] = this[i];
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

        public void Add(T item)
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }

        public void Clear()
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException("ListSegment only supports read and set.");
        }
    }
}