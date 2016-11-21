using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using ZeroFormatter.Formatters;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class StringSegmentTest
    {
        [TestMethod]
        public void String()
        {
            var _ = ZeroFormatterSerializer.Serialize<string>("");
            var str = ZeroFormatterSerializer.Deserialize<string>(_);

            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);
            bw.Write(Encoding.UTF8.GetByteCount("あいうえおかきくけこさしすえそなにぬねの"));
            bw.Write("あいうえおかきくけこさしすえそなにぬねの");

            var actual = ms.ToArray();
            var tracker = new DirtyTracker();
            tracker.IsDirty.IsFalse();
            var segment = new CacheSegment<DefaultResolver, string>(tracker, new ArraySegment<byte>(actual));

            segment.Value = "あいうえおかきくけこ";
            tracker.IsDirty.IsTrue();

            byte[] result = new byte[0];
            segment.Serialize(ref result, 0);

            ZeroFormatterSerializer.Deserialize<string>(result).Is("あいうえおかきくけこ");


            segment.Value = null;

            segment.Serialize(ref result, 0);

            ZeroFormatterSerializer.Deserialize<string>(result).IsNull();
        }
    }
}
