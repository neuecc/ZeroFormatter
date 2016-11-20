using RuntimeUnitTestToolkit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter.Segments;
using Sandbox.Shared;
using ZeroFormatter.Comparers;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class EqualityCompTest
    {
        [TestMethod]
        public void Eq1()
        {
            int? x = 100;
            int? y = 100;
            ZeroFormatterEqualityComparer<int?>.Default.Equals(x, y).IsTrue();

            ZeroFormatterEqualityComparer<MyGlobal?>.Default.Equals(MyGlobal.A, MyGlobal.B).IsFalse();
            ZeroFormatterEqualityComparer<MyGlobal?>.Default.Equals(MyGlobal.A, MyGlobal.A).IsTrue();
        }
    }
}
