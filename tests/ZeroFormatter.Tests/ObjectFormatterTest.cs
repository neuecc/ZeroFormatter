using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Shared.Bar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class ObjectFormatterTest
    {
        [TestMethod]
        public void ObjectFormatter()
        {
            var tracker = new DirtyTracker();
            var mc = new MyClass
            {
                Age = 999,
                FirstName = "hoge",
                LastName = "hugahgua",
                MyList = new List<int> { 1, 10, 100, 1000 }
            };

            byte[] bytes = null;
            int size;
            Formatter<DefaultResolver, MyClass>.Default.Serialize(ref bytes, 0, mc);
            var mc2 = Formatter<DefaultResolver, MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            var getAge = mc2.Age;

            mc2.Age.Is(mc.Age);
            mc2.FirstName.Is(mc.FirstName);
            mc2.LastName.Is(mc.LastName);

            bytes = null;
            Formatter<DefaultResolver, MyClass>.Default.Serialize(ref bytes, 0, mc2);
            var mc3 = Formatter<DefaultResolver, MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc3.Age.Is(mc.Age);
            mc3.FirstName.Is(mc.FirstName);
            mc3.LastName.Is(mc.LastName);

            mc3.Age = 99999;
            mc3.FirstName = "aiueokakikukekosasisuseso";

            bytes = null;
            Formatter<DefaultResolver, MyClass>.Default.Serialize(ref bytes, 0, mc3);
            var mc4 = Formatter<DefaultResolver, MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc4.Age.Is(99999);
            mc4.FirstName.Is("aiueokakikukekosasisuseso");
            mc4.LastName.Is("hugahgua");


            mc4.LastName = null;

            bytes = null;
            Formatter<DefaultResolver, MyClass>.Default.Serialize(ref bytes, 0, mc4);
            var mc5 = Formatter<DefaultResolver, MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc5.Age.Is(99999);
            mc5.FirstName.Is("aiueokakikukekosasisuseso");
            mc5.LastName.IsNull();
        }

        //[TestMethod]
        //public void DynamicFormatterTest()
        //{
        //    var dynamicFormatter = new DynamicObjectFormatter<MyClass>();

        //    byte[] bytes = null;
        //    var size = dynamicFormatter.Serialize(ref bytes, 0, new MyClass
        //    {
        //        Age = 999,
        //        FirstName = "hogehoge",
        //        LastName = "tako",
        //        MyList = new List<int> { 1, 10, 100, 1000 }
        //    });
        //    BinaryUtil.FastResize(ref bytes, size);


        //    var generatedFormatter = new MyClassFormatter();
        //    var mc2 = generatedFormatter.Deserialize(ref bytes, 0, new DirtyTracker(), out size);

        //    mc2.Age.Is(999);
        //    mc2.FirstName.Is("hogehoge");
        //    mc2.LastName.Is("tako");

        //    var mc3 = dynamicFormatter.Deserialize(ref bytes, 0, new DirtyTracker(), out size);
        //    mc3.Age.Is(999);
        //    mc3.FirstName.Is("hogehoge");
        //    mc3.LastName.Is("tako");

        //    mc3.Age = 9;
        //    mc3.LastName = "chop";
        //    mc3.MyList.Add(9999);

        //    bytes = null;
        //    dynamicFormatter.Serialize(ref bytes, 0, mc3);
        //    var mc4 = dynamicFormatter.Deserialize(ref bytes, 0, new DirtyTracker(), out size);

        //    mc4.Age.Is(9);
        //    mc4.LastName.Is("chop");
        //    mc4.MyList.Is(1, 10, 100, 1000, 9999);
        //}


        [ZeroFormattable]
        public class SkipIndex
        {
            [Index(1)]
            public virtual int MyProperty1 { get; set; }
            [Index(2)]
            public virtual int MyProperty2 { get; set; }

            [Index(3)]
            public virtual int MyProperty3 { get; set; }
            [Index(4)]
            public virtual IList<int> MyProperty4 { get; set; }
            [Index(5)]
            public virtual string MyProperty5 { get; set; }
        }

        [ZeroFormattable]
        public class OtherSchema1
        {
            [Index(1)]
            public virtual int MyProperty1 { get; set; }
        }

        [ZeroFormattable]
        public class OtherSchema2
        {
            [Index(3)]
            public virtual int MyProperty3 { get; set; }
        }

        [ZeroFormattable]
        public class OtherSchema3
        {
            [Index(3)]
            public virtual int MyProperty3 { get; set; }

            [Index(7)]
            public virtual double MyProperty7 { get; set; }

            [Index(8)]
            public virtual int? MyProperty8 { get; set; }

            [Index(10)]
            public virtual int MyProperty10 { get; set; }
        }

        [TestMethod]
        public void SkipIndexTest()
        {
            var c = new SkipIndex
            {
                MyProperty1 = 1111,
                MyProperty2 = 9999,
                MyProperty3 = 500,
                MyProperty5 = "ほぐあｈｚｇっｈれあｇはえ"
            };


            var bytes = ZeroFormatterSerializer.Serialize(c);
            var r = ZeroFormatterSerializer.Deserialize<SkipIndex>(bytes);

            r.MyProperty1.Is(1111);
            r.MyProperty2.Is(9999);
            r.MyProperty3.Is(500);
            r.MyProperty5.Is("ほぐあｈｚｇっｈれあｇはえ");

            var r_b = ZeroFormatterSerializer.Convert<SkipIndex>(r);

            r_b.MyProperty1.Is(1111);
            r_b.MyProperty2.Is(9999);
            r_b.MyProperty3.Is(500);
            r_b.MyProperty5.Is("ほぐあｈｚｇっｈれあｇはえ");



            var r2 = ZeroFormatterSerializer.Deserialize<OtherSchema1>(bytes);
            r2.MyProperty1.Is(1111);

            var r3 = ZeroFormatterSerializer.Deserialize<OtherSchema2>(bytes);
            r3.MyProperty3.Is(500);

            var r4 = ZeroFormatterSerializer.Deserialize<OtherSchema3>(bytes);
            r4.MyProperty7.Is(0);
            r4.MyProperty8.IsNull();
            r4.MyProperty10.Is(0);

            r4.MyProperty3 = 3;
            r4.MyProperty8 = 99999999;
            r4.MyProperty7 = 12345.12345;

            r4.MyProperty10 = 54321;

            var moreBytes = ZeroFormatterSerializer.Serialize<OtherSchema3>(r4);
            var r5 = ZeroFormatterSerializer.Deserialize<OtherSchema3>(moreBytes);
            r5.MyProperty3.Is(3);
            r5.MyProperty7.Is(12345.12345);
            r5.MyProperty8.Value.Is(99999999);
            r5.MyProperty10.Is(54321);
        }

        [TestMethod]
        public void BinaryDoubleWrite()
        {
            byte[] bytes = null;

            BinaryUtil.WriteDouble(ref bytes, 0, 12345.12345);
            var newDouble = BinaryUtil.ReadDouble(ref bytes, 0);
            newDouble.Is(12345.12345);


            var newBytes = new byte[bytes.Length];
            Buffer.BlockCopy(bytes, 0, newBytes, 0, bytes.Length);
            var newDouble2 = BinaryUtil.ReadDouble(ref newBytes, 0);

            newBytes = null;
            Formatter<DefaultResolver, double>.Default.Serialize(ref newBytes, 0, 12345.12345);


            var pureBytes = new byte[bytes.Length];
            var hogehogehoge = BinaryUtil.ReadDouble(ref pureBytes, 0);

        }

        [TestMethod]
        public void FooBar()
        {
            var foobar = new FooBar
            {
                BarMyClass = new Sandbox.Shared.Bar.MyClass
                {
                    Age = 999,
                    FirstName = "huga",
                    LastName = "last",
                    List = new[] { Sandbox.Shared.Bar.MogeMoge.Apple },
                    Mone = Sandbox.Shared.Bar.MogeMoge.Apple
                },
                FooMyClass = new Sandbox.Shared.Foo.MyClass
                {
                    Age = 9,
                    FirstName = "foge",
                    LastName = "none",
                    List = new[] { Sandbox.Shared.Foo.MogeMoge.Orange },
                    Mone = Sandbox.Shared.Foo.MogeMoge.Orange
                },
            };

            var newFooBar = ZeroFormatterSerializer.Convert(foobar);

            newFooBar.BarMyClass.Age.Is(999);
            newFooBar.BarMyClass.FirstName.Is("huga");
            newFooBar.BarMyClass.LastName.Is("last");
            newFooBar.BarMyClass.List[0].Is(Sandbox.Shared.Bar.MogeMoge.Apple);
            newFooBar.BarMyClass.Mone.Is(Sandbox.Shared.Bar.MogeMoge.Apple);

            newFooBar.FooMyClass.Age.Is(9);
            newFooBar.FooMyClass.FirstName.Is("foge");
            newFooBar.FooMyClass.LastName.Is("none");
            newFooBar.FooMyClass.List[0].Is(Sandbox.Shared.Foo.MogeMoge.Orange);
            newFooBar.FooMyClass.Mone.Is(Sandbox.Shared.Foo.MogeMoge.Orange);


        }

        [TestMethod]
        public void StaticInclude()
        {
            var prop = new StaticProperty() { HugaHuga = 999, My2 = new[] { new DameClass { Ok = 9 } } };

            var hoge = ZeroFormatterSerializer.Convert(prop);
            hoge.HugaHuga.Is(999);
            hoge.My2[0].Ok.Is(9);
        }
    }
}
