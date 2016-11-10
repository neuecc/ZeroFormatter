using System;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Layout: [fixedElementSize]
    // Layout: [hasValue:1][fixedElementSize]


    internal class Int16Formatter : Formatter<Int16>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int16 value)
        {
            return BinaryUtil.WriteInt16(ref bytes, offset, value);
        }

        public override Int16 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            return BinaryUtil.ReadInt16(ref bytes, offset);
        }
    }

    internal class NullableInt16Formatter : Formatter<Int16?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int16? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 3);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteInt16(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 3;
        }

        public override Int16? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 3;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Int16?);

            return BinaryUtil.ReadInt16(ref bytes, offset + 1);
        }
    }


    internal class Int32Formatter : Formatter<Int32>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int32 value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, value);
        }

        public override Int32 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    internal class NullableInt32Formatter : Formatter<Int32?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int32? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 5);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteInt32(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 5;
        }

        public override Int32? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Int32?);

            return BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }


    internal class Int64Formatter : Formatter<Int64>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int64 value)
        {
            return BinaryUtil.WriteInt64(ref bytes, offset, value);
        }

        public override Int64 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 8;
            return BinaryUtil.ReadInt64(ref bytes, offset);
        }
    }

    internal class NullableInt64Formatter : Formatter<Int64?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int64? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 9);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteInt64(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 9;
        }

        public override Int64? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 9;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Int64?);

            return BinaryUtil.ReadInt64(ref bytes, offset + 1);
        }
    }


    internal class UInt16Formatter : Formatter<UInt16>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt16 value)
        {
            return BinaryUtil.WriteUInt16(ref bytes, offset, value);
        }

        public override UInt16 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            return BinaryUtil.ReadUInt16(ref bytes, offset);
        }
    }

    internal class NullableUInt16Formatter : Formatter<UInt16?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt16? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 3);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteUInt16(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 3;
        }

        public override UInt16? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 3;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(UInt16?);

            return BinaryUtil.ReadUInt16(ref bytes, offset + 1);
        }
    }


    internal class UInt32Formatter : Formatter<UInt32>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt32 value)
        {
            return BinaryUtil.WriteUInt32(ref bytes, offset, value);
        }

        public override UInt32 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return BinaryUtil.ReadUInt32(ref bytes, offset);
        }
    }

    internal class NullableUInt32Formatter : Formatter<UInt32?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt32? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 5);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteUInt32(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 5;
        }

        public override UInt32? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(UInt32?);

            return BinaryUtil.ReadUInt32(ref bytes, offset + 1);
        }
    }


    internal class UInt64Formatter : Formatter<UInt64>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt64 value)
        {
            return BinaryUtil.WriteUInt64(ref bytes, offset, value);
        }

        public override UInt64 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 8;
            return BinaryUtil.ReadUInt64(ref bytes, offset);
        }
    }

    internal class NullableUInt64Formatter : Formatter<UInt64?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt64? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 9);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteUInt64(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 9;
        }

        public override UInt64? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 9;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(UInt64?);

            return BinaryUtil.ReadUInt64(ref bytes, offset + 1);
        }
    }


    internal class SingleFormatter : Formatter<Single>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, Single value)
        {
            return BinaryUtil.WriteSingle(ref bytes, offset, value);
        }

        public override Single Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return BinaryUtil.ReadSingle(ref bytes, offset);
        }
    }

    internal class NullableSingleFormatter : Formatter<Single?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, Single? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 5);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteSingle(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 5;
        }

        public override Single? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Single?);

            return BinaryUtil.ReadSingle(ref bytes, offset + 1);
        }
    }


    internal class DoubleFormatter : Formatter<Double>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, Double value)
        {
            return BinaryUtil.WriteDouble(ref bytes, offset, value);
        }

        public override Double Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 8;
            return BinaryUtil.ReadDouble(ref bytes, offset);
        }
    }

    internal class NullableDoubleFormatter : Formatter<Double?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, Double? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 9);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteDouble(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 9;
        }

        public override Double? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 9;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Double?);

            return BinaryUtil.ReadDouble(ref bytes, offset + 1);
        }
    }


    internal class BooleanFormatter : Formatter<Boolean>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, Boolean value)
        {
            return BinaryUtil.WriteBoolean(ref bytes, offset, value);
        }

        public override Boolean Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return BinaryUtil.ReadBoolean(ref bytes, offset);
        }
    }

    internal class NullableBooleanFormatter : Formatter<Boolean?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, Boolean? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 2);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteBoolean(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 2;
        }

        public override Boolean? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Boolean?);

            return BinaryUtil.ReadBoolean(ref bytes, offset + 1);
        }
    }


    internal class ByteFormatter : Formatter<Byte>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, Byte value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, value);
        }

        public override Byte Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return BinaryUtil.ReadByte(ref bytes, offset);
        }
    }

    internal class NullableByteFormatter : Formatter<Byte?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, Byte? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 2);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteByte(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 2;
        }

        public override Byte? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Byte?);

            return BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }


    internal class SByteFormatter : Formatter<SByte>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, SByte value)
        {
            return BinaryUtil.WriteSByte(ref bytes, offset, value);
        }

        public override SByte Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return BinaryUtil.ReadSByte(ref bytes, offset);
        }
    }

    internal class NullableSByteFormatter : Formatter<SByte?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, SByte? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 2);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteSByte(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 2;
        }

        public override SByte? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(SByte?);

            return BinaryUtil.ReadSByte(ref bytes, offset + 1);
        }
    }


    internal class CharFormatter : Formatter<Char>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, Char value)
        {
            return BinaryUtil.WriteChar(ref bytes, offset, value);
        }

        public override Char Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            return BinaryUtil.ReadChar(ref bytes, offset);
        }
    }

    internal class NullableCharFormatter : Formatter<Char?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, Char? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 3);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteChar(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 3;
        }

        public override Char? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 3;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Char?);

            return BinaryUtil.ReadChar(ref bytes, offset + 1);
        }
    }


    internal class DecimalFormatter : Formatter<Decimal>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 16;
        }

        public override int Serialize(ref byte[] bytes, int offset, Decimal value)
        {
            return BinaryUtil.WriteDecimal(ref bytes, offset, value);
        }

        public override Decimal Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 16;
            return BinaryUtil.ReadDecimal(ref bytes, offset);
        }
    }

    internal class NullableDecimalFormatter : Formatter<Decimal?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 17;
        }

        public override int Serialize(ref byte[] bytes, int offset, Decimal? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 17);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteDecimal(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 17;
        }

        public override Decimal? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 17;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Decimal?);

            return BinaryUtil.ReadDecimal(ref bytes, offset + 1);
        }
    }


    internal class TimeSpanFormatter : Formatter<TimeSpan>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, TimeSpan value)
        {
            return BinaryUtil.WriteTimeSpan(ref bytes, offset, value);
        }

        public override TimeSpan Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 12;
            return BinaryUtil.ReadTimeSpan(ref bytes, offset);
        }
    }

    internal class NullableTimeSpanFormatter : Formatter<TimeSpan?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 13;
        }

        public override int Serialize(ref byte[] bytes, int offset, TimeSpan? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 13);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteTimeSpan(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 13;
        }

        public override TimeSpan? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 13;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(TimeSpan?);

            return BinaryUtil.ReadTimeSpan(ref bytes, offset + 1);
        }
    }


    internal class DateTimeFormatter : Formatter<DateTime>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, DateTime value)
        {
            return BinaryUtil.WriteDateTime(ref bytes, offset, value);
        }

        public override DateTime Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 12;
            return BinaryUtil.ReadDateTime(ref bytes, offset);
        }
    }

    internal class NullableDateTimeFormatter : Formatter<DateTime?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 13;
        }

        public override int Serialize(ref byte[] bytes, int offset, DateTime? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 13);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteDateTime(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 13;
        }

        public override DateTime? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 13;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(DateTime?);

            return BinaryUtil.ReadDateTime(ref bytes, offset + 1);
        }
    }


    internal class DateTimeOffsetFormatter : Formatter<DateTimeOffset>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, DateTimeOffset value)
        {
            return BinaryUtil.WriteDateTimeOffset(ref bytes, offset, value);
        }

        public override DateTimeOffset Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 12;
            return BinaryUtil.ReadDateTimeOffset(ref bytes, offset);
        }
    }

    internal class NullableDateTimeOffsetFormatter : Formatter<DateTimeOffset?>
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 13;
        }

        public override int Serialize(ref byte[] bytes, int offset, DateTimeOffset? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 13);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteDateTimeOffset(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 13;
        }

        public override DateTimeOffset? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 13;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(DateTimeOffset?);

            return BinaryUtil.ReadDateTimeOffset(ref bytes, offset + 1);
        }
    }


}