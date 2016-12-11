using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    public class CustomResolver : ITypeResolver
    {
        public bool IsUseBuiltinSerializer
        {
            get
            {
                return true;
            }
        }

        public void RegisterDynamicUnion(Type unionType, DynamicUnionResolver resolver)
        {

        }

        public object ResolveFormatter(Type type)
        {
            return null;
        }
    }

    [TestClass]
    public class SomeResolverTest
    {
        [TestMethod]
        public void FormatterABC()
        {
            var mc1 = Formatters.Formatter<DefaultResolver, MyClass>.Default;

            var mc2 = Formatters.Formatter<CustomResolver, MyClass>.Default;

            byte[] bytes = null;
            mc2.Serialize(ref bytes, 0, new MyClass());

        }
    }
}
