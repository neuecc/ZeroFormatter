using System;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    // Layout: [fixedElementSize]
    // Layout: [isNull:1][fixedElementSize]


    internal class Int32Formatter : Formatter<Int32>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int32 value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, value);
        }

        public override Int32 Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    internal class NullableInt32Formatter : Formatter<Int32?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int32? value)
        {
            BinaryUtil.WriteBool(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override Int32? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBool(ref bytes, offset);
            if (isNull) return default(Int32?);

            return BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }


    internal class SingleFormatter : Formatter<Single>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, Single value)
        {
            return BinaryUtil.WriteSingle(ref bytes, offset, value);
        }

        public override Single Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadSingle(ref bytes, offset);
        }
    }

    internal class NullableSingleFormatter : Formatter<Single?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, Single? value)
        {
            BinaryUtil.WriteBool(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteSingle(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override Single? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBool(ref bytes, offset);
            if (isNull) return default(Single?);

            return BinaryUtil.ReadSingle(ref bytes, offset + 1);
        }
    }


}