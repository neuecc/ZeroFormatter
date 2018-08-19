using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeroFormatter.Formatters;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [ZeroFormattable]
    public class DictionaryValueTest
    {
        [Index(0)]
        public virtual Dictionary<string, string> NestDict { get; set; }
        [Index(1)]
        public virtual int Int { get; set; }
    }

    [TestClass]
    public class CacheSegmentTest
    {
        [TestMethod]
        public void Dictionary()
        {
            var _ = ZeroFormatterSerializer.Serialize(
                new Dictionary<string, DictionaryValueTest>
                {
                    {"hoge", new DictionaryValueTest{Int=1}},
                    {"foo", new DictionaryValueTest{Int=2}}
                });
            var size = _.Length;
            var dict = ZeroFormatterSerializer.Deserialize<Dictionary<string, DictionaryValueTest>>(_);

            ZeroFormatterSerializer.Serialize(dict).Length.Is(size);

            dict["hoge"] = new DictionaryValueTest{Int=1};

            ZeroFormatterSerializer.Serialize(dict).Length.Is(size);
        }
    }
}