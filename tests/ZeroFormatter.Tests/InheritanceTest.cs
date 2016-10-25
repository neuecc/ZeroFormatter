using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class InheritanceTest
    {
        [ZeroFormattable]
        public class TestBase
        {
            [Index(0)]
            public virtual int MyProperty { get; set; }
        }

        [ZeroFormattable]
        public class Test2 : TestBase
        {
            [Index(1)]
            public virtual int MyProperty1 { get; set; }
        }

        [TestMethod]
        public void MyTestMethod()
        {

            var t2 = new Test2 { MyProperty = 100, MyProperty1 = 99 };

            var t = ZeroFormatterSerializer.Convert(t2);
            t.MyProperty.Is(100);
            t.MyProperty1.Is(99);
        }
    }
}
