using System;
using System.Text;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Format
{
    // Layout: [size:int][utf8bytes...], if size == -1 string is null.
    public struct StringSegment
    {
        byte flag; // 0 = original, 1 = cached, 2 = dirty
        ArraySegment<byte> serializeBytes;
        string cached;

        public StringSegment(ArraySegment<byte> originalBytes)
        {
            this.flag = 0;
            this.serializeBytes = originalBytes;
            this.cached = null;
        }

        public string Value
        {
            get
            {
                switch (flag)
                {
                    case 0:
                        var array = serializeBytes.Array;
                        this.cached = Formatter<string>.Instance.Deserialize(ref array, serializeBytes.Offset);
                        this.flag = 1;
                        goto case 1;
                    case 1:
                    case 2:
                    default:
                        return cached;
                }
            }
            set
            {
                this.cached = value;
                this.flag = 2;
            }
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (targetBytes == null) throw new ArgumentNullException("targetBytes");

            if (flag == 2)
            {
                // TODO:GetByteCount is slow...

                var size = StringEncoding.UTF8.GetByteCount(cached);
                var newBytes = new byte[size + 4];
                BinaryUtil.WriteInt32(ref newBytes, 0, size);

                StringEncoding.UTF8.GetBytes(cached, 0, cached.Length, newBytes, 4);
                serializeBytes = new ArraySegment<byte>(newBytes, 0, newBytes.Length);
                flag = 1; // cached serialize bytes
            }

            if (targetBytes.Length < offset + serializeBytes.Count)
            {
                BinaryUtil.FastResize(ref targetBytes, (offset + serializeBytes.Count)); // fill resize
            }

            Buffer.BlockCopy(serializeBytes.Array, serializeBytes.Offset, targetBytes, offset, serializeBytes.Count);
            return serializeBytes.Count;
        }
    }
}