using RuntimeUnitTestToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroFormatter.Tests
{
    public static class UnitTestLoader
    {
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            UnitTest.RegisterAllMethods<BinaryUtilTest>();
            UnitTest.RegisterAllMethods<DictionaryFormatterTest>();
            UnitTest.RegisterAllMethods<DictionarySegmentTest>();
            UnitTest.RegisterAllMethods<FormatterTest>();
            UnitTest.RegisterAllMethods<KeyTupleFormatterTest>();
            UnitTest.RegisterAllMethods<ListFormatterTest>();
            UnitTest.RegisterAllMethods<LookupSegmentTest>();
            UnitTest.RegisterAllMethods<NullCheckTest>();
            UnitTest.RegisterAllMethods<ObjectFormatterTest>();
            UnitTest.RegisterAllMethods<StringSegmentTest>();
            UnitTest.RegisterAllMethods<InheritanceTest>();
            UnitTest.RegisterAllMethods<OffsetTest>();
            UnitTest.RegisterAllMethods<BlockSerializeTest>();
            UnitTest.RegisterAllMethods<StructTest>();
            UnitTest.RegisterAllMethods<VersioningTest>();
            UnitTest.RegisterAllMethods<EqualityCompTest>();
            UnitTest.RegisterAllMethods<SequenceTest>();
            UnitTest.RegisterAllMethods<UnionTest>();
            UnitTest.RegisterAllMethods<ZeroArgumentTest>();
            UnitTest.RegisterAllMethods<ArrayTest>();

            UnitTest.RegisterAllMethods<PerformanceTest>();
        }
    }
}
