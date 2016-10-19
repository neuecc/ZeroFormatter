using System;
using ZeroFormatter.Internal;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // raw layer of serialization.

    public interface IFormatter
    {
        int? GetLength();
    }

    public abstract class Formatter<T> : IFormatter
    {
        static Formatter<T> defaultFormatter;
        public static Formatter<T> Default
        {
            get
            {
                return defaultFormatter;
            }
            private set
            {
                defaultFormatter = value;
            }
        }

        static Formatter()
        {
            object formatter = null;

            var t = typeof(T);
            var ti = t.GetTypeInfo();

            try
            {

                // Primitive
                if (t == typeof(Int16))
                {
                    formatter = new Int16Formatter();
                }
                else if (t == typeof(Int32))
                {
                    formatter = new Int32Formatter();
                }
                else if (t == typeof(Int64))
                {
                    formatter = new Int64Formatter();
                }
                else if (t == typeof(UInt16))
                {
                    formatter = new UInt16Formatter();
                }
                else if (t == typeof(UInt32))
                {
                    formatter = new UInt32Formatter();
                }
                else if (t == typeof(UInt64))
                {
                    formatter = new UInt64Formatter();
                }
                else if (t == typeof(Single))
                {
                    formatter = new SingleFormatter();
                }
                else if (t == typeof(Double))
                {
                    formatter = new DoubleFormatter();
                }
                else if (t == typeof(bool))
                {
                    formatter = new BooleanFormatter();
                }
                else if (t == typeof(byte))
                {
                    formatter = new ByteFormatter();
                }
                else if (t == typeof(sbyte))
                {
                    formatter = new SByteFormatter();
                }
                else if (t == typeof(decimal))
                {
                    formatter = new DecimalFormatter();
                }
                else if (t == typeof(TimeSpan))
                {
                    formatter = new TimeSpanFormatter();
                }
                else if (t == typeof(DateTime))
                {
                    formatter = new DateTimeFormatter();
                }
                else if (t == typeof(DateTimeOffset))
                {
                    formatter = new DateTimeOffsetFormatter();
                }
                // Nulllable
                else if (t == typeof(Nullable<Int16>))
                {
                    formatter = new NullableInt16Formatter();
                }
                else if (t == typeof(Nullable<Int32>))
                {
                    formatter = new NullableInt32Formatter();
                }
                else if (t == typeof(Nullable<Int64>))
                {
                    formatter = new NullableInt64Formatter();
                }
                else if (t == typeof(Nullable<UInt16>))
                {
                    formatter = new NullableUInt16Formatter();
                }
                else if (t == typeof(Nullable<UInt32>))
                {
                    formatter = new NullableUInt32Formatter();
                }
                else if (t == typeof(Nullable<UInt64>))
                {
                    formatter = new NullableUInt64Formatter();
                }
                else if (t == typeof(Nullable<Single>))
                {
                    formatter = new NullableSingleFormatter();
                }
                else if (t == typeof(Nullable<Double>))
                {
                    formatter = new NullableDoubleFormatter();
                }
                else if (t == typeof(Nullable<bool>))
                {
                    formatter = new NullableBooleanFormatter();
                }
                else if (t == typeof(Nullable<byte>))
                {
                    formatter = new NullableByteFormatter();
                }
                else if (t == typeof(Nullable<sbyte>))
                {
                    formatter = new NullableSByteFormatter();
                }
                else if (t == typeof(Nullable<decimal>))
                {
                    formatter = new NullableDecimalFormatter();
                }
                else if (t == typeof(Nullable<TimeSpan>))
                {
                    formatter = new NullableTimeSpanFormatter();
                }
                else if (t == typeof(Nullable<DateTime>))
                {
                    formatter = new NullableDateTimeFormatter();
                }
                else if (t == typeof(Nullable<DateTimeOffset>))
                {
                    formatter = new NullableDateTimeOffsetFormatter();
                }

                // Others
                else if (t == typeof(String))
                {
                    formatter = new StringFormatter();
                }
                else if (t == typeof(Char))
                {
                    formatter = new CharFormatter();
                }
                else if (t == typeof(Char?))
                {
                    formatter = new NullableCharFormatter();
                }
                else if (t == typeof(byte[]))
                {
                    formatter = new ByteArrayFormatter();
                }

                else if (ti.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    var formatterType = typeof(ListFormatter<>).MakeGenericType(ti.GetGenericArguments());
                    formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                }

#if !UNITY

                else if (ti.IsGenericType && t.GetGenericTypeDefinition() == typeof(IReadOnlyList<>))
                {
                    var formatterType = typeof(ReadOnlyListFormatter<>).MakeGenericType(ti.GetGenericArguments());
                    formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                }

                else if (ti.IsEnum)
                {
                    var underlyingType = Enum.GetUnderlyingType(t);
                    switch (Type.GetTypeCode(underlyingType))
                    {
                        case TypeCode.SByte:
                            formatter = new SByteEnumFormatter<T>();
                            break;
                        case TypeCode.Byte:
                            formatter = new ByteEnumFormatter<T>();
                            break;
                        case TypeCode.Int16:
                            formatter = new Int16EnumFormatter<T>();
                            break;
                        case TypeCode.UInt16:
                            formatter = new UInt16EnumFormatter<T>();
                            break;
                        case TypeCode.Int32:
                            formatter = new Int32EnumFormatter<T>();
                            break;
                        case TypeCode.UInt32:
                            formatter = new UInt32EnumFormatter<T>();
                            break;
                        case TypeCode.Int64:
                            formatter = new Int64EnumFormatter<T>();
                            break;
                        case TypeCode.UInt64:
                            formatter = new UInt64EnumFormatter<T>();
                            break;
                        default:
                            throw new Exception();
                    }
                }

                else if (ti.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>) && ti.GetGenericArguments()[0].GetTypeInfo().IsEnum)
                {
                    var underlyingType = Enum.GetUnderlyingType(ti.GetGenericArguments()[0]);
                    switch (Type.GetTypeCode(underlyingType))
                    {
                        case TypeCode.SByte:
                            {
                                var formatterType = typeof(NullableSByteEnumFormatter<>).MakeGenericType(ti.GetGenericArguments()[0]);
                                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                            }
                            break;
                        case TypeCode.Byte:
                            {
                                var formatterType = typeof(NullableByteEnumFormatter<>).MakeGenericType(ti.GetGenericArguments()[0]);
                                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                            }
                            break;
                        case TypeCode.Int16:
                            {
                                var formatterType = typeof(NullableInt16EnumFormatter<>).MakeGenericType(ti.GetGenericArguments()[0]);
                                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                            }
                            break;
                        case TypeCode.UInt16:
                            {
                                var formatterType = typeof(NullableUInt16EnumFormatter<>).MakeGenericType(ti.GetGenericArguments()[0]);
                                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                            }
                            break;
                        case TypeCode.Int32:
                            {
                                var formatterType = typeof(NullableInt32EnumFormatter<>).MakeGenericType(ti.GetGenericArguments()[0]);
                                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                            }
                            break;
                        case TypeCode.UInt32:
                            {
                                var formatterType = typeof(NullableUInt32EnumFormatter<>).MakeGenericType(ti.GetGenericArguments()[0]);
                                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                            }
                            break;
                        case TypeCode.Int64:
                            {
                                var formatterType = typeof(NullableInt64EnumFormatter<>).MakeGenericType(ti.GetGenericArguments()[0]);
                                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                            }
                            break;
                        case TypeCode.UInt64:
                            {
                                var formatterType = typeof(NullableUInt64EnumFormatter<>).MakeGenericType(ti.GetGenericArguments()[0]);
                                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                            }
                            break;
                        default:
                            throw new Exception();
                    }
                }

#endif

                else if (ti.IsGenericType)
                {
                    if (t.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                    {
                        var formatterType = typeof(DictionaryFormatter<,>).MakeGenericType(ti.GetGenericArguments());
                        formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                    }

#if !UNITY

                    else if (t.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>))
                    {
                        var formatterType = typeof(ReadOnlyDictionaryFormatter<,>).MakeGenericType(ti.GetGenericArguments());
                        formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                    }

#endif

                    else if (t.GetGenericTypeDefinition() == typeof(DictionaryEntry<,>))
                    {
                        var formatterType = typeof(DictionaryEntryFormatter<,>).MakeGenericType(ti.GetGenericArguments());
                        formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                    }

                    else if (t.GetGenericTypeDefinition() == typeof(ILookup<,>))
                    {
                        var formatterType = typeof(LookupFormatter<,>).MakeGenericType(ti.GetGenericArguments());
                        formatter = (Formatter<T>)Activator.CreateInstance(formatterType);

                    }

                    else if (t.GetGenericTypeDefinition() == typeof(GroupingSegment<,>))
                    {
                        var formatterType = typeof(GroupingSegmentFormatter<,>).MakeGenericType(ti.GetGenericArguments());
                        formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                    }

                    else if (ti.GetInterfaces().Any(x => x == typeof(IKeyTuple)))
                    {
                        Type tupleFormatterType = null;
                        switch (ti.GetGenericArguments().Length)
                        {
                            case 1:
                                tupleFormatterType = typeof(KeyTupleFormatter<>);
                                break;
                            case 2:
                                tupleFormatterType = typeof(KeyTupleFormatter<,>);
                                break;
                            case 3:
                                tupleFormatterType = typeof(KeyTupleFormatter<,,>);
                                break;
                            case 4:
                                tupleFormatterType = typeof(KeyTupleFormatter<,,,>);
                                break;
                            case 5:
                                tupleFormatterType = typeof(KeyTupleFormatter<,,,,>);
                                break;
                            case 6:
                                tupleFormatterType = typeof(KeyTupleFormatter<,,,,,>);
                                break;
                            case 7:
                                tupleFormatterType = typeof(KeyTupleFormatter<,,,,,,>);
                                break;
                            case 8:
                                tupleFormatterType = typeof(KeyTupleFormatter<,,,,,,,>);
                                break;
                            default:
                                break;
                        }

                        var formatterType = tupleFormatterType.MakeGenericType(ti.GetGenericArguments());
                        formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                    }

                    else if (t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                    {
                        throw new InvalidOperationException("Dictionary does not support in ZeroFormatter because Dictionary have to deserialize all objects. You can use IDictionary<TK, TV> instead of Dictionary.");
                    }
                }

                else if (t.IsArray)
                {
                    throw new InvalidOperationException("Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[].");
                }

#if !UNITY

                else if (ti.GetCustomAttributes(typeof(ZeroFormattableAttribute), true).FirstOrDefault() != null)
                {
                    formatter = new DynamicObjectFormatter<T>();
                }

#endif

                else
                {
                    formatter = new ErrorFormatter<T>();
                }
            }
            catch (InvalidOperationException ex)
            {
                formatter = new ErrorFormatter<T>(ex);
            }
            catch (Exception ex)
            {
                formatter = new ErrorFormatter<T>(ex);
            }

            Default = (Formatter<T>)formatter;
        }

        public static void Register(Formatter<T> formatter)
        {
            defaultFormatter = formatter;
        }

        public abstract int? GetLength();

        public abstract int Serialize(ref byte[] bytes, int offset, T value);
        public abstract T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize);
    }

    internal interface IErrorFormatter
    {
        InvalidOperationException GetException();
    }

    internal class ErrorFormatter<T> : Formatter<T>, IErrorFormatter
    {
        readonly InvalidOperationException exception;

        public ErrorFormatter()
        {
            this.exception = new InvalidOperationException("Type is not supported, please register " + typeof(T).Name);
        }

        public ErrorFormatter(Exception ex)
        {
            this.exception = new InvalidOperationException("Type is not supported, occurs invalid error: " + typeof(T).Name + " InnerException:" + ex.ToString());
        }

        public ErrorFormatter(InvalidOperationException exception)
        {
            this.exception = exception;
        }

        public InvalidOperationException GetException()
        {
            return exception;
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            throw exception;
        }

        public override int? GetLength()
        {
            throw exception;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            throw exception;
        }
    }
}