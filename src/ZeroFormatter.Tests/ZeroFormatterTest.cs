using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class ZeroFormatterTest
    {
        // Fixed

        [TestMethod]
        public void Int()
        {
            {
                // standard
                var ms = new MemoryStream();
                var bw = new BinaryWriter(ms);
                bw.Write(9999);

                ZeroFormatter.Serialize(9999).Is(ms.ToArray());
                ZeroFormatter.Deserialize<int>(ms.ToArray()).Is(9999);
            }
            {
                // nullable
            }
            {
                // list
                var ms = new MemoryStream();
                var bw = new BinaryWriter(ms);
                bw.Write(3);
                bw.Write(10);
                bw.Write(20);
                bw.Write(30);

                ZeroFormatter.Serialize<IList<int>>(new List<int> { 10, 20, 30 }).Is(ms.ToArray());
                ZeroFormatter.Deserialize<IList<int>>(ms.ToArray()).Is(10, 20, 30);
            }
        }
    }
}
