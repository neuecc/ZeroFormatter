using System;

namespace ZeroFormatter.Segments
{
    // is this needs?

    // Layout: [isNull:bool][t format...]
    public struct NullableSegment<T>
        where T : struct
    {
        DirtyTracker tracker;
        ArraySegment<byte> originalBytes;

        public NullableSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
        {
            this.tracker = tracker;
            this.originalBytes = originalBytes;
        }

        public Nullable<T> Value
        {
            get
            {
                var array = originalBytes.Array;
                int _;
                return Formatters.Formatter<Nullable<T>>.Default.Deserialize(ref array, originalBytes.Offset, tracker, out _);
            }
            set
            {
                var array = originalBytes.Array;
                Formatters.Formatter<Nullable<T>>.Default.Serialize(ref array, originalBytes.Offset, value);
            }
        }
    }
}