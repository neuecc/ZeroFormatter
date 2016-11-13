using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZeroFormatter;
using ZeroFormatter.Tests;

namespace Sandbox.Shared
{
    [ZeroFormattable]
    public class AllNewFormat
    {
        [Index(0)]
        public virtual Int16[] A1 { get; set; }
        [Index(1)]
        public virtual Int32[] A2 { get; set; }
        [Index(2)]
        public virtual Int64[] A3 { get; set; }
        [Index(3)]
        public virtual UInt16[] A4 { get; set; }
        [Index(4)]
        public virtual UInt32[] A5 { get; set; }
        [Index(5)]
        public virtual UInt64[] A6 { get; set; }
        [Index(6)]
        public virtual Single[] A7 { get; set; }
        [Index(7)]
        public virtual Double[] A8 { get; set; }
        [Index(8)]
        public virtual bool[] A9 { get; set; }
        [Index(9)]
        public virtual byte[] A10 { get; set; }
        [Index(10)]
        public virtual sbyte[] A11 { get; set; }
        [Index(11)]
        public virtual char[] A12 { get; set; }
        [Index(12)]
        public virtual MyVector[] V1 { get; set; }
        [Index(13)]
        public virtual MyVectorClass[] V2 { get; set; }
        [Index(14)]
        public virtual Dictionary<int, string> V3 { get; set; }
        [Index(15)]
        public virtual List<int> V4 { get; set; }
        [Index(16)]
        public virtual HashSet<string> V5 { get; set; }
        [Index(17)]
        public virtual KeyValuePair<int, string> V6 { get; set; }
    }

    [ZeroFormattable]
    public class CustomFormat
    {
        [Index(0)]
        public virtual Guid AllowGuid { get; set; }
    }



#pragma warning disable ZeroFormatterAnalyzer_TypeMustBeZeroFormattable // Lint of ZeroFormattable Type.

    [ZeroFormattable]
    public class SequenceFormat
    {
        [Index(0)]
        public virtual MyStructFixed[] ArrayFormat { get; set; }
        [Index(1)]
        public virtual List<int> CollectionFormat { get; set; }
        [Index(2)]
        public virtual ReadOnlyCollection<int> ReadOnlyCollectionFormat { get; set; }
        [Index(3)]
        public virtual Dictionary<int, int> DictionaryFormat { get; set; }
        [Index(4)]
        public virtual IDictionary<int, int> InterafceDictionaryFormat { get; set; }
        [Index(5)]

        public virtual ICollection<int> InterfaceCollectionFormat { get; set; }

        [Index(6)]
        public virtual IEnumerable<int> InterfaceEnumerableFormat { get; set; }

#if !UNITY

        [Index(7)]
        public virtual ISet<int> InterfaceSetFormat { get; set; }
        [Index(8)]
        public virtual IReadOnlyCollection<int> InterfaceReadOnlyCollectionFormat { get; set; }
        [Index(9)]
        public virtual ReadOnlyDictionary<int, int> ReadOnlyDictionaryFormat { get; set; }
        [Index(10)]
        public virtual IReadOnlyDictionary<int, int> InterfaceReadOnlyDictionaryFormat { get; set; }

#endif


        [Index(11)]
        public virtual ILookup<bool, int> LookupFormat { get; set; }


#pragma warning restore ZeroFormatterAnalyzer_TypeMustBeZeroFormattable // Lint of ZeroFormattable Type.
    }

}


