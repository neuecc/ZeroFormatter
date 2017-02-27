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
        public bool ForceDefaultResolver { get; set; }
    }

    public class EnumType : IEquatable<EnumType>
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Namespace { get; set; }
        public string UnderlyingType { get; set; }
        public int Length { get; set; }
        public bool IncludeNullable { get; set; }
        public bool IsGenerateEqualityComparer { get; set; }

        public bool Equals(EnumType other)
        {
            return FullName == other.FullName;
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode();
        }
    }

    public partial class UnionGenerator
    {
        public string Namespace { get; set; }
        public UnionType[] Types { get; set; }
        public bool ForceDefaultResolver { get; set; }
    }

    public class UnionType
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Namespace { get; set; }
        public string UnionKeyTypeName { get; set; }
        public string FallbackTypeName { get; set; }
        public string UnionKeyPropertyName { get; set; }
        public string[] SubTypeNames { get; set; }
    }

    public partial class ObjectGenerator
    {
        public string Namespace { get; set; }
        public ObjectSegmentType[] Types { get; set; }
        public bool ForceDefaultResolver { get; set; }
    }

    public partial class StructGenerator
    {
        public string Namespace { get; set; }
        public ObjectSegmentType[] Types { get; set; }
        public bool ForceDefaultResolver { get; set; }
    }

    public class ObjectSegmentType
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Namespace { get; set; }
        public int LastIndex { get; set; }
        public PropertyTuple[] Properties { get; set; } // Property or Field:)

        public class PropertyTuple
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public bool IsGetProtected { get; set; }
            public bool IsSetProtected { get; set; }
            public bool IsCacheSegment { get; set; }
            public bool IsFixedSize { get; set; }
            public bool IsProperty { get; set; }
            public int FixedSize { get; set; }
        }

        public int[] ElementFixedSizes
        {
            get
            {
                if (Properties.Length == 0) return new int[0];

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

        public int? GetLength()
        {
            if (Properties.Length == 0) return 0;
            
            var sum = 0;
            foreach (var item in Properties)
            {
                if (!item.IsFixedSize) return null;
                sum += item.FixedSize;
            }

            return sum;
        }
    }

    public partial class InitializerGenerator
    {
        public ObjectGenerator[] Objects { get; set; }
        public StructGenerator[] Structs { get; set; }
        public EnumGenerator[] Enums { get; set; }
        public UnionGenerator[] Unions { get; set; }
        public GenericType[] GenericTypes { get; set; }
        public bool UnuseUnityAttribute { get; set; }
        public bool ForceDefaultResolver { get; set; }
        public string ResolverName { get; set; }
        public string Namespace { get; set; }
    }

    public class GenericType : IEquatable<GenericType>, IComparable<GenericType>
    {
        public GenericTypeKind TypeKind { get; set; }
        public string ElementTypes { get; set; } // ", " joined

        public bool Equals(GenericType other)
        {
            return (this.TypeKind == other.TypeKind) && (this.ElementTypes == other.ElementTypes);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(this.TypeKind, this.ElementTypes).GetHashCode();
        }

        public int CompareTo(GenericType other)
        {
            return Comparer<Tuple<GenericTypeKind, string>>.Default.Compare(Tuple.Create(TypeKind, ElementTypes), Tuple.Create(other.TypeKind, other.ElementTypes));
        }
    }

    public enum GenericTypeKind
    {
        KeyTuple,
        List,
        ReadOnlyList,
        Dictionary,
        LazyDictionary,
        LazyReadOnlyDictionary,
        Lookup,
        LazyLookup,
        Array,
        Collection,
        InterfaceCollection,
        Enumerable,
        ReadOnlyCollection,
        KeyValuePair
    }
}