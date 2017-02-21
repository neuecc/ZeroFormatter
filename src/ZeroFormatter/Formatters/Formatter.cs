using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using ZeroFormatter.Comparers;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // raw layer of serialization.

    public interface IFormatter
    {
        int? GetLength();
    }

    public interface ITypeResolver
    {
        /// <summary>
        /// If false, you can use Formatter.GetBuiltinFormatter or Formatter[DefaultResolver].
        /// </summary>
        bool IsUseBuiltinSerializer { get; }
        object ResolveFormatter(Type type);
#if !UNITY
        void RegisterDynamicUnion(Type unionType, DynamicUnionResolver resolver);
#endif
    }

    public class DynamicUnionResolver
    {
        internal bool isStartRegister = false;
        internal Type unionKeyType;
        internal List<KeyTuple<object, Type>> subTypes = new List<KeyTuple<object, Type>>();
        internal Type fallbackType;

        public void RegisterUnionKeyType(Type keyType)
        {
            this.isStartRegister = true;
            this.unionKeyType = keyType;
        }

        public void RegisterSubType(object key, Type subType)
        {
            this.isStartRegister = true;
            this.subTypes.Add(KeyTuple.Create(key, subType));
        }

        public void RegisterFallbackType(Type type)
        {
            this.isStartRegister = true;
            this.fallbackType = type;
        }
    }

    public class DefaultResolver : ITypeResolver
    {
        public bool IsUseBuiltinSerializer
        {
            get
            {
                return true;
            }
        }

        public object ResolveFormatter(Type type)
        {
            return Formatter.ResolveFormatter(type);
        }
#if !UNITY
        public void RegisterDynamicUnion(Type unionType, DynamicUnionResolver resolver)
        {
            Formatter.ResolveDynamicUnion(unionType, resolver);
        }
#endif
    }

    internal static class ResolverCache<T>
         where T : ITypeResolver, new()
    {
        internal static readonly T Default = new T();
    }

    public abstract class Formatter<TTypeResolver, T> : IFormatter
        where TTypeResolver : ITypeResolver, new()
    {
        static Formatter<TTypeResolver, T> defaultFormatter;
        public static Formatter<TTypeResolver, T> Default
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
            var t = typeof(T);
            object formatter = null;
            var resolver = ResolverCache<TTypeResolver>.Default;
            try
            {
                formatter = resolver.ResolveFormatter(t);

                // If Unity, should avoid long static constructor and <T> code because IL2CPP generate every <T>.
                if (formatter == null && resolver.IsUseBuiltinSerializer)
                {
                    formatter = Formatter.GetBuiltinFormatter<TTypeResolver
#if !UNITY
                    , T
#endif
                    >(t, resolver);
                }

                if (formatter == null)
                {
                    formatter = new ErrorFormatter<TTypeResolver, T>();
                }
            }
            catch (Exception ex)
            {
                formatter = new ErrorFormatter<TTypeResolver, T>(ex);
            }

            Default = (Formatter<TTypeResolver, T>)formatter;
        }

        [Preserve]
        public Formatter()
        {
        }

        public static void Register(Formatter<TTypeResolver, T> formatter)
        {
            defaultFormatter = formatter;
        }

        /// <summary>
        /// Optimize option, If formatter does not use dirty tracker can set to true.
        /// </summary>
        public virtual bool NoUseDirtyTracker
        {
            get
            {
                return false;
            }
        }

        public abstract int? GetLength();

        public abstract int Serialize(ref byte[] bytes, int offset, T value);
        public abstract T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize);
    }

    public static class Formatter
    {
        static List<Func<Type, object>> formatterResolver = new List<Func<Type, object>>();
        static List<Action<Type, DynamicUnionResolver>> unionResolver = new List<Action<Type, DynamicUnionResolver>>();

        public static void AppendFormatterResolver(Func<Type, object> formatterResolver)
        {
            Formatter.formatterResolver.Add(formatterResolver);
        }

        public static void AppendDynamicUnionResolver(Action<Type, DynamicUnionResolver> unionResolver)
        {
            Formatter.unionResolver.Add(unionResolver);
        }

        internal static object ResolveFormatter(Type t)
        {
            foreach (var item in formatterResolver)
            {
                var resolved = item(t);
                if (resolved != null)
                {
                    return resolved;
                }
            }

            return null;
        }

        internal static object GetBuiltinFormatter<TTypeResolver
#if !UNITY
            , T
#endif
            >(Type t, TTypeResolver resolver)
            where TTypeResolver : ITypeResolver, new()
        {
            object formatter = null;
            var ti = t.GetTypeInfo();


            // Primitive
            if (t == typeof(Int16))
            {
                formatter = new Int16Formatter<TTypeResolver>();
            }
            else if (t == typeof(Int32))
            {
                formatter = new Int32Formatter<TTypeResolver>();
            }
            else if (t == typeof(Int64))
            {
                formatter = new Int64Formatter<TTypeResolver>();
            }
            else if (t == typeof(UInt16))
            {
                formatter = new UInt16Formatter<TTypeResolver>();
            }
            else if (t == typeof(UInt32))
            {
                formatter = new UInt32Formatter<TTypeResolver>();
            }
            else if (t == typeof(UInt64))
            {
                formatter = new UInt64Formatter<TTypeResolver>();
            }
            else if (t == typeof(Single))
            {
                formatter = new SingleFormatter<TTypeResolver>();
            }
            else if (t == typeof(Double))
            {
                formatter = new DoubleFormatter<TTypeResolver>();
            }
            else if (t == typeof(bool))
            {
                formatter = new BooleanFormatter<TTypeResolver>();
            }
            else if (t == typeof(byte))
            {
                formatter = new ByteFormatter<TTypeResolver>();
            }
            else if (t == typeof(sbyte))
            {
                formatter = new SByteFormatter<TTypeResolver>();
            }
            else if (t == typeof(decimal))
            {
                formatter = new DecimalFormatter<TTypeResolver>();
            }
            else if (t == typeof(TimeSpan))
            {
                formatter = new TimeSpanFormatter<TTypeResolver>();
            }
            else if (t == typeof(DateTime))
            {
                formatter = new DateTimeFormatter<TTypeResolver>();
            }
            else if (t == typeof(DateTimeOffset))
            {
                formatter = new DateTimeOffsetFormatter<TTypeResolver>();
            }
            else if (t == typeof(Guid))
            {
                formatter = new GuidFormatter<TTypeResolver>();
            }
            // Nulllable
            else if (t == typeof(Nullable<Int16>))
            {
                formatter = new NullableInt16Formatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<Int32>))
            {
                formatter = new NullableInt32Formatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<Int64>))
            {
                formatter = new NullableInt64Formatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<UInt16>))
            {
                formatter = new NullableUInt16Formatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<UInt32>))
            {
                formatter = new NullableUInt32Formatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<UInt64>))
            {
                formatter = new NullableUInt64Formatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<Single>))
            {
                formatter = new NullableSingleFormatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<Double>))
            {
                formatter = new NullableDoubleFormatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<bool>))
            {
                formatter = new NullableBooleanFormatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<byte>))
            {
                formatter = new NullableByteFormatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<sbyte>))
            {
                formatter = new NullableSByteFormatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<decimal>))
            {
                formatter = new NullableDecimalFormatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<TimeSpan>))
            {
                formatter = new NullableTimeSpanFormatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<DateTime>))
            {
                formatter = new NullableDateTimeFormatter<TTypeResolver>();
            }
            else if (t == typeof(Nullable<DateTimeOffset>))
            {
                formatter = new NullableDateTimeOffsetFormatter<TTypeResolver>();
            }
            else if (t == typeof(Guid?))
            {
                formatter = new NullableGuidFormatter<TTypeResolver>();
            }

            // Others
            else if (t == typeof(String))
            {
                formatter = new NullableStringFormatter<TTypeResolver>();
            }
            else if (t == typeof(Char))
            {
                formatter = new CharFormatter<TTypeResolver>();
            }
            else if (t == typeof(Char?))
            {
                formatter = new NullableCharFormatter<TTypeResolver>();
            }
            else if (t == typeof(IList<int>)) // known generic formatter...
            {
                formatter = new ListFormatter<TTypeResolver, int>();
            }
            else if (t.IsArray)
            {
                var elementType = t.GetElementType();
                if (elementType.GetTypeInfo().IsEnum)
                {
#if !UNITY
                    var formatterType = typeof(ArrayFormatter<,>).MakeGenericType(typeof(TTypeResolver), elementType);
                    formatter = Activator.CreateInstance(formatterType);
#endif
                }
                else
                {
                    switch (Type.GetTypeCode(elementType))
                    {
                        case TypeCode.Boolean:
                            formatter = new BooleanArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.Char:
                            formatter = new CharArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.SByte:
                            formatter = new SByteArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.Byte:
                            formatter = new ByteArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.Int16:
                            formatter = new Int16ArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.UInt16:
                            formatter = new UInt16ArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.Int32:
                            formatter = new Int32ArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.UInt32:
                            formatter = new UInt32ArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.Int64:
                            formatter = new Int64ArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.UInt64:
                            formatter = new UInt64ArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.Single:
                            formatter = new SingleArrayFormatter<TTypeResolver>();
                            break;
                        case TypeCode.Double:
                            formatter = new DoubleArrayFormatter<TTypeResolver>();
                            break;
                        default:
#if !UNITY
                            var formatterType = typeof(ArrayFormatter<,>).MakeGenericType(typeof(TTypeResolver), elementType);
                            formatter = Activator.CreateInstance(formatterType);
#endif
                            break;
                    }
                }
            }

