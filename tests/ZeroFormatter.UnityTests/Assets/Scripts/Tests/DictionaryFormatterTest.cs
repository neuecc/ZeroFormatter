using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuntimeUnitTestToolkit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class DictionaryFormatterTest
    {
        [TestMethod]
        public void DictionarySerialize()
        {
            {
                IDictionary<int, int> xs = new Dictionary<int, int> { { 1, 120 }, { 3431242, 532 }, { 32, 5 } };

                var r = ZeroFormatterSerializer.Serialize(xs);
                var v = ZeroFormatterSerializer.Deserialize<IDictionary<int, int>>(r);
                v.OrderBy(x => x.Key)
                    .Select(x => Tuple.Create(x.Key, x.Value))
                    .IsCollection(
                        Tuple.Create(1, 120),
                        Tuple.Create(32, 5),
                        Tuple.Create(3431242, 532));
            }
            {
                IDictionary<string, string> xs = new Dictionary<string, string>
                {
                    { "abcde", "hogehoge" },
                    { "あいうえお", "かきくけこ" },
                    { "tt", "tz" },
                    { "z!?fdsf<>", "hugazer0^-zsdf" },
                    { "zfweb", "linqfsd" },
                };

                var r = ZeroFormatterSerializer.Serialize(xs);
                var v = ZeroFormatterSerializer.Deserialize<IDictionary<string, string>>(r);
                v.Count.Is(5);
                v["abcde"].Is("hogehoge");
                v["あいうえお"].Is("かきくけこ");
                v["tt"].Is("tz");
                v["z!?fdsf<>"].Is("hugazer0^-zsdf");
                v["zfweb"].Is("linqfsd");
            }
        }
    }
}