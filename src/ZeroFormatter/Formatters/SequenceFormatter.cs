using System.Collections.Generic;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Sequence:Array(Optimized formatter)
    // Layout: [count:int][t format...] -> if count = -1 is null
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

    // Sequence:Collection
    // Layout: [count:int][t format...] -> if count = -1 is null
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

    // Same as CollectionFormatter but specialized to Dictionary.
    internal class SequenceDictionaryFormatter<TKey, TValue> : Formatter<Dictionary<TKey, TValue>>
    {
        readonly Formatter<KeyValuePair<TKey, TValue>> formatter;

        public SequenceDictionaryFormatter()
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

            foreach (var item in value)
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

            var startOffset = offset;
            offset += 4;
            int size;
            var result = new Dictionary<TKey, TValue>(length);
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
}