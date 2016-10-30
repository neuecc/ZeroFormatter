using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class StructTest
    {
        [ZeroFormattable]
        public struct MyStruct
        {
            [Index(0)]
            public int MyProperty1 { get; set; }
            [Index(1)]
            public string MyProperty2 { get; set; }
        }

        [ZeroFormattable]
        public class MyInStruct
        {
            [Index(0)]
            public virtual int MyProperty { get; set; }
            [Index(1)]
            public virtual int MyProperty2 { get; set; }
        }


        [TestMethod]
        public void Struct()
        {
            var x = ZeroFormatterSerializer.Convert<MyStruct>(new MyStruct { MyProperty1 = 100, MyProperty2 = "hogehoge" });






        }
    }
}
