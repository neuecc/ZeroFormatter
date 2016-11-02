using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    public static partial class AssertEx
    {
        public static void IsEmpty<T>(this IEnumerable<T> source)
        {
            source.Any().IsFalse();
        }
    }
}