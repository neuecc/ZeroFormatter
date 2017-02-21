using System;
using System.Linq;
using System.IO;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;
#if !UNITY
using System.Reflection;
using System.Linq.Expressions;
#endif

namespace ZeroFormatter
{
    public static class ZeroFormatterSerializer
    {
        const int DefaultMaxSize = 67108864;

        static int maxSize = DefaultMaxSize;
        public static int MaximumLengthOfDeserialize
        {
            get
            {
                return maxSize;
            }
            set
            {
                maxSize = value;
            }
        }

        /// <summary>
        /// If reached maximum length, throw exception.
        /// </summary>
        /// <param name="length"></param>
        public static void ValidateNewLength(int length)
        {
            if (MaximumLengthOfDeserialize < length)
            {
                throw new InvalidOperationException("Reached maximum length:" + MaximumLengthOfDeserialize + " so ensure MaximumLengthOfDeserialize or handle alternate strategy.");
            }
        }

        /// <summary>
        /// Serialize to binary.
        /// </summary>
        public static byte[] Serialize<T>(T obj)
        {
            return CustomSerializer<DefaultResolver>.Serialize(obj);
        }

        /// <summary>
        /// Serialize to binary, can accept null buffer that will be filled. return is size and ref buffer is not sized.
        /// </summary>
        public static int Serialize<T>(ref byte[] buffer, int offset, T obj)
        {
            return CustomSerializer<DefaultResolver>.Serialize(ref buffer, offset, obj);
        }

        public static void Serialize<T>(Stream stream, T obj)
        {
            CustomSerializer<DefaultResolver>.Serialize(stream, obj);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            return CustomSerializer<DefaultResolver>.Deserialize<T>(bytes);
        }

        public static T Deserialize<T>(byte[] bytes, int offset)
        {
            return CustomSerializer<DefaultResolver>.Deserialize<T>(bytes, offset);
        }

        public static T Deserialize<T>(Stream stream)
        {
            return CustomSerializer<DefaultResolver>.Deserialize<T>(stream);
        }

        public static T Convert<T>(T obj, bool forceConvert = false)
        {
            return CustomSerializer<DefaultResolver>.Convert<T>(obj, forceConvert);
        }

        public static bool IsFormattedObject<T>(T obj)
        {
            return obj is IZeroFormatterSegment;
        }

        // copy to does not supports before .NET 4
        static ArraySegment<byte> FillFromStream(Stream input)
        {
            var buffer = new byte[input.CanSeek ? input.Length : 16];

            int length = 0;
            int read;
            while ((read = input.Read(buffer, length, buffer.Length - length)) > 0)
            {
                length += read;
                if (length == buffer.Length)
                {
                    BinaryUtil.FastResize(ref buffer, length * 2);
                }
            }

            return new ArraySegment<byte>(buffer, 0, length);
        }

#if !UNITY

        public static class NonGeneric
        {
            static readonly System.Collections.Concurrent.ConcurrentDictionary<Type, CompiledMethods> serializes = new System.Collections.Concurrent.ConcurrentDictionary<Type, CompiledMethods>();

            public static byte[] Serialize(Type type, object obj)
            {
                return serializes.GetOrAdd(type, t => new CompiledMethods(t)).serialize1.Invoke(obj);
            }

            public static int Serialize(Type type, ref byte[] bytes, int offset, object obj)
            {
                return serializes.GetOrAdd(type, t => new CompiledMethods(t)).serialize2.Invoke(ref bytes, offset, obj);
            }

            public static void Serialize(Type type, Stream stream, object obj)
            {
                serializes.GetOrAdd(type, t => new CompiledMethods(t)).serialize3.Invoke(stream, obj);
            }

            public static object Deserialize(Type type, byte[] bytes)
            {
                return serializes.GetOrAdd(type, t => new CompiledMethods(t)).deserialize1.Invoke(bytes);
            }

            public static object Deserialize(Type type, byte[] bytes, int offset)
            {
                return serializes.GetOrAdd(type, t => new CompiledMethods(t)).deserialize2.Invoke(bytes, offset);
            }

            public static object Deserialize(Type type, Stream stream)
            {
                return serializes.GetOrAdd(type, t => new CompiledMethods(t)).deserialize3.Invoke(stream);
            }

            public static object Convert(Type type, object obj, bool forceConvert = false)
            {
                return serializes.GetOrAdd(type, t => new CompiledMethods(t)).convert.Invoke(obj, forceConvert);
            }

            public static bool IsFormattedObject(object obj)
            {
                return obj is IZeroFormatterSegment;
            }

            delegate int RefSerialize(ref byte[] bytes, int offset, object obj);

