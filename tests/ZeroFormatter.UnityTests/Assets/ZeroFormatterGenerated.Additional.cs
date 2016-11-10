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
        // hand register test

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void HandRegisterd()
        {
            Formatter.RegisterDictionary<int, int>();
            Formatter.RegisterDictionary<string, string>();
            Formatter.RegisterDictionary<int, string>();
            Formatter.RegisterLazyDictionary<int, int>();
            Formatter.RegisterLazyDictionary<string, string>();
            Formatter.RegisterLazyDictionary<int, string>();
            Formatter.RegisterList<int?>();
            Formatter.RegisterList<double>();
            Formatter.RegisterList<double?>();
            Formatter.RegisterList<string>();

            Formatter.RegisterLookup<bool, int>();
            Formatter.RegisterLookup<int, int>();
            Formatter.RegisterLazyLookup<bool, int>();
            Formatter.RegisterLazyLookup<int, int>();

            var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector3Formatter();
            ZeroFormatter.Formatters.Formatter<global::UnityEngine.Vector3>.Register(structFormatter);
            Formatter.RegisterArray<UnityEngine.Vector3>();
        }
    }
}
