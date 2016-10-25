using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using RuntimeUnitTestToolkit;
using System.Text;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class InheritanceTest
    {
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