#if !UNITY

            else if (ti.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>))
            {
                var formatterType = typeof(ListFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                formatter = Activator.CreateInstance(formatterType);
            }

            else if (ti.IsGenericType && t.GetGenericTypeDefinition() == typeof(IReadOnlyList<>))
            {
                var formatterType = typeof(ReadOnlyListFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                formatter = Activator.CreateInstance(formatterType);
            }

            else if (ti.IsEnum)
            {
                var underlyingType = Enum.GetUnderlyingType(t);
                switch (Type.GetTypeCode(underlyingType))
                {
                    case TypeCode.SByte:
                        formatter = new SByteEnumFormatter<TTypeResolver, T>();
                        break;
                    case TypeCode.Byte:
                        formatter = new ByteEnumFormatter<TTypeResolver, T>();
                        break;
                    case TypeCode.Int16:
                        formatter = new Int16EnumFormatter<TTypeResolver, T>();
                        break;
                    case TypeCode.UInt16:
                        formatter = new UInt16EnumFormatter<TTypeResolver, T>();
                        break;
                    case TypeCode.Int32:
                        formatter = new Int32EnumFormatter<TTypeResolver, T>();
                        break;
                    case TypeCode.UInt32:
                        formatter = new UInt32EnumFormatter<TTypeResolver, T>();
                        break;
                    case TypeCode.Int64:
                        formatter = new Int64EnumFormatter<TTypeResolver, T>();
                        break;
                    case TypeCode.UInt64:
                        formatter = new UInt64EnumFormatter<TTypeResolver, T>();
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
                            var formatterType = typeof(NullableSByteEnumFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                            formatter = Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.Byte:
                        {
                            var formatterType = typeof(NullableByteEnumFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                            formatter = Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.Int16:
                        {
                            var formatterType = typeof(NullableInt16EnumFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                            formatter = Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.UInt16:
                        {
                            var formatterType = typeof(NullableUInt16EnumFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                            formatter = Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.Int32:
                        {
                            var formatterType = typeof(NullableInt32EnumFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                            formatter = Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.UInt32:
                        {
                            var formatterType = typeof(NullableUInt32EnumFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                            formatter = Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.Int64:
                        {
                            var formatterType = typeof(NullableInt64EnumFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                            formatter = Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.UInt64:
                        {
                            var formatterType = typeof(NullableUInt64EnumFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                            formatter = Activator.CreateInstance(formatterType);
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }

            else if (ti.IsGenericType)
            {
                if (t.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                {
                    var formatterType = typeof(InterfaceDictionaryFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }
                else if (t.GetGenericTypeDefinition() == typeof(ILazyDictionary<,>))
                {
                    var formatterType = typeof(LazyDictionaryFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }
                else if (t.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>))
                {
                    var formatterType = typeof(InterfaceReadOnlyDictionaryFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }
                else if (t.GetGenericTypeDefinition() == typeof(ILazyReadOnlyDictionary<,>))
                {
                    var formatterType = typeof(LazyReadOnlyDictionaryFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }
                else if (t.GetGenericTypeDefinition() == typeof(DictionaryEntry<,,>))
                {
                    var formatterType = typeof(DictionaryEntryFormatter<,,>).MakeGenericType(ti.GetGenericArguments());
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(ILookup<,>))
                {
                    var formatterType = typeof(LookupFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }
                else if (t.GetGenericTypeDefinition() == typeof(ILazyLookup<,>))
                {
                    var formatterType = typeof(LazyLookupFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }
                else if (t.GetGenericTypeDefinition() == typeof(GroupingSegment<,,>))
                {
                    var formatterType = typeof(GroupingSegmentFormatter<,,>).MakeGenericType(ti.GetGenericArguments());
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (ti.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                {
                    var formatterType = typeof(KeyValuePairFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    var formatterType = typeof(DictionaryFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(ReadOnlyDictionary<,>))
                {
                    var formatterType = typeof(ReadOnlyDictionaryFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(ReadOnlyCollection<>))
                {
                    var formatterType = typeof(ReadOnlyCollectionFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    var formatterType = typeof(InterfaceCollectionFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    var formatterType = typeof(InterfaceEnumerableFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(ISet<>))
                {
                    var formatterType = typeof(InterfaceSetFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(IReadOnlyCollection<>))
                {
                    var formatterType = typeof(InterfaceReadOnlyCollectionFormatter<,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (t.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>))
                {
                    var formatterType = typeof(InterfaceReadOnlyDictionaryFormatter<,,>).MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (ti.FullName.StartsWith("System.Tuple"))
                {
                    Type tupleFormatterType = null;
                    switch (ti.GetGenericArguments().Length)
                    {
                        case 1:
                            tupleFormatterType = typeof(TupleFormatter<,>);
                            break;
                        case 2:
                            tupleFormatterType = typeof(TupleFormatter<,,>);
                            break;
                        case 3:
                            tupleFormatterType = typeof(TupleFormatter<,,,>);
                            break;
                        case 4:
                            tupleFormatterType = typeof(TupleFormatter<,,,,>);
                            break;
                        case 5:
                            tupleFormatterType = typeof(TupleFormatter<,,,,,>);
                            break;
                        case 6:
                            tupleFormatterType = typeof(TupleFormatter<,,,,,,>);
                            break;
                        case 7:
                            tupleFormatterType = typeof(TupleFormatter<,,,,,,,>);
                            break;
                        case 8:
                            tupleFormatterType = typeof(TupleFormatter<,,,,,,,,>);
                            break;
                        default:
                            break;
                    }

                    var formatterType = tupleFormatterType.MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (ti.GetInterfaces().Any(x => x == typeof(IKeyTuple)))
                {
                    Type tupleFormatterType = null;
                    switch (ti.GetGenericArguments().Length)
                    {
                        case 1:
                            tupleFormatterType = typeof(KeyTupleFormatter<,>);
                            break;
                        case 2:
                            tupleFormatterType = typeof(KeyTupleFormatter<,,>);
                            break;
                        case 3:
                            tupleFormatterType = typeof(KeyTupleFormatter<,,,>);
                            break;
                        case 4:
                            tupleFormatterType = typeof(KeyTupleFormatter<,,,,>);
                            break;
                        case 5:
                            tupleFormatterType = typeof(KeyTupleFormatter<,,,,,>);
                            break;
                        case 6:
                            tupleFormatterType = typeof(KeyTupleFormatter<,,,,,,>);
                            break;
                        case 7:
                            tupleFormatterType = typeof(KeyTupleFormatter<,,,,,,,>);
                            break;
                        case 8:
                            tupleFormatterType = typeof(KeyTupleFormatter<,,,,,,,,>);
                            break;
                        default:
                            break;
                    }

                    var formatterType = tupleFormatterType.MakeGenericType(ti.GetGenericArguments().StartsWith(typeof(TTypeResolver)));
                    formatter = Activator.CreateInstance(formatterType);
                }

                else if (ti.GetInterfaces().Any(x =>
                {
                    var iti = x.GetTypeInfo();
                    if (iti.IsGenericType && iti.GetGenericTypeDefinition() == typeof(ICollection<>))
                    {
                        return true;
                    }
                    return false;
                }))
                {
                    var formatterType = typeof(CollectionFormatter<,,>).MakeGenericType(typeof(TTypeResolver), ti.GetGenericArguments()[0], t);
                    formatter = Activator.CreateInstance(formatterType);
                }

                // custom nullable struct
                else if (t.GetGenericTypeDefinition() == typeof(Nullable<>) && ti.GetGenericArguments()[0].GetTypeInfo().IsValueType)
                {
                    formatter = DynamicStructFormatter.Create<TTypeResolver, T>();
                }
            }

            else if (ti.GetCustomAttributes(typeof(UnionAttribute), false).FirstOrDefault() != null)
            {
                formatter = DynamicUnionFormatter.Create<TTypeResolver, T>();
            }

            else if (ti.GetCustomAttributes(typeof(DynamicUnionAttribute), false).FirstOrDefault() != null)
            {
                var unionResolver = new DynamicUnionResolver();
                resolver.RegisterDynamicUnion(t, unionResolver);
                if (unionResolver.isStartRegister)
                {
                    formatter = DynamicUnionFormatter.CreateRuntimeUnion<TTypeResolver, T>(unionResolver);
                }
            }

            else if (ti.GetCustomAttributes(typeof(ZeroFormattableAttribute), true).FirstOrDefault() != null)
            {
                if (ti.IsValueType)
                {
                    formatter = DynamicStructFormatter.Create<TTypeResolver, T>();
                }
                else
                {
                    formatter = DynamicFormatter.Create<TTypeResolver, T>();
                }
            }

#endif

            return formatter;
        }

#if !UNITY

        internal static void ResolveDynamicUnion(Type unionType, DynamicUnionResolver resolver)
        {
            foreach (var item in unionResolver)
            {
                item(unionType, resolver);
            }
        }

#endif

#if UNITY

        public static void RegisterLookup<TTypeResolver, TKey, TElement>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, IEnumerable<TElement>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IEnumerable<TElement>>.Register(new InterfaceEnumerableFormatter<TTypeResolver, TElement>());
            }
            if (Formatter<TTypeResolver, ILookup<TKey, TElement>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, ILookup<TKey, TElement>>.Register(new LookupFormatter<TTypeResolver, TKey, TElement>());
            }
            if (Formatter<TTypeResolver, IList<TElement>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IList<TElement>>.Register(new ListFormatter<TTypeResolver, TElement>());
            }
        }

        public static void RegisterLazyLookup<TTypeResolver, TKey, TElement>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, ILazyLookup<TKey, TElement>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, ILazyLookup<TKey, TElement>>.Register(new LazyLookupFormatter<TTypeResolver, TKey, TElement>());
            }
            if (Formatter<TTypeResolver, GroupingSegment<TTypeResolver, TKey, TElement>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, GroupingSegment<TTypeResolver, TKey, TElement>>.Register(new GroupingSegmentFormatter<TTypeResolver, TKey, TElement>());
            }
            if (Formatter<TTypeResolver, IList<TKey>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IList<TKey>>.Register(new ListFormatter<TTypeResolver, TKey>());
            }
            if (Formatter<TTypeResolver, IList<GroupingSegment<TTypeResolver, TKey, TElement>>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IList<GroupingSegment<TTypeResolver, TKey, TElement>>>.Register(new ListFormatter<TTypeResolver, GroupingSegment<TTypeResolver, TKey, TElement>>());
            }
            if (Formatter<TTypeResolver, IList<IList<GroupingSegment<TTypeResolver, TKey, TElement>>>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IList<IList<GroupingSegment<TTypeResolver, TKey, TElement>>>>.Register(new ListFormatter<TTypeResolver, IList<GroupingSegment<TTypeResolver, TKey, TElement>>>());
            }
            if (Formatter<TTypeResolver, IList<TElement>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IList<TElement>>.Register(new ListFormatter<TTypeResolver, TElement>());
            }
        }

        public static void RegisterDictionary<TTypeResolver, TKey, TValue>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>.Register(new KeyValuePairFormatter<TTypeResolver, TKey, TValue>());
            }
            if (Formatter<TTypeResolver, IDictionary<TKey, TValue>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IDictionary<TKey, TValue>>.Register(new InterfaceDictionaryFormatter<TTypeResolver, TKey, TValue>());
            }
            if (Formatter<TTypeResolver, Dictionary<TKey, TValue>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, Dictionary<TKey, TValue>>.Register(new DictionaryFormatter<TTypeResolver, TKey, TValue>());
            }
        }

        public static void RegisterLazyDictionary<TTypeResolver, TKey, TValue>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, ILazyDictionary<TKey, TValue>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, ILazyDictionary<TKey, TValue>>.Register(new LazyDictionaryFormatter<TTypeResolver, TKey, TValue>());
            }
            if (Formatter<TTypeResolver, DictionaryEntry<TTypeResolver, TKey, TValue>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, DictionaryEntry<TTypeResolver, TKey, TValue>>.Register(new DictionaryEntryFormatter<TTypeResolver, TKey, TValue>());
            }
            if (Formatter<TTypeResolver, IList<DictionaryEntry<TTypeResolver, TKey, TValue>>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IList<DictionaryEntry<TTypeResolver, TKey, TValue>>>.Register(new ListFormatter<TTypeResolver, DictionaryEntry<TTypeResolver, TKey, TValue>>());
            }
        }

        public static void RegisterArray<TTypeResolver, T>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, T[]>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, T[]>.Register(new ArrayFormatter<TTypeResolver, T>());
            }
        }

        public static void RegisterCollection<TTypeResolver, TElement, TCollection>()
            where TCollection : ICollection<TElement>, new()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, TCollection>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, TCollection>.Register(new CollectionFormatter<TTypeResolver, TElement, TCollection>());
            }
        }

        public static void RegisterInterfaceCollection<TTypeResolver, T>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, ICollection<T>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, ICollection<T>>.Register(new InterfaceCollectionFormatter<TTypeResolver, T>());
            }
        }
        public static void RegisterEnumerable<TTypeResolver, T>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, IEnumerable<T>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IEnumerable<T>>.Register(new InterfaceEnumerableFormatter<TTypeResolver, T>());
            }
        }

        public static void RegisterReadOnlyCollection<TTypeResolver, T>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, ReadOnlyCollection<T>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, ReadOnlyCollection<T>>.Register(new ReadOnlyCollectionFormatter<TTypeResolver, T>());
            }
        }

        public static void RegisterList<TTypeResolver, T>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, IList<T>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, IList<T>>.Register(new ListFormatter<TTypeResolver, T>());
            }
        }

        public static void RegisterKeyValuePair<TTypeResolver, TKey, TValue>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyValuePair<TKey, TValue>>.Register(new KeyValuePairFormatter<TTypeResolver, TKey, TValue>());
            }
        }

        public static void RegisterKeyTuple<TTypeResolver, T1>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyTuple<T1>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1>>.Register(new KeyTupleFormatter<TTypeResolver, T1>());
            }
            if (Formatter<TTypeResolver, KeyTuple<T1>?>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1>?>.Register(new NullableKeyTupleFormatter<TTypeResolver, T1>());
            }
            if (ZeroFormatterEqualityComparer<KeyTuple<T1>>.Default is IErrorEqualityComparer)
            {
                ZeroFormatterEqualityComparer<KeyTuple<T1>>.Register(new KeyTupleEqualityComparer<T1>());
            }
        }

        public static void RegisterKeyTuple<TTypeResolver, T1, T2>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyTuple<T1, T2>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2>>.Register(new KeyTupleFormatter<TTypeResolver, T1, T2>());
            }
            if (Formatter<TTypeResolver, KeyTuple<T1, T2>?>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2>?>.Register(new NullableKeyTupleFormatter<TTypeResolver, T1, T2>());
            }
            if (ZeroFormatterEqualityComparer<KeyTuple<T1, T2>>.Default is IErrorEqualityComparer)
            {
                ZeroFormatterEqualityComparer<KeyTuple<T1, T2>>.Register(new KeyTupleEqualityComparer<T1, T2>());
            }
        }

        public static void RegisterKeyTuple<TTypeResolver, T1, T2, T3>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3>>.Register(new KeyTupleFormatter<TTypeResolver, T1, T2, T3>());
            }
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3>?>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3>?>.Register(new NullableKeyTupleFormatter<TTypeResolver, T1, T2, T3>());
            }
            if (ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3>>.Default is IErrorEqualityComparer)
            {
                ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3>>.Register(new KeyTupleEqualityComparer<T1, T2, T3>());
            }
        }

        public static void RegisterKeyTuple<TTypeResolver, T1, T2, T3, T4>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4>>.Register(new KeyTupleFormatter<TTypeResolver, T1, T2, T3, T4>());
            }
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4>?>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4>?>.Register(new NullableKeyTupleFormatter<TTypeResolver, T1, T2, T3, T4>());
            }
            if (ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4>>.Default is IErrorEqualityComparer)
            {
                ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4>>.Register(new KeyTupleEqualityComparer<T1, T2, T3, T4>());
            }
        }

        public static void RegisterKeyTuple<TTypeResolver, T1, T2, T3, T4, T5>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5>>.Register(new KeyTupleFormatter<TTypeResolver, T1, T2, T3, T4, T5>());
            }
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5>?>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5>?>.Register(new NullableKeyTupleFormatter<TTypeResolver, T1, T2, T3, T4, T5>());
            }
            if (ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4, T5>>.Default is IErrorEqualityComparer)
            {
                ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4, T5>>.Register(new KeyTupleEqualityComparer<T1, T2, T3, T4, T5>());
            }
        }

        public static void RegisterKeyTuple<TTypeResolver, T1, T2, T3, T4, T5, T6>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6>>.Register(new KeyTupleFormatter<TTypeResolver, T1, T2, T3, T4, T5, T6>());
            }
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6>?>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6>?>.Register(new NullableKeyTupleFormatter<TTypeResolver, T1, T2, T3, T4, T5, T6>());
            }
            if (ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4, T5, T6>>.Default is IErrorEqualityComparer)
            {
                ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4, T5, T6>>.Register(new KeyTupleEqualityComparer<T1, T2, T3, T4, T5, T6>());
            }
        }

        public static void RegisterKeyTuple<TTypeResolver, T1, T2, T3, T4, T5, T6, T7>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6, T7>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6, T7>>.Register(new KeyTupleFormatter<TTypeResolver, T1, T2, T3, T4, T5, T6, T7>());
            }
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6, T7>?>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6, T7>?>.Register(new NullableKeyTupleFormatter<TTypeResolver, T1, T2, T3, T4, T5, T6, T7>());
            }
            if (ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4, T5, T6, T7>>.Default is IErrorEqualityComparer)
            {
                ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4, T5, T6, T7>>.Register(new KeyTupleEqualityComparer<T1, T2, T3, T4, T5, T6, T7>());
            }
        }

        public static void RegisterKeyTuple<TTypeResolver, T1, T2, T3, T4, T5, T6, T7, T8>()
            where TTypeResolver : ITypeResolver, new()
        {
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6, T7, T8>>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6, T7, T8>>.Register(new KeyTupleFormatter<TTypeResolver, T1, T2, T3, T4, T5, T6, T7, T8>());
            }
            if (Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6, T7, T8>?>.Default is IErrorFormatter)
            {
                Formatter<TTypeResolver, KeyTuple<T1, T2, T3, T4, T5, T6, T7, T8>?>.Register(new NullableKeyTupleFormatter<TTypeResolver, T1, T2, T3, T4, T5, T6, T7, T8>());
            }
            if (ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4, T5, T6, T7, T8>>.Default is IErrorEqualityComparer)
            {
                ZeroFormatterEqualityComparer<KeyTuple<T1, T2, T3, T4, T5, T6, T7, T8>>.Register(new KeyTupleEqualityComparer<T1, T2, T3, T4, T5, T6, T7, T8>());
            }
        }

#endif

    }

    internal interface IErrorFormatter
    {
        InvalidOperationException GetException();
    }

    internal class ErrorFormatter<TTypeResolver, T> : Formatter<TTypeResolver, T>, IErrorFormatter
         where TTypeResolver : ITypeResolver, new()
    {
        readonly InvalidOperationException exception;

        public ErrorFormatter()
        {
            string message;
            var t = typeof(T);
            var ti = t.GetTypeInfo();
            if (ti.IsGenericType)
            {
                // depth 1 only:)
                message = t.Name + "<" + string.Join(", ", ti.GetGenericArguments().Select(x => x.Name).ToArray()) + ">";
            }
            else
            {
                message = t.Name;
            }

            this.exception = new InvalidOperationException("Type is not supported, please register " + message);
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