namespace ZeroFormatter.Segments
{
    public sealed class DirtyTracker
    {
        public bool IsDirty { get; private set; }

        public DirtyTracker()
        {
            IsDirty = false;
        }

        public void Dirty()
        {
            IsDirty = true;
        }

        public void Clear()
        {
            IsDirty = false;
        }
    }
}