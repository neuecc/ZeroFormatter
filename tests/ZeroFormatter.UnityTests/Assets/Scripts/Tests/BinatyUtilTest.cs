using System;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using RuntimeUnitTestToolkit;

namespace ZeroFormatter.Tests
{
    public class BinaryUtilTest
    {
        public void Binary()
        {
            const int offset = 33;
            var bytes = new byte[100];

            bytes = new byte[100];
            BinaryUtil.WriteBoolean(ref bytes, offset, true).Is(1);
            BinaryUtil.ReadBoolean(ref bytes, offset).IsTrue();

            bytes = new byte[100];
            BinaryUtil.WriteByte(ref bytes, offset, (byte)234).Is(1);
            BinaryUtil.ReadByte(ref bytes, offset).Is((byte)234);

            bytes = new byte[100];
            BinaryUtil.WriteChar(ref bytes, offset, 'z').Is(2);
            BinaryUtil.ReadChar(ref bytes, offset).Is('z');

            bytes = new byte[100];
            var now = DateTime.Now.ToUniversalTime();
            BinaryUtil.WriteDateTime(ref bytes, offset, now).Is(12);
            BinaryUtil.ReadDateTime(ref bytes, offset).Is(now);

            bytes = new byte[100];
            BinaryUtil.WriteDecimal(ref bytes, offset, decimal.MaxValue).Is(16);
            BinaryUtil.ReadDecimal(ref bytes, offset).Is(decimal.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteDouble(ref bytes, offset, double.MaxValue).Is(8);
            BinaryUtil.ReadDouble(ref bytes, offset).Is(double.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteInt16(ref bytes, offset, short.MaxValue).Is(2);
            BinaryUtil.ReadInt16(ref bytes, offset).Is(short.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteInt32(ref bytes, offset, int.MaxValue).Is(4);
            BinaryUtil.ReadInt32(ref bytes, offset).Is(int.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, int.MaxValue);
            BinaryUtil.ReadInt32(ref bytes, offset).Is(int.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteInt64(ref bytes, offset, long.MaxValue).Is(8);
            BinaryUtil.ReadInt64(ref bytes, offset).Is(long.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteSByte(ref bytes, offset, sbyte.MaxValue).Is(1);
            BinaryUtil.ReadSByte(ref bytes, offset).Is(sbyte.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteSingle(ref bytes, offset, Single.MaxValue).Is(4);
            BinaryUtil.ReadSingle(ref bytes, offset).Is(Single.MaxValue);

            bytes = new byte[100];
            var c = BinaryUtil.WriteString(ref bytes, offset, "あいうえおかきくけこ");
            BinaryUtil.ReadString(ref bytes, offset, c).Is("あいうえおかきくけこ");

            var ts = new TimeSpan(14, 213, 41241);
            bytes = new byte[100];
            BinaryUtil.WriteTimeSpan(ref bytes, offset, ts).Is(12);
            BinaryUtil.ReadTimeSpan(ref bytes, offset).Is(ts);

            bytes = new byte[100];
            BinaryUtil.WriteUInt16(ref bytes, offset, UInt16.MaxValue).Is(2);
            BinaryUtil.ReadUInt16(ref bytes, offset).Is(UInt16.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteUInt32(ref bytes, offset, UInt32.MaxValue).Is(4);
            BinaryUtil.ReadUInt32(ref bytes, offset).Is(UInt32.MaxValue);

            bytes = new byte[100];
            BinaryUtil.WriteUInt64(ref bytes, offset, UInt64.MaxValue).Is(8);
            BinaryUtil.ReadUInt64(ref bytes, offset).Is(UInt64.MaxValue);
        }

        public void IsLittleEndian()
        {
            System.BitConverter.IsLittleEndian.IsTrue();
        }

        public void WriteFloatFromNull()
        {
            byte[] bytes = null;
            var len = BinaryUtil.WriteSingle(ref bytes, 0, 3.14f);
            len.Is(4);

            bytes[0].Is((byte)195);
            bytes[1].Is((byte)245);
            bytes[2].Is((byte)72);
            bytes[3].Is((byte)64);
        }

        public void WriteFloatFromExists()
        {
            byte[] bytes = new byte[4];
            var len = BinaryUtil.WriteSingle(ref bytes, 0, 3.14f);
            len.Is(4);

            bytes[0].Is((byte)195);
            bytes[1].Is((byte)245);
            bytes[2].Is((byte)72);
            bytes[3].Is((byte)64);
        }

        public void ReadFloat()
        {
            byte[] bytes = new byte[4] { (byte)195, (byte)245, (byte)72, (byte)64 };

            var f = BinaryUtil.ReadSingle(ref bytes, 0);
            f.Is(3.14f);

        }

        public void WriteDoubleFromNull()
        {
            byte[] bytes = null;
            var len = BinaryUtil.WriteDouble(ref bytes, 0, 3.14);
            len.Is(8);

            bytes[0].Is((byte)31);
            bytes[1].Is((byte)133);
            bytes[2].Is((byte)235);
            bytes[3].Is((byte)81);
            bytes[4].Is((byte)184);
            bytes[5].Is((byte)30);
            bytes[6].Is((byte)9);
            bytes[7].Is((byte)64);
        }

        public void WriteDoubleFromExists()
        {
            byte[] bytes = new byte[8];
            var len = BinaryUtil.WriteDouble(ref bytes, 0, 3.14);
            len.Is(8);

            bytes[0].Is((byte)31);
            bytes[1].Is((byte)133);
            bytes[2].Is((byte)235);
            bytes[3].Is((byte)81);
            bytes[4].Is((byte)184);
            bytes[5].Is((byte)30);
            bytes[6].Is((byte)9);
            bytes[7].Is((byte)64);
        }

        public void ReadDouble()
        {
            byte[] bytes = new byte[8] { (byte)31, (byte)133, (byte)235, (byte)81, (byte)184, (byte)30, (byte)9, (byte)64 };

            var d = BinaryUtil.ReadDouble(ref bytes, 0);
            d.Is(3.14);
        }
    }
}
