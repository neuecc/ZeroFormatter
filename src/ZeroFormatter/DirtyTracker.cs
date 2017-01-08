using System.Threading;

namespace ZeroFormatter
{
    // Note:Can we change to struct? like CancellationTokenSource, CreateLinkedTokenSource...

    public class DirtyTracker
    {
        public static readonly DirtyTracker NullTracker = new NullDirtyTracker();

        readonly DirtyTracker parent;

        public virtual bool IsDirty { get; private set; }

        public DirtyTracker()
        {
            this.IsDirty = false;
        }

        DirtyTracker(DirtyTracker parent)
        {
            this.parent = parent;
            IsDirty = parent.IsDirty;
        }

        public virtual void Dirty()
        {
            IsDirty = true;
            if (parent != null)
            {
                parent.Dirty();
            }
        }

        public virtual DirtyTracker CreateChild()
        {
            return new DirtyTracker(this);
        }

        sealed class NullDirtyTracker : DirtyTracker
        {
            public NullDirtyTracker()
                : base()
            {

            }

            public override bool IsDirty
            {
                get
                {
                    return false;
                }
            }

            public override DirtyTracker CreateChild()
            {
                return this;
            }

            public override void Dirty()
            {
            }
        }
    }
}