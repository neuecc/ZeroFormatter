using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class SequenceFormatterTest
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void PrimitiveArrayFormatter()
        {
            /*
        Tuple.Create(typeof(Int16), 2),
        Tuple.Create(typeof(Int32), 4),
        Tuple.Create(typeof(Int64), 8),
        Tuple.Create(typeof(UInt16), 2),
        Tuple.Create(typeof(UInt32), 4),
        Tuple.Create(typeof(UInt64), 8),
        Tuple.Create(typeof(Single), 4),
        Tuple.Create(typeof(Double), 8),
        Tuple.Create(typeof(bool), 1),
        Tuple.Create(typeof(byte), 1),
        Tuple.Create(typeof(sbyte), 1),
        Tuple.Create(typeof(char), 2),
            */

            ZeroFormatterSerializer.Convert(new Int16[] { 1, 2, 3, short.MinValue, short.MaxValue }).Is((short)1, (short)2, (short)3, short.MinValue, short.MaxValue);
            ZeroFormatterSerializer.Convert(new Int32[] { 1, 2, 3, int.MinValue, int.MaxValue }).Is((Int32)1, (Int32)2, (Int32)3, int.MinValue, int.MaxValue);
            ZeroFormatterSerializer.Convert(new Int64[] { 1, 2, 3, long.MinValue, long.MaxValue }).Is((Int64)1, (Int64)2, (Int64)3, long.MinValue, long.MaxValue);
            ZeroFormatterSerializer.Convert(new UInt16[] { 1, 2, 3, UInt16.MinValue, UInt16.MaxValue }).Is((UInt16)1, (UInt16)2, (UInt16)3, UInt16.MinValue, UInt16.MaxValue);
            ZeroFormatterSerializer.Convert(new UInt32[] { 1, 2, 3, UInt32.MinValue, UInt32.MaxValue }).Is((UInt32)1, (UInt32)2, (UInt32)3, UInt32.MinValue, UInt32.MaxValue);
            ZeroFormatterSerializer.Convert(new UInt64[] { 1, 2, 3, UInt64.MinValue, UInt64.MaxValue }).Is((UInt64)1, (UInt64)2, (UInt64)3, UInt64.MinValue, UInt64.MaxValue);
            ZeroFormatterSerializer.Convert(new Single[] { float.MinValue, 2.2f, float.MaxValue }).Is(float.MinValue, 2.2f, float.MaxValue);
            ZeroFormatterSerializer.Convert(new Double[] { double.MinValue, 2.2, double.MaxValue }).Is(double.MinValue, 2.2, double.MaxValue);
            ZeroFormatterSerializer.Convert(new Boolean[] { true, false, true }).Is(true, false, true);
            ZeroFormatterSerializer.Convert(new byte[] { 0, 1, 2, byte.MinValue, byte.MaxValue }).Is((byte)0, (byte)1, (byte)2, byte.MinValue, byte.MaxValue);
            ZeroFormatterSerializer.Convert(new sbyte[] { 0, 1, 2, sbyte.MinValue, sbyte.MaxValue }).Is((sbyte)0, (sbyte)1, (sbyte)2, sbyte.MinValue, sbyte.MaxValue);
            ZeroFormatterSerializer.Convert(new char[] { char.MinValue, char.MaxValue, 'a', 'あ' }).Is(char.MinValue, char.MaxValue, 'a', 'あ');

        }

        [TestMethod]
        public void ArrayFormatter()
        {
            {
                var conv = ZeroFormatterSerializer.Convert(new[]
                {
                    new MyVector(1.32342f, 32423.342f),
                    new MyVector(-1.0f, 42.452f),
                    new MyVector(0f, -32662.25252f),
                });

                conv[0].X.Is(1.32342f); conv[0].Y.Is(32423.342f);
                conv[1].X.Is(-1.0f); conv[1].Y.Is(42.452f);
                conv[2].X.Is(0f); conv[2].Y.Is(-32662.25252f);
            }
            {
                var conv = ZeroFormatterSerializer.Convert(new[]
                {
                    new MyVectorClass(1.32342f, 32423.342f),
                    new MyVectorClass(-1.0f, 42.452f),
                    new MyVectorClass(0f, -32662.25252f),
                });

                conv[0].X.Is(1.32342f); conv[0].Y.Is(32423.342f);
                conv[1].X.Is(-1.0f); conv[1].Y.Is(42.452f);
                conv[2].X.Is(0f); conv[2].Y.Is(-32662.25252f);
            }
        }

        [TestMethod]
        public void SequenceDictionaryFormatter()
        {
            {
                var r = ZeroFormatterSerializer.Convert(new Dictionary<int, string> { { 1, "a" }, { 2, "b" }, { 3, "cdefg" } });
                r[1].Is("a");
                r[2].Is("b");
                r[3].Is("cdefg");
            }
        }

        [TestMethod]
        public void CollectionFormatter()
        {
            {
                var r = ZeroFormatterSerializer.Convert(new List<int> { 1, 10, 100, 1000, 10000 });
                r.Is(1, 10, 100, 1000, 10000);
            }
            {
                var r = ZeroFormatterSerializer.Convert(new HashSet<string> { "a", "b", "cdefg" });
                r.OrderBy(x => x).Is("a", "b", "cdefg");
            }
        }


        [TestMethod]
        public void WellknownInterfaces()
        {
            var baseObject = new SequenceFormat()
            {
                ArrayFormat = new[] { new MyStructFixed(1, 10, 3.4f), new MyStructFixed(2, 6, 5.2f) },
                CollectionFormat = new List<int> { 1, 10, 100 },
                DictionaryFormat = new Dictionary<int, int> { { 1, 100 }, { -4, 9999 } },
                InterafceDictionaryFormat = new Dictionary<int, int> { { 1, 100 }, { -4, 9999 } },
                InterfaceCollectionFormat = new[] { 1, 10, 1000 },
                InterfaceEnumerableFormat = new[] { 1, 2, 3 },
                InterfaceReadOnlyCollectionFormat = new[] { 5, 6, 7 },
                InterfaceSetFormat = new HashSet<int>(new[] { 1, 9099, 3452 }),
                ReadOnlyCollectionFormat = new System.Collections.ObjectModel.ReadOnlyCollection<int>(new[] { 1, 10, 100 }),
                ReadOnlyDictionaryFormat = new System.Collections.ObjectModel.ReadOnlyDictionary<int, int>(new Dictionary<int, int> { { 9, 9999 } }),
                InterfaceReadOnlyDictionaryFormat = new System.Collections.ObjectModel.ReadOnlyDictionary<int, int>(new Dictionary<int, int> { { 9, 9999 } }),
                LookupFormat = Enumerable.Range(1, 5).ToLookup(x => x % 2 == 0)
            };

            var converted = ZeroFormatterSerializer.Convert(baseObject, true);

            converted.ArrayFormat[0].MyProperty1.Is(1); converted.ArrayFormat[0].MyProperty2.Is(10); converted.ArrayFormat[0].MyProperty3.Is(3.4f);
            converted.ArrayFormat[1].MyProperty1.Is(2); converted.ArrayFormat[1].MyProperty2.Is(6); converted.ArrayFormat[1].MyProperty3.Is(5.2f);

            converted.CollectionFormat.Is(1, 10, 100);
            converted.DictionaryFormat[1].Is(100); converted.DictionaryFormat[-4].Is(9999);
            converted.InterafceDictionaryFormat[1].Is(100); converted.InterafceDictionaryFormat[-4].Is(9999);
            converted.InterfaceCollectionFormat.Is(1, 10, 1000);
            converted.InterfaceEnumerableFormat.Is(1, 2, 3);
            converted.ReadOnlyCollectionFormat.Is(1, 10, 100);
            converted.InterfaceSetFormat.OrderBy(x => x).Is(1, 3452, 9099);
            converted.ReadOnlyCollectionFormat.Is(1, 10, 100);
            converted.ReadOnlyDictionaryFormat[9].Is(9999);
            converted.InterfaceReadOnlyDictionaryFormat[9].Is(9999);
            converted.LookupFormat[true].Is(2, 4);
            converted.LookupFormat[false].Is(1, 3, 5);
        }
    }
}
