using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZeroFormatter.Tests
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
        public virtual IDictionary<int, int> MyProperty1 { get; set; }
        [Index(1)]
        public virtual IList<int> MyProperty2 { get; set; }
        [Index(2)]
        public virtual IList<string> MyProperty3 { get; set; }
        [Index(3)]
        public virtual ILookup<int, int> MyProperty4 { get; set; }
        [Index(4)]
        public virtual MyFormatClass MyProperty5 { get; set; }
        [Index(5)]
        public virtual byte[] MyProperty6 { get; set; }
        [Index(6)]
        public virtual string MyProperty7 { get; set; }
        [Index(7)]
        public virtual IDictionary<int, int> MyProperty8 { get; set; }
    }

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
    }
}
