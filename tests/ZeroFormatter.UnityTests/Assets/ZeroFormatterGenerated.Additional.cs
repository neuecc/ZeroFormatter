namespace ZeroFormatter.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public static partial class ZeroFormatterInitializer
    {
        // TODO:Test, hand register

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register2()
        {
            Formatter<IDictionary<int, string>>.Register(new DictionaryFormatter<int, string>());
            Formatter<DictionaryEntry<int, string>>.Register(new DictionaryEntryFormatter<int, string>());

            Formatter<IList<int>>.Register(new ListFormatter<int>());
            Formatter<IList<string>>.Register(new ListFormatter<string>());

            Formatter<ILookup<bool, int>>.Register(new LookupFormatter<bool, int>());
            Formatter<GroupingSegment<bool, int>>.Register(new GroupingSegmentFormatter<bool, int>());

            Formatter<IDictionary<string, int>>.Register(new DictionaryFormatter<string, int>());
            Formatter<DictionaryEntry<string, int>>.Register(new DictionaryEntryFormatter<string, int>());
        }
    }
}
