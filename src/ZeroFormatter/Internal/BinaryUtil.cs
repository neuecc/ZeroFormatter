using System;

namespace ZeroFormatter.Internal
{
    // does not use BinaryWriter/Reader for save memory allocation
    // like MemoryStream, auto ensure capacity writer

    // Primitive: bool, byte, sbyte, float, double, short, ushort, int uint, long, ulong
    // Built-in: char, decimal, string
    // DateTime, DateTimeOffset as Timestamp(protobuf), long seconds + int nanos
    // TimeSpan as Duration(protobuf), long seconds + int nanos

    // Timestamp, Duration codes are based on Google.Protobuf

    // "internal" but "public" because generated code uses BinaryUtil.
    public static class BinaryUtil
    {
        public static void EnsureCapacity(ref byte[] bytes, int offset, int appendLength)
        {
            // If null(most case fisrt time) fill byte.
            if (bytes == null)
            {
                bytes = new byte[offset + appendLength];
                return;
            }

            // like MemoryStream.EnsureCapacity
            var current = bytes.Length;
            var newLength = offset + appendLength;

            if (newLength > current)
            {
                int num = newLength;
                if (num < 256)
                {
                    num = 256;
                }
                if (num < current * 2)
                {
                    num = current * 2;
                }
                if (current * 2 > 2147483591)
                {
                    num = ((current > 2147483591) ? current : 2147483591);
                }

                FastResize(ref bytes, num);
            }
        }

        // Buffer.BlockCopy version of Array.Resize
        public static void FastResize(ref byte[] array, int newSize)
        {
            if (newSize < 0) throw new ArgumentOutOfRangeException("newSize");

            byte[] array2 = array;
            if (array2 == null)
            {
                array = new byte[newSize];
                return;
            }

            if (array2.Length != newSize)
            {
                byte[] array3 = new byte[newSize];
                Buffer.BlockCopy(array2, 0, array3, 0, (array2.Length > newSize) ? newSize : array2.Length);
                array = array3;
            }
        }

        public static int WriteBoolean(ref byte[] bytes, int offset, bool value)
        {
            EnsureCapacity(ref bytes, offset, 1);

            bytes[offset] = (byte)(value ? 1 : 0);
            return 1;
        }

        /// <summary>
        /// Unsafe! don't ensure capacity and don't return size.
        /// </summary>
        public static void WriteBooleanUnsafe(ref byte[] bytes, int offset, bool value)
        {
            bytes[offset] = (byte)(value ? 1 : 0);
        }

        public static bool ReadBoolean(ref byte[] bytes, int offset)
        {
            return (bytes[offset] == 0) ? false : true;
        }

        public static int WriteByte(ref byte[] bytes, int offset, byte value)
        {
            EnsureCapacity(ref bytes, offset, 1);

            bytes[offset] = value;
            return 1;
        }

        public static byte ReadByte(ref byte[] bytes, int offset)
        {
            return bytes[offset];
        }

        public static int WriteSByte(ref byte[] bytes, int offset, sbyte value)
        {
            EnsureCapacity(ref bytes, offset, 1);

            bytes[offset] = (byte)value;
            return 1;
        }

        public static sbyte ReadSByte(ref byte[] bytes, int offset)
        {
            return (sbyte)bytes[offset];
        }

        public static unsafe int WriteSingle(ref byte[] bytes, int offset, float value)
        {
            EnsureCapacity(ref bytes, offset, 4);

            fixed (byte* ptr = bytes)
            {
                *(float*)(ptr + offset) = value;
            }

            return 4;
        }

        public static unsafe float ReadSingle(ref byte[] bytes, int offset)
        {
            fixed (byte* ptr = bytes)
            {
                return *(float*)(ptr + offset);
            }
        }

        public static unsafe int WriteDouble(ref byte[] bytes, int offset, double value)
        {
            EnsureCapacity(ref bytes, offset, 8);

            fixed (byte* ptr = bytes)
            {
                *(double*)(ptr + offset) = value;
            }

            return 8;
        }

        public static unsafe double ReadDouble(ref byte[] bytes, int offset)
        {
            fixed (byte* ptr = bytes)
            {
                return *(double*)(ptr + offset);
            }
        }

        public static unsafe int WriteInt16(ref byte[] bytes, int offset, short value)
        {
            EnsureCapacity(ref bytes, offset, 2);

            fixed (byte* ptr = bytes)
            {
                *(short*)(ptr + offset) = value;
            }

            return 2;
        }

        public static unsafe short ReadInt16(ref byte[] bytes, int offset)
        {
            fixed (byte* ptr = bytes)
            {
                return *(short*)(ptr + offset);
            }
        }

        public static unsafe int WriteInt32(ref byte[] bytes, int offset, int value)
        {
            EnsureCapacity(ref bytes, offset, 4);

            fixed (byte* ptr = bytes)
            {
                *(int*)(ptr + offset) = value;
            }

            return 4;
        }

