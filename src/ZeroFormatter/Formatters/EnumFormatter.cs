using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    internal class EnumFormatter
    {
    }

    internal class ByteEnumFormatter<T> : Formatter<T>
    {
        static byte ByteIdentity(byte x) { return x; }

        readonly Func<byte, T> deserializeCast;
        readonly Func<T, byte> serializeCast;

        public ByteEnumFormatter()
        {
            Func<byte, byte> identity = ByteIdentity;
            this.serializeCast = Delegate.CreateDelegate(typeof(Func<T, byte>), identity.Method) as Func<T, byte>;
            this.deserializeCast = Delegate.CreateDelegate(typeof(Func<byte, T>), identity.Method) as Func<byte, T>;
        }

        public override int? GetLength()
        {
            return 2;
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

    internal class EnumFormatter<T> : Formatter<T>
    {
        static byte ByteIdentity(byte x) { return x; }
        static sbyte SByteIdentity(sbyte x) { return x; }
        static short ShortIdentity(short x) { return x; }
        static ushort UShortIdentity(ushort x) { return x; }
        static uint UIntIdentity(uint x) { return x; }
        static ulong ULongIdentity(ulong x) { return x; }
        static long LongIdentity(long x) { return x; }
        static int IntIdentity(int x) { return x; }

        public EnumFormatter()
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new ArgumentException("Type is not enum:" + type.Name);

            var underlyingType = Enum.GetUnderlyingType(type);

            switch (Type.GetTypeCode(underlyingType))
            {
                case TypeCode.SByte:
                    {
                        Func<sbyte, sbyte> identity = SByteIdentity;
                        var cast = Delegate.CreateDelegate(typeof(Func<sbyte, T>), identity.Method) as Func<sbyte, T>;
                    }
                    break;
                case TypeCode.Byte:
                    {
                        Func<Byte, int> getHash = ByteGetHashCode;
                        Func<Byte, Byte, bool> eq = ByteEquals;
                        GetHashCodeDelegate = Delegate.CreateDelegate(typeof(Func<T, int>), getHash.Method) as Func<T, int>;
                        EqualsDelegate = Delegate.CreateDelegate(typeof(Func<T, T, bool>), eq.Method) as Func<T, T, bool>;
                    }
                    break;
                case TypeCode.Int16:
                    {
                        Func<Int16, int> getHash = ShortGetHashCode;
                        Func<Int16, Int16, bool> eq = ShortEquals;
                        GetHashCodeDelegate = Delegate.CreateDelegate(typeof(Func<T, int>), getHash.Method) as Func<T, int>;
                        EqualsDelegate = Delegate.CreateDelegate(typeof(Func<T, T, bool>), eq.Method) as Func<T, T, bool>;
                    }
                    break;
                case TypeCode.UInt16:
                    {
                        Func<UInt16, int> getHash = UShortGetHashCode;
                        Func<UInt16, UInt16, bool> eq = UShortEquals;
                        GetHashCodeDelegate = Delegate.CreateDelegate(typeof(Func<T, int>), getHash.Method) as Func<T, int>;
                        EqualsDelegate = Delegate.CreateDelegate(typeof(Func<T, T, bool>), eq.Method) as Func<T, T, bool>;
                    }
                    break;
                case TypeCode.Int32:
                    {
                        Func<int, int> getHash = IntGetHashCode;
                        Func<int, int, bool> eq = IntEquals;
                        GetHashCodeDelegate = Delegate.CreateDelegate(typeof(Func<T, int>), getHash.Method) as Func<T, int>;
                        EqualsDelegate = Delegate.CreateDelegate(typeof(Func<T, T, bool>), eq.Method) as Func<T, T, bool>;
                    }
                    break;
                case TypeCode.UInt32:
                    {
                        Func<UInt32, int> getHash = UIntGetHashCode;
                        Func<UInt32, UInt32, bool> eq = UIntEquals;
                        GetHashCodeDelegate = Delegate.CreateDelegate(typeof(Func<T, int>), getHash.Method) as Func<T, int>;
                        EqualsDelegate = Delegate.CreateDelegate(typeof(Func<T, T, bool>), eq.Method) as Func<T, T, bool>;
                    }
                    break;
                case TypeCode.Int64:
                    {
                        Func<Int64, int> getHash = LongGetHashCode;
                        Func<Int64, Int64, bool> eq = LongEquals;
                        GetHashCodeDelegate = Delegate.CreateDelegate(typeof(Func<T, int>), getHash.Method) as Func<T, int>;
                        EqualsDelegate = Delegate.CreateDelegate(typeof(Func<T, T, bool>), eq.Method) as Func<T, T, bool>;
                    }
                    break;
                case TypeCode.UInt64:
                    {
                        Func<UInt64, int> getHash = ULongGetHashCode;
                        Func<UInt64, UInt64, bool> eq = ULongEquals;
                        GetHashCodeDelegate = Delegate.CreateDelegate(typeof(Func<T, int>), getHash.Method) as Func<T, int>;
                        EqualsDelegate = Delegate.CreateDelegate(typeof(Func<T, T, bool>), eq.Method) as Func<T, T, bool>;
                    }
                    break;
                default:
                    throw new NotSupportedException("The underlying type is invalid.");
            }
        }

        public override int? GetLength()
        {
            throw new NotImplementedException();
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            throw new NotImplementedException();
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var i = BinaryUtil.ReadInt32(ref bytes, offset);
        }

    }
}
