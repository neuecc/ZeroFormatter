using System;
using System.Text;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Format
{
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
                        this.cached = Encoding.UTF8.GetString(serializeBytes.Array, serializeBytes.Offset, serializeBytes.Count);
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
                var getBytes = StringEncoding.UTF8.GetBytes(cached);
                serializeBytes = new ArraySegment<byte>(getBytes, 0, getBytes.Length);
                flag = 1; // cached serialize bytes
            }

            // TODO:Write header...
            if (targetBytes.Length < offset + serializeBytes.Count)
            {
                Array.Resize(ref targetBytes, (offset + serializeBytes.Count)); // fill resize
            }

            Buffer.BlockCopy(serializeBytes.Array, serializeBytes.Offset, targetBytes, offset, serializeBytes.Count);
            return serializeBytes.Count;
        }
    }
}