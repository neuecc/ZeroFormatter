using System;
using System.Text;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // Layout: [size:int][utf8bytes...], if size == -1 string is null.
    public class StringSegment : IZeroFormatterSegment
    {
        readonly DirtyTracker tracker;
        SegmentState state;
        ArraySegment<byte> serializedBytes;
        string cached;

        public StringSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
        {
            this.tracker = tracker;
            this.state = SegmentState.Original;
            this.serializedBytes = originalBytes;
            this.cached = null;
        }

        public string Value
        {
            get
            {
                switch (state)
                {
                    case SegmentState.Original:
                        var array = serializedBytes.Array;
                        int _;
                        this.cached = Formatter<string>.Default.Deserialize(ref array, serializedBytes.Offset, out _);
                        this.state = SegmentState.Cached;
                        return cached;
                    default:
                        return cached;
                }
            }
            set
            {
                this.tracker.Dirty();
                this.state = SegmentState.Dirty;
                this.cached = value;
            }
        }

        public bool CanDirectCopy()
        {
            return (state == SegmentState.Original) || (state == SegmentState.Cached);
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return serializedBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (targetBytes == null) throw new ArgumentNullException("targetBytes");

            if (state == SegmentState.Dirty) // dirty
            {
                var formatter = Formatter<String>.Default;

                byte[] newBytes = null;
                var length = formatter.Serialize(ref newBytes, 0, cached);
                serializedBytes = new ArraySegment<byte>(newBytes, 0, newBytes.Length);
                state = SegmentState.Cached;
            }
            else if (serializedBytes.Count == 0)
            {
                var array = serializedBytes.Array;
                var length = BinaryUtil.ReadInt32(ref array, serializedBytes.Offset);
                if (length == -1) length = 4;
                serializedBytes = new ArraySegment<byte>(serializedBytes.Array, serializedBytes.Offset, length + 4);
            }

            BinaryUtil.EnsureCapacity(ref targetBytes, offset, serializedBytes.Count);
            Buffer.BlockCopy(serializedBytes.Array, serializedBytes.Offset, targetBytes, offset, serializedBytes.Count);
            return serializedBytes.Count;
        }
    }
}