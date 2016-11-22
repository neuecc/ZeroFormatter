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

    // if byteSize == -1 is null

    // [int byteSize]
    // [int count]
    // [IList<IList<GroupingSemengt>>]


    public class LookupSegment<TTypeResolver, TKey, TElement> : ILookup<TKey, TElement>, ILazyLookup<TKey, TElement>, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static TElement[] EmptyArray = new TElement[0];
        readonly IEqualityComparer<TKey> comparer;

        // serialize
        int count;
        IList<IList<GroupingSegment<TTypeResolver, TKey, TElement>>> groupings;

        // others
        internal DirtyTracker tracker;
        ArraySegment<byte> originalBytes;

        // from Formatter only for serialize.
        internal LookupSegment(ILookup<TKey, TElement> source)
        {
            this.comparer = ZeroFormatterEqualityComparer<TKey>.Default;
            this.groupings = new List<IList<GroupingSegment<TTypeResolver, TKey, TElement>>>(source.Count);
            for (int i = 0; i < source.Count; i++)
            {
                groupings.Add(null); // null clear
            }

            foreach (var g in source)
            {
                var group = GetGrouping(g.Key, true);
                foreach (var item in g)
                {
                    group.Add(item);
                }
            }

            this.count = source.Count;
        }

        public static LookupSegment<TTypeResolver, TKey, TElement> Create(DirtyTracker tracker, byte[] bytes, int offset, out int byteSize)
        {
            tracker = tracker.CreateChild();

            var byteSizeOrCount = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSizeOrCount == -1)
            {
                byteSize = 4;
                return null;
            }

            var segment = new LookupSegment<TTypeResolver, TKey, TElement>();

            byteSize = byteSizeOrCount;
            segment.count = BinaryUtil.ReadInt32(ref bytes, offset + 4);

            var formatter = Formatter<TTypeResolver, IList<IList<GroupingSegment<TTypeResolver, TKey, TElement>>>>.Default;
            int _;
            segment.groupings = formatter.Deserialize(ref bytes, offset + 8, tracker, out _);

            segment.tracker = tracker;
            segment.originalBytes = new ArraySegment<byte>(bytes, offset, byteSize);

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
                GroupingSegment<TTypeResolver, TKey, TElement> grouping = GetGrouping(key, create: false);
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

        GroupingSegment<TTypeResolver, TKey, TElement> GetGrouping(TKey key, bool create)
        {
            int hashCode = (key == null) ? 0 : comparer.GetHashCode(key) & 0x7FFFFFFF;

            IList<GroupingSegment<TTypeResolver, TKey, TElement>> groupList = groupings[hashCode % groupings.Count];
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
                var g = new GroupingSegment<TTypeResolver, TKey, TElement>(key, hashCode);

                var list = groupings[index];
                if (list == null)
                {
                    list = groupings[index] = new List<GroupingSegment<TTypeResolver, TKey, TElement>>();
                }
                list.Add(g);

                count++;
                return g;
            }

            return null;
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
                var totalSize = 4;
                totalSize += BinaryUtil.WriteInt32(ref bytes, offset + 4, count);
                var formatter = Formatter<TTypeResolver, IList<IList<GroupingSegment<TTypeResolver, TKey, TElement>>>>.Default;
                totalSize += formatter.Serialize(ref bytes, offset + 8, groupings);
                BinaryUtil.WriteInt32(ref bytes, offset, totalSize);

                return totalSize;
            }
        }
    }

    // [TKey key]
    // [int hashCode]
    // [IList<TElement> elements]
    public class GroupingSegment<TTypeResolver, TKey, TElement> : IGrouping<TKey, TElement>, IList<TElement>, IZeroFormatterSegment
         where TTypeResolver : ITypeResolver, new()
    {
        // serializestate.
        internal TKey key;
        internal int hashCode;
        internal IList<TElement> elements;

        // others
        internal DirtyTracker tracker;
        ArraySegment<byte> originalBytes;

        internal static GroupingSegment<TTypeResolver, TKey, TElement> Create(DirtyTracker tracker, byte[] bytes, int offset, out int byteSize)
        {
            var segment = new GroupingSegment<TTypeResolver, TKey, TElement>();

            tracker = tracker.CreateChild();
            segment.tracker = tracker;

            var keyFormatter = Formatter<TTypeResolver, TKey>.Default;
            var listFormatter = Formatter<TTypeResolver, IList<TElement>>.Default;

            int keySize;
            segment.key = keyFormatter.Deserialize(ref bytes, offset, tracker, out keySize);

            segment.hashCode = BinaryUtil.ReadInt32(ref bytes, offset + keySize);

            int listSize;
            segment.elements = listFormatter.Deserialize(ref bytes, offset + keySize + 4, tracker, out listSize);

            byteSize = keySize + 4 + listSize;
            segment.originalBytes = new ArraySegment<byte>(bytes, offset, byteSize);

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
                var keyFormatter = Formatter<TTypeResolver, TKey>.Default;
                var listFormatter = Formatter<TTypeResolver, IList<TElement>>.Default;

                var initialOffset = offset;

                offset += keyFormatter.Serialize(ref bytes, offset, key);

                BinaryUtil.WriteInt32(ref bytes, offset, hashCode);
                offset += 4;

                offset += listFormatter.Serialize(ref bytes, offset, elements);

                // Note:Cache serialized byte? or not?, initial release does not cache.
                var writeSize = offset - initialOffset;
                return writeSize;
            }
        }
    }
}