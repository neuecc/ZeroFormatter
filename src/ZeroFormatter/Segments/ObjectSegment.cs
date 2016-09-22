using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ZeroFormatter.Segments
{
    // ObjectSegment is inherit to target class directly but make helper methods.

    internal class ObjectSegment : IZeroFormatterSegment
    {
        readonly DirtyTracker parentTracker;
        readonly DirtyTracker childTracker;
        SegmentState state;
        ArraySegment<byte> serializedBytes;

        public ObjectSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
        {
            this.parentTracker = tracker;
            this.childTracker = new DirtyTracker();
            this.state = SegmentState.Original;
            this.serializedBytes = originalBytes;
        }

        bool IZeroFormatterSegment.CanDirectCopy()
        {
            return !parentTracker.IsDirty && !childTracker.IsDirty;
        }

        ArraySegment<byte> IZeroFormatterSegment.GetBufferReference()
        {
            return serializedBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (!parentTracker.IsDirty)
            {
                var src = serializedBytes.Array;
                Buffer.BlockCopy(src, serializedBytes.Offset, targetBytes, offset, serializedBytes.Count);
            }

            // var formatter1 = Formatter<T>.Default;
            // formatter1.

            // formatter1
            // offset += Formatters.Formatter<int>.Default.Serialize(ref targetBytes, offset, v1);


            throw new NotImplementedException();
        }
    }
}
