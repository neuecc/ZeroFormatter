using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZeroFormatter.Comparers;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Sequence:
    // Layout: [count:int][t format...] -> if count = -1 is null

    // Array(Optimized formatter)
    internal class ArrayFormatter<T> : Formatter<T[]>
    {
        readonly Formatter<T> formatter;
        readonly int? formatterLength;

        public ArrayFormatter()
        {
            this.formatter = Formatter<T>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.
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
    internal class CollectionFormatter<TElement, TCollection> : Formatter<TCollection>
        where TCollection : ICollection<TElement>, new()
    {
        readonly Formatter<TElement> formatter;
        readonly int? formatterLength;
        readonly bool isList;

        public CollectionFormatter()
        {
            this.formatter = Formatter<TElement>.Default;
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

            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.
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
    internal class ReadOnlyCollectionFormatter<T> : Formatter<ReadOnlyCollection<T>>
    {
        readonly Formatter<T> formatter;
        readonly int? formatterLength;

        public ReadOnlyCollectionFormatter()
        {
            this.formatter = Formatter<T>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.
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
    internal class DictionaryFormatter<TKey, TValue> : Formatter<Dictionary<TKey, TValue>>
    {
        readonly Formatter<KeyValuePair<TKey, TValue>> formatter;

        public DictionaryFormatter()
        {
            this.formatter = Formatter<KeyValuePair<TKey, TValue>>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

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
    internal class InterfaceDictionaryFormatter<TKey, TValue> : Formatter<IDictionary<TKey, TValue>>
    {
        readonly Formatter<KeyValuePair<TKey, TValue>> formatter;

        public InterfaceDictionaryFormatter()
        {
            this.formatter = Formatter<KeyValuePair<TKey, TValue>>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

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

    internal class InterfaceCollectionFormatter<T> : Formatter<ICollection<T>>
    {
        readonly Formatter<T> formatter;
        readonly int? formatterLength;

        public InterfaceCollectionFormatter()
        {
            this.formatter = Formatter<T>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

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

    internal class InterfaceEnumerableFormatter<T> : Formatter<IEnumerable<T>>
    {
        readonly Formatter<T> formatter;

        public InterfaceEnumerableFormatter()
        {
            this.formatter = Formatter<T>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

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
    internal class LookupFormatter<TKey, TElement> : Formatter<ILookup<TKey, TElement>>
    {
        readonly Formatter<TKey> keyFormatter;
        readonly Formatter<TElement> valueFormatter;
        readonly Formatter<IEnumerable<TElement>> valuesFormatter;

        public LookupFormatter()
        {
            keyFormatter = Formatter<TKey>.Default;
            valueFormatter = Formatter<TElement>.Default;
            valuesFormatter = Formatter<IEnumerable<TElement>>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

            var startOffset = offset;
            offset += 4;
            var lastOffset = offset;
            var lookup = DeserializeSequence(bytes, offset, tracker, length).ToLookup(x => x.Item1, x =>
            {
                lastOffset = x.Item3; // capture in lambda is overhead but lookup can only create from ToLookup
                return x.Item2;
            });

            byteSize = lastOffset - startOffset;
            return lookup;
        }

        IEnumerable<KeyTuple<TKey, TElement, int>> DeserializeSequence(byte[] bytes, int offset, DirtyTracker tracker, int length)
        {
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
                    yield return new KeyTuple<TKey, TElement, int>(key, value, offset);
                }
            }
        }
    }


#if !UNITY

    internal class InterfaceSetFormatter<T> : Formatter<ISet<T>>
    {
        readonly Formatter<T> formatter;
        readonly int? formatterLength;

        public InterfaceSetFormatter()
        {
            this.formatter = Formatter<T>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

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

    internal class InterfaceReadOnlyCollectionFormatter<T> : Formatter<IReadOnlyCollection<T>>
    {
        readonly Formatter<T> formatter;
        readonly int? formatterLength;

        public InterfaceReadOnlyCollectionFormatter()
        {
            this.formatter = Formatter<T>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

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

    internal class ReadOnlyDictionaryFormatter<TKey, TValue> : Formatter<ReadOnlyDictionary<TKey, TValue>>
    {
        readonly Formatter<KeyValuePair<TKey, TValue>> formatter;

        public ReadOnlyDictionaryFormatter()
        {
            this.formatter = Formatter<KeyValuePair<TKey, TValue>>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

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

    internal class InterfaceReadOnlyDictionaryFormatter<TKey, TValue> : Formatter<IReadOnlyDictionary<TKey, TValue>>
    {
        readonly Formatter<KeyValuePair<TKey, TValue>> formatter;

        public InterfaceReadOnlyDictionaryFormatter()
        {
            this.formatter = Formatter<KeyValuePair<TKey, TValue>>.Default;
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
            BinaryUtil.ValidateNewSize(length); // size is not strict(Marshal.SizeOf<T>()) but okay to use.

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