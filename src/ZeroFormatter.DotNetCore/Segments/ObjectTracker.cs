namespace ZeroFormatter.DotNetCore.Segments
{
    // Note:Can we change to struct? like CancellationTokenSource, CreateLinkedTokenSource...

    public sealed class DirtyTracker
    {
        readonly DirtyTracker parent;
        public bool IsDirty { get; private set; }

        public DirtyTracker()
        {
            IsDirty = false;
        }

        DirtyTracker(DirtyTracker parent)
        {
            this.parent = parent;
            IsDirty = parent.IsDirty;
        }

        public void Dirty()
        {
            IsDirty = true;
            if (parent != null)
            {
                parent.Dirty();
            }
        }

        public DirtyTracker CreateChild()
        {
            return new DirtyTracker(this);
        }
    }
}