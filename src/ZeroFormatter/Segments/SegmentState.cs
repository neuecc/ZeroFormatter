namespace ZeroFormatter.Segments
{
    /// <summary>
    /// Mutable Segment State
    /// </summary>
    public enum SegmentState
    {
        Original = 0,
        Cached = 1,
        Dirty = 2
    }

    public static class SegmentStateExtensions
    {
        public static bool CanDirectCopy(this SegmentState state)
        {
            return (state == SegmentState.Original) || (state == SegmentState.Cached);
        }
    }
}