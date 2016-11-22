using RuntimeUnitTestToolkit;
using System;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    public class StructTest
    {
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

        public void Vector2()
        {
            var v = new UnityEngine.Vector2(15.5f, 20.49f);
            var v2 = ZeroFormatterSerializer.Convert(v);

            v2.x.Is(v.x);
            v2.y.Is(v.y);
        }
    }
}
