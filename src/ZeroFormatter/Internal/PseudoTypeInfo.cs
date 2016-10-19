#if UNITY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Internal
{
    internal class PseudoTypeInfo
    {
        readonly Type type;

        public PseudoTypeInfo(Type type)
        {
            this.type = type;
        }

        public Type[] GetInterfaces()
        {
            return type.GetInterfaces();
        }

        public Type[] GetGenericArguments()
        {
            return type.GetGenericArguments();
        }

        public bool IsEnum()
        {
            return type.IsEnum;
        }

        public bool IsGenericType
        {
            get
            {
                return type.IsGenericType;
            }
        }
    }

    internal static class TypeInfoExtensions
    {
        internal static PseudoTypeInfo GetTypeInfo(this Type type)
        {
            return new Internal.PseudoTypeInfo(type);
        }
    }
}

#endif