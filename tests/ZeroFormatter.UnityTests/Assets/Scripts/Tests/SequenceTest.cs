using Sandbox.Shared;
using RuntimeUnitTestToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroFormatter.Tests
{
    public class SequenceTest
    {
        public void Seq()
        {
            var t = new AllNewFormat()
            {
                A1 = new Int16[] { 1, 2, 3, short.MinValue, short.MaxValue },
                A2 = new Int32[] { 1, 2, 3, int.MinValue, int.MaxValue },
                A3 = new Int64[] { 1, 2, 3, long.MinValue, long.MaxValue },
                A4 = new UInt16[] { 1, 2, 3, UInt16.MinValue, UInt16.MaxValue },
                A5 = new UInt32[] { 1, 2, 3, UInt32.MinValue, UInt32.MaxValue },
                A6 = new UInt64[] { 1, 2, 3, UInt64.MinValue, UInt64.MaxValue },
                A7 = new Single[] { float.MinValue, 2.2f, float.MaxValue },
                A8 = new Double[] { double.MinValue, 2.2, double.MaxValue },
                A9 = new Boolean[] { true, false, true },
                A10 = new byte[] { 0, 1, 2, byte.MinValue, byte.MaxValue },
                A11 = new sbyte[] { 0, 1, 2, sbyte.MinValue, sbyte.MaxValue },
                A12 = new char[] { char.MinValue, char.MaxValue, 'a', 'あ' },
                V1 = new[] { new MyVector(1.3f, 10.4f) },
                V2 = new[] { new MyVectorClass { X = 3242.3141f, Y = 34224.423f } },
                V3 = new Dictionary<int, string> { { 1231, "hogehoge" } },
                V4 = new List<int> { 1, 10, 100 },
                V5 = new HashSet<string> { "a", "b", "cde" },
                V6 = new KeyValuePair<int, string>(1000, "aiueo")
            };

            var newT = ZeroFormatterSerializer.Convert(t);

            newT.A1.IsCollection(t.A1);
            newT.A2.IsCollection(t.A2);
            newT.A3.IsCollection(t.A3);
            newT.A4.IsCollection(t.A4);
            newT.A5.IsCollection(t.A5);
            newT.A6.IsCollection(t.A6);
            newT.A7.IsCollection(t.A7);
            newT.A8.IsCollection(t.A8);
            newT.A9.IsCollection(t.A9);
            newT.A10.IsCollection(t.A10);
            newT.A11.IsCollection(t.A11);
            newT.A12.IsCollection(t.A12);

            newT.V1[0].X.Is(1.3f); newT.V1[0].Y.Is(10.4f);
            newT.V2[0].X.Is(3242.3141f); newT.V2[0].Y.Is(34224.423f);
            newT.V3[1231].Is("hogehoge");
            newT.V4.IsCollection(1, 10, 100);
            newT.V5.OrderBy(x => x).IsCollection("a", "b", "cde");
            newT.V6.Key.Is(1000);
            newT.V6.Value.Is("aiueo");
        }
    }
}
