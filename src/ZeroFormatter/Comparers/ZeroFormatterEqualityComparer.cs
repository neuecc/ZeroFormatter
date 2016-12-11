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

        // In Unity, EqualityComparer<Enum> is slow
        // zfc.exe generates fast EqualityComparer and this method can use it.
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

        public static IEqualityComparer<T> NondeterministicSafeFallbacked
        {
            get
            {
                var comparer = defaultComparer;
                if (ZeroFormatterEqualityComparerHelper.IsSlowBuiltinComparer(comparer))
                {
                    // native EqualityComparer<string> is faster than deterministic embeded comparer.
                    return EqualityComparer<T>.Default;
                }

                return comparer;
            }
        }

        static ZeroFormatterEqualityComparer()
        {
            var comparer = ZeroFormatterEqualityComparerHelper.GetBuiltinComparer
#if !UNITY
                <T>
#endif
                (typeof(T));

            if (comparer == null)
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

    // If Unity, IL2CPP generates large codes on static constructor, this helper avoid it.
    internal static class ZeroFormatterEqualityComparerHelper
    {
        internal static bool IsSlowBuiltinComparer(object comparer)
        {
            if (comparer == null
             || comparer is StringEqualityComparer
             || comparer is SingleEqualityComparer
             || comparer is DoubleEqualityComparer
             || comparer is DecimalEqualityComparer
             || comparer is GuidEqualityComparer
             || comparer is TimeSpanEqualityComparer
             || comparer is DeteTimeEqualityComparer
             || comparer is DeteTimeOffsetEqualityComparer
             || comparer is IErrorEqualityComparer)
            {
                return true;
            }

            return false;
        }

        internal static object GetBuiltinComparer
#if !UNITY
            <T>
#endif
            (Type t)
        {
            object comparer = null;

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
            else if (t == typeof(TimeSpan))
            {
                comparer = new TimeSpanEqualityComparer();
            }
            else if (t == typeof(DateTime))
            {
                comparer = new DeteTimeEqualityComparer();
            }
            else if (t == typeof(DateTimeOffset))
            {
                comparer = new DeteTimeOffsetEqualityComparer();
            }
            else if (t == typeof(decimal))
            {
                comparer = new DecimalEqualityComparer();
            }
            else if (t == typeof(Guid))
            {
                comparer = new GuidEqualityComparer();
            }

            else if (t == typeof(Int16?))
            {
                comparer = new NullableEqualityComparer<Int16>();
            }
            else if (t == typeof(Int32?))
            {
                comparer = new NullableEqualityComparer<Int32>();
            }
            else if (t == typeof(Int64?))
            {
                comparer = new NullableEqualityComparer<Int64>();
            }
            else if (t == typeof(UInt16?))
            {
                comparer = new NullableEqualityComparer<UInt16>();
            }
            else if (t == typeof(UInt32?))
            {
                comparer = new NullableEqualityComparer<UInt32>();
            }
            else if (t == typeof(UInt64?))
            {
                comparer = new NullableEqualityComparer<UInt64>();
            }
            else if (t == typeof(Single?))
            {
                comparer = new NullableEqualityComparer<Single>();
            }
            else if (t == typeof(Double?))
            {
                comparer = new NullableEqualityComparer<Double>();
            }
            else if (t == typeof(bool?))
            {
                comparer = new NullableEqualityComparer<bool>();
            }
            else if (t == typeof(byte?))
            {
                comparer = new NullableEqualityComparer<byte>();
            }
            else if (t == typeof(sbyte?))
            {
                comparer = new NullableEqualityComparer<sbyte>();
            }
            else if (t == typeof(Char?))
            {
                comparer = new NullableEqualityComparer<Char>();
            }
            else if (t == typeof(TimeSpan?))
            {
                comparer = new NullableEqualityComparer<TimeSpan>();
            }
            else if (t == typeof(DateTime?))
            {
                comparer = new NullableEqualityComparer<DateTime>();
            }
            else if (t == typeof(DateTimeOffset?))
            {
                comparer = new NullableEqualityComparer<DateTimeOffset>();
            }
            else if (t == typeof(decimal?))
            {
                comparer = new NullableEqualityComparer<decimal>();
            }
            else if (t == typeof(Guid?))
            {
                comparer = new NullableEqualityComparer<Guid>();
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

            else if (t.GetTypeInfo().IsNullable() && t.GetTypeInfo().GenericTypeArguments[0].GetTypeInfo().IsEnum)
            {
                var formatterType = typeof(NullableEqualityComparer<>).MakeGenericType(t.GetTypeInfo().GenericTypeArguments[0]);
                comparer = Activator.CreateInstance(formatterType);
            }

#endif
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