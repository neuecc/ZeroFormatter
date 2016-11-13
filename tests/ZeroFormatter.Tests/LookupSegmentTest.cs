using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ZeroFormatter.Segments;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class LookupSegmentTest
    {
        [TestMethod]
        public void LookupSegment()
        {
            ILazyLookup<bool, int> lookup = Enumerable.Range(1, 10).ToLookup(x => x % 2 == 0).AsLazyLookup();
            var segment = ZeroFormatterSerializer.Convert(lookup);

            segment[true].Is(2, 4, 6, 8, 10);
            segment[false].Is(1, 3, 5, 7, 9);

            bool isFirst = true;
            foreach (var g in segment.OrderByDescending(x => x.Key))
            {
                if (isFirst)
                {
                    isFirst = false;
                    g.Key.IsTrue();
                    g.AsEnumerable().Is(2, 4, 6, 8, 10);
                }
                else
                {
                    g.Key.IsFalse();
                    g.AsEnumerable().Is(1, 3, 5, 7, 9);
                }
            }
        }

        [TestMethod]
        public void Immediate()
        {
            {
                ILookup<bool, int> lookup = Enumerable.Range(1, 10).ToLookup(x => x % 2 == 0);
                var hugahuga = ZeroFormatterSerializer.Convert(lookup, true);
                hugahuga[true].Is(2, 4, 6, 8, 10);
                hugahuga[false].Is(1, 3, 5, 7, 9);

                var onemore = ZeroFormatterSerializer.Convert(hugahuga, true);
                onemore[true].Is(2, 4, 6, 8, 10);
                onemore[false].Is(1, 3, 5, 7, 9);
            }
            {
                ILazyLookup<bool, int> lookup = Enumerable.Range(1, 10).ToLookup(x => x % 2 == 0).AsLazyLookup();
                var hugahuga = ZeroFormatterSerializer.Convert(lookup, true);
                hugahuga[true].Is(2, 4, 6, 8, 10);
                hugahuga[false].Is(1, 3, 5, 7, 9);

                var onemore = ZeroFormatterSerializer.Convert(hugahuga, true);
                onemore[true].Is(2, 4, 6, 8, 10);
                onemore[false].Is(1, 3, 5, 7, 9);
            }
        }
    }
}
