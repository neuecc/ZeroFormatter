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

        T[] cached;

        public FixedListSegement(ArraySegment<byte> originalBytes)
        {
            this.originalBytes = originalBytes;
            this.formatter = Formatters.Formatter<T>.Instance;

            var length = formatter.GetLength();
            if (length == null) throw new InvalidOperationException("T should be fixed length. Type: " + typeof(T).Name);
            elementSize = length.Value;
        }

        public T this[int index]
        {
            get
            {
                // TODO:out-of-range exception?
                var offset = 4 + (elementSize * index);
                var array = originalBytes.Array;
                return formatter.Deserialize(ref array, originalBytes.Offset + offset);
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
                var array = originalBytes.Array;
                return BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
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