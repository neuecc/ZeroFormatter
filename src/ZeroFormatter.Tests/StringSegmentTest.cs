using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class StringSegmentTest
    {
        [TestMethod]
        public void String()
        {
            var _ = ZeroFormatter.Serialize<string>("");
            var str = ZeroFormatter.Deserialize<string>(_);

            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);
            bw.Write(Encoding.UTF8.GetByteCount("あいうえおかきくけこさしすえそなにぬねの"));
            bw.Write("あいうえおかきくけこさしすえそなにぬねの");

            var actual = ms.ToArray();
            var tracker = new DirtyTracker();
            tracker.IsDirty.IsFalse();
            var segment = new CacheSegment<string>(tracker, new ArraySegment<byte>(actual));

            segment.Value = "あいうえおかきくけこ";
            tracker.IsDirty.IsTrue();

            byte[] result = new byte[0];
            segment.Serialize(ref result, 0);

            ZeroFormatter.Deserialize<string>(result).Is("あいうえおかきくけこ");


            segment.Value = null;

            segment.Serialize(ref result, 0);

            ZeroFormatter.Deserialize<string>(result).IsNull();
        }
    }
}
