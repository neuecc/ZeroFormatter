using System;
using RuntimeUnitTestToolkit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class NullCheckTest
    {
 

        [TestMethod]
        public void NullCheck()
        {
            // Segment:

            var bytes = ZeroFormatterSerializer.Serialize<IDictionary<int, int>>(null);
            ZeroFormatterSerializer.Deserialize<IDictionary<int, int>>(bytes).IsNull();

            bytes = ZeroFormatterSerializer.Serialize<IList<int>>(null);
            ZeroFormatterSerializer.Deserialize<IList<int>>(bytes).IsNull();

            bytes = ZeroFormatterSerializer.Serialize<IList<string>>(null);
            ZeroFormatterSerializer.Deserialize<IList<string>>(bytes).IsNull();

            bytes = ZeroFormatterSerializer.Serialize<ILookup<int, int>>(null);
            ZeroFormatterSerializer.Deserialize<ILookup<int, int>>(bytes).IsNull();

            bytes = ZeroFormatterSerializer.Serialize<MyFormatClass>(null);
            ZeroFormatterSerializer.Deserialize<MyFormatClass>(bytes).IsNull();

            bytes = ZeroFormatterSerializer.Serialize<byte[]>(null);
            ZeroFormatterSerializer.Deserialize<byte[]>(bytes).IsNull();

            bytes = ZeroFormatterSerializer.Serialize<string>(null);
            ZeroFormatterSerializer.Deserialize<string>(bytes).IsNull();
        }

        [TestMethod]
        public void NullCheck2()
        {
            var c = new AllNullClass();

            var c2 = ZeroFormatterSerializer.Convert<AllNullClass>(c);

            c2.MyProperty1.IsNull();
            c2.MyProperty2.IsNull();
            c2.MyProperty3.IsNull();
            c2.MyProperty4.IsNull();
            c2.MyProperty5.IsNull();
            c2.MyProperty6.IsNull();
            c2.MyProperty7.IsNull();
            c2.MyProperty8.IsNull();

            var notnull = new AllNullClass
            {
                MyProperty1 = new Dictionary<int, string> { { 10, "hoge" }, { 999, "hugahuga" }, { 10000, null } },
                MyProperty2 = new List<int> { 1, 2, 3, 4, 5 },
                MyProperty3 = new List<string> { "a", "b", "c" },
                MyProperty4 = Enumerable.Range(1, 10).ToLookup(x => x % 2 == 0),
                MyProperty5 = new MyFormatClass() { MyProperty = 1000 },
                MyProperty6 = new byte[] { 1, 10, 100 },
                MyProperty7 = "aaa",
                MyProperty8 = new Dictionary<string, int> { { "hoge", 10 } }
            };

            var nc = ZeroFormatterSerializer.Convert<AllNullClass>(notnull);

            nc.MyProperty1.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).IsCollection(
                Tuple.Create(10, "hoge"), Tuple.Create(999, "hugahuga"), Tuple.Create(10000, (string)null));
            nc.MyProperty2.IsCollection(1, 2, 3, 4, 5);
            nc.MyProperty3.IsCollection("a", "b", "c");
            nc.MyProperty4[true].IsCollection(2, 4, 6, 8, 10);
            nc.MyProperty4[false].IsCollection(1, 3, 5, 7, 9);
            nc.MyProperty5.MyProperty.Is(1000);
            nc.MyProperty6.IsCollection((byte)1, (byte)10, (byte)100);
            nc.MyProperty7.Is("aaa");
            nc.MyProperty8.Count.Is(1);
            nc.MyProperty8["hoge"].Is(10);
        }
    }
}
