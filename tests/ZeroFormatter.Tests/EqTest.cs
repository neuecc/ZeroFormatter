using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeroFormatter.Comparers;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class EqTest
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
