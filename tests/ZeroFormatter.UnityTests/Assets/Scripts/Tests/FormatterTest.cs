using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuntimeUnitTestToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroFormatter.Tests
{
    // bool, byte, sbyte, float, double, short, ushort, int uint, long, ulong) + Nullable
    public class FormatterTest
    {
   
        public void Bool()
        {
            {
                var r = ZeroFormatterSerializer.Serialize(true);
                ZeroFormatterSerializer.Deserialize<bool>(r).IsTrue();
            }
            {
                var r = ZeroFormatterSerializer.Serialize(false);
                ZeroFormatterSerializer.Deserialize<bool>(r).IsFalse();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<bool?>(null);
                ZeroFormatterSerializer.Deserialize<bool?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<bool?>(true);
                ZeroFormatterSerializer.Deserialize<bool?>(r).Value.IsTrue();
            }
        }

        public void Byte()
        {
            {
                var r = ZeroFormatterSerializer.Serialize((byte)123);
                ZeroFormatterSerializer.Deserialize<byte>(r).Is((byte)123);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<byte?>(null);
                ZeroFormatterSerializer.Deserialize<byte?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<byte?>(234);
                ZeroFormatterSerializer.Deserialize<byte?>(r).Value.Is((byte)234);
            }
        }

        public void SByte()
        {
            {
                var r = ZeroFormatterSerializer.Serialize((sbyte)123);
                ZeroFormatterSerializer.Deserialize<sbyte>(r).Is((sbyte)123);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<sbyte?>(null);
                ZeroFormatterSerializer.Deserialize<sbyte?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<sbyte?>(111);
                ZeroFormatterSerializer.Deserialize<sbyte?>(r).Value.Is((sbyte)111);
            }
        }

        public void Float()
        {
            {
                var r = ZeroFormatterSerializer.Serialize(123.445f);
                ZeroFormatterSerializer.Deserialize<float>(r).Is(123.445f);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<float?>(null);
                ZeroFormatterSerializer.Deserialize<float?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<float?>(4444.444f);
                ZeroFormatterSerializer.Deserialize<float?>(r).Value.Is(4444.444f);
            }
        }


        public void Double()
        {
            {
                var r = ZeroFormatterSerializer.Serialize(123.445);
                ZeroFormatterSerializer.Deserialize<double>(r).Is(123.445);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<double?>(null);
                ZeroFormatterSerializer.Deserialize<double?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<double?>(4444.444);
                ZeroFormatterSerializer.Deserialize<double?>(r).Value.Is(4444.444);
            }
        }


        public void Short()
        {
            {
                var r = ZeroFormatterSerializer.Serialize((short)123);
                ZeroFormatterSerializer.Deserialize<short>(r).Is((short)123);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<short?>(null);
                ZeroFormatterSerializer.Deserialize<short?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<short?>((short)44);
                ZeroFormatterSerializer.Deserialize<short?>(r).Value.Is((short)44);
            }
        }


        public void UShort()
        {
            {
                var r = ZeroFormatterSerializer.Serialize(ushort.MaxValue);
                ZeroFormatterSerializer.Deserialize<ushort>(r).Is((ushort)ushort.MaxValue);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ushort?>(null);
                ZeroFormatterSerializer.Deserialize<ushort?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ushort?>(ushort.MinValue);
                ZeroFormatterSerializer.Deserialize<ushort?>(r).Value.Is(ushort.MinValue);
            }
        }


        public void Int()
        {
            {
                var r = ZeroFormatterSerializer.Serialize(int.MaxValue);
                ZeroFormatterSerializer.Deserialize<int>(r).Is((int)int.MaxValue);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<int?>(null);
                ZeroFormatterSerializer.Deserialize<int?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<int?>(int.MinValue);
                ZeroFormatterSerializer.Deserialize<int?>(r).Value.Is(int.MinValue);
            }
        }


        public void UInt()
        {
            {
                var r = ZeroFormatterSerializer.Serialize(uint.MaxValue);
                ZeroFormatterSerializer.Deserialize<uint>(r).Is((uint)uint.MaxValue);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<uint?>(null);
                ZeroFormatterSerializer.Deserialize<uint?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<uint?>(uint.MinValue);
                ZeroFormatterSerializer.Deserialize<uint?>(r).Value.Is(uint.MinValue);
            }
        }


        public void Long()
        {
            {
                var r = ZeroFormatterSerializer.Serialize(long.MaxValue);
                ZeroFormatterSerializer.Deserialize<long>(r).Is((long)long.MaxValue);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<long?>(null);
                ZeroFormatterSerializer.Deserialize<long?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<long?>(long.MinValue);
                ZeroFormatterSerializer.Deserialize<long?>(r).Value.Is(long.MinValue);
            }
        }


        public void ULong()
        {
            {
                var r = ZeroFormatterSerializer.Serialize(ulong.MaxValue);
                ZeroFormatterSerializer.Deserialize<ulong>(r).Is((ulong)ulong.MaxValue);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ulong?>(null);
                ZeroFormatterSerializer.Deserialize<ulong?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ulong?>(ulong.MinValue);
                ZeroFormatterSerializer.Deserialize<ulong?>(r).Value.Is(ulong.MinValue);
            }
        }


        public void String()
        {
            {
                var r = ZeroFormatterSerializer.Serialize("あいうえお");
                ZeroFormatterSerializer.Deserialize<string>(r).Is("あいうえお");
            }
            {
                var r = ZeroFormatterSerializer.Serialize<string>(null);
                ZeroFormatterSerializer.Deserialize<string>(r).IsNull();
            }
        }


        public void Char()
        {
            {
                var r = ZeroFormatterSerializer.Serialize('あ');
                ZeroFormatterSerializer.Deserialize<char>(r).Is('あ');
            }
            {
                var r = ZeroFormatterSerializer.Serialize('z');
                ZeroFormatterSerializer.Deserialize<char>(r).Is('z');
            }

            {
                var r = ZeroFormatterSerializer.Serialize<char?>(null);
                ZeroFormatterSerializer.Deserialize<char?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<char?>('花');
                ZeroFormatterSerializer.Deserialize<char?>(r).Value.Is('花');
            }
        }

        public void Decimal()
        {
            {
                var r = ZeroFormatterSerializer.Serialize<decimal>(1000M);
                ZeroFormatterSerializer.Deserialize<decimal>(r).Is(1000M);
            }

            {
                var r = ZeroFormatterSerializer.Serialize<decimal?>(null);
                ZeroFormatterSerializer.Deserialize<decimal?>(r).IsNull();
            }

            {
                var r = ZeroFormatterSerializer.Serialize<decimal?>(decimal.MaxValue);
                ZeroFormatterSerializer.Deserialize<decimal?>(r).Is(decimal.MaxValue);
            }
        }


        public void TimeSpan()
        {
            {
                var r = ZeroFormatterSerializer.Serialize<TimeSpan>(new System.TimeSpan(12, 12, 43, 54));
                ZeroFormatterSerializer.Deserialize<TimeSpan>(r).Is(new System.TimeSpan(12, 12, 43, 54));
            }

            {
                var r = ZeroFormatterSerializer.Serialize<TimeSpan?>(null);
                ZeroFormatterSerializer.Deserialize<TimeSpan?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<TimeSpan?>(System.TimeSpan.Zero);
                ZeroFormatterSerializer.Deserialize<TimeSpan?>(r).Is(System.TimeSpan.Zero);
            }
        }


        public void Datetime()
        {
            var now = DateTime.Now.ToUniversalTime();
            {
                var r = ZeroFormatterSerializer.Serialize<DateTime>(now);
                ZeroFormatterSerializer.Deserialize<DateTime>(r).ToString("yyyy-MM-dd HH:mm:ss fff").Is(now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }

            {
                var r = ZeroFormatterSerializer.Serialize<DateTime?>(null);
                ZeroFormatterSerializer.Deserialize<DateTime?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<DateTime?>(now);
                ZeroFormatterSerializer.Deserialize<DateTime?>(r).Is(now);
            }
        }


        public void DatetimeOffset()
        {
            var now = new DateTimeOffset(2000, 1, 1, 0, 0, 0, System.TimeSpan.FromHours(9));
            {
                var r = ZeroFormatterSerializer.Serialize<DateTimeOffset>(now);
                ZeroFormatterSerializer.Deserialize<DateTimeOffset>(r).ToString("yyyy-MM-dd HH:mm:ss fff").Is(now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }

            {
                var r = ZeroFormatterSerializer.Serialize<DateTimeOffset?>(null);
                ZeroFormatterSerializer.Deserialize<DateTimeOffset?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<DateTimeOffset?>(now);
                ZeroFormatterSerializer.Deserialize<DateTimeOffset?>(r).Is(now);
            }
        }


        public void ByteArray()
        {
            {
                var bytes = new byte[] { 123, 31, 5, 64, 26, 2, 47, 2, 43 };
                var r = ZeroFormatterSerializer.Serialize(bytes);
                ZeroFormatterSerializer.Deserialize<byte[]>(r).IsCollection(bytes);
            }
            {
                var bytes = new byte[0] { };
                var r = ZeroFormatterSerializer.Serialize(bytes);
                ZeroFormatterSerializer.Deserialize<byte[]>(r).IsCollection(bytes);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<byte[]>(null);
                ZeroFormatterSerializer.Deserialize<byte[]>(r).IsNull();
            }
        }


        public void EnumFormatTest()
        {
            {
                var r = ZeroFormatterSerializer.Serialize<IntEnum>(IntEnum.Apple);
                ZeroFormatterSerializer.Deserialize<IntEnum>(r).Is(IntEnum.Apple);


                ZeroFormatterSerializer.Serialize<IntEnum>(IntEnum.Orange);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<IntEnum?>(null);
                ZeroFormatterSerializer.Deserialize<IntEnum?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<IntEnum?>(IntEnum.Apple);
                ZeroFormatterSerializer.Deserialize<IntEnum?>(r).Is(IntEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<UIntEnum>(UIntEnum.Apple);
                ZeroFormatterSerializer.Deserialize<UIntEnum>(r).Is(UIntEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<UIntEnum?>(null);
                ZeroFormatterSerializer.Deserialize<UIntEnum?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<UIntEnum?>(UIntEnum.Apple);
                ZeroFormatterSerializer.Deserialize<UIntEnum?>(r).Is(UIntEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<UShortEnum>(UShortEnum.Apple);
                ZeroFormatterSerializer.Deserialize<UShortEnum>(r).Is(UShortEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<UShortEnum?>(null);
                ZeroFormatterSerializer.Deserialize<UShortEnum?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<UShortEnum?>(UShortEnum.Apple);
                ZeroFormatterSerializer.Deserialize<UShortEnum?>(r).Is(UShortEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ByteEnum>(ByteEnum.Apple);
                ZeroFormatterSerializer.Deserialize<ByteEnum>(r).Is(ByteEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ByteEnum?>(null);
                ZeroFormatterSerializer.Deserialize<ByteEnum?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ByteEnum?>(ByteEnum.Apple);
                ZeroFormatterSerializer.Deserialize<ByteEnum?>(r).Is(ByteEnum.Apple);
            }


            {
                var r = ZeroFormatterSerializer.Serialize<SByteEnum>(SByteEnum.Apple);
                ZeroFormatterSerializer.Deserialize<SByteEnum>(r).Is(SByteEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<SByteEnum?>(null);
                ZeroFormatterSerializer.Deserialize<SByteEnum?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<SByteEnum?>(SByteEnum.Apple);
                ZeroFormatterSerializer.Deserialize<SByteEnum?>(r).Is(SByteEnum.Apple);
            }


            {
                var r = ZeroFormatterSerializer.Serialize<LongEnum>(LongEnum.Apple);
                ZeroFormatterSerializer.Deserialize<LongEnum>(r).Is(LongEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<LongEnum?>(null);
                ZeroFormatterSerializer.Deserialize<LongEnum?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<LongEnum?>(LongEnum.Apple);
                ZeroFormatterSerializer.Deserialize<LongEnum?>(r).Is(LongEnum.Apple);
            }


            {
                var r = ZeroFormatterSerializer.Serialize<ULongEnum>(ULongEnum.Apple);
                ZeroFormatterSerializer.Deserialize<ULongEnum>(r).Is(ULongEnum.Apple);
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ULongEnum?>(null);
                ZeroFormatterSerializer.Deserialize<ULongEnum?>(r).IsNull();
            }
            {
                var r = ZeroFormatterSerializer.Serialize<ULongEnum?>(ULongEnum.Apple);
                ZeroFormatterSerializer.Deserialize<ULongEnum?>(r).Is(ULongEnum.Apple);
            }
        }
    }

    
}