        /// <summary>
        /// Unsafe! don't ensure capacity and don't return size.
        /// </summary>
        public static unsafe void WriteInt32Unsafe(ref byte[] bytes, int offset, int value)
        {
            fixed (byte* ptr = bytes)
            {
                *(int*)(ptr + offset) = value;
            }
        }

        public static unsafe int ReadInt32(ref byte[] bytes, int offset)
        {
            fixed (byte* ptr = bytes)
            {
                return *(int*)(ptr + offset);
            }
        }

        public static unsafe int WriteInt64(ref byte[] bytes, int offset, long value)
        {
            EnsureCapacity(ref bytes, offset, 8);

            fixed (byte* ptr = bytes)
            {
                *(long*)(ptr + offset) = value;
            }

            return 8;
        }

        public static unsafe long ReadInt64(ref byte[] bytes, int offset)
        {
            fixed (byte* ptr = bytes)
            {
                return *(long*)(ptr + offset);
            }
        }

        public static unsafe int WriteUInt16(ref byte[] bytes, int offset, ushort value)
        {
            EnsureCapacity(ref bytes, offset, 2);

            fixed (byte* ptr = bytes)
            {
                *(ushort*)(ptr + offset) = value;
            }

            return 2;
        }

        public static unsafe ushort ReadUInt16(ref byte[] bytes, int offset)
        {
            fixed (byte* ptr = bytes)
            {
                return *(ushort*)(ptr + offset);
            }
        }

        public static unsafe int WriteUInt32(ref byte[] bytes, int offset, uint value)
        {
            EnsureCapacity(ref bytes, offset, 4);

            fixed (byte* ptr = bytes)
            {
                *(uint*)(ptr + offset) = value;
            }

            return 4;
        }

        public static unsafe uint ReadUInt32(ref byte[] bytes, int offset)
        {
            fixed (byte* ptr = bytes)
            {
                return *(uint*)(ptr + offset);
            }
        }

        public static unsafe int WriteUInt64(ref byte[] bytes, int offset, ulong value)
        {
            EnsureCapacity(ref bytes, offset, 8);

            fixed (byte* ptr = bytes)
            {
                *(ulong*)(ptr + offset) = value;
            }

            return 8;
        }

        public static unsafe ulong ReadUInt64(ref byte[] bytes, int offset)
        {
            fixed (byte* ptr = bytes)
            {
                return *(ulong*)(ptr + offset);
            }
        }

        public static int WriteChar(ref byte[] bytes, int offset, char value)
        {
            return WriteUInt16(ref bytes, offset, (ushort)value);
        }

        public static char ReadChar(ref byte[] bytes, int offset)
        {
            return (char)ReadUInt16(ref bytes, offset);
        }

        public static int WriteString(ref byte[] bytes, int offset, string value)
        {
            var ensureSize = StringEncoding.UTF8.GetMaxByteCount(value.Length);
            EnsureCapacity(ref bytes, offset, ensureSize);

            return StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, offset);
        }

        public static string ReadString(ref byte[] bytes, int offset, int count)
        {
            return StringEncoding.UTF8.GetString(bytes, offset, count);
        }

        public static int WriteDecimal(ref byte[] bytes, int offset, decimal value)
        {
            EnsureCapacity(ref bytes, offset, 16);

            var bits = decimal.GetBits(value);
            var lo = bits[0];
            var mid = bits[1];
            var hi = bits[2];
            var flags = bits[3];

            bytes[offset + 0] = (byte)lo;
            bytes[offset + 1] = (byte)(lo >> 8);
            bytes[offset + 2] = (byte)(lo >> 16);
            bytes[offset + 3] = (byte)(lo >> 24);
            bytes[offset + 4] = (byte)mid;
            bytes[offset + 5] = (byte)(mid >> 8);
            bytes[offset + 6] = (byte)(mid >> 16);
            bytes[offset + 7] = (byte)(mid >> 24);
            bytes[offset + 8] = (byte)hi;
            bytes[offset + 9] = (byte)(hi >> 8);
            bytes[offset + 10] = (byte)(hi >> 16);
            bytes[offset + 11] = (byte)(hi >> 24);
            bytes[offset + 12] = (byte)flags;
            bytes[offset + 13] = (byte)(flags >> 8);
            bytes[offset + 14] = (byte)(flags >> 16);
            bytes[offset + 15] = (byte)(flags >> 24);

            return 16;
        }

