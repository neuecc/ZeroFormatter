using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class LookupSegmentTest
    {
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            var test = new LookupSegmentTest();

            UnitTestRoot.AddTest("LookupSegmentTest", "LookupSegment", test.LookupSegment);
        }

        [TestMethod]
        public void LookupSegment()
        {
            var lookup = Enumerable.Range(1, 10)
                .ToLookup(x => x % 2 == 0);
            var bytes = ZeroFormatterSerializer.Serialize(lookup);

            int _;
            var segment = LookupSegment<bool, int>.Create(new DirtyTracker(), bytes, 0, out _);

            segment[true].IsCollection(2, 4, 6, 8, 10);
            segment[false].IsCollection(1, 3, 5, 7, 9);

            bool isFirst = true;
            foreach (var g in segment.OrderByDescending(x => x.Key))
            {
                if (isFirst)
                {
                    isFirst = false;
                    g.Key.IsTrue();
                    g.AsEnumerable().IsCollection(2, 4, 6, 8, 10);
                }
                else
                {
                    g.Key.IsFalse();
                    g.AsEnumerable().IsCollection(1, 3, 5, 7, 9);
                }
            }
        }
    }
}
