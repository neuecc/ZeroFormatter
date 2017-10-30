using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class GenericTest
    {
        [ZeroFormattable]
        public struct MyGenericStruct<T>
        {
            [Index(0)]
            public T x;
            [Index(1)]
            public int y;
            [Index(2)]
            public T z;

            public MyGenericStruct(T x, int y, T z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        [TestMethod]
        public void GenericStruct()
        {
            var ofDouble = new MyGenericStruct<double>(100.4f, -3, 200.5f);

            var ofDouble2 = ZeroFormatterSerializer.Convert(ofDouble);

            ofDouble2.x.Is(100.4f);
            ofDouble2.y.Is(-3);
            ofDouble2.z.Is(200.5f);

            var ofString = new MyGenericStruct<string>("", int.MaxValue, "abc");

            var ofString2 = ZeroFormatterSerializer.Convert(ofString);

            ofString2.x.Is("");
            ofString2.y.Is(int.MaxValue);
            ofString2.z.Is("abc");
        }

        [ZeroFormattable]
        public struct MyGenericClass<T>
        {
            [Index(0)]
            public T x;
            [Index(1)]
            public int y;

            public MyGenericClass(T x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [TestMethod]
        public void GenericClass()
        {
            var ofString = new MyGenericClass<string>("xyz", int.MinValue);

            var ofString2 = ZeroFormatterSerializer.Convert(ofString);

            ofString2.x.Is("xyz");
            ofString2.y.Is(int.MinValue);

            var ofMGS =
                new MyGenericClass<MyGenericStruct<double>>(
                    new MyGenericStruct<double>(0, 2, 3),
                    int.MinValue);

            var ofMGS2 = ZeroFormatterSerializer.Convert(ofMGS);

            ofMGS2.x.x.Is(0d);
            ofMGS2.x.y.Is(2);
            ofMGS2.x.z.Is(3d);
            ofMGS2.y.Is(int.MinValue);
        }

    }
}
