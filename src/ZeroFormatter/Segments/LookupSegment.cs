using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Comparers;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // Lookup gurantees element order, key order is not guranteed.

    // [int byteSize]
    // [int count]
    // [IList<IList<GroupingSemengt>>]
    public class LookupSegment<TKey, TElement> : ILookup<TKey, TElement>
    {
        static TElement[] EmptyArray = new TElement[0];
        readonly IEqualityComparer<TKey> comparer;

        // serialize
        int count;
        IList<IList<GroupingSegment<TKey, TElement>>> groupings;

        public LookupSegment(ILookup<TKey, TElement> source)
        {
            this.comparer = ZeroFormatterEqualityComparer<TKey>.Default;
            this.groupings = new List<IList<GroupingSegment<TKey, TElement>>>(source.Count);
            for (int i = 0; i < source.Count; i++)
            {
                groupings.Add(null); // null clear
            }

            foreach (var g in source)
            {
                foreach (var item in g)
                {
                    GetGrouping(g.Key, true).Add(item);
                }
            }

            this.count = source.Count;
        }

        internal static LookupSegment<TKey, TElement> Create(ArraySegment<byte> originalBytes, out int byteSize)
        {
            var segment = new LookupSegment<TKey, TElement>();

            var array = originalBytes.Array;

            byteSize = BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
            segment.count = BinaryUtil.ReadInt32(ref array, originalBytes.Offset + 4);

            var formatter = Formatter<IList<IList<GroupingSegment<TKey, TElement>>>>.Default;
            int _;
            segment.groupings = formatter.Deserialize(ref array, originalBytes.Offset + 8, out _);

            return segment;
        }

        LookupSegment()
        {
            this.comparer = ZeroFormatterEqualityComparer<TKey>.Default;
        }

        public int Count
        {
            get { return count; }
        }

        public IEnumerable<TElement> this[TKey key]
        {
            get
            {
                GroupingSegment<TKey, TElement> grouping = GetGrouping(key, create: false);
                if (grouping != null)
                {
                    return grouping;
                }

                return EmptyArray;
            }
        }

        public bool Contains(TKey key)
        {
            return GetGrouping(key, create: false) != null;
        }

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            for (int i = 0; i < groupings.Count; i++)
            {
                var g = groupings[i];
                if (g != null)
                {
                    foreach (var item in g)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        GroupingSegment<TKey, TElement> GetGrouping(TKey key, bool create)
        {
            int hashCode = (key == null) ? 0 : comparer.GetHashCode(key) & 0x7FFFFFFF;

            IList<GroupingSegment<TKey, TElement>> groupList = groupings[hashCode % groupings.Count];
            if (groupList != null)
            {
                for (int i = 0; i < groupList.Count; i++)
                {
                    var g = groupList[i];
                    if (g.hashCode == hashCode && comparer.Equals(g.key, key))
                    {
                        return g;
                    }
                }
            }

            if (create)
            {
                int index = hashCode % groupings.Count;
                var g = new GroupingSegment<TKey, TElement>(key, hashCode);

                var list = groupings[index];
                if (list == null)
                {
                    list = groupings[index] = new List<GroupingSegment<TKey, TElement>>();
                }
                list.Add(g);

                count++;
                return g;
            }

            return null;
        }

        public int Serialize(ref byte[] bytes, int offset)
        {
            var totalSize = 4;
            totalSize += BinaryUtil.WriteInt32(ref bytes, offset + 4, count);
            var formatter = Formatter<IList<IList<GroupingSegment<TKey, TElement>>>>.Default;
            totalSize += formatter.Serialize(ref bytes, offset + 8, groupings);
            BinaryUtil.WriteInt32(ref bytes, offset, totalSize);

            return totalSize;
        }
    }


    // [TKey key]
    // [int hashCode]
    // [IList<TElement> elements]
    public class GroupingSegment<TKey, TElement> : IGrouping<TKey, TElement>, IList<TElement>
    {
        internal TKey key;
        internal int hashCode;
        internal IList<TElement> elements;

        internal static GroupingSegment<TKey, TElement> Create(ArraySegment<byte> originalBytes, out int byteSize)
        {
            var segment = new GroupingSegment<TKey, TElement>();

            var array = originalBytes.Array;
            var offset = originalBytes.Offset;

            var keyFormatter = Formatter<TKey>.Default;
            var listFormatter = Formatter<IList<TElement>>.Default;

            int keySize;
            segment.key = keyFormatter.Deserialize(ref array, offset, out keySize);

            segment.hashCode = BinaryUtil.ReadInt32(ref array, offset + keySize);

            int listSize;
            segment.elements = listFormatter.Deserialize(ref array, offset + keySize + 4, out listSize);

            byteSize = keySize + 4 + listSize;
            return segment;
        }

        GroupingSegment()
        {
        }

        internal GroupingSegment(TKey key, int hashCode)
        {
            this.key = key;
            this.hashCode = hashCode;
            this.elements = new List<TElement>();
        }

        internal void Add(TElement element)
        {
            elements.Add(element);
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TKey Key
        {
            get { return key; }
        }

        int ICollection<TElement>.Count
        {
            get { return elements.Count; }
        }

        bool ICollection<TElement>.IsReadOnly
        {
            get { return true; }
        }

        void ICollection<TElement>.Add(TElement item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TElement>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TElement>.Contains(TElement item)
        {
            return elements.Contains(item);
        }

        void ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        bool ICollection<TElement>.Remove(TElement item)
        {
            throw new NotSupportedException();
        }

        int IList<TElement>.IndexOf(TElement item)
        {
            return elements.IndexOf(item);
        }

        void IList<TElement>.Insert(int index, TElement item)
        {
            throw new NotSupportedException();
        }

        void IList<TElement>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        TElement IList<TElement>.this[int index]
        {
            get
            {
                if (index < 0 || index >= elements.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                return elements[index];
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        internal int Serialize(ref byte[] bytes, int offset)
        {
            var keyFormatter = Formatter<TKey>.Default;
            var listFormatter = Formatter<IList<TElement>>.Default;

            var initialOffset = offset;

            offset += keyFormatter.Serialize(ref bytes, offset, key);

            BinaryUtil.WriteInt32(ref bytes, offset, hashCode);
            offset += 4;

            offset += listFormatter.Serialize(ref bytes, offset, elements);

            return offset - initialOffset;
        }
    }
}