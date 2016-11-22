using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ZeroFormatter.Comparers;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;
using RuntimeUnitTestToolkit;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class DictionarySegmentTest
    {


        DictionarySegment<DefaultResolver, int, string> CreateFresh()
        {
            ILazyDictionary<int, string> sampleDict = new Dictionary<int, string>()
            {
                {1234, "aaaa" },
                {-1, "mainasu" },
                {-42432, "more mainasu" },
                {99999, "plus plus" }
            }.AsLazyDictionary();
            return ZeroFormatter.ZeroFormatterSerializer.Convert(sampleDict) as DictionarySegment<DefaultResolver, int, string>;
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
            dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).IsCollection(
                Tuple.Create(-42432, "more mainasu"),
                Tuple.Create(-1, "mainasu"),
                Tuple.Create(1234, "aaaa"),
                Tuple.Create(99999, "plus plus"));


            dict[1234] = "zzz";
            dict[1234].Is("zzz");
            dict.Count.Is(4);
            dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).IsCollection(
                Tuple.Create(-42432, "more mainasu"),
                Tuple.Create(-1, "mainasu"),
                Tuple.Create(1234, "zzz"),
                Tuple.Create(99999, "plus plus"));

            dict.Add(9999, "hogehoge");
            dict[9999].Is("hogehoge");
            dict.Count.Is(5);
            dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).IsCollection(
                Tuple.Create(-42432, "more mainasu"),
                Tuple.Create(-1, "mainasu"),
                Tuple.Create(1234, "zzz"),
                Tuple.Create(9999, "hogehoge"),
                Tuple.Create(99999, "plus plus"));

            dict.Clear();
            dict.Count.Is(0);
            dict.ToArray().IsEmpty();
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

            dict.OrderBy(x => x.Key).Select(x => Tuple.Create(x.Key, x.Value)).IsCollection(
                Tuple.Create(-1, "mainus one"),
                Tuple.Create(9991, "hogehoge one"));
        }


        public void ModeLazyAll()
        {
            ILazyDictionary<int, string> dict = new Dictionary<int, string>
            {
                {1, "a" },
                {2, "b" },
                {3, "c" }
            }.AsLazyDictionary();

            var immediateLazySegment = ZeroFormatterSerializer.Convert(dict);
            var segment = immediateLazySegment as IZeroFormatterSegment;

            immediateLazySegment[1].Is("a");
            immediateLazySegment[2].Is("b");
            immediateLazySegment[3].Is("c");

            segment.CanDirectCopy().IsTrue();
            var moreSerialize = ZeroFormatterSerializer.Convert(immediateLazySegment, true);
            (moreSerialize as IZeroFormatterSegment).CanDirectCopy().IsTrue();

            moreSerialize.Add(10, "hugahuga");
            (moreSerialize as IZeroFormatterSegment).CanDirectCopy().IsFalse();
            moreSerialize[10].Is("hugahuga");

            var lastSerialize = ZeroFormatterSerializer.Convert(moreSerialize, true);

            lastSerialize[1].Is("a");
            lastSerialize[2].Is("b");
            lastSerialize[3].Is("c");
            moreSerialize[10].Is("hugahuga");
        }
    }
}
