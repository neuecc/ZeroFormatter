using System;
using System.Collections.Generic;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace PerformanceComparison
{
    public static class ImmediateDictionaryResolver
    {
        public static void Register()
        {
            ZeroFormatter.Formatters.Formatter.AppendFormatterResolver(x =>
            {
                if (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    return Activator.CreateInstance(typeof(ImmediateDictionaryFormatter<,>).MakeGenericType(x.GenericTypeArguments));
                }

                return null;
            });
        }
    }

    // Layout:[count:int][(key, value)....]
    public class ImmediateDictionaryFormatter<TKey, TValue> : Formatter<Dictionary<TKey, TValue>>
    {
        readonly Formatter<TKey> keyFormatter;
        readonly Formatter<TValue> valueFormatter;

        public ImmediateDictionaryFormatter()
        {
            this.keyFormatter = Formatter<TKey>.Default;
            this.valueFormatter = Formatter<TValue>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Dictionary<TKey, TValue> value)
        {
            var startOffset = offset;
            if (value == null)
            {
                ZeroFormatter.Internal.BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                offset += ZeroFormatter.Internal.BinaryUtil.WriteInt32(ref bytes, offset, value.Count);
            }

            foreach (var item in value)
            {
                offset += keyFormatter.Serialize(ref bytes, offset, item.Key);
                offset += valueFormatter.Serialize(ref bytes, offset, item.Value);
            }

            return offset - startOffset;
        }

        public override Dictionary<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            var count = BinaryUtil.ReadInt32(ref bytes, offset);
            if (count == -1)
            {
                return null;
            }
            offset += 4;

            var dict = new Dictionary<TKey, TValue>(count);
            var size = 0;
            for (int i = 0; i < count; i++)
            {
                var key = keyFormatter.Deserialize(ref bytes, offset, tracker, out size);
                byteSize += size;
                offset += size;

                var value = valueFormatter.Deserialize(ref bytes, offset, tracker, out size);
                byteSize += size;
                offset += size;

                dict.Add(key, value);
            }

            return dict;
        }
    }
}