        public static decimal ReadDecimal(ref byte[] bytes, int offset)
        {
            var lo = (int)bytes[offset + 0] | (int)bytes[offset + 1] << 8 | (int)bytes[offset + 2] << 16 | (int)bytes[offset + 3] << 24;
            var mid = (int)bytes[offset + 4] | (int)bytes[offset + 5] << 8 | (int)bytes[offset + 6] << 16 | (int)bytes[offset + 7] << 24;
            var hi = (int)bytes[offset + 8] | (int)bytes[offset + 9] << 8 | (int)bytes[offset + 10] << 16 | (int)bytes[offset + 11] << 24;
            var flags = (int)bytes[offset + 12] | (int)bytes[offset + 13] << 8 | (int)bytes[offset + 14] << 16 | (int)bytes[offset + 15] << 24;

            return new decimal(new[] { lo, mid, hi, flags });
        }

        #region Timestamp/Duration

        public static int WriteTimeSpan(ref byte[] bytes, int offset, TimeSpan timeSpan)
        {
            checked
            {
                long ticks = timeSpan.Ticks;
                long seconds = ticks / TimeSpan.TicksPerSecond;
                int nanos = (int)(ticks % TimeSpan.TicksPerSecond) * Duration.NanosecondsPerTick;

                WriteInt64(ref bytes, offset, seconds);
                WriteInt32(ref bytes, offset + 8, nanos);

                return 12;
            }
        }

        public static TimeSpan ReadTimeSpan(ref byte[] bytes, int offset)
        {
            checked
            {
                Int64 seconds = ReadInt64(ref bytes, offset);
                Int32 nanos = ReadInt32(ref bytes, offset + 8);

                if (!Duration.IsNormalized(seconds, nanos))
                {
                    throw new InvalidOperationException("Duration was not a valid normalized duration");
                }
                long ticks = seconds * TimeSpan.TicksPerSecond + nanos / Duration.NanosecondsPerTick;
                return TimeSpan.FromTicks(ticks);
            }
        }

        public static int WriteDateTime(ref byte[] bytes, int offset, DateTime dateTime)
        {
            dateTime = dateTime.ToUniversalTime();

            // Do the arithmetic using DateTime.Ticks, which is always non-negative, making things simpler.
            long secondsSinceBclEpoch = dateTime.Ticks / TimeSpan.TicksPerSecond;
            int nanoseconds = (int)(dateTime.Ticks % TimeSpan.TicksPerSecond) * Duration.NanosecondsPerTick;

            WriteInt64(ref bytes, offset, secondsSinceBclEpoch - Timestamp.BclSecondsAtUnixEpoch);
            WriteInt32(ref bytes, offset + 8, nanoseconds);

            return 12;
        }

        public static DateTime ReadDateTime(ref byte[] bytes, int offset)
        {
            Int64 seconds = ReadInt64(ref bytes, offset);
            Int32 nanos = ReadInt32(ref bytes, offset + 8);

            if (!Timestamp.IsNormalized(seconds, nanos))
            {
                throw new InvalidOperationException(string.Format(@"Timestamp contains invalid values: Seconds={0}; Nanos={1}", seconds, nanos));
            }
            return Timestamp.UnixEpoch.AddSeconds(seconds).AddTicks(nanos / Duration.NanosecondsPerTick);
        }

        public static int WriteDateTimeOffset(ref byte[] bytes, int offset, DateTimeOffset dateTime)
        {
            return WriteDateTime(ref bytes, offset, dateTime.UtcDateTime);
        }

        public static DateTimeOffset ReadDateTimeOffset(ref byte[] bytes, int offset)
        {
            return new DateTimeOffset(ReadDateTime(ref bytes, offset), TimeSpan.Zero);
        }

        internal static class Timestamp
        {
            internal static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            internal const long BclSecondsAtUnixEpoch = 62135596800;
            internal const long UnixSecondsAtBclMaxValue = 253402300799;
            internal const long UnixSecondsAtBclMinValue = -BclSecondsAtUnixEpoch;
            internal const int MaxNanos = Duration.NanosecondsPerSecond - 1;

            internal static bool IsNormalized(long seconds, int nanoseconds)
            {
                return nanoseconds >= 0 &&
                    nanoseconds <= MaxNanos &&
                    seconds >= UnixSecondsAtBclMinValue &&
                    seconds <= UnixSecondsAtBclMaxValue;
            }
        }

        internal static class Duration
        {
            public const int NanosecondsPerSecond = 1000000000;
            public const int NanosecondsPerTick = 100;
            public const long MaxSeconds = 315576000000L;
            public const long MinSeconds = -315576000000L;
            internal const int MaxNanoseconds = NanosecondsPerSecond - 1;
            internal const int MinNanoseconds = -NanosecondsPerSecond + 1;

            internal static bool IsNormalized(long seconds, int nanoseconds)
            {
                // Simple boundaries
                if (seconds < MinSeconds || seconds > MaxSeconds ||
                    nanoseconds < MinNanoseconds || nanoseconds > MaxNanoseconds)
                {
                    return false;
                }
                // We only have a problem is one is strictly negative and the other is
                // strictly positive.
                return Math.Sign(seconds) * Math.Sign(nanoseconds) != -1;
            }
        }

        #endregion
    }
}
