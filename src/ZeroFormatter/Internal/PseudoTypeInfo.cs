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

        public bool IsEnum
        {
            get
            {
                return type.IsEnum;
            }
        }

        public bool IsGenericType
        {
            get
            {
                return type.IsGenericType;
            }
        }

        public bool IsValueType
        {
            get
            {
                return type.IsValueType;
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
#if !UNITY


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

#endif