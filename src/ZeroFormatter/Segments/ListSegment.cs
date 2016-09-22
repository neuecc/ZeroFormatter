using System;
using System.Collections;
using System.Collections.Generic;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // Layout: FixedSize -> [length:int][t format...]
    public class FixedListSegement<T> : IList<T>
    {
        ArraySegment<byte> originalBytes;
        readonly int elementSize;
        readonly Formatter<T> formatter;

        // originalBytes and if append, use appendableArray

        T[] appendArray;
        int appendedSize;

        public FixedListSegement(ArraySegment<byte> originalBytes)
        {
            this.originalBytes = originalBytes;
            this.formatter = Formatters.Formatter<T>.Default;

            var length = formatter.GetLength();
            if (length == null) throw new InvalidOperationException("T should be fixed length. Type: " + typeof(T).Name);
            elementSize = length.Value;
        }

        public T this[int index]
        {
            get
            {
                // TODO:out-of-range exception?
                // TODO:calc appendable? or original?

                var array = originalBytes.Array;
                var offset = 4 + (elementSize * index);
                return formatter.Deserialize(ref array, originalBytes.Offset + offset);
            }
            set
            {
                // TODO:out-of-range exception?
                var offset = 4 + (elementSize * index);
                var array = originalBytes.Array;
                formatter.Serialize(ref array, originalBytes.Offset + offset, value);
            }
        }

        public int Count
        {
            get
            {
                var array = originalBytes.Array;
                if (array == null) return appendedSize;
                return BinaryUtil.ReadInt32(ref array, originalBytes.Offset) + appendedSize;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (appendArray == null)
            {
                appendArray = new T[4];
            }
            else if (appendArray.Length == appendedSize)
            {
                Array.Resize(ref appendArray, appendedSize * 2);
            }

            appendArray[appendedSize++] = item;
        }

        public void Clear()
        {
            originalBytes = default(ArraySegment<byte>);
            appendArray = null;
            appendedSize = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();



        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();


        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            //

            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    // Layout: VriableSize -> [length:int][elementSize...][t format...]
    public class VariableListSegment<T> : IList<T>
    {
        int count;

        Dictionary<int, T> cached;

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}