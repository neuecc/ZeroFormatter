namespace ZeroFormatter
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
            ZeroFormatterInitializer.Register(); // call before hand register.

            Formatter.RegisterDictionary<DefaultResolver, int, int>();
            Formatter.RegisterDictionary<DefaultResolver, string, string>();
            Formatter.RegisterDictionary<DefaultResolver, int, string>();
            Formatter.RegisterLazyDictionary<DefaultResolver, int, int>();
            Formatter.RegisterLazyDictionary<DefaultResolver, string, string>();
            Formatter.RegisterLazyDictionary<DefaultResolver, int, string>();
            Formatter.RegisterList<DefaultResolver, int?>();
            Formatter.RegisterList<DefaultResolver, double>();
            Formatter.RegisterList<DefaultResolver, double?>();
            Formatter.RegisterList<DefaultResolver, string>();

            Formatter.RegisterLookup<DefaultResolver, bool, int>();
            Formatter.RegisterLookup<DefaultResolver, int, int>();
            Formatter.RegisterLazyLookup<DefaultResolver, bool, int>();
            Formatter.RegisterLazyLookup<DefaultResolver, int, int>();

            var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector3Formatter<DefaultResolver>();
            ZeroFormatter.Formatters.Formatter<DefaultResolver, global::UnityEngine.Vector3>.Register(structFormatter);
            Formatter.RegisterArray<DefaultResolver, UnityEngine.Vector3>();

            Formatter.RegisterArray<DefaultResolver, Sandbox.Shared.IStandardUnion>();

            Formatter.RegisterArray<DefaultResolver, Sandbox.Shared.StandardEnum>();
            Formatter.RegisterList<DefaultResolver, Sandbox.Shared.StandardEnum>();
            Formatter.RegisterCollection<DefaultResolver, Sandbox.Shared.StandardEnum, List<Sandbox.Shared.StandardEnum>>();
        }
    }
}
