using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class ListFormatterTest
    {
        [TestMethod]
        public void ArrayCannotSerialize()
        {
            var xs = new[] { 12, 431, 426, 76, 373, 7, 53, 563, 563 };
            AssertEx.Catch<Exception>(() => ZeroFormatter.Serialize(xs)).Message.Contains("Array does not support");
        }

        [TestMethod]
        public void FixedList()
        {
            {
                IList<int> xs = new[] { 12, 431, 426, 76, 373, 7, 53, 563, 563 };
                var result = ZeroFormatter.Serialize(xs);
                ZeroFormatter.Deserialize<IList<int>>(result).Is(12, 431, 426, 76, 373, 7, 53, 563, 563);
            }

            {
                IList<int?> xs = new int?[] { 12, 431, 426, null, 76, 373, 7, 53, 563, 563 };
                var result = ZeroFormatter.Serialize(xs);
                ZeroFormatter.Deserialize<IList<int?>>(result).Is(12, 431, 426, null, 76, 373, 7, 53, 563, 563);
            }

            {
                IList<double> xs = new[] { 12.32, 43.1, 4.26, 76, 0.373, 7.3, 0.53, 56.3, 5.63 };
                var result = ZeroFormatter.Serialize(xs);
                ZeroFormatter.Deserialize<IList<double>>(result).Is(12.32, 43.1, 4.26, 76, 0.373, 7.3, 0.53, 56.3, 5.63);
            }

            {
                IList<double?> xs = new double?[] { 12.32, 43.1, 4.26, 76, 0.373, 7.3, null, 0.53, 56.3, null, 5.63 };
                var result = ZeroFormatter.Serialize(xs);
                ZeroFormatter.Deserialize<IList<double?>>(result).Is(12.32, 43.1, 4.26, 76, 0.373, 7.3, null, 0.53, 56.3, null, 5.63);
            }

            {
                IList<int> xs = new int[0];
                var result = ZeroFormatter.Serialize(xs);
                ZeroFormatter.Deserialize<IList<int>>(result).IsZero();
            }
        }

        [TestMethod]
        public void VariableList()
        {
            {
                IList<string> xs = new[] { "aaa", "あいうえお", "hogehoge", "hugahugahugahugahuga" };
                var result = ZeroFormatter.Serialize(xs);
                ZeroFormatter.Deserialize<IList<string>>(result).Is("aaa", "あいうえお", "hogehoge", "hugahugahugahugahuga");
            }
            {
                IList<string> xs = new[] { "aaa", "あいうえお", "hogehoge", null, "hugahugahugahugahuga" };
                var result = ZeroFormatter.Serialize(xs);
                ZeroFormatter.Deserialize<IList<string>>(result).Is("aaa", "あいうえお", "hogehoge", null, "hugahugahugahugahuga");
            }
        }
    }
}
