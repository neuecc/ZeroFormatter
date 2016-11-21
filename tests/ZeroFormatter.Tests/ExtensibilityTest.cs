using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    public class CannotSerialize
    {
        public int MyProperty1 { get; private set; }
        public string MyProperty2 { get; private set; }

        public CannotSerialize(int p1, string p2)
        {
            this.MyProperty1 = p1;
            this.MyProperty2 = p2;
        }
    }

    public class CannotSerializeFormatter : Formatter<DefaultResolver, CannotSerialize>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, CannotSerialize value)
        {
            var start = offset;
            offset += Formatter<DefaultResolver, int>.Default.Serialize(ref bytes, offset, value.MyProperty1);
            offset += Formatter<DefaultResolver, string>.Default.Serialize(ref bytes, offset, value.MyProperty2);
            return offset - start;
        }

        public override CannotSerialize Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var size = 0;
            byteSize = 0;
            var p1 = Formatter<DefaultResolver, int>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var p2 = Formatter<DefaultResolver, string>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            return new CannotSerialize(p1, p2);
        }
    }

    public class KeyValuePairFormatter<TKey, TValue> : Formatter<DefaultResolver, KeyValuePair<TKey, TValue>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyValuePair<TKey, TValue> value)
        {
            var start = offset;
            offset += Formatter<DefaultResolver, TKey>.Default.Serialize(ref bytes, offset, value.Key);
            offset += Formatter<DefaultResolver, TValue>.Default.Serialize(ref bytes, offset, value.Value);
            return offset - start;
        }

        public override KeyValuePair<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var size = 0;
            byteSize = 0;
            var p1 = Formatter<DefaultResolver, TKey>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var p2 = Formatter<DefaultResolver, TValue>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            return new KeyValuePair<TKey, TValue>(p1, p2);
        }
    }

    public class UriFormatter : Formatter<DefaultResolver, Uri>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Uri value)
        {
            var uri = value.ToString();
            return Formatter<DefaultResolver, string>.Default.Serialize(ref bytes, offset, uri);
        }

        public override Uri Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var str = Formatter<DefaultResolver, string>.Default.Deserialize(ref bytes, offset, tracker, out byteSize);
            return new Uri(str);
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ExtensibilityTest
    {
        [TestMethod]
        public void Extensiblity()
        {
            Formatter.AppendFormatterResolver(t =>
            {
                if (t == typeof(CannotSerialize))
                {
                    return new CannotSerializeFormatter();
                }

                return null;
            });

            Formatter.AppendFormatterResolver(t =>
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                {
                    return Activator.CreateInstance(typeof(KeyValuePairFormatter<,>).MakeGenericType(t.GenericTypeArguments));
                }

                return null;
            });

            Formatter.AppendFormatterResolver(t =>
            {
                if (t == typeof(Uri))
                {
                    return new UriFormatter();
                }

                return null;
            });

            var a = ZeroFormatterSerializer.Convert(new CannotSerialize(99, "aaa"));
            a.MyProperty1.Is(99);
            a.MyProperty2.Is("aaa");

            var b = ZeroFormatterSerializer.Convert(new KeyValuePair<string, int>("hoge", 1000));
            b.Key.Is("hoge");
            b.Value.Is(1000);

            var c = ZeroFormatterSerializer.Convert(new Uri("http://google.co.jp/"));
            c.ToString().Is("http://google.co.jp/");
        }
    }
}
