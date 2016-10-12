using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    // bool, byte, sbyte, float, double, short, ushort, int uint, long, ulong) + Nullable
    [TestClass]
    public class FormatterTest
    {
        [TestMethod]
        public void Bool()
        {
            {
                var r = Serializer.Serialize(true);
                Serializer.Deserialize<bool>(r).IsTrue();
            }
            {
                var r = Serializer.Serialize(false);
                Serializer.Deserialize<bool>(r).IsFalse();
            }
            {
                var r = Serializer.Serialize<bool?>(null);
                Serializer.Deserialize<bool?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<bool?>(true);
                Serializer.Deserialize<bool?>(r).Value.IsTrue();
            }
        }

        [TestMethod]
        public void Byte()
        {
            {
                var r = Serializer.Serialize((byte)123);
                Serializer.Deserialize<byte>(r).Is((byte)123);
            }
            {
                var r = Serializer.Serialize<byte?>(null);
                Serializer.Deserialize<byte?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<byte?>(234);
                Serializer.Deserialize<byte?>(r).Value.Is((byte)234);
            }
        }

        [TestMethod]
        public void SByte()
        {
            {
                var r = Serializer.Serialize((sbyte)123);
                Serializer.Deserialize<sbyte>(r).Is((sbyte)123);
            }
            {
                var r = Serializer.Serialize<sbyte?>(null);
                Serializer.Deserialize<sbyte?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<sbyte?>(111);
                Serializer.Deserialize<sbyte?>(r).Value.Is((sbyte)111);
            }
        }

        [TestMethod]
        public void Float()
        {
            {
                var r = Serializer.Serialize(123.445f);
                Serializer.Deserialize<float>(r).Is(123.445f);
            }
            {
                var r = Serializer.Serialize<float?>(null);
                Serializer.Deserialize<float?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<float?>(4444.444f);
                Serializer.Deserialize<float?>(r).Value.Is(4444.444f);
            }
        }

        [TestMethod]
        public void Double()
        {
            {
                var r = Serializer.Serialize(123.445);
                Serializer.Deserialize<double>(r).Is(123.445);
            }
            {
                var r = Serializer.Serialize<double?>(null);
                Serializer.Deserialize<double?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<double?>(4444.444);
                Serializer.Deserialize<double?>(r).Value.Is(4444.444);
            }
        }

        [TestMethod]
        public void Short()
        {
            {
                var r = Serializer.Serialize((short)123);
                Serializer.Deserialize<short>(r).Is((short)123);
            }
            {
                var r = Serializer.Serialize<short?>(null);
                Serializer.Deserialize<short?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<short?>((short)44);
                Serializer.Deserialize<short?>(r).Value.Is((short)44);
            }
        }

        [TestMethod]
        public void UShort()
        {
            {
                var r = Serializer.Serialize(ushort.MaxValue);
                Serializer.Deserialize<ushort>(r).Is((ushort)ushort.MaxValue);
            }
            {
                var r = Serializer.Serialize<ushort?>(null);
                Serializer.Deserialize<ushort?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<ushort?>(ushort.MinValue);
                Serializer.Deserialize<ushort?>(r).Value.Is(ushort.MinValue);
            }
        }

        [TestMethod]
        public void Int()
        {
            {
                var r = Serializer.Serialize(int.MaxValue);
                Serializer.Deserialize<int>(r).Is((int)int.MaxValue);
            }
            {
                var r = Serializer.Serialize<int?>(null);
                Serializer.Deserialize<int?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<int?>(int.MinValue);
                Serializer.Deserialize<int?>(r).Value.Is(int.MinValue);
            }
        }

        [TestMethod]
        public void UInt()
        {
            {
                var r = Serializer.Serialize(uint.MaxValue);
                Serializer.Deserialize<uint>(r).Is((uint)uint.MaxValue);
            }
            {
                var r = Serializer.Serialize<uint?>(null);
                Serializer.Deserialize<uint?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<uint?>(uint.MinValue);
                Serializer.Deserialize<uint?>(r).Value.Is(uint.MinValue);
            }
        }

        [TestMethod]
        public void Long()
        {
            {
                var r = Serializer.Serialize(long.MaxValue);
                Serializer.Deserialize<long>(r).Is((long)long.MaxValue);
            }
            {
                var r = Serializer.Serialize<long?>(null);
                Serializer.Deserialize<long?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<long?>(long.MinValue);
                Serializer.Deserialize<long?>(r).Value.Is(long.MinValue);
            }
        }

        [TestMethod]
        public void ULong()
        {
            {
                var r = Serializer.Serialize(ulong.MaxValue);
                Serializer.Deserialize<ulong>(r).Is((ulong)ulong.MaxValue);
            }
            {
                var r = Serializer.Serialize<ulong?>(null);
                Serializer.Deserialize<ulong?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<ulong?>(ulong.MinValue);
                Serializer.Deserialize<ulong?>(r).Value.Is(ulong.MinValue);
            }
        }

        [TestMethod]
        public void String()
        {
            {
                var r = Serializer.Serialize("あいうえお");
                Serializer.Deserialize<string>(r).Is("あいうえお");
            }
            {
                var r = Serializer.Serialize<string>(null);
                Serializer.Deserialize<string>(r).IsNull();
            }
        }

        [TestMethod]
        public void Char()
        {
            {
                var r = Serializer.Serialize('あ');
                Serializer.Deserialize<char>(r).Is('あ');
            }
            {
                var r = Serializer.Serialize('z');
                Serializer.Deserialize<char>(r).Is('z');
            }

            {
                var r = Serializer.Serialize<char?>(null);
                Serializer.Deserialize<char?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<char?>('花');
                Serializer.Deserialize<char?>(r).Value.Is('花');
            }
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Decimal()
        {
            {
                var r = Serializer.Serialize<decimal>(1000M);
                Serializer.Deserialize<decimal>(r).Is(1000M);
            }

            {
                var r = Serializer.Serialize<decimal?>(null);
                Serializer.Deserialize<decimal?>(r).IsNull();
            }

            {
                var r = Serializer.Serialize<decimal?>(decimal.MaxValue);
                Serializer.Deserialize<decimal?>(r).Is(decimal.MaxValue);
            }
        }

        [TestMethod]
        public void TimeSpan()
        {
            {
                var r = Serializer.Serialize<TimeSpan>(new System.TimeSpan(12, 12, 43, 54));
                Serializer.Deserialize<TimeSpan>(r).Is(new System.TimeSpan(12, 12, 43, 54));
            }

            {
                var r = Serializer.Serialize<TimeSpan?>(null);
                Serializer.Deserialize<TimeSpan?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<TimeSpan?>(System.TimeSpan.Zero);
                Serializer.Deserialize<TimeSpan?>(r).Is(System.TimeSpan.Zero);
            }
        }

        [TestMethod]
        public void Datetime()
        {
            var now = DateTime.Now.ToUniversalTime();
            {
                var r = Serializer.Serialize<DateTime>(now);
                Serializer.Deserialize<DateTime>(r).ToString("yyyy-MM-dd HH:mm:ss fff").Is(now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }

            {
                var r = Serializer.Serialize<DateTime?>(null);
                Serializer.Deserialize<DateTime?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<DateTime?>(now);
                Serializer.Deserialize<DateTime?>(r).Is(now);
            }
        }

        [TestMethod]
        public void DatetimeOffset()
        {
            var now = DateTimeOffset.Now.ToUniversalTime();
            {
                var r = Serializer.Serialize<DateTimeOffset>(now);
                Serializer.Deserialize<DateTimeOffset>(r).ToString("yyyy-MM-dd HH:mm:ss fff").Is(now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }

            {
                var r = Serializer.Serialize<DateTimeOffset?>(null);
                Serializer.Deserialize<DateTimeOffset?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<DateTimeOffset?>(now);
                Serializer.Deserialize<DateTimeOffset?>(r).Is(now);
            }
        }

        [TestMethod]
        public void ByteArray()
        {
            {
                var bytes = new byte[] { 123, 31, 5, 64, 26, 2, 47, 2, 43 };
                var r = Serializer.Serialize(bytes);
                Serializer.Deserialize<byte[]>(r).Is(bytes);
            }
            {
                var bytes = new byte[0] { };
                var r = Serializer.Serialize(bytes);
                Serializer.Deserialize<byte[]>(r).Is(bytes);
            }
            {
                var r = Serializer.Serialize<byte[]>(null);
                Serializer.Deserialize<byte[]>(r).IsNull();
            }
        }

        [TestMethod]
        public void EnumFormatTest()
        {
            {
                var r = Serializer.Serialize<IntEnum>(IntEnum.Apple);
                Serializer.Deserialize<IntEnum>(r).Is(IntEnum.Apple);


                Serializer.Serialize<IntEnum>(IntEnum.Orange);
            }
            {
                var r = Serializer.Serialize<IntEnum?>(null);
                Serializer.Deserialize<IntEnum?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<IntEnum?>(IntEnum.Apple);
                Serializer.Deserialize<IntEnum?>(r).Is(IntEnum.Apple);
            }
            {
                var r = Serializer.Serialize<UIntEnum>(UIntEnum.Apple);
                Serializer.Deserialize<UIntEnum>(r).Is(UIntEnum.Apple);
            }
            {
                var r = Serializer.Serialize<UIntEnum?>(null);
                Serializer.Deserialize<UIntEnum?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<UIntEnum?>(UIntEnum.Apple);
                Serializer.Deserialize<UIntEnum?>(r).Is(UIntEnum.Apple);
            }
            {
                var r = Serializer.Serialize<UShortEnum>(UShortEnum.Apple);
                Serializer.Deserialize<UShortEnum>(r).Is(UShortEnum.Apple);
            }
            {
                var r = Serializer.Serialize<UShortEnum?>(null);
                Serializer.Deserialize<UShortEnum?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<UShortEnum?>(UShortEnum.Apple);
                Serializer.Deserialize<UShortEnum?>(r).Is(UShortEnum.Apple);
            }
            {
                var r = Serializer.Serialize<ByteEnum>(ByteEnum.Apple);
                Serializer.Deserialize<ByteEnum>(r).Is(ByteEnum.Apple);
            }
            {
                var r = Serializer.Serialize<ByteEnum?>(null);
                Serializer.Deserialize<ByteEnum?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<ByteEnum?>(ByteEnum.Apple);
                Serializer.Deserialize<ByteEnum?>(r).Is(ByteEnum.Apple);
            }


            {
                var r = Serializer.Serialize<SByteEnum>(SByteEnum.Apple);
                Serializer.Deserialize<SByteEnum>(r).Is(SByteEnum.Apple);
            }
            {
                var r = Serializer.Serialize<SByteEnum?>(null);
                Serializer.Deserialize<SByteEnum?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<SByteEnum?>(SByteEnum.Apple);
                Serializer.Deserialize<SByteEnum?>(r).Is(SByteEnum.Apple);
            }


            {
                var r = Serializer.Serialize<LongEnum>(LongEnum.Apple);
                Serializer.Deserialize<LongEnum>(r).Is(LongEnum.Apple);
            }
            {
                var r = Serializer.Serialize<LongEnum?>(null);
                Serializer.Deserialize<LongEnum?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<LongEnum?>(LongEnum.Apple);
                Serializer.Deserialize<LongEnum?>(r).Is(LongEnum.Apple);
            }


            {
                var r = Serializer.Serialize<ULongEnum>(ULongEnum.Apple);
                Serializer.Deserialize<ULongEnum>(r).Is(ULongEnum.Apple);
            }
            {
                var r = Serializer.Serialize<ULongEnum?>(null);
                Serializer.Deserialize<ULongEnum?>(r).IsNull();
            }
            {
                var r = Serializer.Serialize<ULongEnum?>(ULongEnum.Apple);
                Serializer.Deserialize<ULongEnum?>(r).Is(ULongEnum.Apple);
            }
        }
    }

    public enum IntEnum : int
    {
        Orange, Apple, Grape
    }

    public enum UIntEnum : uint
    {
        Orange, Apple, Grape
    }

    public enum ShortEnum : short
    {
        Orange, Apple, Grape
    }

    public enum UShortEnum : ushort
    {
        Orange, Apple, Grape
    }

    public enum ByteEnum : byte
    {
        Orange, Apple, Grape
    }

    public enum SByteEnum : sbyte
    {
        Orange, Apple, Grape
    }

    public enum LongEnum : long
    {
        Orange, Apple, Grape
    }

    public enum ULongEnum : ulong
    {
        Orange, Apple, Grape
    }
}
