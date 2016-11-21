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

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class UnionAttribute : Attribute
    {
        public Type[] SubTypes { get; private set; }
        public Type FallbackType { get; private set; }

        public UnionAttribute(params Type[] subTypes)
        {
            this.SubTypes = subTypes;
        }

        public UnionAttribute(Type[] subTypes, Type fallbackType)
        {
            this.SubTypes = subTypes;
            this.FallbackType = fallbackType;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UnionKeyAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class DynamicUnionAttribute : Attribute
    {

    }

    public sealed class PreserveAttribute : Attribute
    {
        public bool AllMembers;
        public bool Conditional;
    }
}