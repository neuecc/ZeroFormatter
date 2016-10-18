using System;
using System.Reflection;
using System.Linq;

namespace ZeroFormatter.DotNetCore
{
    // We need to use Analyazer so can't use DataContractAttribute.
    // Analyzer detect attribtues by "short" name.
    // Short name means does not needs reference ZeroFormatter so create no dependent libraries.

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ZeroFormattableAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IndexAttribute : Attribute
    {
        public int Index { get; private set; }

        public IndexAttribute(int index)
        {
            this.Index = index;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IgnoreFormatAttribute : Attribute
    {
    }
}

namespace ZeroFormatter.DotNetCore.Internal
{
    internal static class ReflectionExtensions
    {
        public static Attribute GetAttributeShortName(this Type type, string shortName)
        {
            return type.GetTypeInfo().GetCustomAttributes<Attribute>(true).FirstOrDefault(x => x.GetType().Name == shortName);
        }

        public static Attribute GetAttributeShortName(this PropertyInfo propInfo, string shortName)
        {
            return propInfo.GetCustomAttributes<Attribute>(true).FirstOrDefault(x => x.GetType().Name == shortName);
        }

        public static int? GetIndexAttribute(this PropertyInfo propInfo)
        {
            var indexAttr = propInfo.GetCustomAttributes<Attribute>(true).FirstOrDefault(x => x.GetType().Name == "IndexAttribute");
            if (indexAttr == null) return null;

            var i = indexAttr.GetType().GetTypeInfo().GetProperty("Index").GetGetMethod().Invoke(indexAttr, null);
            return (int)i;
        }
    }
}