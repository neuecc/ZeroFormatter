#if UNITY

using System;

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

        public bool IsNullable()
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
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

namespace ZeroFormatter.Internal
{
    internal static class ReflectionExtensions
    {
        public static bool IsNullable(this System.Reflection.TypeInfo type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(System.Nullable<>);
        }
    }
}