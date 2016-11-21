using System.Threading;

namespace ZeroFormatter
{
    // Note:Can we change to struct? like CancellationTokenSource, CreateLinkedTokenSource...

    public sealed class DirtyTracker
    {
        internal static readonly DirtyTracker NullTracker = new DirtyTracker();

        readonly DirtyTracker parent;

        public bool IsDirty { get; private set; }

        public DirtyTracker()
        {
            this.IsDirty = false;
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