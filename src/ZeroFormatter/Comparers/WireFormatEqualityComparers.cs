using System;
using ZeroFormatter.Internal;
using System.Collections.Generic;

namespace ZeroFormatter.Comparers
{
    public class NullableEqualityComparer<T> : IEqualityComparer<Nullable<T>>
        where T : struct
    {
        readonly IEqualityComparer<T> innerComparer;

        public NullableEqualityComparer()
        {
            this.innerComparer = ZeroFormatterEqualityComparer<T>.Default;
        }

        public bool Equals(T? x, T? y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;

            return innerComparer.Equals(x.Value, y.Value);
        }

        public int GetHashCode(T? obj)
        {
            if (obj == null) return 0;
            return innerComparer.GetHashCode(obj.Value);
        }
    }

    internal class BoolEqualityComparer : IEqualityComparer<bool>
    {
        public bool Equals(bool x, bool y)
        {
            return x == y;
        }

        public int GetHashCode(bool obj)
        {
            return !obj ? 0 : 1;
        }
    }

    internal class CharEqualityComparer : IEqualityComparer<char>
    {
        public bool Equals(char x, char y)
        {
            return x == y;
        }

        public int GetHashCode(char obj)
        {
            return (int)(obj | (int)obj << 16);
        }
    }

    internal class ByteEqualityComparer : IEqualityComparer<byte>
    {
        public bool Equals(byte x, byte y)
        {
            return x == y;
        }

        public int GetHashCode(byte obj)
        {
            return (int)obj;
        }
    }

    internal class SByteEqualityComparer : IEqualityComparer<sbyte>
    {
        public bool Equals(sbyte x, sbyte y)
        {
            return x == y;
        }

        public int GetHashCode(sbyte obj)
        {
            return (int)obj ^ (int)obj << 8;
        }
    }

    internal class Int16EqualityComparer : IEqualityComparer<short>
    {
        public bool Equals(short x, short y)
        {
            return x == y;
        }

        public int GetHashCode(short obj)
        {
            return (int)((ushort)obj) | (int)obj << 16;
        }
    }

