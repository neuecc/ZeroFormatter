using System;
using System.Collections.Generic;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Struct Layouts.
    internal class KeyValuePairFormatter<TKey, TValue> : Formatter<KeyValuePair<TKey, TValue>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyValuePair<TKey, TValue> value)
        {
            var startOffset = offset;
            offset += Formatter<TKey>.Default.Serialize(ref bytes, offset, value.Key);
            offset += Formatter<TValue>.Default.Serialize(ref bytes, offset, value.Value);
            return offset - startOffset;
        }

        public override KeyValuePair<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            int size;
            byteSize = 0;

            var key = Formatter<TKey>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            var value = Formatter<TValue>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyValuePair<TKey, TValue>(key, value);
        }
    }
}
