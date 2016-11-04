using System;

namespace ZeroFormatter
{
    // We need to use Analyazer so can't use DataContractAttribute.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class ZeroFormattableAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class IndexAttribute : Attribute
    {
        public int Index { get; private set; }

        public IndexAttribute(int index)
        {
            this.Index = index;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class IgnoreFormatAttribute : Attribute
    {
    }

    public sealed class PreserveAttribute : Attribute
    {
        public bool AllMembers;
        public bool Conditional;
    }
}