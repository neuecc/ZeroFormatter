using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class NonGenericTest
    {
        [TestMethod]
        public void NonGeneric()
        {
            {
                var xs = ZeroFormatterSerializer.NonGeneric.Serialize(typeof(int), 100);
                ((int)ZeroFormatterSerializer.NonGeneric.Deserialize(typeof(int), xs)).Is(100);

                byte[] bytes = null;
                ZeroFormatterSerializer.NonGeneric.Serialize(typeof(int), 200, ref bytes);
                ((int)ZeroFormatterSerializer.NonGeneric.Deserialize(typeof(int), bytes)).Is(200);

                var ms = new MemoryStream();
                ZeroFormatterSerializer.NonGeneric.Serialize(typeof(int), 999, ms);
                ms.Position = 0;
                ((int)ZeroFormatterSerializer.NonGeneric.Deserialize(typeof(int), ms)).Is(999);

                ((int)ZeroFormatterSerializer.NonGeneric.Convert(typeof(int), 9999)).Is(9999);

                ZeroFormatterSerializer.NonGeneric.IsFormattedObject(9999).IsFalse();
            }

            {
                var xs = ZeroFormatterSerializer.NonGeneric.Serialize(typeof(MyClass), new MyClass { Age = 100 });
                ((MyClass)ZeroFormatterSerializer.NonGeneric.Deserialize(typeof(MyClass), xs)).Age.Is(100);

                byte[] bytes = null;
                ZeroFormatterSerializer.NonGeneric.Serialize(typeof(MyClass), new MyClass { Age = 200 }, ref bytes);
                ((MyClass)ZeroFormatterSerializer.NonGeneric.Deserialize(typeof(MyClass), bytes)).Age.Is(200);

                var ms = new MemoryStream();
                ZeroFormatterSerializer.NonGeneric.Serialize(typeof(MyClass), new MyClass { Age = 999 }, ms);
                ms.Position = 0;
                ((MyClass)ZeroFormatterSerializer.NonGeneric.Deserialize(typeof(MyClass), ms)).Age.Is(999);

                var converted = ((MyClass)ZeroFormatterSerializer.NonGeneric.Convert(typeof(MyClass), new MyClass { Age = 9999 }));
                converted.Age.Is(9999);

                ZeroFormatterSerializer.NonGeneric.IsFormattedObject(new MyClass()).IsFalse();
                ZeroFormatterSerializer.NonGeneric.IsFormattedObject(converted).IsTrue();
            }
        }
    }
}
