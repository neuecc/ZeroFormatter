using System.Threading;

namespace ZeroFormatter.Segments
{
    // Note:Can we change to struct? like CancellationTokenSource, CreateLinkedTokenSource...

    public sealed class DirtyTracker
    {
        readonly DirtyTracker parent;

        public int RootOffset { get; private set; }
        public bool IsDirty { get; private set; }

        public DirtyTracker(int rootOffset)
        {
            this.RootOffset = rootOffset;
            this.IsDirty = false;
        }

        DirtyTracker(DirtyTracker parent)
        {
            this.parent = parent;
            IsDirty = parent.IsDirty;
            RootOffset = parent.RootOffset;
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