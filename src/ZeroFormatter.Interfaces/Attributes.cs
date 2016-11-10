using System;

namespace ZeroFormatter
{
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

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UnionAttribute : Attribute
    {
        public Type[] SubTypes { get; private set; }

        public UnionAttribute(params Type[] subTypes)
        {
            this.SubTypes = subTypes;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UnionKeyAttribute : Attribute
    {

    }

    public sealed class PreserveAttribute : Attribute
    {
        public bool AllMembers;
        public bool Conditional;
    }
}