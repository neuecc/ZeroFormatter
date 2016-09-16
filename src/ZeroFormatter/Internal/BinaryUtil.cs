using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Internal
{
    // does not use BinaryWriter/Reader for save memory allocation
    // like MemoryStream, auto ensure capacity writer

    // Primitive: bool, byte, sbyte, char, double, short, ushort, int uint, long, ulong, float
    // Built-in: decimal, string
    // DateTime, DateTimeOffset as Timestamp(protobuf)
    // TimeSpan, Guid

    internal static class BinaryUtil
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
            var newLength = offset + current + appendLength;

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

        public static int WriteBool(ref byte[] bytes, int offset, bool value)
        {
            EnsureCapacity(ref bytes, offset, 1);

            bytes[offset] = (byte)(value ? 1 : 0);
            return 1;
        }

        public static bool ReadBool(ref byte[] bytes, int offset)
        {
            return (bytes[offset] == 0) ? false : false;
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

        public static int WriteChar(ref byte[] bytes, int offset, char value)
        {
            var ensureSize = StringEncoding.UTF8.GetMaxByteCount(1);
            EnsureCapacity(ref bytes, offset, ensureSize);

            return StringEncoding.UTF8.GetBytes(new[] { value }, 0, 1, bytes, 0);
        }

        public static char ReadChar(ref byte[] bytes, int offset, int count)
        {
            return StringEncoding.UTF8.GetChars(bytes, offset, count)[0];
        }

        public static int WriteInt32(ref byte[] bytes, int offset, int value, bool ensureCapacity = true)
        {
            if (ensureCapacity)
            {
                EnsureCapacity(ref bytes, offset, 4);
            }

            bytes[offset] = (byte)value;
            bytes[offset + 1] = (byte)(value >> 8);
            bytes[offset + 2] = (byte)(value >> 16);
            bytes[offset + 3] = (byte)(value >> 24);

            return 4;
        }

        public static int ReadInt32(ref byte[] bytes, int offset)
        {
            return bytes[offset]
                + (bytes[offset + 1] << 8)
                + (bytes[offset + 2] << 16)
                + (bytes[offset + 3] << 24);
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

        public static int WriteGuid(ref byte[] bytes, int offset, Guid guid)
        {
            EnsureCapacity(ref bytes, offset, 16);
            Buffer.BlockCopy(guid.ToByteArray(), 0, bytes, offset, 16);
            return 16;
        }

        public static Guid ReadGuid(ref byte[] bytes, int offset)
        {
            var guidArray = new byte[]
            {
                bytes[offset],
                bytes[offset + 1],
                bytes[offset + 2],
                bytes[offset + 3],
                bytes[offset + 4],
                bytes[offset + 5],
                bytes[offset + 6],
                bytes[offset + 7],
                bytes[offset + 8],
                bytes[offset + 9],
                bytes[offset + 10],
                bytes[offset + 11],
                bytes[offset + 12],
                bytes[offset + 13],
                bytes[offset + 14],
                bytes[offset + 15],
            };

            return new Guid(guidArray);
        }
    }
}
