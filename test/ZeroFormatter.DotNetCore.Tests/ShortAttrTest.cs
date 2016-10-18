using System;
using Xunit;
using ZeroFormatter.DotNetCore;

namespace AnotherNamespace
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal class ZeroFormattableAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class IndexAttribute : Attribute
    {
        public int Index { get; private set; }

        public IndexAttribute(int index)
        {
            this.Index = index;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class IgnoreFormatAttribute : Attribute
    {
    }
}

namespace ZeroFormatter.Tests
{
    [AnotherNamespace.ZeroFormattable]
    public class AttrSerializableTarget
    {
        [AnotherNamespace.Index(0)]
        public virtual int MyProperty0 { get; set; }
        [AnotherNamespace.IgnoreFormat]
        public virtual int MyProperty_ { get; set; }
        [AnotherNamespace.Index(1)]
        public virtual string MyProperty1 { get; set; }
    }


    public class ShortAttrTest
    {
        [Fact]
        public void ShortAttrSerialize()
        {
            var c = new AttrSerializableTarget { MyProperty0 = 100, MyProperty_ = 9999, MyProperty1 = "aaa" };
            var v = ZeroFormatterSerializer.Convert(c);

            v.MyProperty0.Is(100);
            v.MyProperty_.Is(0);
            v.MyProperty1.Is("aaa");
        }
    }
}
