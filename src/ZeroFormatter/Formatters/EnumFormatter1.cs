using System;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    // Layout: [fixedElementSize]
    // Layout: [isNull:1][fixedElementSize]


    internal class Int16EnumFormatter<T> : Formatter<T>
    {
        static Int16 Identity(Int16 x) { return x; }

        readonly Func<Int16, T> deserializeCast;
        readonly Func<T, Int16> serializeCast;

        public Int16EnumFormatter()
        {
            Func<Int16, Int16> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Int16>), identity.Method) as Func<T, Int16>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Int16, T>), identity.Method) as Func<Int16, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteInt16(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadInt16(ref bytes, offset));
        }
    }

    internal class NullableInt16EnumFormatter<T> : Formatter<T>
    {
        static Int16 Identity(Int16 x) { return x; }

        readonly Func<Int16, T> deserializeCast;
        readonly Func<T, Int16> serializeCast;

        public NullableInt16EnumFormatter()
        {
            Func<Int16, Int16> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Int16>), identity.Method) as Func<T, Int16>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Int16, T>), identity.Method) as Func<Int16, T>;
        }

        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteInt16(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 3);
            }

            return 3;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Int16?);

            return serializeCast(BinaryUtil.ReadInt16(ref bytes, offset + 1));
        }
    }


    internal class Int32EnumFormatter<T> : Formatter<T>
    {
        static Int32 Identity(Int32 x) { return x; }

        readonly Func<Int32, T> deserializeCast;
        readonly Func<T, Int32> serializeCast;

        public Int32EnumFormatter()
        {
            Func<Int32, Int32> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Int32>), identity.Method) as Func<T, Int32>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Int32, T>), identity.Method) as Func<Int32, T>;
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadInt32(ref bytes, offset));
        }
    }

    internal class NullableInt32EnumFormatter<T> : Formatter<T>
    {
        static Int32 Identity(Int32 x) { return x; }

        readonly Func<Int32, T> deserializeCast;
        readonly Func<T, Int32> serializeCast;

        public NullableInt32EnumFormatter()
        {
            Func<Int32, Int32> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Int32>), identity.Method) as Func<T, Int32>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Int32, T>), identity.Method) as Func<Int32, T>;
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Int32?);

            return serializeCast(BinaryUtil.ReadInt32(ref bytes, offset + 1));
        }
    }


    internal class Int64EnumFormatter<T> : Formatter<T>
    {
        static Int64 Identity(Int64 x) { return x; }

        readonly Func<Int64, T> deserializeCast;
        readonly Func<T, Int64> serializeCast;

        public Int64EnumFormatter()
        {
            Func<Int64, Int64> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Int64>), identity.Method) as Func<T, Int64>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Int64, T>), identity.Method) as Func<Int64, T>;
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteInt64(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadInt64(ref bytes, offset));
        }
    }

    internal class NullableInt64EnumFormatter<T> : Formatter<T>
    {
        static Int64 Identity(Int64 x) { return x; }

        readonly Func<Int64, T> deserializeCast;
        readonly Func<T, Int64> serializeCast;

        public NullableInt64EnumFormatter()
        {
            Func<Int64, Int64> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Int64>), identity.Method) as Func<T, Int64>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Int64, T>), identity.Method) as Func<Int64, T>;
        }

        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteInt64(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Int64?);

            return serializeCast(BinaryUtil.ReadInt64(ref bytes, offset + 1));
        }
    }


    internal class UInt16EnumFormatter<T> : Formatter<T>
    {
        static UInt16 Identity(UInt16 x) { return x; }

        readonly Func<UInt16, T> deserializeCast;
        readonly Func<T, UInt16> serializeCast;

        public UInt16EnumFormatter()
        {
            Func<UInt16, UInt16> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, UInt16>), identity.Method) as Func<T, UInt16>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<UInt16, T>), identity.Method) as Func<UInt16, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteUInt16(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadUInt16(ref bytes, offset));
        }
    }

    internal class NullableUInt16EnumFormatter<T> : Formatter<T>
    {
        static UInt16 Identity(UInt16 x) { return x; }

        readonly Func<UInt16, T> deserializeCast;
        readonly Func<T, UInt16> serializeCast;

        public NullableUInt16EnumFormatter()
        {
            Func<UInt16, UInt16> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, UInt16>), identity.Method) as Func<T, UInt16>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<UInt16, T>), identity.Method) as Func<UInt16, T>;
        }

        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteUInt16(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 3);
            }

            return 3;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(UInt16?);

            return serializeCast(BinaryUtil.ReadUInt16(ref bytes, offset + 1));
        }
    }


    internal class UInt32EnumFormatter<T> : Formatter<T>
    {
        static UInt32 Identity(UInt32 x) { return x; }

        readonly Func<UInt32, T> deserializeCast;
        readonly Func<T, UInt32> serializeCast;

        public UInt32EnumFormatter()
        {
            Func<UInt32, UInt32> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, UInt32>), identity.Method) as Func<T, UInt32>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<UInt32, T>), identity.Method) as Func<UInt32, T>;
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteUInt32(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadUInt32(ref bytes, offset));
        }
    }

    internal class NullableUInt32EnumFormatter<T> : Formatter<T>
    {
        static UInt32 Identity(UInt32 x) { return x; }

        readonly Func<UInt32, T> deserializeCast;
        readonly Func<T, UInt32> serializeCast;

        public NullableUInt32EnumFormatter()
        {
            Func<UInt32, UInt32> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, UInt32>), identity.Method) as Func<T, UInt32>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<UInt32, T>), identity.Method) as Func<UInt32, T>;
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteUInt32(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(UInt32?);

            return serializeCast(BinaryUtil.ReadUInt32(ref bytes, offset + 1));
        }
    }


    internal class UInt64EnumFormatter<T> : Formatter<T>
    {
        static UInt64 Identity(UInt64 x) { return x; }

        readonly Func<UInt64, T> deserializeCast;
        readonly Func<T, UInt64> serializeCast;

        public UInt64EnumFormatter()
        {
            Func<UInt64, UInt64> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, UInt64>), identity.Method) as Func<T, UInt64>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<UInt64, T>), identity.Method) as Func<UInt64, T>;
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteUInt64(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadUInt64(ref bytes, offset));
        }
    }

    internal class NullableUInt64EnumFormatter<T> : Formatter<T>
    {
        static UInt64 Identity(UInt64 x) { return x; }

        readonly Func<UInt64, T> deserializeCast;
        readonly Func<T, UInt64> serializeCast;

        public NullableUInt64EnumFormatter()
        {
            Func<UInt64, UInt64> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, UInt64>), identity.Method) as Func<T, UInt64>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<UInt64, T>), identity.Method) as Func<UInt64, T>;
        }

        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteUInt64(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(UInt64?);

            return serializeCast(BinaryUtil.ReadUInt64(ref bytes, offset + 1));
        }
    }


    internal class SingleEnumFormatter<T> : Formatter<T>
    {
        static Single Identity(Single x) { return x; }

        readonly Func<Single, T> deserializeCast;
        readonly Func<T, Single> serializeCast;

        public SingleEnumFormatter()
        {
            Func<Single, Single> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Single>), identity.Method) as Func<T, Single>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Single, T>), identity.Method) as Func<Single, T>;
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteSingle(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadSingle(ref bytes, offset));
        }
    }

    internal class NullableSingleEnumFormatter<T> : Formatter<T>
    {
        static Single Identity(Single x) { return x; }

        readonly Func<Single, T> deserializeCast;
        readonly Func<T, Single> serializeCast;

        public NullableSingleEnumFormatter()
        {
            Func<Single, Single> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Single>), identity.Method) as Func<T, Single>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Single, T>), identity.Method) as Func<Single, T>;
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteSingle(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Single?);

            return serializeCast(BinaryUtil.ReadSingle(ref bytes, offset + 1));
        }
    }


    internal class DoubleEnumFormatter<T> : Formatter<T>
    {
        static Double Identity(Double x) { return x; }

        readonly Func<Double, T> deserializeCast;
        readonly Func<T, Double> serializeCast;

        public DoubleEnumFormatter()
        {
            Func<Double, Double> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Double>), identity.Method) as Func<T, Double>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Double, T>), identity.Method) as Func<Double, T>;
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteDouble(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadDouble(ref bytes, offset));
        }
    }

    internal class NullableDoubleEnumFormatter<T> : Formatter<T>
    {
        static Double Identity(Double x) { return x; }

        readonly Func<Double, T> deserializeCast;
        readonly Func<T, Double> serializeCast;

        public NullableDoubleEnumFormatter()
        {
            Func<Double, Double> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Double>), identity.Method) as Func<T, Double>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Double, T>), identity.Method) as Func<Double, T>;
        }

        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteDouble(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Double?);

            return serializeCast(BinaryUtil.ReadDouble(ref bytes, offset + 1));
        }
    }


    internal class BooleanEnumFormatter<T> : Formatter<T>
    {
        static Boolean Identity(Boolean x) { return x; }

        readonly Func<Boolean, T> deserializeCast;
        readonly Func<T, Boolean> serializeCast;

        public BooleanEnumFormatter()
        {
            Func<Boolean, Boolean> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Boolean>), identity.Method) as Func<T, Boolean>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Boolean, T>), identity.Method) as Func<Boolean, T>;
        }

        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteBoolean(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadBoolean(ref bytes, offset));
        }
    }

    internal class NullableBooleanEnumFormatter<T> : Formatter<T>
    {
        static Boolean Identity(Boolean x) { return x; }

        readonly Func<Boolean, T> deserializeCast;
        readonly Func<T, Boolean> serializeCast;

        public NullableBooleanEnumFormatter()
        {
            Func<Boolean, Boolean> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Boolean>), identity.Method) as Func<T, Boolean>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Boolean, T>), identity.Method) as Func<Boolean, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteBoolean(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Boolean?);

            return serializeCast(BinaryUtil.ReadBoolean(ref bytes, offset + 1));
        }
    }


    internal class ByteEnumFormatter<T> : Formatter<T>
    {
        static Byte Identity(Byte x) { return x; }

        readonly Func<Byte, T> deserializeCast;
        readonly Func<T, Byte> serializeCast;

        public ByteEnumFormatter()
        {
            Func<Byte, Byte> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Byte>), identity.Method) as Func<T, Byte>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Byte, T>), identity.Method) as Func<Byte, T>;
        }

        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadByte(ref bytes, offset));
        }
    }

    internal class NullableByteEnumFormatter<T> : Formatter<T>
    {
        static Byte Identity(Byte x) { return x; }

        readonly Func<Byte, T> deserializeCast;
        readonly Func<T, Byte> serializeCast;

        public NullableByteEnumFormatter()
        {
            Func<Byte, Byte> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Byte>), identity.Method) as Func<T, Byte>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Byte, T>), identity.Method) as Func<Byte, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Byte?);

            return serializeCast(BinaryUtil.ReadByte(ref bytes, offset + 1));
        }
    }


    internal class SByteEnumFormatter<T> : Formatter<T>
    {
        static SByte Identity(SByte x) { return x; }

        readonly Func<SByte, T> deserializeCast;
        readonly Func<T, SByte> serializeCast;

        public SByteEnumFormatter()
        {
            Func<SByte, SByte> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, SByte>), identity.Method) as Func<T, SByte>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<SByte, T>), identity.Method) as Func<SByte, T>;
        }

        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteSByte(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadSByte(ref bytes, offset));
        }
    }

    internal class NullableSByteEnumFormatter<T> : Formatter<T>
    {
        static SByte Identity(SByte x) { return x; }

        readonly Func<SByte, T> deserializeCast;
        readonly Func<T, SByte> serializeCast;

        public NullableSByteEnumFormatter()
        {
            Func<SByte, SByte> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, SByte>), identity.Method) as Func<T, SByte>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<SByte, T>), identity.Method) as Func<SByte, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteSByte(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(SByte?);

            return serializeCast(BinaryUtil.ReadSByte(ref bytes, offset + 1));
        }
    }


    internal class DecimalEnumFormatter<T> : Formatter<T>
    {
        static Decimal Identity(Decimal x) { return x; }

        readonly Func<Decimal, T> deserializeCast;
        readonly Func<T, Decimal> serializeCast;

        public DecimalEnumFormatter()
        {
            Func<Decimal, Decimal> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Decimal>), identity.Method) as Func<T, Decimal>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Decimal, T>), identity.Method) as Func<Decimal, T>;
        }

        public override int? GetLength()
        {
            return 16;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteDecimal(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadDecimal(ref bytes, offset));
        }
    }

    internal class NullableDecimalEnumFormatter<T> : Formatter<T>
    {
        static Decimal Identity(Decimal x) { return x; }

        readonly Func<Decimal, T> deserializeCast;
        readonly Func<T, Decimal> serializeCast;

        public NullableDecimalEnumFormatter()
        {
            Func<Decimal, Decimal> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, Decimal>), identity.Method) as Func<T, Decimal>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<Decimal, T>), identity.Method) as Func<Decimal, T>;
        }

        public override int? GetLength()
        {
            return 17;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteDecimal(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 17);
            }

            return 17;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(Decimal?);

            return serializeCast(BinaryUtil.ReadDecimal(ref bytes, offset + 1));
        }
    }


    internal class TimeSpanEnumFormatter<T> : Formatter<T>
    {
        static TimeSpan Identity(TimeSpan x) { return x; }

        readonly Func<TimeSpan, T> deserializeCast;
        readonly Func<T, TimeSpan> serializeCast;

        public TimeSpanEnumFormatter()
        {
            Func<TimeSpan, TimeSpan> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, TimeSpan>), identity.Method) as Func<T, TimeSpan>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<TimeSpan, T>), identity.Method) as Func<TimeSpan, T>;
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteTimeSpan(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadTimeSpan(ref bytes, offset));
        }
    }

    internal class NullableTimeSpanEnumFormatter<T> : Formatter<T>
    {
        static TimeSpan Identity(TimeSpan x) { return x; }

        readonly Func<TimeSpan, T> deserializeCast;
        readonly Func<T, TimeSpan> serializeCast;

        public NullableTimeSpanEnumFormatter()
        {
            Func<TimeSpan, TimeSpan> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, TimeSpan>), identity.Method) as Func<T, TimeSpan>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<TimeSpan, T>), identity.Method) as Func<TimeSpan, T>;
        }

        public override int? GetLength()
        {
            return 13;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteTimeSpan(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 13);
            }

            return 13;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(TimeSpan?);

            return serializeCast(BinaryUtil.ReadTimeSpan(ref bytes, offset + 1));
        }
    }


    internal class DateTimeEnumFormatter<T> : Formatter<T>
    {
        static DateTime Identity(DateTime x) { return x; }

        readonly Func<DateTime, T> deserializeCast;
        readonly Func<T, DateTime> serializeCast;

        public DateTimeEnumFormatter()
        {
            Func<DateTime, DateTime> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, DateTime>), identity.Method) as Func<T, DateTime>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<DateTime, T>), identity.Method) as Func<DateTime, T>;
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteDateTime(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadDateTime(ref bytes, offset));
        }
    }

    internal class NullableDateTimeEnumFormatter<T> : Formatter<T>
    {
        static DateTime Identity(DateTime x) { return x; }

        readonly Func<DateTime, T> deserializeCast;
        readonly Func<T, DateTime> serializeCast;

        public NullableDateTimeEnumFormatter()
        {
            Func<DateTime, DateTime> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, DateTime>), identity.Method) as Func<T, DateTime>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<DateTime, T>), identity.Method) as Func<DateTime, T>;
        }

        public override int? GetLength()
        {
            return 13;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteDateTime(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 13);
            }

            return 13;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(DateTime?);

            return serializeCast(BinaryUtil.ReadDateTime(ref bytes, offset + 1));
        }
    }


    internal class DateTimeOffsetEnumFormatter<T> : Formatter<T>
    {
        static DateTimeOffset Identity(DateTimeOffset x) { return x; }

        readonly Func<DateTimeOffset, T> deserializeCast;
        readonly Func<T, DateTimeOffset> serializeCast;

        public DateTimeOffsetEnumFormatter()
        {
            Func<DateTimeOffset, DateTimeOffset> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, DateTimeOffset>), identity.Method) as Func<T, DateTimeOffset>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<DateTimeOffset, T>), identity.Method) as Func<DateTimeOffset, T>;
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteDateTimeOffset(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            return deserializeCast(BinaryUtil.ReadDateTimeOffset(ref bytes, offset));
        }
    }

    internal class NullableDateTimeOffsetEnumFormatter<T> : Formatter<T>
    {
        static DateTimeOffset Identity(DateTimeOffset x) { return x; }

        readonly Func<DateTimeOffset, T> deserializeCast;
        readonly Func<T, DateTimeOffset> serializeCast;

        public NullableDateTimeOffsetEnumFormatter()
        {
            Func<DateTimeOffset, DateTimeOffset> identity = Identity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, DateTimeOffset>), identity.Method) as Func<T, DateTimeOffset>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<DateTimeOffset, T>), identity.Method) as Func<DateTimeOffset, T>;
        }

        public override int? GetLength()
        {
            return 13;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value != null);
            if (value != null)
            {
                BinaryUtil.WriteDateTimeOffset(ref bytes, offset + 1, serializeCast(value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 13);
            }

            return 13;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(DateTimeOffset?);

            return serializeCast(BinaryUtil.ReadDateTimeOffset(ref bytes, offset + 1));
        }
    }


}