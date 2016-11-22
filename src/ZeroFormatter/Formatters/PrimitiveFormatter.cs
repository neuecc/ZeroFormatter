using System;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    // Layout: [fixedElementSize]
    // Layout: [hasValue:1][fixedElementSize]


    internal class Int16Formatter<TTypeResolver> : Formatter<TTypeResolver, Int16>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableInt16Formatter<TTypeResolver> : Formatter<TTypeResolver, Int16?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class Int32Formatter<TTypeResolver> : Formatter<TTypeResolver, Int32>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableInt32Formatter<TTypeResolver> : Formatter<TTypeResolver, Int32?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class Int64Formatter<TTypeResolver> : Formatter<TTypeResolver, Int64>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableInt64Formatter<TTypeResolver> : Formatter<TTypeResolver, Int64?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class UInt16Formatter<TTypeResolver> : Formatter<TTypeResolver, UInt16>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableUInt16Formatter<TTypeResolver> : Formatter<TTypeResolver, UInt16?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class UInt32Formatter<TTypeResolver> : Formatter<TTypeResolver, UInt32>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableUInt32Formatter<TTypeResolver> : Formatter<TTypeResolver, UInt32?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class UInt64Formatter<TTypeResolver> : Formatter<TTypeResolver, UInt64>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableUInt64Formatter<TTypeResolver> : Formatter<TTypeResolver, UInt64?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class SingleFormatter<TTypeResolver> : Formatter<TTypeResolver, Single>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableSingleFormatter<TTypeResolver> : Formatter<TTypeResolver, Single?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class DoubleFormatter<TTypeResolver> : Formatter<TTypeResolver, Double>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableDoubleFormatter<TTypeResolver> : Formatter<TTypeResolver, Double?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class BooleanFormatter<TTypeResolver> : Formatter<TTypeResolver, Boolean>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableBooleanFormatter<TTypeResolver> : Formatter<TTypeResolver, Boolean?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class ByteFormatter<TTypeResolver> : Formatter<TTypeResolver, Byte>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableByteFormatter<TTypeResolver> : Formatter<TTypeResolver, Byte?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class SByteFormatter<TTypeResolver> : Formatter<TTypeResolver, SByte>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableSByteFormatter<TTypeResolver> : Formatter<TTypeResolver, SByte?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class CharFormatter<TTypeResolver> : Formatter<TTypeResolver, Char>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableCharFormatter<TTypeResolver> : Formatter<TTypeResolver, Char?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class DecimalFormatter<TTypeResolver> : Formatter<TTypeResolver, Decimal>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableDecimalFormatter<TTypeResolver> : Formatter<TTypeResolver, Decimal?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class GuidFormatter<TTypeResolver> : Formatter<TTypeResolver, Guid>
        where TTypeResolver : ITypeResolver, new()
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

        public override int Serialize(ref byte[] bytes, int offset, Guid value)
        {
            return BinaryUtil.WriteGuid(ref bytes, offset, value);
        }

        public override Guid Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 16;
            return BinaryUtil.ReadGuid(ref bytes, offset);
        }
    }

    internal class NullableGuidFormatter<TTypeResolver> : Formatter<TTypeResolver, Guid?>
        where TTypeResolver : ITypeResolver, new()
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

        public override int Serialize(ref byte[] bytes, int offset, Guid? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 17);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteGuid(ref bytes, offset + 1, value.Value);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 17;
        }

        public override Guid? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 17;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Guid?);

            return BinaryUtil.ReadGuid(ref bytes, offset + 1);
        }
    }


    internal class TimeSpanFormatter<TTypeResolver> : Formatter<TTypeResolver, TimeSpan>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableTimeSpanFormatter<TTypeResolver> : Formatter<TTypeResolver, TimeSpan?>
        where TTypeResolver : ITypeResolver, new()
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


    internal class DateTimeFormatter<TTypeResolver> : Formatter<TTypeResolver, DateTime>
        where TTypeResolver : ITypeResolver, new()
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

    internal class NullableDateTimeFormatter<TTypeResolver> : Formatter<TTypeResolver, DateTime?>
        where TTypeResolver : ITypeResolver, new()
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


}