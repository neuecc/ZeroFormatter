#if !UNITY

using System;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    internal class RuntimeUnionFormatter<TKey> : Formatter<object>
    {
        readonly string name;
        readonly KeyTuple<TKey, Type>[] unionSubTypes;
        readonly Dictionary<Type, TKey> keyLookup;
        readonly Dictionary<TKey, Type> typeLookup;
        readonly Formatter<TKey> keyFormatter;

        public RuntimeUnionFormatter(string name, KeyTuple<TKey, Type>[] unionSubTypes)
        {
            this.name = name;
            this.unionSubTypes = unionSubTypes;
            this.keyLookup = unionSubTypes.ToDictionary(x => x.Item2, x => x.Item1);
            this.typeLookup = unionSubTypes.ToDictionary(x => x.Item1, x => x.Item2, ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<TKey>.NondeterministicSafeFallbacked);
            this.keyFormatter = Formatter<TKey>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, object value)
        {
            if (value == null)
            {
                BinaryUtil.WriteBoolean(ref bytes, offset, false);
                return 1;
            }
            else
            {
                BinaryUtil.WriteBoolean(ref bytes, offset, true);
            }

            var t = value.GetType();
            TKey key;
            if (!keyLookup.TryGetValue(t, out key))
            {
                throw new InvalidOperationException(string.Format("Runtime Union Key not registered. FormatterName:{0}, Type:{1}", name, t.GetType().FullName));
            }

            var startOffset = offset;
            offset += 1; // hasValue
            offset += keyFormatter.Serialize(ref bytes, offset, key);
            offset += Formatter.NonGeneric.Serialize(t, ref bytes, offset, value); // NonGeneric can use only not unity.

            return offset - startOffset;
        }

        public override object Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var startOffset = offset;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue)
            {
                byteSize = 1;
                return null;
            }
            offset += 1;

            int size;
            var key = keyFormatter.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;

            Type type;
            if (!typeLookup.TryGetValue(key, out type))
            {
                throw new InvalidOperationException(string.Format("Runtime Union Key not registered. FormatterName:{0}, Key:{1}", name, key));
            }

            var value = Formatter.NonGeneric.Deserialize(type, ref bytes, offset, tracker, out size);
            offset += size;
            byteSize = offset - startOffset;
            return value;
        }
    }
}

#endif