using System.Collections.Generic;

namespace ZeroFormatter.Formatters
{
    // Struct Layouts.
    internal class KeyValuePairFormatter<TTypeResolver, TKey, TValue> : Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyValuePair<TKey, TValue> value)
        {
            var startOffset = offset;
            offset += Formatter<TTypeResolver, TKey>.Default.Serialize(ref bytes, offset, value.Key);
            offset += Formatter<TTypeResolver, TValue>.Default.Serialize(ref bytes, offset, value.Value);
            return offset - startOffset;
        }

        public override KeyValuePair<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            int size;
            byteSize = 0;

            var key = Formatter<TTypeResolver, TKey>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            var value = Formatter<TTypeResolver, TValue>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyValuePair<TKey, TValue>(key, value);
        }
    }
}
