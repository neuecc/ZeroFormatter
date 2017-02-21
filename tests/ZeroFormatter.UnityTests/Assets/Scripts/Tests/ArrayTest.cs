using Sandbox.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuntimeUnitTestToolkit;

namespace ZeroFormatter.Tests
{
    public class ArrayTest
    {
        public void EnumArray()
        {
            var xs = new[] { StandardEnum.A, StandardEnum.B, StandardEnum.C };
            ZeroFormatterSerializer.Convert(xs, true).IsCollection(StandardEnum.A, StandardEnum.B, StandardEnum.C);

            IList<StandardEnum> ys = new List<StandardEnum> { StandardEnum.A, StandardEnum.B, StandardEnum.C };
            ZeroFormatterSerializer.Convert(ys, true).IsCollection(StandardEnum.A, StandardEnum.B, StandardEnum.C);

            List<StandardEnum> zs = new List<StandardEnum> { StandardEnum.A, StandardEnum.B, StandardEnum.C };
            ZeroFormatterSerializer.Convert(zs, true).IsCollection(StandardEnum.A, StandardEnum.B, StandardEnum.C);
        }
    }
}
