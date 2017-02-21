#if !UNITY

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class DictionaryFormatterTest
    {
        [ZeroFormattable]
        public class InDictionary
        {
            [Index(0)]
            public virtual IDictionary<string, int> D1 { get; set; }
            [Index(1)]
            public virtual ILazyDictionary<string, int> D2 { get; set; }
            [Index(2)]
            public virtual IReadOnlyDictionary<string, int> D3 { get; set; }
            [Index(3)]
            public virtual ILazyReadOnlyDictionary<string, int> D4 { get; set; }
        }

        [TestMethod]
        public void DictionarySerialize()
        {
            {
                IDictionary<int, int> xs = new Dictionary<int, int> { { 1, 120 }, { 3431242, 532 }, { 32, 5 } };

                var r = ZeroFormatterSerializer.Serialize(xs);
                var v = ZeroFormatterSerializer.Deserialize<IDictionary<int, int>>(r);
                v.OrderBy(x => x.Key)
                    .Select(x => Tuple.Create(x.Key, x.Value))
                    .Is(
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

        [TestMethod]
        public void Serialize2()
        {
            var d = new InDictionary
            {
                D1 = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } },
                D2 = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } }.AsLazyDictionary(),
                D3 = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } },
                D4 = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } }.AsLazyReadOnlyDictionary(),
            };

            var c = ZeroFormatterSerializer.Convert(d);

            var props = c.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            c.D1["a"].Is(1); c.D1["b"].Is(2);
            c.D2["a"].Is(1); c.D2["b"].Is(2);
            c.D2["a"].Is(1); c.D2["b"].Is(2);
            c.D2["a"].Is(1); c.D2["b"].Is(2);
        }

        [TestMethod]
        public void FormatterTracking()
        {
            var cleanBytes = ZeroFormatterSerializer.Serialize(new ClassA
            {
                ValueA = new Dictionary<string, ClassB>
                {
                    { "Mogemoge", new ClassB { Value = "Fugafuga" } },
                },
                ValueB = "HogeHoge",
                ValueC = 10000
            });

            // case of dictionary
            {
                var obj1 = ZeroFormatterSerializer.Deserialize<ClassA>(cleanBytes);

                ZeroFormatterSerializer.Convert(obj1).ValueA["Mogemoge"].Value.Is("Fugafuga");
                obj1.ValueA["Mogemoge"].Value = "hugahgua";

                ZeroFormatterSerializer.Convert(obj1).ValueA["Mogemoge"].Value.Is("hugahgua");
            }

            // case of string
            {
                var obj1 = ZeroFormatterSerializer.Deserialize<ClassA>(cleanBytes);

                ZeroFormatterSerializer.Convert(obj1).ValueB.Is("HogeHoge");
                obj1.ValueB = "ABCDEFG";

                ZeroFormatterSerializer.Convert(obj1).ValueB.Is("ABCDEFG");
                ZeroFormatterSerializer.Convert(obj1).ValueB.Is("ABCDEFG");
            }

            // case of int
            {
                var obj1 = ZeroFormatterSerializer.Deserialize<ClassA>(cleanBytes);

                ZeroFormatterSerializer.Convert(obj1).ValueC.Is(10000);
                obj1.ValueC = 9999;

                ZeroFormatterSerializer.Convert(obj1).ValueC.Is(9999);
            }
        }

        [ZeroFormattable]
        public class ClassA
        {
            [Index(0)]
            public virtual Dictionary<string, ClassB> ValueA { get; set; }

            [Index(1)]
            public virtual string ValueB { get; set; }


            [Index(2)]
            public virtual int ValueC { get; set; }
        }

        [ZeroFormattable]
        public class ClassB
        {
            [Index(0)]
            public virtual string Value { get; set; }
        }
    }
}

#endif