using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            var test = new ObjectFormatterTest();

            UnitTestRoot.AddTest("ObjectFormatterTest", "ObjectFormatter", test.ObjectFormatter);
            UnitTestRoot.AddTest("ObjectFormatterTest", "SkipIndexTest", test.SkipIndexTest);
            UnitTestRoot.AddTest("ObjectFormatterTest", "BinaryDoubleWrite", test.BinaryDoubleWrite);
        }


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
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc);
            var mc2 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);


            mc2.Age.Is(mc.Age);
            mc2.FirstName.Is(mc.FirstName);
            mc2.LastName.Is(mc.LastName);

            bytes = null;
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc2);
            var mc3 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc3.Age.Is(mc.Age);
            mc3.FirstName.Is(mc.FirstName);
            mc3.LastName.Is(mc.LastName);

            mc3.Age = 99999;
            mc3.FirstName = "aiueokakikukekosasisuseso";

            bytes = null;
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc3);
            var mc4 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc4.Age.Is(99999);
            mc4.FirstName.Is("aiueokakikukekosasisuseso");
            mc4.LastName.Is("hugahgua");


            mc4.LastName = null;

            bytes = null;
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc4);
            var mc5 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc5.Age.Is(99999);
            mc5.FirstName.Is("aiueokakikukekosasisuseso");
            mc5.LastName.IsNull();
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
            r4.MyProperty10 = 0;

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

            newBytes = null;
            Formatter<double>.Default.Serialize(ref newBytes, 0, 12345.12345);



        }
    }
}
