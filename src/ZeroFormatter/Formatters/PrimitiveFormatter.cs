using System;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    // Layout: [fixedElementSize]
    // Layout: [isNull:1][fixedElementSize]


    internal class Int16Formatter : Formatter<Int16>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int16 value)
        {
            return BinaryUtil.WriteInt16(ref bytes, offset, value);
        }

        public override Int16 Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadInt16(ref bytes, offset);
        }
    }

    internal class NullableInt16Formatter : Formatter<Int16?>
    {
        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int16? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt16(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 3);
            }

            return 3;
        }

        public override Int16? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(Int16?);

            return BinaryUtil.ReadInt16(ref bytes, offset + 1);
        }
    }


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
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
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
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(Int32?);

            return BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }


    internal class Int64Formatter : Formatter<Int64>
    {
        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int64 value)
        {
            return BinaryUtil.WriteInt64(ref bytes, offset, value);
        }

        public override Int64 Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadInt64(ref bytes, offset);
        }
    }

    internal class NullableInt64Formatter : Formatter<Int64?>
    {
        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int64? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt64(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override Int64? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(Int64?);

            return BinaryUtil.ReadInt64(ref bytes, offset + 1);
        }
    }


    internal class UInt16Formatter : Formatter<UInt16>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt16 value)
        {
            return BinaryUtil.WriteUInt16(ref bytes, offset, value);
        }

        public override UInt16 Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadUInt16(ref bytes, offset);
        }
    }

    internal class NullableUInt16Formatter : Formatter<UInt16?>
    {
        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt16? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt16(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 3);
            }

            return 3;
        }

        public override UInt16? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(UInt16?);

            return BinaryUtil.ReadUInt16(ref bytes, offset + 1);
        }
    }


    internal class UInt32Formatter : Formatter<UInt32>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt32 value)
        {
            return BinaryUtil.WriteUInt32(ref bytes, offset, value);
        }

        public override UInt32 Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadUInt32(ref bytes, offset);
        }
    }

    internal class NullableUInt32Formatter : Formatter<UInt32?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt32? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt32(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override UInt32? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(UInt32?);

            return BinaryUtil.ReadUInt32(ref bytes, offset + 1);
        }
    }


    internal class UInt64Formatter : Formatter<UInt64>
    {
        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt64 value)
        {
            return BinaryUtil.WriteUInt64(ref bytes, offset, value);
        }

        public override UInt64 Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadUInt64(ref bytes, offset);
        }
    }

    internal class NullableUInt64Formatter : Formatter<UInt64?>
    {
        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt64? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt64(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override UInt64? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(UInt64?);

            return BinaryUtil.ReadUInt64(ref bytes, offset + 1);
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
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
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
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(Single?);

            return BinaryUtil.ReadSingle(ref bytes, offset + 1);
        }
    }


    internal class DoubleFormatter : Formatter<Double>
    {
        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, Double value)
        {
            return BinaryUtil.WriteDouble(ref bytes, offset, value);
        }

        public override Double Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadDouble(ref bytes, offset);
        }
    }

    internal class NullableDoubleFormatter : Formatter<Double?>
    {
        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, Double? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteDouble(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override Double? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(Double?);

            return BinaryUtil.ReadDouble(ref bytes, offset + 1);
        }
    }


    internal class BooleanFormatter : Formatter<Boolean>
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, Boolean value)
        {
            return BinaryUtil.WriteBoolean(ref bytes, offset, value);
        }

        public override Boolean Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadBoolean(ref bytes, offset);
        }
    }

    internal class NullableBooleanFormatter : Formatter<Boolean?>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, Boolean? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteBoolean(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override Boolean? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(Boolean?);

            return BinaryUtil.ReadBoolean(ref bytes, offset + 1);
        }
    }


    internal class ByteFormatter : Formatter<Byte>
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, Byte value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, value);
        }

        public override Byte Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadByte(ref bytes, offset);
        }
    }

    internal class NullableByteFormatter : Formatter<Byte?>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, Byte? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override Byte? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(Byte?);

            return BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }


    internal class SByteFormatter : Formatter<SByte>
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, SByte value)
        {
            return BinaryUtil.WriteSByte(ref bytes, offset, value);
        }

        public override SByte Deserialize(ref byte[] bytes, int offset)
        {
            return BinaryUtil.ReadSByte(ref bytes, offset);
        }
    }

    internal class NullableSByteFormatter : Formatter<SByte?>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, SByte? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteSByte(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override SByte? Deserialize(ref byte[] bytes, int offset)
        {
            var isNull = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (isNull) return default(SByte?);

            return BinaryUtil.ReadSByte(ref bytes, offset + 1);
        }
    }


}