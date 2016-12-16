using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class EnumArraySerialize
    {
        [TestMethod]
        public void EnumArray()
        {
            var xs = new[] { StandardEnum.A, StandardEnum.B, StandardEnum.C };
            ZeroFormatterSerializer.Convert(xs, true).Is(StandardEnum.A, StandardEnum.B, StandardEnum.C);

            IList<StandardEnum> ys = new List<StandardEnum> { StandardEnum.A, StandardEnum.B, StandardEnum.C };
            ZeroFormatterSerializer.Convert(ys, true).Is(StandardEnum.A, StandardEnum.B, StandardEnum.C);

            List<StandardEnum> zs = new List<StandardEnum> { StandardEnum.A, StandardEnum.B, StandardEnum.C };
            ZeroFormatterSerializer.Convert(zs, true).Is(StandardEnum.A, StandardEnum.B, StandardEnum.C);
        }
    }
}
