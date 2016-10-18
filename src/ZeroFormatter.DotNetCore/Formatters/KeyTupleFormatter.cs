using System;
using ZeroFormatter.DotNetCore.Internal;
using ZeroFormatter.DotNetCore.Segments;

namespace ZeroFormatter.DotNetCore.Formatters
{
    // Layout: [T1, T2...]
    // Layout: [hasValue:1][T1, T2...]


    internal class KeyTupleFormatter<T1> : Formatter<KeyTuple<T1>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1> value)
        {
            var startOffset = offset;
            offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Item1);
            return offset - startOffset;
        }

        public override KeyTuple<T1> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1>(item1);
        }
    }

    internal class NullableKeyTupleFormatter<T1> : Formatter<KeyTuple<T1>?>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1>? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Value.Item1);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override KeyTuple<T1>? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;
            
            offset += 1;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1>(item1);
        }
    }


    internal class KeyTupleFormatter<T1, T2> : Formatter<KeyTuple<T1, T2>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2> value)
        {
            var startOffset = offset;
            offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Item1);
            offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Item2);
            return offset - startOffset;
        }

        public override KeyTuple<T1, T2> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2>(item1, item2);
        }
    }

    internal class NullableKeyTupleFormatter<T1, T2> : Formatter<KeyTuple<T1, T2>?>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2>? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Value.Item1);
                offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Value.Item2);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override KeyTuple<T1, T2>? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;
            
            offset += 1;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2>(item1, item2);
        }
    }


    internal class KeyTupleFormatter<T1, T2, T3> : Formatter<KeyTuple<T1, T2, T3>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3> value)
        {
            var startOffset = offset;
            offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Item1);
            offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Item2);
            offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Item3);
            return offset - startOffset;
        }

        public override KeyTuple<T1, T2, T3> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3>(item1, item2, item3);
        }
    }

    internal class NullableKeyTupleFormatter<T1, T2, T3> : Formatter<KeyTuple<T1, T2, T3>?>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3>? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Value.Item1);
                offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Value.Item2);
                offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Value.Item3);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override KeyTuple<T1, T2, T3>? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;
            
            offset += 1;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3>(item1, item2, item3);
        }
    }


    internal class KeyTupleFormatter<T1, T2, T3, T4> : Formatter<KeyTuple<T1, T2, T3, T4>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4> value)
        {
            var startOffset = offset;
            offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Item1);
            offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Item2);
            offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Item3);
            offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Item4);
            return offset - startOffset;
        }

        public override KeyTuple<T1, T2, T3, T4> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }
    }

    internal class NullableKeyTupleFormatter<T1, T2, T3, T4> : Formatter<KeyTuple<T1, T2, T3, T4>?>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4>? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Value.Item1);
                offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Value.Item2);
                offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Value.Item3);
                offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Value.Item4);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override KeyTuple<T1, T2, T3, T4>? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;
            
            offset += 1;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }
    }


    internal class KeyTupleFormatter<T1, T2, T3, T4, T5> : Formatter<KeyTuple<T1, T2, T3, T4, T5>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4, T5> value)
        {
            var startOffset = offset;
            offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Item1);
            offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Item2);
            offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Item3);
            offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Item4);
            offset += Formatter<T5>.Default.Serialize(ref bytes, offset, value.Item5);
            return offset - startOffset;
        }

        public override KeyTuple<T1, T2, T3, T4, T5> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = Formatter<T5>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }
    }

    internal class NullableKeyTupleFormatter<T1, T2, T3, T4, T5> : Formatter<KeyTuple<T1, T2, T3, T4, T5>?>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4, T5>? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Value.Item1);
                offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Value.Item2);
                offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Value.Item3);
                offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Value.Item4);
                offset += Formatter<T5>.Default.Serialize(ref bytes, offset, value.Value.Item5);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override KeyTuple<T1, T2, T3, T4, T5>? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;
            
            offset += 1;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = Formatter<T5>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }
    }


    internal class KeyTupleFormatter<T1, T2, T3, T4, T5, T6> : Formatter<KeyTuple<T1, T2, T3, T4, T5, T6>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4, T5, T6> value)
        {
            var startOffset = offset;
            offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Item1);
            offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Item2);
            offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Item3);
            offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Item4);
            offset += Formatter<T5>.Default.Serialize(ref bytes, offset, value.Item5);
            offset += Formatter<T6>.Default.Serialize(ref bytes, offset, value.Item6);
            return offset - startOffset;
        }

        public override KeyTuple<T1, T2, T3, T4, T5, T6> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = Formatter<T5>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item6 = Formatter<T6>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }
    }

    internal class NullableKeyTupleFormatter<T1, T2, T3, T4, T5, T6> : Formatter<KeyTuple<T1, T2, T3, T4, T5, T6>?>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4, T5, T6>? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Value.Item1);
                offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Value.Item2);
                offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Value.Item3);
                offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Value.Item4);
                offset += Formatter<T5>.Default.Serialize(ref bytes, offset, value.Value.Item5);
                offset += Formatter<T6>.Default.Serialize(ref bytes, offset, value.Value.Item6);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override KeyTuple<T1, T2, T3, T4, T5, T6>? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;
            
            offset += 1;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = Formatter<T5>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item6 = Formatter<T6>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }
    }


    internal class KeyTupleFormatter<T1, T2, T3, T4, T5, T6, T7> : Formatter<KeyTuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4, T5, T6, T7> value)
        {
            var startOffset = offset;
            offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Item1);
            offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Item2);
            offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Item3);
            offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Item4);
            offset += Formatter<T5>.Default.Serialize(ref bytes, offset, value.Item5);
            offset += Formatter<T6>.Default.Serialize(ref bytes, offset, value.Item6);
            offset += Formatter<T7>.Default.Serialize(ref bytes, offset, value.Item7);
            return offset - startOffset;
        }

        public override KeyTuple<T1, T2, T3, T4, T5, T6, T7> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = Formatter<T5>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item6 = Formatter<T6>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item7 = Formatter<T7>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }
    }

    internal class NullableKeyTupleFormatter<T1, T2, T3, T4, T5, T6, T7> : Formatter<KeyTuple<T1, T2, T3, T4, T5, T6, T7>?>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4, T5, T6, T7>? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Value.Item1);
                offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Value.Item2);
                offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Value.Item3);
                offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Value.Item4);
                offset += Formatter<T5>.Default.Serialize(ref bytes, offset, value.Value.Item5);
                offset += Formatter<T6>.Default.Serialize(ref bytes, offset, value.Value.Item6);
                offset += Formatter<T7>.Default.Serialize(ref bytes, offset, value.Value.Item7);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override KeyTuple<T1, T2, T3, T4, T5, T6, T7>? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;
            
            offset += 1;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = Formatter<T5>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item6 = Formatter<T6>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item7 = Formatter<T7>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }
    }


    internal class KeyTupleFormatter<T1, T2, T3, T4, T5, T6, T7, TRest> : Formatter<KeyTuple<T1, T2, T3, T4, T5, T6, T7, TRest>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4, T5, T6, T7, TRest> value)
        {
            var startOffset = offset;
            offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Item1);
            offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Item2);
            offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Item3);
            offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Item4);
            offset += Formatter<T5>.Default.Serialize(ref bytes, offset, value.Item5);
            offset += Formatter<T6>.Default.Serialize(ref bytes, offset, value.Item6);
            offset += Formatter<T7>.Default.Serialize(ref bytes, offset, value.Item7);
            offset += Formatter<TRest>.Default.Serialize(ref bytes, offset, value.Rest);
            return offset - startOffset;
        }

        public override KeyTuple<T1, T2, T3, T4, T5, T6, T7, TRest> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = Formatter<T5>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item6 = Formatter<T6>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item7 = Formatter<T7>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item8 = Formatter<TRest>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(item1, item2, item3, item4, item5, item6, item7, item8);
        }
    }

    internal class NullableKeyTupleFormatter<T1, T2, T3, T4, T5, T6, T7, TRest> : Formatter<KeyTuple<T1, T2, T3, T4, T5, T6, T7, TRest>?>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyTuple<T1, T2, T3, T4, T5, T6, T7, TRest>? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                var startOffset = offset;
                offset += 1;
                offset += Formatter<T1>.Default.Serialize(ref bytes, offset, value.Value.Item1);
                offset += Formatter<T2>.Default.Serialize(ref bytes, offset, value.Value.Item2);
                offset += Formatter<T3>.Default.Serialize(ref bytes, offset, value.Value.Item3);
                offset += Formatter<T4>.Default.Serialize(ref bytes, offset, value.Value.Item4);
                offset += Formatter<T5>.Default.Serialize(ref bytes, offset, value.Value.Item5);
                offset += Formatter<T6>.Default.Serialize(ref bytes, offset, value.Value.Item6);
                offset += Formatter<T7>.Default.Serialize(ref bytes, offset, value.Value.Item7);
                offset += Formatter<TRest>.Default.Serialize(ref bytes, offset, value.Value.Rest);
                return offset - startOffset;
            }
            else
            {
                return 1;
            }
        }

        public override KeyTuple<T1, T2, T3, T4, T5, T6, T7, TRest>? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;
            
            offset += 1;
            int size;

            var item1 = Formatter<T1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<T2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = Formatter<T3>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = Formatter<T4>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = Formatter<T5>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item6 = Formatter<T6>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item7 = Formatter<T7>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item8 = Formatter<TRest>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(item1, item2, item3, item4, item5, item6, item7, item8);
        }
    }


}