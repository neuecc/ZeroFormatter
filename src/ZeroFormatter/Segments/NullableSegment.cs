using System;

namespace ZeroFormatter.Format
{
    // is this needs?

    // Layout: [isNull:bool][t format...]
    public struct NullableSegment<T>
        where T : struct
    {
        ArraySegment<byte> originalBytes;

        public NullableSegment(ArraySegment<byte> originalBytes)
        {
            this.originalBytes = originalBytes;
        }

        public Nullable<T> Value
        {
            get
            {
                var array = originalBytes.Array;
                return Formatters.Formatter<Nullable<T>>.Instance.Deserialize(ref array, originalBytes.Offset);
            }
            set
            {
                var array = originalBytes.Array;
                Formatters.Formatter<Nullable<T>>.Instance.Serialize(ref array, originalBytes.Offset, value);
            }
        }
    }
}