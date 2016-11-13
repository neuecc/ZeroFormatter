using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class VersiongTest
    {

        [TestMethod]
        public void MyTestMethod()
        {
            var standard = ZeroFormatterSerializer.Serialize(new Standard { MyProperty0 = 100, MyProperty3 = 300 });

            var large = ZeroFormatterSerializer.Deserialize<Large>(standard);


            large.MyProperty5.Is(0);
            large.MyProperty6.IsNull();
            large.MyProperty10.IsNull();
            large.MyProperty11.IsNull();
            large.MyProperty13.IsNull();
            large.MyProperty15.IsNull();
            large.MyProperty20.Is(0);

            large.MyProperty0 = 99;
            large.MyProperty3 = 49;
            large.MyProperty5 = 999;
            large.MyProperty6 = "hugahuga";
            large.MyProperty10 = new List<int> { 1, 10, 100 };
            large.MyProperty11 = Enumerable.Range(1, 10).ToLookup(x => x % 2 == 0);
            large.MyProperty13 = new List<string> { "a", "bcde" };
            large.MyProperty15 = Enumerable.Range(1, 10).ToDictionary(x => x.ToString());
            large.MyProperty20 = 999999;

            var convert = ZeroFormatterSerializer.Convert(large);


            convert.MyProperty0.Is(99);
            convert.MyProperty3.Is(49);
            convert.MyProperty5.Is(999);
            convert.MyProperty6.Is("hugahuga");
            convert.MyProperty10.Is(new List<int> { 1, 10, 100 });
            convert.MyProperty11[true].Is(2, 4, 6, 8, 10);
            convert.MyProperty13.Is(new List<string> { "a", "bcde" });
            convert.MyProperty15["3"].Is(3);
            convert.MyProperty20.Is(999999);
        }

        [ZeroFormattable]
        public class Version1
        {
            [Index(0)]
            public virtual int Prop1 { get; set; }
            [Index(1)]
            public virtual int Prop2 { get; set; }

            // If deserialize from new data, ignored.
        }

        [ZeroFormattable]
        public class Version2
        {
            [Index(0)]
            public virtual int Prop1 { get; set; }
            [Index(1)]
            public virtual int Prop2 { get; set; }
            // You can add new property. If deserialize from old data, value is assigned default(T).
            [Index(2)]
            public virtual int NewType { get; set; }
        }

        [ZeroFormattable]
        public class VersionEx1
        {
            [Index(0)]
            public virtual string Prop1 { get; set; }
            [Index(1)]
            public virtual string Prop2 { get; set; }

            // If deserialize from new data, ignored.
        }

        [ZeroFormattable]
        public class VersionEx2
        {
            [Index(0)]
            public virtual string Prop1 { get; set; }
            [Index(1)]
            public virtual string Prop2 { get; set; }
            // You can add new property. If deserialize from old data, value is assigned default(T).
            [Index(2)]
            public virtual string NewType { get; set; }
        }

        [TestMethod]
        public void VersiongCheckReadme()
        {
            var v1 = new Version1 { Prop1 = 999, Prop2 = 1000 };
            var v2 = new Version2 { Prop1 = 10, Prop2 = 100, NewType = 9 };

            var v1Data = ZeroFormatterSerializer.Serialize(v1);
            var v2Data = ZeroFormatterSerializer.Serialize(v2);

            // deserialize new data to old schema
            var newV1 = ZeroFormatterSerializer.Deserialize<Version1>(v2Data);
            newV1.Prop1.Is(10); newV1.Prop2.Is(100);

            var newV2 = ZeroFormatterSerializer.Deserialize<Version2>(v1Data);
            newV2.Prop1.Is(999); newV2.Prop2.Is(1000); newV2.NewType.Is(default(int));
            newV2.NewType = 99999;
            ZeroFormatterSerializer.Convert(newV2).NewType.Is(99999);
        }


        [TestMethod]
        public void VersiongCheckReadme2()
        {
            var v1 = new VersionEx1 { Prop1 = "aiueo", Prop2 = "あいうえお" };
            var v2 = new VersionEx2 { Prop1 = "kakikukeko", Prop2 = "ほげ", NewType = "ふがふが" };

            var v1Data = ZeroFormatterSerializer.Serialize(v1);
            var v2Data = ZeroFormatterSerializer.Serialize(v2);

            // deserialize new data to old schema
            var newV1 = ZeroFormatterSerializer.Deserialize<VersionEx1>(v2Data);
            newV1.Prop1.Is("kakikukeko"); newV1.Prop2.Is("ほげ");

            var newV2 = ZeroFormatterSerializer.Deserialize<VersionEx2>(v1Data);
            newV2.Prop1.Is("aiueo"); newV2.Prop2.Is("あいうえお"); newV2.NewType.Is(default(string));
            newV2.NewType = "とりあえず";
            ZeroFormatterSerializer.Convert(newV2).NewType.Is("とりあえず");
        }
    }
}
