using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZeroFormatter.Comparers;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    // Sequence:
    // Layout: [count:int][t format...] -> if count = -1 is null

    // Array(Optimized formatter)
    internal class ArrayFormatter<TTypeResolver, T> : Formatter<TTypeResolver, T[]>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> formatter;
        readonly int? formatterLength;

        public ArrayFormatter()
        {
            this.formatter = Formatter<TTypeResolver, T>.Default;
            this.formatterLength = formatter.GetLength();
        }

        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter.NoUseDirtyTracker;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, T[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            if (formatterLength != null)
            {
                // make fixed size.
                BinaryUtil.EnsureCapacity(ref bytes, offset, 4 + formatterLength.Value * value.Length);
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Length);

            for (int i = 0; i < value.Length; i++)
            {
                offset += formatter.Serialize(ref bytes, offset, value[i]);
            }

            return offset - startOffset;
        }

        public override T[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }

            var startOffset = offset;
            offset += 4;
            int size;
            ZeroFormatterSerializer.ValidateNewLength(length);
            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = formatter.Deserialize(ref bytes, offset, tracker, out size);
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

    // Collection(All concrete collections like List<T>, HashSet<T>, etc...
    internal class CollectionFormatter<TTypeResolver, TElement, TCollection> : Formatter<TTypeResolver, TCollection>
        where TCollection : ICollection<TElement>, new()
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, TElement> formatter;
        readonly int? formatterLength;
        readonly bool isList;

        public CollectionFormatter()
        {
            this.formatter = Formatter<TTypeResolver, TElement>.Default;
            this.formatterLength = formatter.GetLength();
            this.isList = typeof(TCollection).GetGenericTypeDefinition() == typeof(List<>);
        }

        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter.NoUseDirtyTracker;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, TCollection value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            if (formatterLength != null)
            {
                // make fixed size.
                BinaryUtil.EnsureCapacity(ref bytes, offset, 4 + formatterLength.Value * value.Count);
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            // Optimize iteration
            var array = value as TElement[];
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    offset += formatter.Serialize(ref bytes, offset, array[i]);
                }
            }
            else
            {
                var list = value as List<TElement>;
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        offset += formatter.Serialize(ref bytes, offset, list[i]);
                    }
                }
                else
                {
                    foreach (var item in value)
                    {
                        offset += formatter.Serialize(ref bytes, offset, item);
                    }
                }
            }

            return offset - startOffset;
        }

        public override TCollection Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return default(TCollection);
            }

            var startOffset = offset;
            offset += 4;
            int size;

            ZeroFormatterSerializer.ValidateNewLength(length);
            TCollection result;
            if (isList)
            {
                // optmize fixed length.
                result = (TCollection)(object)new List<TElement>(length);
            }
            else
            {
                result = new TCollection();
            }
            for (int i = 0; i < length; i++)
            {
                result.Add(formatter.Deserialize(ref bytes, offset, tracker, out size));
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

    // Same as CollectionFormatter but specialized to ReadOnlyCollection.
    internal class ReadOnlyCollectionFormatter<TTypeResolver, T> : Formatter<TTypeResolver, ReadOnlyCollection<T>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> formatter;
        readonly int? formatterLength;

        public ReadOnlyCollectionFormatter()
        {
            this.formatter = Formatter<TTypeResolver, T>.Default;
            this.formatterLength = formatter.GetLength();
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ReadOnlyCollection<T> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            if (formatterLength != null)
            {
                // make fixed size.
                BinaryUtil.EnsureCapacity(ref bytes, offset, 4 + formatterLength.Value * value.Count);
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            for (int i = 0; i < value.Count; i++)
            {
                offset += formatter.Serialize(ref bytes, offset, value[i]);
            }

            return offset - startOffset;
        }

        public override ReadOnlyCollection<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            // tracker.Dirty(); ReadOnly is immutable

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }

            var startOffset = offset;
            offset += 4;
            int size;
            ZeroFormatterSerializer.ValidateNewLength(length);
            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = formatter.Deserialize(ref bytes, offset, tracker, out size);
                offset += size;
            }

            byteSize = offset - startOffset;
            return new ReadOnlyCollection<T>(result);
        }
    }

    // Same as CollectionFormatter but specialized to Dictionary.
    internal class DictionaryFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, Dictionary<TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, KeyValuePair<TKey, TValue>> formatter;

        public DictionaryFormatter()
        {
            this.formatter = Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>.Default;
        }

        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter.NoUseDirtyTracker;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Dictionary<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            foreach (var item in value) // Dictionary.Enumerator is faster than from interfaces...
            {
                offset += formatter.Serialize(ref bytes, offset, item);
            }

            return offset - startOffset;
        }

        public override Dictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            int size;
            var comparer = ZeroFormatterEqualityComparer<TKey>.NondeterministicSafeFallbacked;
            var result = new Dictionary<TKey, TValue>(length, comparer);
            for (int i = 0; i < length; i++)
            {
                var kvp = formatter.Deserialize(ref bytes, offset, tracker, out size);
                result.Add(kvp.Key, kvp.Value);
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

    // well known interfaces, fallback to concrete collection.
    internal class InterfaceDictionaryFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, IDictionary<TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, KeyValuePair<TKey, TValue>> formatter;

        public InterfaceDictionaryFormatter()
        {
            this.formatter = Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>.Default;
        }

        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter.NoUseDirtyTracker;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IDictionary<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            foreach (var item in value)
            {
                offset += formatter.Serialize(ref bytes, offset, item);
            }

            return offset - startOffset;
        }

        public override IDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            int size;
            var comparer = ZeroFormatterEqualityComparer<TKey>.NondeterministicSafeFallbacked;
            var result = new Dictionary<TKey, TValue>(length, comparer);
            for (int i = 0; i < length; i++)
            {
                var kvp = formatter.Deserialize(ref bytes, offset, tracker, out size);
                result.Add(kvp.Key, kvp.Value);
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

    internal class InterfaceCollectionFormatter<TTypeResolver, T> : Formatter<TTypeResolver, ICollection<T>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> formatter;
        readonly int? formatterLength;

        public InterfaceCollectionFormatter()
        {
            this.formatter = Formatter<TTypeResolver, T>.Default;
            this.formatterLength = formatter.GetLength();
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ICollection<T> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            if (formatterLength != null)
            {
                // make fixed size.
                BinaryUtil.EnsureCapacity(ref bytes, offset, 4 + formatterLength.Value * value.Count);
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            foreach (var item in value)
            {
                offset += formatter.Serialize(ref bytes, offset, item);
            }

            return offset - startOffset;
        }

        public override ICollection<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            int size;
            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = formatter.Deserialize(ref bytes, offset, tracker, out size);
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

    internal class InterfaceEnumerableFormatter<TTypeResolver, T> : Formatter<TTypeResolver, IEnumerable<T>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> formatter;

        public InterfaceEnumerableFormatter()
        {
            this.formatter = Formatter<TTypeResolver, T>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IEnumerable<T> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var startOffset = offset;
            offset += 4;

            var count = 0;
            foreach (var item in value)
            {
                offset += formatter.Serialize(ref bytes, offset, item);
                count++;
            }
            BinaryUtil.WriteInt32(ref bytes, startOffset, count);

            return offset - startOffset;
        }

        public override IEnumerable<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            // tracker.Dirty(); // IEnumerable is immutable

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            int size;
            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = formatter.Deserialize(ref bytes, offset, tracker, out size);
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

    // IGrouping<TKey, TElement> was encoded by struct format(key, T[]).
    internal class LookupFormatter<TTypeResolver, TKey, TElement> : Formatter<TTypeResolver, ILookup<TKey, TElement>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, TKey> keyFormatter;
        readonly Formatter<TTypeResolver, TElement> valueFormatter;
        readonly Formatter<TTypeResolver, IEnumerable<TElement>> valuesFormatter;

        public LookupFormatter()
        {
            keyFormatter = Formatter<TTypeResolver, TKey>.Default;
            valueFormatter = Formatter<TTypeResolver, TElement>.Default;
            valuesFormatter = Formatter<TTypeResolver, IEnumerable<TElement>>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ILookup<TKey, TElement> value)
        {
            var startOffset = offset;
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            offset += ZeroFormatter.Internal.BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            foreach (var item in value)
            {
                offset += keyFormatter.Serialize(ref bytes, offset, item.Key);
                offset += valuesFormatter.Serialize(ref bytes, offset, item);
            }

            return offset - startOffset;
        }

        public override ILookup<TKey, TElement> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            // tracker.Dirty(); // ilookup is immutable

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            var lastOffset = offset;
            var comparer = ZeroFormatterEqualityComparer<TKey>.NondeterministicSafeFallbacked;
            var sequence = new DeserializeSequence(bytes, offset, tracker, length, keyFormatter, valueFormatter);
            var lookup = sequence.ToLookup(x => x.Item1, x => x.Item2, comparer);

            byteSize = sequence.offset - startOffset;
            return lookup;
        }

        class DeserializeSequence : IEnumerable<KeyTuple<TKey, TElement>>
        {
            public int offset; // can read last offset. be careful.

            readonly byte[] refBytes;
            readonly DirtyTracker tracker;
            readonly int length;
            readonly Formatter<TTypeResolver, TKey> keyFormatter;
            readonly Formatter<TTypeResolver, TElement> valueFormatter;

            public DeserializeSequence(byte[] bytes, int offset, DirtyTracker tracker, int length, Formatter<TTypeResolver, TKey> keyFormatter, Formatter<TTypeResolver, TElement> valueFormatter)
            {
                this.refBytes = bytes;
                this.offset = offset;
                this.tracker = tracker;
                this.length = length;
                this.keyFormatter = keyFormatter;
                this.valueFormatter = valueFormatter;
            }

            public IEnumerator<KeyTuple<TKey, TElement>> GetEnumerator()
            {
                var bytes = refBytes;

                int size;
                for (int i = 0; i < length; i++)
                {
                    var key = keyFormatter.Deserialize(ref bytes, offset, tracker, out size);
                    offset += size;

                    // no use valuesFormatter(avoid intermediate array allocate)
                    var valuesLength = BinaryUtil.ReadInt32(ref bytes, offset);
                    offset += 4;

                    for (int j = 0; j < valuesLength; j++)
                    {
                        var value = valueFormatter.Deserialize(ref bytes, offset, tracker, out size);
                        offset += size;
                        yield return new KeyTuple<TKey, TElement>(key, value);
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }

#if !UNITY

    internal class InterfaceSetFormatter<TTypeResolver, T> : Formatter<TTypeResolver, ISet<T>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> formatter;
        readonly int? formatterLength;

        public InterfaceSetFormatter()
        {
            this.formatter = Formatter<TTypeResolver, T>.Default;
            this.formatterLength = formatter.GetLength();
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ISet<T> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            if (formatterLength != null)
            {
                // make fixed size.
                BinaryUtil.EnsureCapacity(ref bytes, offset, 4 + formatterLength.Value * value.Count);
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            foreach (var item in value)
            {
                offset += formatter.Serialize(ref bytes, offset, item);
            }

            return offset - startOffset;
        }

        public override ISet<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            int size;
            var comparer = ZeroFormatterEqualityComparer<T>.NondeterministicSafeFallbacked;
            var result = new HashSet<T>(comparer);
            for (int i = 0; i < length; i++)
            {
                result.Add(formatter.Deserialize(ref bytes, offset, tracker, out size));
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

    internal class InterfaceReadOnlyCollectionFormatter<TTypeResolver, T> : Formatter<TTypeResolver, IReadOnlyCollection<T>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> formatter;
        readonly int? formatterLength;

        public InterfaceReadOnlyCollectionFormatter()
        {
            this.formatter = Formatter<TTypeResolver, T>.Default;
            this.formatterLength = formatter.GetLength();
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IReadOnlyCollection<T> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            if (formatterLength != null)
            {
                // make fixed size.
                BinaryUtil.EnsureCapacity(ref bytes, offset, 4 + formatterLength.Value * value.Count);
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            foreach (var item in value)
            {
                offset += formatter.Serialize(ref bytes, offset, item);
            }

            return offset - startOffset;
        }

        public override IReadOnlyCollection<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            // tracker.Dirty(); // immutable

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            int size;
            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = formatter.Deserialize(ref bytes, offset, tracker, out size);
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

    internal class ReadOnlyDictionaryFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, ReadOnlyDictionary<TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, KeyValuePair<TKey, TValue>> formatter;

        public ReadOnlyDictionaryFormatter()
        {
            this.formatter = Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>.Default;
        }

        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter.NoUseDirtyTracker;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, ReadOnlyDictionary<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            foreach (var item in value) // Dictionary.Enumerator is faster than from interfaces...
            {
                offset += formatter.Serialize(ref bytes, offset, item);
            }

            return offset - startOffset;
        }

        public override ReadOnlyDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            // tracker.Dirty(); // immutable

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            int size;
            var comparer = ZeroFormatterEqualityComparer<TKey>.NondeterministicSafeFallbacked;
            var result = new Dictionary<TKey, TValue>(length, comparer);
            for (int i = 0; i < length; i++)
            {
                var kvp = formatter.Deserialize(ref bytes, offset, tracker, out size);
                result.Add(kvp.Key, kvp.Value);
                offset += size;
            }

            byteSize = offset - startOffset;
            return new ReadOnlyDictionary<TKey, TValue>(result);
        }
    }

    internal class InterfaceReadOnlyDictionaryFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, IReadOnlyDictionary<TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, KeyValuePair<TKey, TValue>> formatter;

        public InterfaceReadOnlyDictionaryFormatter()
        {
            this.formatter = Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>.Default;
        }

        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter.NoUseDirtyTracker;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IReadOnlyDictionary<TKey, TValue> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var startOffset = offset;
            offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

            foreach (var item in value) // Dictionary.Enumerator is faster than from interfaces...
            {
                offset += formatter.Serialize(ref bytes, offset, item);
            }

            return offset - startOffset;
        }

        public override IReadOnlyDictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            // tracker.Dirty(); // immutable

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            ZeroFormatterSerializer.ValidateNewLength(length);

            var startOffset = offset;
            offset += 4;
            int size;
            var comparer = ZeroFormatterEqualityComparer<TKey>.NondeterministicSafeFallbacked;
            var result = new Dictionary<TKey, TValue>(length, comparer);
            for (int i = 0; i < length; i++)
            {
                var kvp = formatter.Deserialize(ref bytes, offset, tracker, out size);
                result.Add(kvp.Key, kvp.Value);
                offset += size;
            }

            byteSize = offset - startOffset;
            return result;
        }
    }

#endif
}