using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ZeroFormatter.DotNetCore.Tests
{
    [ZeroFormattable]
    public class MyFormatClass
    {
        [Index(0)]
        public virtual int MyProperty { get; set; }
    }


    [ZeroFormattable]
    public class AllNullClass
    {
        [Index(0)]
        public virtual IDictionary<int, string> MyProperty1 { get; set; }
        [Index(1)]
        public virtual IList<int> MyProperty2 { get; set; }
        [Index(2)]
        public virtual IList<string> MyProperty3 { get; set; }
        [Index(3)]
        public virtual ILookup<bool, int> MyProperty4 { get; set; }
        [Index(4)]
        public virtual MyFormatClass MyProperty5 { get; set; }
        [Index(5)]
        public virtual byte[] MyProperty6 { get; set; }
        [Index(6)]
        public virtual string MyProperty7 { get; set; }
        [Index(7)]
        public virtual IDictionary<string, int> MyProperty8 { get; set; }
    }

    public class NullCheckTest
    {
        [Fact]
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

        [Fact]
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

            nc.MyProperty1.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).Is(
                Tuple.Create(10, "hoge"), Tuple.Create(999, "hugahuga"), Tuple.Create(10000, (string)null));
            nc.MyProperty2.Is(1, 2, 3, 4, 5);
            nc.MyProperty3.Is("a", "b", "c");
            nc.MyProperty4[true].Is(2, 4, 6, 8, 10);
            nc.MyProperty4[false].Is(1, 3, 5, 7, 9);
            nc.MyProperty5.MyProperty.Is(1000);
            nc.MyProperty6.Is((byte)1, (byte)10, (byte)100);
            nc.MyProperty7.Is("aaa");
            nc.MyProperty8.Count.Is(1);
            nc.MyProperty8["hoge"].Is(10);
        }
    }
}
