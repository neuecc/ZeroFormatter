using System;
using System.Reflection;
using System.Linq;
using ZeroFormatter.Internal;
using System.Collections.Generic;

namespace ZeroFormatter.Comparers
{
    /// <summary>
    /// Get deterministic EqualityComparer for calcluate safe hashCode.
    /// </summary>
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

#if !UNITY

            else if (t.GetTypeInfo().GetInterfaces().Any(x => x == typeof(IKeyTuple)))
            {
                var ti = t.GetTypeInfo();

                Type keyTupleComparerType = null;
                switch (ti.GetGenericArguments().Length)
                {
                    case 1:
                        keyTupleComparerType = typeof(KeyTupleEqualityComparer<>);
                        break;
                    case 2:
                        keyTupleComparerType = typeof(KeyTupleEqualityComparer<,>);
                        break;
                    case 3:
                        keyTupleComparerType = typeof(KeyTupleEqualityComparer<,,>);
                        break;
                    case 4:
                        keyTupleComparerType = typeof(KeyTupleEqualityComparer<,,,>);
                        break;
                    case 5:
                        keyTupleComparerType = typeof(KeyTupleEqualityComparer<,,,,>);
                        break;
                    case 6:
                        keyTupleComparerType = typeof(KeyTupleEqualityComparer<,,,,,>);
                        break;
                    case 7:
                        keyTupleComparerType = typeof(KeyTupleEqualityComparer<,,,,,,>);
                        break;
                    case 8:
                        keyTupleComparerType = typeof(KeyTupleEqualityComparer<,,,,,,,>);
                        break;
                    default:
                        break;
                }

                var formatterType = keyTupleComparerType.MakeGenericType(ti.GetGenericArguments());
                comparer = Activator.CreateInstance(formatterType);
            }

            // Unity Can't use EnumEqualityComparer.

            else if (t.GetTypeInfo().IsEnum)
            {
                comparer = EnumEqualityComparer<T>.Default;
            }

#endif

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

        public static IEqualityComparer<T> GetUndeterministicSafeFallbackedEqualityComparer()
        {
            var comparer = Default;
            if (comparer is StringEqualityComparer || comparer is IErrorEqualityComparer)
            {
                // native EqualityComparer<string> is faster than deterministic embeded comparer.
                return EqualityComparer<T>.Default;
            }

            return comparer;
        }
    }

    internal interface IErrorEqualityComparer
    {
    }

    internal class ErrorEqualityComparer<T> : IEqualityComparer<T>, IErrorEqualityComparer
    {
        readonly Exception exception;

        public ErrorEqualityComparer()
        {
            this.exception = new InvalidOperationException("Type is not supported, please register " + typeof(T).Name);
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