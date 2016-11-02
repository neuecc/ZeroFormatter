using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class EmptyCheckTest
    {
        [TestMethod]
        public void Empty()
        {
            {
                IDictionary<long, bool> dict = new Dictionary<long, bool>();
                var bytes = ZeroFormatterSerializer.Serialize(dict);

                var d = ZeroFormatterSerializer.Deserialize<IDictionary<long, bool>>(bytes);

                d.IsEmpty();
            }
            {
                var lookup = Enumerable.Empty<int>().ToLookup(x => x % 2 == 0);
                var c = ZeroFormatterSerializer.Convert(lookup);
                c.IsEmpty();
            }
            {
                IList<int> fixedList = Enumerable.Empty<int>().ToArray();
                var c = ZeroFormatterSerializer.Convert(fixedList);
                c.IsEmpty();
            }
            {
                IList<string> variableList = Enumerable.Empty<string>().ToArray();
                var c = ZeroFormatterSerializer.Convert(variableList);
                c.IsEmpty();
            }
        }
    }
}
