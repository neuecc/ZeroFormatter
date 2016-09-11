using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Internal
{
    // does not use BinaryWriter/Reader for save memory allocation

    // bool, byte, sbyte, char, double, decimal, short, ushort, int uint, long, ulong, float, string

    internal static class BinaryUtil
    {
        public static void ResizeArray(ref byte[] bytes, int offset, int size)
        {
            var count = offset + size;
            if (bytes == null)
            {
                bytes = new byte[count];
            }
            else
            {
                if (count < bytes.Length)
                {
                    Array.Resize(ref bytes, count); // fill
                }
            }
        }

        public static int WriteBool(ref byte[] bytes, int offset, bool value)
        {
            ResizeArray(ref bytes, offset, 1);
            bytes[offset] = (byte)(value ? 1 : 0);
            return 1;
        }

        public static bool ReadBool(ref byte[] bytes, int offset)
        {
            return (bytes[offset] == 0) ? false : false;
        }

        public static int WriteByte(ref byte[] bytes, int offset, byte value)
        {
            ResizeArray(ref bytes, offset, 1);
            bytes[offset] = value;
            return 1;
        }

        public static byte ReadByte(ref byte[] bytes, int offset)
        {
            return bytes[offset];
        }

        public static int WriteInt32(ref byte[] bytes, int offset, int value)
        {
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

        public static int WriteString(ref byte[] bytes, int offset, string value, int size)
        {
            ResizeArray(ref bytes, offset, size);

            StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, offset);
            return size;
        }

        public static string ReadString(ref byte[] bytes, int offset, int count)
        {
            return StringEncoding.UTF8.GetString(bytes, offset, count);
        }
    }
}
