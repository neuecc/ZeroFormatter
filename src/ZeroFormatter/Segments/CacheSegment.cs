using System;
using System.Reflection;
using System.Linq;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using System.Collections;
using System.Collections.Generic;

namespace ZeroFormatter.Segments
{
    /// <summary>
    /// Mutable Segment State
    /// </summary>
    internal enum SegmentState
    {
        Original = 0,
        Cached = 1,
        Dirty = 2
    }

    public struct CacheSegment<TTypeResolver, T> : IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        readonly DirtyTracker tracker;
        SegmentState state;
        ArraySegment<byte> serializedBytes;
        T cached;

        public CacheSegment(DirtyTracker tracker, ArraySegment<byte> originalBytes)
        {
            this.tracker = tracker.CreateChild();
            this.state = SegmentState.Original;
            this.serializedBytes = originalBytes;
            this.cached = default(T);

            if (originalBytes.Array == null)
            {
                this.state = SegmentState.Dirty;
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
                        this.cached = Formatter<TTypeResolver, T>.Default.Deserialize(ref array, serializedBytes.Offset, tracker, out _);
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
            if (Formatter<TTypeResolver, T>.Default.NoUseDirtyTracker)
            {
                return (state == SegmentState.Original || state == SegmentState.Cached);
            }
            else
            {
                return state == SegmentState.Original;
            }
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return serializedBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (targetBytes == null) throw new ArgumentNullException("targetBytes");

            if (!CanDirectCopy())
            {
                var formatter = Formatter<TTypeResolver, T>.Default;
                if (formatter.NoUseDirtyTracker)
                {
                    byte[] newBytes = null;
                    var length = formatter.Serialize(ref newBytes, 0, Value);
                    serializedBytes = new ArraySegment<byte>(newBytes, 0, newBytes.Length);
                    state = SegmentState.Cached;
                }
                else
                {
                    // direct direct write.
                    return formatter.Serialize(ref targetBytes, offset, Value);
                }
            }

            BinaryUtil.EnsureCapacity(ref targetBytes, offset, serializedBytes.Count);
            Buffer.BlockCopy(serializedBytes.Array, serializedBytes.Offset, targetBytes, offset, serializedBytes.Count);
            return serializedBytes.Count;
        }
    }
}