using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.CodeGenerator
{
    public partial class EnumGenerator
    {
        public string Namespace { get; set; }
        public EnumType[] Types { get; set; }
    }

    public class EnumType
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string UnderlyingType { get; set; }
        public int Length { get; set; }
    }


    public partial class ObjectGenerator
    {
        public string Namespace { get; set; }
        public ObjectSegmentType[] Types { get; set; }
    }

    public class ObjectSegmentType
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Namespace { get; set; }
        public int LastIndex { get; set; }
        public PropertyTuple[] Properties { get; set; }

        public class PropertyTuple
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public bool IsGetProtected { get; set; }
            public bool IsSetProtected { get; set; }
            public bool IsCacheSegment { get; set; }
            public bool IsFixedSize { get; set; }
            public int FixedSize { get; set; }
        }

        public int[] ElementFixedSizes
        {
            get
            {
                var schemaLastIndex = Properties.Select(x => x.Index).LastOrDefault();
                var dict = Properties.Where(x => x.IsFixedSize).ToDictionary(x => x.Index, x => x.FixedSize);
                var elementSizes = new int[schemaLastIndex + 1];
                for (int i = 0; i < schemaLastIndex + 1; i++)
                {
                    if (!dict.TryGetValue(i, out elementSizes[i]))
                    {
                        elementSizes[i] = 0;
                    }
                }

                return elementSizes;
            }
        }
    }

    public partial class InitializerGenerator
    {
        public ObjectGenerator[] Objects { get; set; }
        public EnumGenerator[] Enums { get; set; }
        public GenericType[] GenericTypes { get; set; }
    }

    public class GenericType : IEqualityComparer<GenericType>
    {
        public GenericTypeKind TypeKind { get; set; }
        public string Type { get; set; }
        public string ElementTypes { get; set; } // ", " joined

        public bool Equals(GenericType x, GenericType y)
        {
            return (x.TypeKind == y.TypeKind) && (x.Type == y.Type);
        }

        public int GetHashCode(GenericType obj)
        {
            return Tuple.Create(obj.TypeKind, obj.Type).GetHashCode();
        }
    }

    public enum GenericTypeKind
    {
        KeyTuple, // needs to create KeyTupleFormatter, KeyTupleEqualityComparer, NullableKeyTupleFormatter
        List, // needs to create ListFormatter
        Dictionary, // needs to create DictionaryFormatter, DictionaryEntryFormatter
        Lookup, // needs to create LookupFormatter, GroupingSegmentFormatter
    }
}