using System.Linq;
using Xunit;
using ZeroFormatter.Formatters;
using ZeroFormatter.Segments;

namespace ZeroFormatter.DotNetCore.Tests
{
    public class LookupSegmentTest
    {
        [Fact]
        public void LookupSegment()
        {
            ILazyLookup<bool, int> lookup = Enumerable.Range(1, 10)
                .ToLookup(x => x % 2 == 0).AsLazyLookup();
            var bytes = ZeroFormatterSerializer.Serialize(lookup);

            int _;
            var segment = LookupSegment<DefaultResolver, bool, int>.Create(new DirtyTracker(), bytes, 0, out _);

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
    }
}