            class CompiledMethods
            {
                public readonly Func<object, byte[]> serialize1;
                public readonly RefSerialize serialize2;
                public readonly Action<Stream, object> serialize3;
                public readonly Func<byte[], object> deserialize1;
                public readonly Func<byte[], int, object> deserialize2;
                public readonly Func<Stream, object> deserialize3;
                public readonly Func<object, bool, object> convert;

                public CompiledMethods(Type type)
                {
                    var ti = type.GetTypeInfo();
                    var methods = typeof(ZeroFormatterSerializer).GetTypeInfo().GetMethods();

                    {
                        // public static byte[] Serialize<T>(T obj)
                        var serialize = methods.First(x => x.Name == "Serialize" && x.GetParameters().Length == 1).MakeGenericMethod(type);

                        var param1 = Expression.Parameter(typeof(object), "obj");
                        var body = Expression.Call(serialize, ti.IsValueType
                            ? Expression.Unbox(param1, type)
                            : Expression.Convert(param1, type));
                        var lambda = Expression.Lambda<Func<object, byte[]>>(body, param1).Compile();

                        this.serialize1 = lambda;
                    }
                    {
                        // public static void Serialize<T>(ref byte[] buffer, int offset, T obj)
                        var serialize = methods.First(x => x.Name == "Serialize" && (x.GetParameters().Length == 3)).MakeGenericMethod(type);

                        var param1 = Expression.Parameter(typeof(byte[]).MakeByRefType(), "bytes");
                        var param2 = Expression.Parameter(typeof(int), "offset");
                        var param3 = Expression.Parameter(typeof(object), "obj");

                        var body = Expression.Call(serialize, param1, param2, ti.IsValueType
                            ? Expression.Unbox(param3, type)
                            : Expression.Convert(param3, type));
                        var lambda = Expression.Lambda<RefSerialize>(body, param1, param2, param3).Compile();

                        this.serialize2 = lambda;
                    }
                    {
                        // public static void Serialize<T>(Stream stream, T obj)
                        var serialize = methods.First(x => x.Name == "Serialize" && (x.GetParameters().Length == 2)).MakeGenericMethod(type);

                        var param1 = Expression.Parameter(typeof(Stream), "stream");
                        var param2 = Expression.Parameter(typeof(object), "obj");

                        var body = Expression.Call(serialize, param1, ti.IsValueType
                            ? Expression.Unbox(param2, type)
                            : Expression.Convert(param2, type));
                        var lambda = Expression.Lambda<Action<Stream, object>>(body, param1, param2).Compile();

                        this.serialize3 = lambda;
                    }

                    {
                        // public static T Deserialize<T>(byte[] bytes)
                        var deserialize = methods.First(x => x.Name == "Deserialize" && x.GetParameters()[0].ParameterType == typeof(byte[])).MakeGenericMethod(type);

                        var param1 = Expression.Parameter(typeof(byte[]), "bytes");
                        var body = Expression.Convert(Expression.Call(deserialize, param1), typeof(object));
                        var lambda = Expression.Lambda<Func<byte[], object>>(body, param1).Compile();

                        this.deserialize1 = lambda;
                    }
                    {
                        // public static T Deserialize<T>(byte[] bytes, int offset)
                        var deserialize = methods.First(x => x.Name == "Deserialize" && x.GetParameters().Length == 2).MakeGenericMethod(type);

                        var param1 = Expression.Parameter(typeof(byte[]), "bytes");
                        var param2 = Expression.Parameter(typeof(int), "offset");
                        var body = Expression.Convert(Expression.Call(deserialize, param1, param2), typeof(object));
                        var lambda = Expression.Lambda<Func<byte[], int, object>>(body, param1, param2).Compile();

                        this.deserialize2 = lambda;
                    }
                    {
                        // public static T Deserialize<T>(Stream stream)
                        var deserialize = methods.First(x => x.Name == "Deserialize" && x.GetParameters()[0].ParameterType == typeof(Stream)).MakeGenericMethod(type);

                        var param1 = Expression.Parameter(typeof(Stream), "stream");
                        var body = Expression.Convert(Expression.Call(deserialize, param1), typeof(object));
                        var lambda = Expression.Lambda<Func<Stream, object>>(body, param1).Compile();

                        this.deserialize3 = lambda;
                    }

                    {
                        // public static T Convert<T>(T obj)
                        var convert = methods.First(x => x.Name == "Convert").MakeGenericMethod(type);

                        var param1 = Expression.Parameter(typeof(object), "obj");
                        var param2 = Expression.Parameter(typeof(bool), "forceConvert");
                        var callConvert = Expression.Call(convert, ti.IsValueType
                                ? Expression.Unbox(param1, type)
                                : Expression.Convert(param1, type), param2);
                        var body = Expression.Convert(callConvert, typeof(object));
                        var lambda = Expression.Lambda<Func<object, bool, object>>(body, param1, param2).Compile();

                        this.convert = lambda;
                    }
                }
            }
        }

#endif

