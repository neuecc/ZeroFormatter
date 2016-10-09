using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ZeroFormatter.Collections;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class DictionarySegmentTest
    {
        DictionarySegment<int, string> CreateFresh()
        {
            IDictionary<int, string> sampleDict = new Dictionary<int, string>()
            {
                {1234, "aaaa" },
                {-1, "mainasu" },
                {-42432, "more mainasu" },
                {99999, "plus plus" }
            };
            var bytes = ZeroFormatter.Serialize(sampleDict);

            return new DictionarySegment<int, string>(new DirtyTracker(), new ArraySegment<byte>(bytes, 0, bytes.Length));
        }

        [TestMethod]
        public void DictionarySegment()
        {
            var dict = CreateFresh();

            dict[1234].Is("aaaa");
            dict[-1].Is("mainasu");
            dict[-42432].Is("more mainasu");
            dict[99999].Is("plus plus");
            dict.Count.Is(4);
            dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).Is(
                Tuple.Create(-42432, "more mainasu"),
                Tuple.Create(-1, "mainasu"),
                Tuple.Create(1234, "aaaa"),
                Tuple.Create(99999, "plus plus"));


            dict[1234] = "zzz";
            dict[1234].Is("zzz");
            dict.Count.Is(4);
            dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).Is(
                Tuple.Create(-42432, "more mainasu"),
                Tuple.Create(-1, "mainasu"),
                Tuple.Create(1234, "zzz"),
                Tuple.Create(99999, "plus plus"));

            dict.Add(9999, "hogehoge");
            dict[9999].Is("hogehoge");
            dict.Count.Is(5);
            dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).Is(
                Tuple.Create(-42432, "more mainasu"),
                Tuple.Create(-1, "mainasu"),
                Tuple.Create(1234, "zzz"),
                Tuple.Create(9999, "hogehoge"),
                Tuple.Create(99999, "plus plus"));

            dict.Clear();
            dict.Count.Is(0);
            dict.ToArray().IsZero();
            dict.Add(1234, "aaaa");
            dict.Add(-1, "mainus one");
            dict.Add(9991, "hogehoge one");
            dict.ContainsKey(1234).IsTrue();
            dict.ContainsKey(-9999).IsFalse();
            dict.ContainsValue("aaaa").IsTrue();
            dict.ContainsValue("not not").IsFalse();

            dict.Remove(1234).IsTrue();
            dict.Remove(-30).IsFalse();

            dict.ToArray().Length.Is(2); // CopyTo

            dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).Is(
                Tuple.Create(-1, "mainus one"),
                Tuple.Create(9991, "hogehoge one"));
        }
    }
}
