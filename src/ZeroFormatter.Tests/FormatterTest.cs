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
                var r = ZeroFormatter.Serialize(true);
                ZeroFormatter.Deserialize<bool>(r).IsTrue();
            }
            {
                var r = ZeroFormatter.Serialize(false);
                ZeroFormatter.Deserialize<bool>(r).IsFalse();
            }
            {
                var r = ZeroFormatter.Serialize<bool?>(null);
                ZeroFormatter.Deserialize<bool?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<bool?>(true);
                ZeroFormatter.Deserialize<bool?>(r).Value.IsTrue();
            }
        }

        [TestMethod]
        public void Byte()
        {
            {
                var r = ZeroFormatter.Serialize((byte)123);
                ZeroFormatter.Deserialize<byte>(r).Is((byte)123);
            }
            {
                var r = ZeroFormatter.Serialize<byte?>(null);
                ZeroFormatter.Deserialize<byte?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<byte?>(234);
                ZeroFormatter.Deserialize<byte?>(r).Value.Is((byte)234);
            }
        }

        [TestMethod]
        public void SByte()
        {
            {
                var r = ZeroFormatter.Serialize((sbyte)123);
                ZeroFormatter.Deserialize<sbyte>(r).Is((sbyte)123);
            }
            {
                var r = ZeroFormatter.Serialize<sbyte?>(null);
                ZeroFormatter.Deserialize<sbyte?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<sbyte?>(111);
                ZeroFormatter.Deserialize<sbyte?>(r).Value.Is((sbyte)111);
            }
        }

        [TestMethod]
        public void Float()
        {
            {
                var r = ZeroFormatter.Serialize(123.445f);
                ZeroFormatter.Deserialize<float>(r).Is(123.445f);
            }
            {
                var r = ZeroFormatter.Serialize<float?>(null);
                ZeroFormatter.Deserialize<float?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<float?>(4444.444f);
                ZeroFormatter.Deserialize<float?>(r).Value.Is(4444.444f);
            }
        }

        [TestMethod]
        public void Double()
        {
            {
                var r = ZeroFormatter.Serialize(123.445);
                ZeroFormatter.Deserialize<double>(r).Is(123.445);
            }
            {
                var r = ZeroFormatter.Serialize<double?>(null);
                ZeroFormatter.Deserialize<double?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<double?>(4444.444);
                ZeroFormatter.Deserialize<double?>(r).Value.Is(4444.444);
            }
        }

        [TestMethod]
        public void Short()
        {
            {
                var r = ZeroFormatter.Serialize((short)123);
                ZeroFormatter.Deserialize<short>(r).Is((short)123);
            }
            {
                var r = ZeroFormatter.Serialize<short?>(null);
                ZeroFormatter.Deserialize<short?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<short?>((short)44);
                ZeroFormatter.Deserialize<short?>(r).Value.Is((short)44);
            }
        }

        [TestMethod]
        public void UShort()
        {
            {
                var r = ZeroFormatter.Serialize(ushort.MaxValue);
                ZeroFormatter.Deserialize<ushort>(r).Is((ushort)ushort.MaxValue);
            }
            {
                var r = ZeroFormatter.Serialize<ushort?>(null);
                ZeroFormatter.Deserialize<ushort?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<ushort?>(ushort.MinValue);
                ZeroFormatter.Deserialize<ushort?>(r).Value.Is(ushort.MinValue);
            }
        }

        [TestMethod]
        public void Int()
        {
            {
                var r = ZeroFormatter.Serialize(int.MaxValue);
                ZeroFormatter.Deserialize<int>(r).Is((int)int.MaxValue);
            }
            {
                var r = ZeroFormatter.Serialize<int?>(null);
                ZeroFormatter.Deserialize<int?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<int?>(int.MinValue);
                ZeroFormatter.Deserialize<int?>(r).Value.Is(int.MinValue);
            }
        }

        [TestMethod]
        public void UInt()
        {
            {
                var r = ZeroFormatter.Serialize(uint.MaxValue);
                ZeroFormatter.Deserialize<uint>(r).Is((uint)uint.MaxValue);
            }
            {
                var r = ZeroFormatter.Serialize<uint?>(null);
                ZeroFormatter.Deserialize<uint?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<uint?>(uint.MinValue);
                ZeroFormatter.Deserialize<uint?>(r).Value.Is(uint.MinValue);
            }
        }

        [TestMethod]
        public void Long()
        {
            {
                var r = ZeroFormatter.Serialize(long.MaxValue);
                ZeroFormatter.Deserialize<long>(r).Is((long)long.MaxValue);
            }
            {
                var r = ZeroFormatter.Serialize<long?>(null);
                ZeroFormatter.Deserialize<long?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<long?>(long.MinValue);
                ZeroFormatter.Deserialize<long?>(r).Value.Is(long.MinValue);
            }
        }

        [TestMethod]
        public void ULong()
        {
            {
                var r = ZeroFormatter.Serialize(ulong.MaxValue);
                ZeroFormatter.Deserialize<ulong>(r).Is((ulong)ulong.MaxValue);
            }
            {
                var r = ZeroFormatter.Serialize<ulong?>(null);
                ZeroFormatter.Deserialize<ulong?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<ulong?>(ulong.MinValue);
                ZeroFormatter.Deserialize<ulong?>(r).Value.Is(ulong.MinValue);
            }
        }

        [TestMethod]
        public void String()
        {
            {
                var r = ZeroFormatter.Serialize("あいうえお");
                ZeroFormatter.Deserialize<string>(r).Is("あいうえお");
            }
            {
                var r = ZeroFormatter.Serialize<string>(null);
                ZeroFormatter.Deserialize<string>(r).IsNull();
            }
        }

        [TestMethod]
        public void Char()
        {
            {
                var r = ZeroFormatter.Serialize('あ');
                ZeroFormatter.Deserialize<char>(r).Is('あ');
            }
            {
                var r = ZeroFormatter.Serialize('z');
                ZeroFormatter.Deserialize<char>(r).Is('z');
            }

            {
                var r = ZeroFormatter.Serialize<char?>(null);
                ZeroFormatter.Deserialize<char?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<char?>('花');
                ZeroFormatter.Deserialize<char?>(r).Value.Is('花');
            }
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Decimal()
        {
            {
                var r = ZeroFormatter.Serialize<decimal>(1000M);
                ZeroFormatter.Deserialize<decimal>(r).Is(1000M);
            }

            {
                var r = ZeroFormatter.Serialize<decimal?>(null);
                ZeroFormatter.Deserialize<decimal?>(r).IsNull();
            }

            {
                var r = ZeroFormatter.Serialize<decimal?>(decimal.MaxValue);
                ZeroFormatter.Deserialize<decimal?>(r).Is(decimal.MaxValue);
            }
        }

        [TestMethod]
        public void TimeSpan()
        {
            {
                var r = ZeroFormatter.Serialize<TimeSpan>(new System.TimeSpan(12, 12, 43, 54));
                ZeroFormatter.Deserialize<TimeSpan>(r).Is(new System.TimeSpan(12, 12, 43, 54));
            }

            {
                var r = ZeroFormatter.Serialize<TimeSpan?>(null);
                ZeroFormatter.Deserialize<TimeSpan?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<TimeSpan?>(System.TimeSpan.Zero);
                ZeroFormatter.Deserialize<TimeSpan?>(r).Is(System.TimeSpan.Zero);
            }
        }

        [TestMethod]
        public void Datetime()
        {
            var now = DateTime.Now.ToUniversalTime();
            {
                var r = ZeroFormatter.Serialize<DateTime>(now);
                ZeroFormatter.Deserialize<DateTime>(r).ToString("yyyy-MM-dd HH:mm:ss fff").Is(now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }

            {
                var r = ZeroFormatter.Serialize<DateTime?>(null);
                ZeroFormatter.Deserialize<DateTime?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<DateTime?>(now);
                ZeroFormatter.Deserialize<DateTime?>(r).Is(now);
            }
        }

        [TestMethod]
        public void DatetimeOffset()
        {
            var now = DateTimeOffset.Now.ToUniversalTime();
            {
                var r = ZeroFormatter.Serialize<DateTimeOffset>(now);
                ZeroFormatter.Deserialize<DateTimeOffset>(r).ToString("yyyy-MM-dd HH:mm:ss fff").Is(now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }

            {
                var r = ZeroFormatter.Serialize<DateTimeOffset?>(null);
                ZeroFormatter.Deserialize<DateTimeOffset?>(r).IsNull();
            }
            {
                var r = ZeroFormatter.Serialize<DateTimeOffset?>(now);
                ZeroFormatter.Deserialize<DateTimeOffset?>(r).Is(now);
            }
        }

        [TestMethod]
        public void ByteArray()
        {
            {
                var bytes = new byte[] { 123, 31, 5, 64, 26, 2, 47, 2, 43 };
                var r = ZeroFormatter.Serialize(bytes);
                ZeroFormatter.Deserialize<byte[]>(r).Is(bytes);
            }
            {
                var bytes = new byte[0] { };
                var r = ZeroFormatter.Serialize(bytes);
                ZeroFormatter.Deserialize<byte[]>(r).Is(bytes);
            }
            {
                var r = ZeroFormatter.Serialize<byte[]>(null);
                ZeroFormatter.Deserialize<byte[]>(r).IsNull();
            }
        }

        [TestMethod]
        public void EnumFormatTest()
        {
            ZeroFormatter.Serialize<MyEnum>(MyEnum.Apple);
        }
    }

    public enum MyEnum
    {
        Orange, Apple, Grape
    }
}
