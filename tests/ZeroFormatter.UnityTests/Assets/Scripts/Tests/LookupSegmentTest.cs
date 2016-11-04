using System;
using RuntimeUnitTestToolkit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ZeroFormatter.Segments;



namespace ZeroFormatter.Tests
{
    [TestClass]
    public class LookupSegmentTest
    {
        
        [TestMethod]
        public void LookupSegment()
        {
            var lookup = Enumerable.Range(1, 10)
                .ToLookup(x => x % 2 == 0);
            var bytes = ZeroFormatterSerializer.Serialize(lookup);

            int _;
            var segment = LookupSegment<bool, int>.Create(new DirtyTracker(0), bytes, 0, LookupSegmentMode.Immediate, out _);

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



        [TestMethod]
        public void Immediate()
        {
            {
                ILookup<bool, int> lookup = Enumerable.Range(1, 10).ToLookup(x => x % 2 == 0);
                var hugahuga = ZeroFormatterSerializer.Convert(lookup, true);
                hugahuga[true].IsCollection(2, 4, 6, 8, 10);
                hugahuga[false].IsCollection(1, 3, 5, 7, 9);

                var onemore = ZeroFormatterSerializer.Convert(hugahuga, true);
                onemore[true].IsCollection(2, 4, 6, 8, 10);
                onemore[false].IsCollection(1, 3, 5, 7, 9);
            }
            {
                ILazyLookup<bool, int> lookup = Enumerable.Range(1, 10).ToLookup(x => x % 2 == 0).AsLazyLookup();
                var hugahuga = ZeroFormatterSerializer.Convert(lookup, true);
                hugahuga[true].IsCollection(2, 4, 6, 8, 10);
                hugahuga[false].IsCollection(1, 3, 5, 7, 9);

                var onemore = ZeroFormatterSerializer.Convert(hugahuga, true);
                onemore[true].IsCollection(2, 4, 6, 8, 10);
                onemore[false].IsCollection(1, 3, 5, 7, 9);
            }
        }
    }


}
