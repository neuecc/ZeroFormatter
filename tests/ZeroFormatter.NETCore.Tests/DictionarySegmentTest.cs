using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using ZeroFormatter.Comparers;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.DotNetCore.Tests
{
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
            var bytes = ZeroFormatterSerializer.Serialize(sampleDict);

            int _;
            return DictionarySegment<DefaultResolver, int, string>.Create(new DirtyTracker(), bytes, 0, out _);
        }

        [Fact]
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

        [Fact]
        public void CollisionCheck()
        {
            Formatter<DefaultResolver, HashCollision>.Register(new TestFormatter());
            ZeroFormatterEqualityComparer<HashCollision>.Register(new HashCollisionEqualityComparer());

            var dict = new DictionarySegment<DefaultResolver, HashCollision, int>(new DirtyTracker(), 5);
            dict.Add(new HashCollision(10, 999), 6);
            dict.Add(new HashCollision(99, 999), 9);

            dict[new HashCollision(10, 999)].Is(6);
            dict[new HashCollision(99, 999)].Is(9);
        }
    }

    public class HashCollision
    {
        public readonly int identifier;
        public readonly int hashCode;

        public HashCollision(int identifier, int hashCode)
        {
            this.identifier = identifier;
            this.hashCode = hashCode;
        }
    }

    public class TestFormatter : Formatter<DefaultResolver, HashCollision>
    {
        public override HashCollision Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var a = BinaryUtil.ReadInt32(ref bytes, offset);
            var b = BinaryUtil.ReadInt32(ref bytes, offset + 4);
            byteSize = 8;
            return new HashCollision(a, b);
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, HashCollision value)
        {
            BinaryUtil.WriteInt32(ref bytes, offset, value.identifier);
            BinaryUtil.WriteInt32(ref bytes, offset, value.hashCode);
            return 8;
        }
    }

    public class HashCollisionEqualityComparer : IEqualityComparer<HashCollision>
    {
        public bool Equals(HashCollision x, HashCollision y)
        {
            return x.identifier.Equals(y.identifier);
        }

        public int GetHashCode(HashCollision obj)
        {
            return obj.hashCode.GetHashCode();
        }
    }
}
