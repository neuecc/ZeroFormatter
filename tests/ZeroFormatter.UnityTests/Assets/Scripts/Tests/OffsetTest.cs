using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RuntimeUnitTestToolkit;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class OffsetTest
    {
        [TestMethod]
        public void Offset()
        {
            var ot = new OffsetType()
            {
                Dummy1 = 100,
                Dummy2 = "hogehogehugahuga",
                VariableSizeList = new[] { "a", "bvcde", "fwadfaze" },
                Dictionary = new Dictionary<string, int> { { "a", 3232 }, { "fdaaz", 9999 } },
                ObjectProp = new Offset2 { Prop1 = 10, Prop2 = "abc" }
            };

            var ms = new MemoryStream();
            ms.Position = 99; // skip to...

            ZeroFormatterSerializer.Serialize(ms, ot);
            var originalBytes = ms.ToArray();
            // var originalBytes = ZeroFormatterSerializer.Serialize(ot);

            var newBytes = new byte[originalBytes.Length + 13];
            Array.Copy(originalBytes, 0, newBytes, 13, originalBytes.Length);

            int size;
            var newT = Formatter<DefaultResolver, OffsetType>.Default.Deserialize(ref newBytes, 13 + 99, new DirtyTracker(), out size);

            size.Is(originalBytes.Length - 99);
            newT.Dummy1.Is(ot.Dummy1);
            newT.Dummy2.Is(ot.Dummy2);
            newT.VariableSizeList.IsCollection(ot.VariableSizeList);
            newT.Dictionary["a"].Is(3232);
            newT.Dictionary["fdaaz"].Is(9999);
            newT.ObjectProp.Prop1.Is(ot.ObjectProp.Prop1);
            newT.ObjectProp.Prop2.Is(ot.ObjectProp.Prop2);


            var bytes = ZeroFormatterSerializer.Serialize(newT);
            var newT2 = ZeroFormatterSerializer.Deserialize<OffsetType>(bytes);

            newT2.Dummy1.Is(ot.Dummy1);
            newT2.Dummy2.Is(ot.Dummy2);
            newT2.VariableSizeList.IsCollection(ot.VariableSizeList);
            newT2.Dictionary["a"].Is(3232);
            newT2.Dictionary["fdaaz"].Is(9999);
            newT2.ObjectProp.Prop1.Is(ot.ObjectProp.Prop1);
            newT2.ObjectProp.Prop2.Is(ot.ObjectProp.Prop2);
        }
    }
}
