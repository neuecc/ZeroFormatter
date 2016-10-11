using System;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // for KeyTuple, String, byte[]
    public class CacheSegment<T> : IZeroFormatterSegment
    {
        readonly DirtyTracker tracker;
        SegmentState state;
        ArraySegment<byte> serializedBytes;
        T cached;

        public CacheSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
        {
            this.tracker = tracker;
            this.state = SegmentState.Original;
            this.serializedBytes = originalBytes;
            this.cached = default(T);

            if (originalBytes.Count == 0)
            {
            }
        }

        public T Value
        {
            get
            {
                switch (state)
                {
                    case SegmentState.Original:
                        var array = serializedBytes.Array;
                        int _;
                        this.cached = Formatter<T>.Default.Deserialize(ref array, serializedBytes.Offset, tracker, out _);
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
                var formatter = Formatter<T>.Default;

                byte[] newBytes = null;
                var length = formatter.Serialize(ref newBytes, 0, cached);
                serializedBytes = new ArraySegment<byte>(newBytes, 0, newBytes.Length);
                state = SegmentState.Cached;
            }

            BinaryUtil.EnsureCapacity(ref targetBytes, offset, serializedBytes.Count);
            Buffer.BlockCopy(serializedBytes.Array, serializedBytes.Offset, targetBytes, offset, serializedBytes.Count);
            return serializedBytes.Count;
        }
    }
}