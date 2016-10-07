using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class DictionaryFormatterTest
    {
        [TestMethod]
        public void DictionarySerialize()
        {
            var xs = new Dictionary<int, int> { { 1, 120 }, { 3431242, 532 }, { 32, 5 } };

            ZeroFormatter.Serialize(xs);
            
        }
    }
}
