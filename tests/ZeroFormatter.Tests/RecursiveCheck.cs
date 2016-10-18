using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
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


        [TestMethod]
        public void RecCheck()
        {
            AssertEx.Throws<InvalidOperationException>(() =>
                ZeroFormatter.ZeroFormatterSerializer.Serialize(new MyClass() { Hoge = 10, Rec = new MyClass { Hoge = 100, Rec = null } }))
                .Message.Contains("Circular reference").IsTrue();
        }
    }
}
