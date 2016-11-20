using RuntimeUnitTestToolkit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter.Segments;
using Sandbox.Shared;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class VersioningTest
    {
        [TestMethod]
        public void Versioning1()
        {
            var standard = ZeroFormatterSerializer.Serialize(new Standard { MyProperty0 = 100, MyProperty3 = 300 });

            var large = ZeroFormatterSerializer.Deserialize<Large>(standard);


            large.MyProperty5.Is(0);
            large.MyProperty6.IsNull();
            large.MyProperty10.IsNull();
            large.MyProperty11.IsNull();
            large.MyProperty13.IsNull();
            large.MyProperty15.IsNull();

            large.MyProperty0 = 99;
            large.MyProperty3 = 49;
            large.MyProperty5 = 999;
            large.MyProperty6 = "hugahuga";
            large.MyProperty10 = new List<int> { 1, 10, 100 };
            large.MyProperty11 = Enumerable.Range(1, 10).ToLookup(x => x % 2 == 0);
            large.MyProperty13 = new List<string> { "a", "bcde" };
            large.MyProperty15 = Enumerable.Range(1, 10).ToDictionary(x => x.ToString());

            var convert = ZeroFormatterSerializer.Convert(large);


            convert.MyProperty0.Is(99);
            convert.MyProperty3.Is(49);
            convert.MyProperty5.Is(999);
            convert.MyProperty6.Is("hugahuga");
            convert.MyProperty10.IsCollection(new List<int> { 1, 10, 100 });
            convert.MyProperty11[true].IsCollection(2, 4, 6, 8, 10);
            convert.MyProperty13.IsCollection(new List<string> { "a", "bcde" });
            convert.MyProperty15["3"].Is(3);
        }
    }
}
