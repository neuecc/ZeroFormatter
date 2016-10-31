using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class StructTest
    {
        [ZeroFormattable]
        public struct MyStructFixed
        {
            [Index(0)]
            public int MyProperty1 { get; set; }
            [Index(1)]
            public long MyProperty2 { get; set; }
            [Index(2)]
            public float MyProperty3 { get; set; }

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
            public int MyProperty1 { get; set; }
            [Index(1)]
            public string MyProperty2 { get; set; }
            [Index(2)]
            public float MyProperty3 { get; set; }

            public MyStructVariable(int x, string y, float z)
            {
                MyProperty1 = x;
                MyProperty2 = y;
                MyProperty3 = z;
            }
        }

        [TestMethod]
        public void Struct()
        {
            {
                var xs = ZeroFormatterSerializer.Serialize<MyStructFixed>(new MyStructFixed { MyProperty1 = 100, MyProperty2 = 99999999, MyProperty3 = -123.43f });
                var x = ZeroFormatterSerializer.Deserialize<MyStructFixed>(xs);
                x.MyProperty1.Is(100);
                x.MyProperty2.Is(99999999);
                x.MyProperty3.Is(-123.43f);

                var xs2 = ZeroFormatterSerializer.Serialize<MyStructFixed?>(new MyStructFixed { MyProperty1 = 100, MyProperty2 = 99999999, MyProperty3 = -123.43f });
                var x2 = ZeroFormatterSerializer.Deserialize<MyStructFixed?>(xs2);
                x2.Value.MyProperty1.Is(100);
                x2.Value.MyProperty2.Is(99999999);
                x2.Value.MyProperty3.Is(-123.43f);

                var xs3 = ZeroFormatterSerializer.Serialize<MyStructFixed?>(null);
                var x3 = ZeroFormatterSerializer.Deserialize<MyStructFixed?>(xs3);
                x3.IsNull();

                var formatter = ZeroFormatter.Formatters.Formatter<MyStructFixed>.Default;
                formatter.GetLength().Is(sizeof(int) + sizeof(long) + sizeof(float));

                var formatter2 = ZeroFormatter.Formatters.Formatter<MyStructFixed?>.Default;
                formatter2.GetLength().Is(sizeof(int) + sizeof(long) + sizeof(float) + 1);
            }
            {
                var y = ZeroFormatterSerializer.Convert<MyStructVariable>(new MyStructVariable { MyProperty1 = 100, MyProperty2 = "hogehoge", MyProperty3 = -123.43f });
                y.MyProperty1.Is(100);
                y.MyProperty2.Is("hogehoge");
                y.MyProperty3.Is(-123.43f);

                var y2 = ZeroFormatterSerializer.Convert<MyStructVariable?>(new MyStructVariable { MyProperty1 = 100, MyProperty2 = "hogehoge", MyProperty3 = -123.43f });
                y2.Value.MyProperty1.Is(100);
                y2.Value.MyProperty2.Is("hogehoge");
                y2.Value.MyProperty3.Is(-123.43f);

                var y3 = ZeroFormatterSerializer.Convert<MyStructVariable?>(null);
                y3.IsNull();

                var formatter = ZeroFormatter.Formatters.Formatter<MyStructVariable>.Default;
                formatter.GetLength().IsNull();

                var formatter2 = ZeroFormatter.Formatters.Formatter<MyStructVariable?>.Default;
                formatter2.GetLength().IsNull();
            }
        }
    }
}