        public static class CustomSerializer<TTypeResolver>
            where TTypeResolver : ITypeResolver, new()
        {
            /// <summary>
            /// Serialize to binary.
            /// </summary>
            public static byte[] Serialize<T>(T obj)
            {
                byte[] bytes = null;
                var size = Serialize(ref bytes, 0, obj);

                if (bytes.Length != size)
                {
                    BinaryUtil.FastResize(ref bytes, size);
                }

                return bytes;
            }

            /// <summary>
            /// Serialize to binary, can accept null buffer that will be filled. return is size and ref buffer is not sized.
            /// </summary>
            public static int Serialize<T>(ref byte[] buffer, int offset, T obj)
            {
                var formatter = Formatter<TTypeResolver, T>.Default;
                if (formatter == null) throw new InvalidOperationException("Formatter not found, " + typeof(T).Name);

                return formatter.Serialize(ref buffer, offset, obj);
            }

            public static void Serialize<T>(Stream stream, T obj)
            {
                // optimized path
                // TryGetBuffer does not supports before .NET 4.6
                // MEMO: If allowgetbuffer = false, throws Exception...

                var ms = stream as MemoryStream;
                if (ms != null && ms.Position == 0)
                {
                    var zeroFormatterObj = obj as IZeroFormatterSegment;
                    if (zeroFormatterObj != null && zeroFormatterObj.CanDirectCopy())
                    {
                        var bufferRef = zeroFormatterObj.GetBufferReference();

#if NET_CORE
                    ArraySegment<byte> buf;
                    if (ms.TryGetBuffer(out buf))
                    {
                        ms.SetLength(bufferRef.Count);
                        var dest = buf.Array;
                        Buffer.BlockCopy(bufferRef.Array, bufferRef.Offset, dest, 0, bufferRef.Count);
                        return;
                    }
#else
                        ms.SetLength(bufferRef.Count);
                        var dest = ms.GetBuffer();
                        Buffer.BlockCopy(bufferRef.Array, bufferRef.Offset, dest, 0, bufferRef.Count);
                        return;
#endif
                    }
                }

                var buffer = Serialize<T>(obj);
                stream.Write(buffer, 0, buffer.Length);
            }

            public static T Deserialize<T>(byte[] bytes)
            {
                var formatter = Formatter<TTypeResolver, T>.Default;
                if (formatter == null) throw new InvalidOperationException("Formatter not found, " + typeof(T).Name);

                var tracker = formatter.NoUseDirtyTracker ? DirtyTracker.NullTracker : new DirtyTracker();
                int _;
                return formatter.Deserialize(ref bytes, 0, tracker, out _);
            }

            public static T Deserialize<T>(byte[] bytes, int offset)
            {
                var formatter = Formatter<TTypeResolver, T>.Default;
                if (formatter == null) throw new InvalidOperationException("Formatter not found, " + typeof(T).Name);

                var tracker = formatter.NoUseDirtyTracker ? DirtyTracker.NullTracker : new DirtyTracker();
                int _;
                return formatter.Deserialize(ref bytes, offset, tracker, out _);
            }

            public static T Deserialize<T>(Stream stream)
            {
                var ms = stream as MemoryStream;
                var formatter = Formatter<TTypeResolver, T>.Default;
                var tracker = formatter.NoUseDirtyTracker ? DirtyTracker.NullTracker : new DirtyTracker();
                if (ms != null)
                {
#if NET_CORE
                ArraySegment<byte> b;
                if (ms.TryGetBuffer(out b))
                {
                    var buffer = b.Array;
                    int _;
                    return formatter.Deserialize(ref buffer, b.Offset, tracker, out _);
                }
#else
                    var buffer = ms.GetBuffer();
                    int _;
                    return formatter.Deserialize(ref buffer, (int)ms.Position, tracker, out _);
#endif
                }

                {
                    var buffer = FillFromStream(stream);
                    var array = buffer.Array;
                    int _;
                    return formatter.Deserialize(ref array, buffer.Offset, tracker, out _);
                }
            }

            public static T Convert<T>(T obj, bool forceConvert = false)
            {
                var wrapper = obj as IZeroFormatterSegment;
                if (!forceConvert)
                {
                    if (wrapper != null && wrapper.CanDirectCopy())
                    {
                        return obj;
                    }
                }

                return Deserialize<T>(Serialize(obj));
            }
        }
    }
}