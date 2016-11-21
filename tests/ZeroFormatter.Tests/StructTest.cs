using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class StructTest
    {
        [ZeroFormattable]
        public struct MyStructFixed
        {
            [Index(0)]
            public int MyProperty1 { get; private set; }
            [Index(1)]
            public long MyProperty2 { get; private set; }
            [Index(2)]
            public float MyProperty3 { get; private set; }

            public MyStructFixed(int x, long y, float z)
            {
                MyProperty1 = x;
                MyProperty2 = y;
                MyProperty3 = z;
            }
        }

        [ZeroFormattable]
        public struct MyStructVariable
        {
            [Index(0)]
            public int MyProperty1 { get; private set; }
            [Index(1)]
            public string MyProperty2 { get; private set; }
            [Index(2)]
            public float MyProperty3 { get; private set; }

            public MyStructVariable(int x, string y, float z)
            {
                MyProperty1 = x;
                MyProperty2 = y;
                MyProperty3 = z;
            }
        }

        [ZeroFormattable]
        public class IncludeStruct
        {
            [Index(0)]
            public virtual MyStructFixed MyProperty0 { get; set; }
            [Index(1)]
            public virtual MyStructVariable MyProperty1 { get; set; }
        }

        [ZeroFormattable]
        public struct KlassStruct
        {
            [Index(0)]
            public MyClass t;

            public KlassStruct(MyClass t)
            {
                this.t = t;
            }
        }

        

        [ZeroFormattable]
        public struct FloatVector2
        {
            [Index(0)]
            public float x;
            [Index(1)]
            public float y;

            public FloatVector2(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [TestMethod]
        public void Struct()
        {
            {
                var xs = ZeroFormatterSerializer.Serialize<MyStructFixed>(new MyStructFixed(100, 99999999, -123.43f));
                var x = ZeroFormatterSerializer.Deserialize<MyStructFixed>(xs);
                x.MyProperty1.Is(100);
                x.MyProperty2.Is(99999999);
                x.MyProperty3.Is(-123.43f);

                var xs2 = ZeroFormatterSerializer.Serialize<MyStructFixed?>(new MyStructFixed(100, 99999999, -123.43f));
                var x2 = ZeroFormatterSerializer.Deserialize<MyStructFixed?>(xs2);
                x2.Value.MyProperty1.Is(100);
                x2.Value.MyProperty2.Is(99999999);
                x2.Value.MyProperty3.Is(-123.43f);

                var xs3 = ZeroFormatterSerializer.Serialize<MyStructFixed?>(null);
                var x3 = ZeroFormatterSerializer.Deserialize<MyStructFixed?>(xs3);
                x3.IsNull();

                var formatter = ZeroFormatter.Formatters.Formatter<DefaultResolver, MyStructFixed>.Default;
                formatter.GetLength().Is(sizeof(int) + sizeof(long) + sizeof(float));

                var formatter2 = ZeroFormatter.Formatters.Formatter<DefaultResolver, MyStructFixed?>.Default;
                formatter2.GetLength().Is(sizeof(int) + sizeof(long) + sizeof(float) + 1);
            }
            {
                var y = ZeroFormatterSerializer.Convert<MyStructVariable>(new MyStructVariable(100, "hogehoge", -123.43f));
                y.MyProperty1.Is(100);
                y.MyProperty2.Is("hogehoge");
                y.MyProperty3.Is(-123.43f);

                var y2 = ZeroFormatterSerializer.Convert<MyStructVariable?>(new MyStructVariable(100, "hogehoge", -123.43f));
                y2.Value.MyProperty1.Is(100);
                y2.Value.MyProperty2.Is("hogehoge");
                y2.Value.MyProperty3.Is(-123.43f);

                var y3 = ZeroFormatterSerializer.Convert<MyStructVariable?>(null);
                y3.IsNull();

                var formatter = ZeroFormatter.Formatters.Formatter<DefaultResolver, MyStructVariable>.Default;
                formatter.GetLength().IsNull();

                var formatter2 = ZeroFormatter.Formatters.Formatter<DefaultResolver, MyStructVariable?>.Default;
                formatter2.GetLength().IsNull();
            }
        }

        [TestMethod]
        public void Includestruct()
        {
            var xs = ZeroFormatterSerializer.Convert(new IncludeStruct
            {
                MyProperty0 = new MyStructFixed(100, 99999999, -123.43f),
                MyProperty1 = new MyStructVariable(100, "hogehoge", -123.43f)
            });

            xs.MyProperty0.MyProperty1.Is(100);
            xs.MyProperty0.MyProperty2.Is(99999999);
            xs.MyProperty0.MyProperty3.Is(-123.43f);

            xs.MyProperty1.MyProperty1.Is(100);
            xs.MyProperty1.MyProperty2.Is("hogehoge");
            xs.MyProperty1.MyProperty3.Is(-123.43f);
        }

        [TestMethod]
        public void FieldStruct()
        {
            var xs = new FloatVector2(100.4f, 200.5f);

            var huga = ZeroFormatterSerializer.Convert(xs);

            huga.x.Is(100.4f);
            huga.y.Is(200.5f);
        }

        [TestMethod]
        public void NoUseDirtyTracker()
        {
            var f = ZeroFormatter.Formatters.Formatter<DefaultResolver, MyStructFixed>.Default;
            f.NoUseDirtyTracker.IsTrue();

            ZeroFormatter.Formatters.Formatter<DefaultResolver, MyClass>.Default.NoUseDirtyTracker.IsFalse();

            var f2 = ZeroFormatter.Formatters.Formatter<DefaultResolver, KlassStruct>.Default;
            f2.NoUseDirtyTracker.IsFalse();
        }
    }
}
