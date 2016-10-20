namespace ZeroFormatter.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;
    using global::ZeroFormatter.Comparers;

    public static partial class ZeroFormatterInitializer
    {
        // hand register

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void HandRegisterd()
        {
            Formatter<IDictionary<int, int>>.Register(new DictionaryFormatter<int, int>());
            Formatter<DictionaryEntry<int, int>>.Register(new DictionaryEntryFormatter<int, int>());
            Formatter<IDictionary<string, string>>.Register(new DictionaryFormatter<string, string>());
            Formatter<DictionaryEntry<string, string>>.Register(new DictionaryEntryFormatter<string, string>());
            Formatter<IDictionary<int, string>>.Register(new DictionaryFormatter<int, string>());
            Formatter<DictionaryEntry<int, string>>.Register(new DictionaryEntryFormatter<int, string>());

            GenericFormatter.RegisterDictionary<int, int>();
            GenericFormatter.RegisterDictionary<string, string>();
            GenericFormatter.RegisterDictionary<int, string>();
            GenericFormatter.RegisterList<int?>();
            GenericFormatter.RegisterList<double>();
            GenericFormatter.RegisterList<double?>();
            GenericFormatter.RegisterList<string>();

            GenericFormatter.RegisterLookup<bool, int>();
            GenericFormatter.RegisterLookup<int, int>();
        }
    }
}
