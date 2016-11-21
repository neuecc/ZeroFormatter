using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class RelativeTest
    {
        [TestMethod]
        public void VariableList()
        {
            var bytes = new byte[1000];
            IList<string> variableList = new[] { "abcde", "fghijk" };
            var record = KeyTuple.Create("aiueo", variableList, "kakikukeko");

            var size = ZeroFormatterSerializer.Serialize(ref bytes, 33, record);

            var newBytes = new byte[2000];
            Buffer.BlockCopy(bytes, 33, newBytes, 99, size);

            var result = ZeroFormatterSerializer.Deserialize<KeyTuple<string, IList<string>, string>>(newBytes, 99);
            {
                result.Item1.Is("aiueo");
                var l = result.Item2;
                l.Count.Is(2);
                l[0].Is("abcde");
                l[1].Is("fghijk");
                result.Item3.Is("kakikukeko");
            }

            result.Item2[0] = "zzzzz"; // mutate

            var reconvert = ZeroFormatterSerializer.Convert(result);
            {
                reconvert.Item1.Is("aiueo");
                var l = reconvert.Item2;
                l.Count.Is(2);
                l[0].Is("zzzzz");
                l[1].Is("fghijk");
                reconvert.Item3.Is("kakikukeko");
            }
        }

        [TestMethod]
        public void VariableReadOnlyList()
        {
            var bytes = new byte[1000];
            IReadOnlyList<string> variableList = new[] { "abcde", "fghijk" };
            var record = KeyTuple.Create("aiueo", variableList, "kakikukeko");

            var size = ZeroFormatterSerializer.Serialize(ref bytes, 33, record);

            var newBytes = new byte[2000];
            Buffer.BlockCopy(bytes, 33, newBytes, 99, size);

            var result = ZeroFormatterSerializer.Deserialize<KeyTuple<string, IList<string>, string>>(newBytes, 99);
            {
                result.Item1.Is("aiueo");
                var l = result.Item2;
                l.Count.Is(2);
                l[0].Is("abcde");
                l[1].Is("fghijk");
                result.Item3.Is("kakikukeko");
            }

            result.Item2[0] = "zzzzz"; // mutate

            var reconvert = ZeroFormatterSerializer.Convert(result);
            {
                reconvert.Item1.Is("aiueo");
                var l = reconvert.Item2;
                l.Count.Is(2);
                l[0].Is("zzzzz");
                l[1].Is("fghijk");
                reconvert.Item3.Is("kakikukeko");
            }
        }

        [TestMethod]
        public void ClassRelative()
        {
            var bytes = new byte[1000];
            var variableField = new MyClass { Age = 99, FirstName = "aaa", LastName = "bbb" };
            var record = KeyTuple.Create("aiueo", variableField, "kakikukeko");

            var size = ZeroFormatterSerializer.Serialize(ref bytes, 33, record);

            var newBytes = new byte[2000];
            Buffer.BlockCopy(bytes, 33, newBytes, 99, size);

            var result = ZeroFormatterSerializer.Deserialize<KeyTuple<string, MyClass, string>>(newBytes, 99);
            {
                result.Item1.Is("aiueo");
                var l = result.Item2;
                l.Age.Is(99);
                l.FirstName.Is("aaa");
                l.LastName.Is("bbb");
                result.Item3.Is("kakikukeko");
            }

            result.Item2.LastName = "zzzzz"; // mutate

            var reconvert = ZeroFormatterSerializer.Convert(result);
            {
                reconvert.Item1.Is("aiueo");
                var l = reconvert.Item2;
                l.Age.Is(99);
                l.FirstName.Is("aaa");
                l.LastName.Is("zzzzz");
                reconvert.Item3.Is("kakikukeko");
            }
        }
    }
}
