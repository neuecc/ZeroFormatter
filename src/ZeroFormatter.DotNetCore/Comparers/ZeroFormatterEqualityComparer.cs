using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ZeroFormatter.DotNetCore.Comparers
{
    public static class ZeroFormatterEqualityComparer<T>
    {
        static IEqualityComparer<T> defaultComparer;
        public static IEqualityComparer<T> Default
        {
            get
            {
                return defaultComparer;
            }
            private set
            {
                defaultComparer = value;
            }
        }

        static ZeroFormatterEqualityComparer()
        {
            object comparer = null;

            var t = typeof(T);
            if (t == typeof(Int16))
            {
                comparer = new Int16EqualityComparer();
            }
            else if (t == typeof(Int32))
            {
                comparer = new Int32EqualityComparer();
            }
            else if (t == typeof(Int64))
            {
                comparer = new Int64EqualityComparer();
            }
            else if (t == typeof(UInt16))
            {
                comparer = new UInt16EqualityComparer();
            }
            else if (t == typeof(UInt32))
            {
                comparer = new UInt32EqualityComparer();
            }
            else if (t == typeof(UInt64))
            {
                comparer = new UInt64EqualityComparer();
            }
            else if (t == typeof(Single))
            {
                comparer = new SingleEqualityComparer();
            }
            else if (t == typeof(Double))
            {
                comparer = new DoubleEqualityComparer();
            }
            else if (t == typeof(bool))
            {
                comparer = new BoolEqualityComparer();
            }
            else if (t == typeof(byte))
            {
                comparer = new ByteEqualityComparer();
            }
            else if (t == typeof(sbyte))
            {
                comparer = new SByteEqualityComparer();
            }

            else if (t == typeof(String))
            {
                comparer = new StringEqualityComparer();
            }
            else if (t == typeof(Char))
            {
                comparer = new CharEqualityComparer();
            }

            else if (t.GetTypeInfo().IsEnum)
            {
                comparer = EnumEqualityComparer<T>.Default;
            }
            else if (t.GetTypeInfo().GetInterfaces().Any(x => x == typeof(IKeyTuple)))
            {
                comparer = EqualityComparer<T>.Default; // IKeyTuple implements safe EqualityComaprer
            }
            else
            {
                comparer = new ErrorEqualityComparer<T>();
            }

            defaultComparer = (IEqualityComparer<T>)comparer;
        }

        public static void Register(IEqualityComparer<T> comparer)
        {
            defaultComparer = comparer;
        }
    }

    internal class ErrorEqualityComparer<T> : IEqualityComparer<T>
    {
        readonly Exception exception;

        public ErrorEqualityComparer()
        {
            this.exception = new InvalidOperationException("Type is not supported, please register,:" + typeof(T).Name);
        }

        public bool Equals(T x, T y)
        {
            throw exception;
        }

        public int GetHashCode(T obj)
        {
            throw exception;
        }
    }
}