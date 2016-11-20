using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using ZeroFormatter.Comparers;

namespace ZeroFormatter.Tests
{
    public enum MyGlobal
    {
        A, B, C
    }

    public class EqTest
    {
        [Fact]
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
