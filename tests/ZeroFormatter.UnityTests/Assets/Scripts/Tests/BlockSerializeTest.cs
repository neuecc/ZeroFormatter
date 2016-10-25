using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuntimeUnitTestToolkit;
using Sandbox.Shared.Foo;
using System.Linq;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class BlockSerializeTest
    {
        [TestMethod]
        public void BlockSerialize()
        {
            var mc = new Sandbox.Shared.Foo.MyClass
            {
                Age = 222,
                FirstName = "a",
                LastName = "bbb",
                List = new[] { MogeMoge.Orange, MogeMoge.Apple },
                Mone = MogeMoge.Orange
            };

            var bytes1 = ZeroFormatterSerializer.Serialize<Sandbox.Shared.Foo.MyClass>(mc);

            mc.Age = 999;
            mc.FirstName = "hugahuga";
            var bytes2 = ZeroFormatterSerializer.Serialize<Sandbox.Shared.Foo.MyClass>(mc);

            mc.Age = 3;
            mc.LastName = "tetete";
            mc.List[1] = MogeMoge.Orange;
            mc.Mone = MogeMoge.Apple;
            var bytes3 = ZeroFormatterSerializer.Serialize<Sandbox.Shared.Foo.MyClass>(mc);


            var block = bytes1.Concat(bytes2).Concat(bytes3).ToArray(); // slow:)

            var a = ZeroFormatterSerializer.Deserialize<Sandbox.Shared.Foo.MyClass>(block);
            var b = ZeroFormatterSerializer.Deserialize<Sandbox.Shared.Foo.MyClass>(block, bytes1.Length);
            var c = ZeroFormatterSerializer.Deserialize<Sandbox.Shared.Foo.MyClass>(block, bytes1.Length + bytes2.Length);

            a.Age.Is(222);
            a.FirstName.Is("a");
            a.LastName.Is("bbb");
            a.List[0].Is(MogeMoge.Orange); a.List[1].Is(MogeMoge.Apple);
            a.Mone.Is(MogeMoge.Orange);

            b.Age.Is(999);
            b.FirstName.Is("hugahuga");
            b.LastName.Is("bbb");
            b.List[0].Is(MogeMoge.Orange); b.List[1].Is(MogeMoge.Apple);
            b.Mone.Is(MogeMoge.Orange);

            c.Age.Is(3);
            c.FirstName.Is("hugahuga");
            c.LastName.Is("tetete");
            c.List[0].Is(MogeMoge.Orange); c.List[1].Is(MogeMoge.Orange);
            c.Mone.Is(MogeMoge.Apple);
        }
    }
}
