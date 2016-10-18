using System;
using Xunit;

namespace ZeroFormatter.DotNetCore.Tests
{
    public class RecursiveCheck
    {
        [ZeroFormattable]
        public class MyClass
        {
            [Index(0)]
            public virtual int Hoge { get; set; }
            [Index(1)]
            public virtual MyClass Rec { get; set; }
        }


        [Fact]
        public void RecCheck()
        {
            AssertEx.Throws<InvalidOperationException>(() =>
                ZeroFormatterSerializer.Serialize(new MyClass() { Hoge = 10, Rec = new MyClass { Hoge = 100, Rec = null } }))
                .Message.Contains("Circular reference").IsTrue();
        }
    }
}
