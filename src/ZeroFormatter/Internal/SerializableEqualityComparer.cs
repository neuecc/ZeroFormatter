using System.Collections.Generic;

namespace ZeroFormatter.Internal
{
    internal static class SerializableEqualityComparer
    {
        static readonly System.RuntimeTypeHandle StringTypeHandle = typeof(string).TypeHandle;

        internal static IEqualityComparer<T> GetDefault<T>()
        {
            if (typeof(T).TypeHandle.Equals(StringTypeHandle))
            {
                return (IEqualityComparer<T>)(object)SerializableStringHashCodeEqualityComparer.Instance;
            }
            else
            {
                return EqualityComparer<T>.Default;
            }
        }
    }

    internal class SerializableStringHashCodeEqualityComparer : IEqualityComparer<string>
    {
        public static SerializableStringHashCodeEqualityComparer Instance = new SerializableStringHashCodeEqualityComparer();

        SerializableStringHashCodeEqualityComparer()
        {

        }

        public bool Equals(string x, string y)
        {
            return x == y;
        }

        public int GetHashCode(string value)
        {
            unchecked
            {
                var hashCode = 0;
                var count = value.Length;
                for (var i = 0; i < count; i++)
                {
                    hashCode = hashCode * 31 + value[i];
                }
                return hashCode;
            }
        }
    }
}