    internal class Int32EqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return x == y;
        }

        public int GetHashCode(int obj)
        {
            return obj;
        }
    }

    internal class Int64EqualityComparer : IEqualityComparer<long>
    {
        public bool Equals(long x, long y)
        {
            return x == y;
        }

        public int GetHashCode(long obj)
        {
            return (int)obj ^ (int)(obj >> 32);
        }
    }

    internal class UInt16EqualityComparer : IEqualityComparer<ushort>
    {
        public bool Equals(ushort x, ushort y)
        {
            return x == y;
        }

        public int GetHashCode(ushort obj)
        {
            return obj;
        }
    }

    internal class UInt32EqualityComparer : IEqualityComparer<uint>
    {
        public bool Equals(uint x, uint y)
        {
            return x == y;
        }

        public int GetHashCode(uint obj)
        {
            return (int)obj;
        }
    }

    internal class UInt64EqualityComparer : IEqualityComparer<ulong>
    {
        public bool Equals(ulong x, ulong y)
        {
            return x == y;
        }

        public int GetHashCode(ulong obj)
        {
            return (int)obj ^ (int)(obj >> 32);
        }
    }

    internal class SingleEqualityComparer : IEqualityComparer<float>
    {
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float obj)
        {
            var num = BitConverter.DoubleToInt64Bits(obj);
            return (int)num;
        }
    }

    internal class DoubleEqualityComparer : IEqualityComparer<double>
    {
        public bool Equals(double x, double y)
        {
            return x == y;
        }

        public int GetHashCode(double obj)
        {
            var num = BitConverter.DoubleToInt64Bits(obj);
            return (int)num ^ (int)(num >> 32);
        }
    }

    internal class DecimalEqualityComparer : IEqualityComparer<decimal>
    {
        public bool Equals(decimal x, decimal y)
        {
            return x == y;
        }

        public int GetHashCode(decimal obj)
        {
            var bits = decimal.GetBits(obj);
            var lo = bits[0];
            var mid = bits[1];
            var hi = bits[2];
            var flags = bits[3];

            return (int)(flags ^ hi ^ lo ^ mid);
        }
    }

    internal class GuidEqualityComparer : IEqualityComparer<Guid>
    {
        public bool Equals(Guid x, Guid y)
        {
            return x == y;
        }

        public int GetHashCode(Guid obj)
        {
            var b = obj.ToByteArray();

            var _a = ((int)b[3] << 24) | ((int)b[2] << 16) | ((int)b[1] << 8) | b[0];
            var _b = (short)(((int)b[5] << 8) | b[4]);
            var _c = (short)(((int)b[7] << 8) | b[6]);
            //var _d = b[8];
            //var _e = b[9];
            var _f = b[10];
            //var _g = b[11];
            //var _h = b[12];
            //var _i = b[13];
            //var _j = b[14];
            var _k = b[15];

            return _a ^ (((int)_b << 16) | (int)(ushort)_c) ^ (((int)_f << 24) | _k);
        }
    }

    internal class TimeSpanEqualityComparer : IEqualityComparer<TimeSpan>
    {
        public bool Equals(TimeSpan x, TimeSpan y)
        {
            return x == y;
        }

        public int GetHashCode(TimeSpan timeSpan)
        {
            long ticks = timeSpan.Ticks;
            long seconds = ticks / TimeSpan.TicksPerSecond;
            int nanos = (int)(ticks % TimeSpan.TicksPerSecond) * Internal.BinaryUtil.Duration.NanosecondsPerTick;

            var h0 = (int)seconds ^ (int)(seconds >> 32);
            h0 = (h0 << 5) + h0 ^ nanos;
            return h0;
        }
    }

    internal class DeteTimeEqualityComparer : IEqualityComparer<DateTime>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            return x == y;
        }

        public int GetHashCode(DateTime dateTime)
        {
            dateTime = dateTime.ToUniversalTime();

            long secondsSinceBclEpoch = dateTime.Ticks / TimeSpan.TicksPerSecond;
            long seconds = secondsSinceBclEpoch - BinaryUtil.Timestamp.BclSecondsAtUnixEpoch;
            int nanoseconds = (int)(dateTime.Ticks % TimeSpan.TicksPerSecond) * BinaryUtil.Duration.NanosecondsPerTick;

            var h0 = (int)seconds ^ (int)(seconds >> 32);
            h0 = (h0 << 5) + h0 ^ nanoseconds;
            return h0;
        }
    }

    internal class DeteTimeOffsetEqualityComparer : IEqualityComparer<DateTimeOffset>
    {
        public bool Equals(DateTimeOffset x, DateTimeOffset y)
        {
            return x == y;
        }

        public int GetHashCode(DateTimeOffset dateTime)
        {
            dateTime = dateTime.UtcDateTime;

            long secondsSinceBclEpoch = dateTime.Ticks / TimeSpan.TicksPerSecond;
            long seconds = secondsSinceBclEpoch - BinaryUtil.Timestamp.BclSecondsAtUnixEpoch;
            int nanoseconds = (int)(dateTime.Ticks % TimeSpan.TicksPerSecond) * BinaryUtil.Duration.NanosecondsPerTick;

            var h0 = (int)seconds ^ (int)(seconds >> 32);
            h0 = (h0 << 5) + h0 ^ nanoseconds;
            return h0;
        }
    }

    internal class StringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x == y;
        }

        public int GetHashCode(string value)
        {
            unchecked
            {
                var hashCode = 0;
                var count = value.Length;
                for (var i = 0; i < count; i++)
                {
                    hashCode = hashCode * 31 + value[i];
                }
                return hashCode;
            }
        }
    }
}