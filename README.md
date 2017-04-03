ZeroFormatter
===
Fastest C# Serializer and Infinitely Fast Deserializer for .NET, .NET Core and Unity.

[![Gitter](https://badges.gitter.im/neuecc/ZeroFormatter.svg)](https://gitter.im/neuecc/ZeroFormatter?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

![image](https://cloud.githubusercontent.com/assets/46207/20072942/ba760e70-a56d-11e6-918f-edf84f0187da.png)

Note: this is **unfair** comparison, please see the [performance](https://github.com/neuecc/ZeroFormatter#performance) section for the details.

Why use ZeroFormatter?
---
* **Fastest** C# serializer, the code is extremely tuned by both implementation and binary layout(see: [performance](https://github.com/neuecc/ZeroFormatter#performance))
* Deserialize/re-serialize is Infinitely fast because formatter can access to serialized data without parsing/packing(see: [architecture](https://github.com/neuecc/ZeroFormatter#architecture))
* Strongly Typed and C# Code as schema, no needs to other IDL like `.proto`, `.fbs`...
* Smart API, only to use `Serialize<T>` and `Deserialize<T>`
* Full set of general purpose, multifunctional serializer, supports Union(Polymorphism) and native support of Dictionary, MultiDictionary(ILookup)
* First-class support to Unity(IL2CPP), it's faster than native JsonUtility

ZeroFormatter is similar as [FlatBuffers](http://google.github.io/flatbuffers/) but ZeroFormatter has clean API(FlatBuffers API is too ugly, [see: sample](https://github.com/google/flatbuffers/blob/master/samples/SampleBinary.cs); we can not use regularly) and C# specialized. If you need to performance such as Game, Distributed Computing, Microservices, etc..., ZeroFormatter will help you.

Install
---
for .NET, .NET Core

* PM> Install-Package [ZeroFormatter](https://www.nuget.org/packages/ZeroFormatter)

for Unity(Interfaces can reference both .NET 3.5 and Unity for share types), Unity binary exists on [ZeroFormatter/Releases](https://github.com/neuecc/ZeroFormatter/releases) as well. More details, please see the [Unity-Supports](https://github.com/neuecc/ZeroFormatter#unity-supports) section.

* PM> Install-Package [ZeroFormatter.Interfaces](https://www.nuget.org/packages/ZeroFormatter.Interfaces/)
* PM> Install-Package [ZeroFormatter.Unity](https://www.nuget.org/packages/ZeroFormatter.Unity)

Visual Studio Analyzer

* PM> Install-Package [ZeroFormatter.Analyzer](https://www.nuget.org/packages/ZeroFormatter.Analyzer)

Quick Start
---
Define class and mark as `[ZeroFormattable]` and public properties mark `[Index]` and declare `virtual`, call `ZeroFormatterSerializer.Serialize<T>/Deserialize<T>`. 

```csharp
// mark ZeroFormattableAttribute
[ZeroFormattable]
public class MyClass
{
    // Index is key of serialization
    [Index(0)]
    public virtual int Age { get; set; }

    [Index(1)]
    public virtual string FirstName { get; set; }

    [Index(2)]
    public virtual string LastName { get; set; }

    // When mark IgnoreFormatAttribute, out of the serialization target
    [IgnoreFormat]
    public string FullName { get { return FirstName + LastName; } }

    [Index(3)]
    public virtual IList<int> List { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var mc = new MyClass
        {
            Age = 99,
            FirstName = "hoge",
            LastName = "huga",
            List = new List<int> { 1, 10, 100 }
        };

        var bytes = ZeroFormatterSerializer.Serialize(mc);
        var mc2 = ZeroFormatterSerializer.Deserialize<MyClass>(bytes);

        // ZeroFormatter.DynamicObjectSegments.MyClass
        Console.WriteLine(mc2.GetType().FullName);
    }
}
```

Serializable target must mark `ZeroFormattableAttribute`, there public property must be `virtual` and requires `IndexAttribute`.

Analyzer
---
ZeroFormatter.Analyzer helps object definition. Attributes, accessibility etc are detected and it becomes a compiler error.

![zeroformatteranalyzer](https://cloud.githubusercontent.com/assets/46207/20078766/3ea54f14-a585-11e6-9873-b99cb5d9efe5.gif)

If you want to allow a specific type (for example, when registering a custom type), put `ZeroFormatterAnalyzer.json` at the project root and make the Build Action to `AdditionalFiles`.

![image](https://cloud.githubusercontent.com/assets/46207/20149311/0e6f73d6-a6f4-11e6-91cb-44c771c267cb.png)

This is a sample of the contents of ZeroFormatterAnalyzer.json. 

```
[ "System.Uri" ]
```

Built-in support types
---
All primitives, All enums, `TimeSpan`,  `DateTime`, `DateTimeOffset`, `Guid`, `Tuple<,...>`, `KeyValuePair<,>`, `KeyTuple<,...>`, `Array`, `List<>`, `HashSet<>`, `Dictionary<,>`, `ReadOnlyCollection<>`, `ReadOnlyDictionary<,>`, `IEnumerable<>`, `ICollection<>`, `IList<>`, `ISet<,>`, `IReadOnlyCollection<>`, `IReadOnlyList<>`, `IReadOnlyDictionary<,>`, `ILookup<,>` and inherited `ICollection<>` with paramterless constructor. Support type can extend easily, see: [Extensibility](https://github.com/neuecc/ZeroFormatter#extensibility) section.

Define object rules
---
There rules can detect ZeroFormatter.Analyzer.

* Type must be marked with ZeroformattableAttribute.  
* Public property must be marked with IndexAttribute or IgnoreFormatAttribute.
* Public property's must needs both public/protected get and set accessor.
* Public property's accessor must be virtual.
* Class is only supported public property not field(If struct can define field).
* IndexAttribute is not allowed duplicate number.
* Class must needs a parameterless constructor.
* Struct index must be started with 0 and be sequential.
* Struct needs full parameter constructor of index property types.
* Union type requires UnionKey property.
* UnionKey does not support multiple keys.
* All Union sub types must be inherited type.

The definition of struct is somewhat different from class. 

```csharp
[ZeroFormattable]
public struct Vector2
{
    [Index(0)]
    public float x;
    [Index(1)]
    public float y;

    // arg0 = Index0, arg1 = Index1
    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}
```

Struct index must be started with 0 and be sequential and needs full parameter constructor of index property types.

eager/lazy-evaluation
---
ZeroFormatter has two types of evaluation, "eager-evaluation" and "lazy-evaluation". If the type is lazy-evaluation, deserialization will be infinitely fast because it does not parse. If the user-defined class or type is `IList<>`, `IReadOnlyList<>`, `ILazyLookup<>`, `ILazyDicitonary<>`, `ILazyReadOnlyDictionary<>`, deserialization of that type will be lazily evaluated.

```csharp
// MyClass is lazy-evaluation, all properties are lazily
[ZeroFormattable]
public class MyClass
{
    // int[] is eager-evaluation, when accessing Prop2, all values are deserialized
    [Index(0)]
    public virtual int[] Prop1 { get; set; }

    // IList<int> is lazy-evaluation, when accessing Prop2 with indexer, only that index value is deserialized 
    [Index(1)]
    public virtual IList<int> Prop2 { get; set; }
}
```

If you want to maximize the power of lazy-evaluation, define all collections with `IList<>`/`IReadOnlyList<>`.

`ILazyLookup<>`, `ILazyDicitonary<>`, `ILazyReadOnlyDictionary<>` is special collection interface, it defined by ZeroFormatter. The values defined in these cases are deserialized very quickly because the internal structure is also serialized in its entirety and does not need to be rebuilt data structure. But there are some limitations instead. Key type must be primitive, enum or there KeyTuple only because the key must be deterministic.

```csharp
[ZeroFormattable]
public class MyClass
{
    [Index(0)]
    public virtual ILazyDictionary<int, int> LazyDictionary { get; set; }

    [Index(1)]
    public virtual ILazyLookup<int, int> LazyLookup { get; set; }
}

// there properties can set from `AsLazy***` extension methods. 

var mc = new MyClass();

mc.LazyDictionary = Enumerable.Range(1, 10).ToDictionary(x => x).AsLazyDictionary();
mc.LazyLookup = Enumerable.Range(1, 10).ToLookup(x => x).AsLazyLookup();
```

As a precaution, the binary size will be larger because all internal structures are serialized. This is a tradeoff, please select the best case depending on the situation.

Architecture
---
When deserializing an object, it returns a byte[] wrapper object. When accessing the property, it reads the data from the offset information of the header(and cache when needed).

![image](https://cloud.githubusercontent.com/assets/46207/20246782/e11518da-aa01-11e6-99c4-aa8e55f6b726.png)

Why must we define object in virtual? The reason is to converts access to properties into access to byte buffers.

If there is no change in data, reserialization is very fast because it writes the internal buffer data as it is. All serialized data can mutate and if the property type is fixed-length(primitive and some struct),  it is written directly to internal binary data so keep the reserialization speed. If property is variable-length(string, list, object, etc...) the type and property are marked dirty. And it serializes only the difference, it is faster than normal serialization.

![](https://cloud.githubusercontent.com/assets/46207/20078613/9f9ddfda-a584-11e6-9d7c-b98f8a6ac70e.png)

> If property includes array/collection, ZeroFormatter can not track data was mutated so always marks dirty initially even if you have not mutated it. To avoid it, declare all collections with `IList<>` or `IReadOnlyList<>`.

If you want to define Immutable, you can use "protected set" and "IReadOnlyList<>".

```csharp
[ZeroFormattable]
public class ImmutableClass
{
    [Index(0)]
    public virtual int ImmutableValue { get; protected set; }

    // IReadOnlyDictionary, ILazyReadOnlyDictionary, etc, too.
    [Index(1)]
    public virtual IReadOnlyList<int> ImmutableList { get; protected set; }
}
```

Binary size is slightly larger than Protobuf, MsgPack because of needs the header index area and all primitives are fixed-length(same size as FlatBuffers, smaller than JSON). It is a good idea to compress it to shrink the data size, gzip or LZ4(recommended, LZ4 is fast compression/decompression algorithm).

Versioning
---
If schema is growing, you can add Index.

```csharp
[ZeroFormattable]
public class Version1
{
    [Index(0)]
    public virtual int Prop1 { get; set; }
    [Index(1)]
    public virtual int Prop2 { get; set; }
    
    // If deserialize from new data, ignored.
}

[ZeroFormattable]
public class Version2
{
    [Index(0)]
    public virtual int Prop1 { get; set; }
    [Index(1)]
    public virtual int Prop2 { get; set; }
    // You can add new property. If deserialize from old data, value is assigned default(T).
    [Index(2)]
    public virtual int NewType { get; set; }
}
```

But you can not delete index. If that index is unnecessary, please make it blank(such as [0, 1, 3]).

Only `class` definition is supported for versioning. Please note that `struct` is not supported.

DateTime
---
`DateTime` is serialized to UniversalTime so lose the TimeKind. If you want to change local time, use ToLocalTime after converted. 

```csharp
// in Tokyo, Japan Local Time(UTC+9)
var date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local);
Console.WriteLine(date);

// 1999/12/31 15:00:00(UTC)
var deserialized = ZeroFormatterSerializer.Deserialize<DateTime>(ZeroFormatterSerializer.Serialize(date));

// 2000/1/1 00:00:00(in Tokyo, +9:00)
var toLocal = deserialized.ToLocalTime();
```

If you want to save offset info, use DateTimeOffset instead of DateTime. 

```csharp
// in Tokyo, Japan Local Time(UTC+9)
var date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local);

// 2000/1/1, +9:00
var target = new DateTimeOffset(date);

// 2000/1/1, +9:00
var deserialized = ZeroFormatterSerializer.Deserialize<DateTimeOffset>(ZeroFormatterSerializer.Serialize(target));
```

Union
---
ZeroFormatter supports Union(Polymorphic) type. It can define abstract class and `UnionAttributes`, `UnionKeyAttribute`.

```csharp
public enum CharacterType
{
    Human, Monster
}

// UnionAttribute abstract/interface type becomes Union, arguments is union subtypes.
// It needs single UnionKey to discriminate
[Union(typeof(Human), typeof(Monster))]
public abstract class Character
{
    [UnionKey]
    public abstract CharacterType Type { get; }
}

[ZeroFormattable]
public class Human : Character
{
    // UnionKey value must return constant value(Type is free, you can use int, string, enum, etc...)
    public override CharacterType Type
    {
        get
        {
            return CharacterType.Human;
        }
    }

    [Index(0)]
    public virtual string Name { get; set; }

    [Index(1)]
    public virtual DateTime Birth { get; set; }

    [Index(2)]
    public virtual int Age { get; set; }

    [Index(3)]
    public virtual int Faith { get; set; }
}

[ZeroFormattable]
public class Monster : Character
{
    public override CharacterType Type
    {
        get
        {
            return CharacterType.Monster;
        }
    }

    [Index(0)]
    public virtual string Race { get; set; }

    [Index(1)]
    public virtual int Power { get; set; }

    [Index(2)]
    public virtual int Magic { get; set; }
}
```

You can use Union as following.

```csharp
var demon = new Monster { Race = "Demon", Power = 9999, Magic = 1000 };

// use UnionType(Character) formatter(be carefule, does not use concrete type)
var data = ZeroFormatterSerializer.Serialize<Character>(demon);

var union = ZeroFormatterSerializer.Deserialize<Character>(data);

// you can discriminate by UnionKey.
switch (union.Type)
{
    case CharacterType.Monster:
        var demon2 = (Monster)union;
        demon2.Race...
        demon2.Power..
        demon2.Magic...
        break;
    case CharacterType.Human:
        var human2 = (Human)union;
        human2.Name...
        human2.Birth...
        human2.Age..
        human2.Faith...
        break;
    default:
        Assert.Fail("invalid");
        break;
}
```

If an unknown identification key arrives, an exception is thrown by default. However, it is also possible to return the default type - fallbackType.

```csharp
// If new type received, return new UnknownEvent()
[Union(subTypes: new[] { typeof(MailEvent), typeof(NotifyEvent) }, fallbackType: typeof(UnknownEvent))]
public interface IEvent
{
    [UnionKey]
    byte Key { get; }
}

[ZeroFormattable]
public class MailEvent : IEvent
{
    [IgnoreFormat]
    public byte Key => 1;

    [Index(0)]
    public string Message { get; set; }
}

[ZeroFormattable]
public class NotifyEvent : IEvent
{
    [IgnoreFormat]
    public byte Key => 1;

    [Index(0)]
    public bool IsCritical { get; set; }
}

[ZeroFormattable]
public class UnknownEvent : IEvent
{
    [IgnoreFormat]
    public byte Key => 0;
}
```

Union can construct on execution time. You can mark `DynamicUnion` and make resolver on `AppendDynamicUnionResolver`.

```csharp
[DynamicUnion] // root of DynamicUnion
public class MessageBase
{

}

public class UnknownMessage : MessageBase { }

[ZeroFormattable]
public class MessageA : MessageBase { }

[ZeroFormattable]
public class MessageB : MessageBase
{
    [Index(0)]
    public virtual IList<IEvent> Events { get; set; }
}

ZeroFormatter.Formatters.Formatter.AppendDynamicUnionResolver((unionType, resolver) =>
{
    //can be easily extended to reflection based scan if library consumer wants it
    if (unionType == typeof(MessageBase))
    {
        resolver.RegisterUnionKeyType(typeof(byte));
        resolver.RegisterSubType(key: (byte)1, subType: typeof(MessageA));
        resolver.RegisterSubType(key: (byte)2, subType: typeof(MessageB));
        resolver.RegisterFallbackType(typeof(UnknownMessage));
    }
});
```

Unity Supports
---
Put the `ZeroFormatter.dll` and `ZeroFormatter.Interfaces.dll`, modify Edit -> Project Settings -> Player -> Optimization -> Api Compatibillity Level to `.NET 2.0` or higher.

![image](https://cloud.githubusercontent.com/assets/46207/20293228/d3a4add2-ab37-11e6-878b-24daad4dc2c1.png)

ZeroFormatter.Unity works on all platforms(PC, Android, iOS, etc...). But it can 'not' use dynamic serializer generation due to IL2CPP issue. But pre code generate helps it. Code Generator is located in `packages\ZeroFormatter.Interfaces.*.*.*\tools\zfc.exe`. zfc is using [Roslyn](https://github.com/dotnet/roslyn) so analyze source code, pass the target `csproj`. 

```
zfc arguments help:
  -i, --input=VALUE             [required]Input path of analyze csproj
  -o, --output=VALUE            [required]Output path(file) or directory base(in separated mode)
  -s, --separate                [optional, default=false]Output files are separated
  -u, --unuseunityattr          [optional, default=false]Unuse UnityEngine's RuntimeInitializeOnLoadMethodAttribute on ZeroFormatterInitializer
  -t, --customtypes=VALUE       [optional, default=empty]comma separated allows custom types
  -c, --conditionalsymbol=VALUE [optional, default=empty]conditional compiler symbol
  -r, --resolvername=VALUE      [optional, default=DefaultResolver]Register CustomSerializer target
  -d, --disallowinternaltype    [optional, default=false]Don't generate internal type
  -e, --propertyenumonly        [optional, default=false]Generate only property enum type only
  -m, --disallowinmetadata      [optional, default=false]Don't generate in metadata type
  -g, --gencomparekeyonly       [optional, default=false]Don't generate in EnumEqualityComparer except dictionary key
  -n, --namespace=VALUE         [optional, default=ZeroFormatter]Set namespace root name
  -f, --forcedefaultresolver    [optional, default=false]Force use DefaultResolver
```

> Note: Some options is important for reduce code generation size and startup speed on IL2CPP, especially `-f` is recommend if you use only DefaultResolver.

```
// Simple Case:
zfc.exe -i "..\src\Sandbox.Shared.csproj" -o "ZeroFormatterGenerated.cs"

// with t, c
zfc.exe -i "..\src\Sandbox.Shared.csproj" -o "..\unity\ZfcCompiled\ZeroFormatterGenerated.cs" -t "System.Uri" -c "UNITY"

// -s
zfc.exe -i "..\src\Sandbox.Shared.csproj" -s -o "..\unity\ZfcCompiled\" 
```

`zfc.exe` can setup on csproj's `PreBuildEvent`(useful to generate file path under self project) or `PostBuildEvent`(useful to generate file path is another project).

> Note: zfc.exe is currently only run on Windows. It is .NET Core's [Roslyn](https://github.com/dotnet/roslyn) workspace API limitation but I want to implements to all platforms...

Generated formatters must need to register on Startup. By default, zfc generate automatic register code on `RuntimeInitializeOnLoad` timing.

For Unity Unit Tests, the generated formatters must be registered in the `SetUp` method:

```csharp
    [SetUp]
    public void RegisterZeroFormatter()
    {
        ZeroFormatterInitializer.Register();
    }
```

ZeroFormatter can not serialize Unity native types by default but you can make custom formatter by define pseudo type. For example create `Vector2` to ZeroFormatter target. 

```csharp
#if INCLUDE_ONLY_CODE_GENERATION

using ZeroFormatter;

namespace UnityEngine
{
    [ZeroFormattable]
    public struct Vector2
    {
        [Index(0)]
        public float x;
        [Index(1)]
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

#endif
```

`INCLUDE_ONLY_CODE_GENERATION` is special symbol of zfc, include generator target but does not include compile.

If you encounter `InvalidOperationException` such as 

```
InvalidOperationException: Type is not supported, please register Vector3[]
```

It means not generated/registered type. Especially collections are not automatically registered if they are not included in the property. You can register manually such as `Formatter.RegisterArray<UnityEngine.Vector3>()` or create hint type for zfc.

```csharp
using ZeroFormatter;

namespace ZfcHint
{
    [ZeroFormattable]
    public class TypeHint
    {
        // zfc analyzes UnityEngine.Vector3[] type and register it. 
        [Index(0)]
        public UnityEngine.Vector3[] Hint1;
    }
}
```

Performance
---
Benchmarks comparing to other serializers run on `Windows 10 Pro x64 Intel Core i7-6700 3.40GHz, 32GB RAM`. Benchmark code is [here](https://github.com/neuecc/ZeroFormatter/tree/master/sandbox/PerformanceComparison) and full-result is [here](https://gist.github.com/neuecc/f786e7161e0af9578d717942372bc1f4), latest compare with more serializers(Wire, NetSerializer, etc...) result is [here](https://github.com/neuecc/ZeroFormatter/issues/30).

![](https://cloud.githubusercontent.com/assets/46207/20078590/81b890aa-a584-11e6-838b-5f2a4f1a11f8.png)

![](https://cloud.githubusercontent.com/assets/46207/20077970/f3ce8044-a581-11e6-909d-e30b2a33e991.png)

Deserialize speed is Infinitely fast(but of course, it is **unfair**, ZeroFormatter's deserialize is delayed when access target field). Serialize speed is fair-comparison. ZeroFormatter is fastest(compare to protobuf-net, 2~3x fast) for sure. ZeroFormatter has many reasons why fast.

* Serializer uses only `ref byte[]` and `int offset`, don't use MemoryStream(call MemoryStream api is overhead)
* Don't use variable-length number when encode number so there has encode cost(for example; protobuf uses ZigZag Encoding)
* Acquire strict length of byte[] when knows final serialized length(for example; int, fixed-length list, string, etc...)
* Avoid boxing all codes, all platforms(include Unity/IL2CPP)
* Reduce native string encoder methods
* Don't create intermediate utility instance(XxxWriter/Reader, XxxContext, etc...)
* Heavyly tuned dynamic il code generation: [DynamicObjectFormatter.cs](https://github.com/neuecc/ZeroFormatter/blob/853a0d0c6b7de66b8447b426ab47b90336deca2c/src/ZeroFormatter/Formatters/DynamicFormatter.cs#L212-L980)
* Getting cached generated formatter on static generic field(don't use dictinary-cache because dictionary lookup is overhead): [Formatter.cs](https://github.com/neuecc/ZeroFormatter/blob/853a0d0c6b7de66b8447b426ab47b90336deca2c/src/ZeroFormatter/Formatters/Formatter.cs)
* Enum is serialized only underlying-value and uses fastest cast technique: [EnumFormatter.cs](https://github.com/neuecc/ZeroFormatter/blob/853a0d0c6b7de66b8447b426ab47b90336deca2c/src/ZeroFormatter/Formatters/EnumFormatter.cs)

The result is achieved from both sides of implementation and binary layout. ZeroFormatter's binary layout is tuned for serialize/deserialize speed(this is advantage than other serializer).

**In Unity**

Result run on iPhone 6s Plus and IL2CPP build.

![](https://cloud.githubusercontent.com/assets/46207/20076797/281f7b78-a57d-11e6-8fbd-e83cc6b72025.png)

ZeroFormatter is faster than JsonUtility so yes, faster than native serializer! Why MsgPack-Cli is slow? MsgPack-Cli's Unity implemntation has a lot of hack of avoid AOT issues, it causes performance impact(especially struct, all codes pass boxing). ZeroFormatter codes is full tuned for Unity with/without IL2CPP.

**Single Integer(1), Large String(represents HTML), Vector3 Struct(float, float, float), Vector3[100]**

![image](https://cloud.githubusercontent.com/assets/46207/20247341/2393be4a-aa0d-11e6-8475-ec50bfefa687.png)
![image](https://cloud.githubusercontent.com/assets/46207/20140306/c6b1b0fc-a6cd-11e6-9193-303179d23764.png)

ZeroFormatter is optimized for all types(small struct to large object!). I know why protobuf-net is slow on integer test, currently [protobuf-net's internal serialize method](https://github.com/mgravell/protobuf-net/blob/0d0bb407865600c7dad1b833a9a1f71ef48c7106/protobuf-net/Meta/TypeModel.cs#L210) has only `object value` so it causes boxing and critical for performance. Anyway, ZeroFormatter's simple struct and struct array(struct array is serialized FixedSizeList format internally, it is faster than class array)'s serialization/deserialization speed is very fast that effective storing value to KeyValueStore(like Redis) or network gaming(transport many transform position), etc.

Compare with MessagePack for C#
---
Author also created [MessagePack for C#](https://github.com/neuecc/MessagePack-CSharp). It is fast, compact general purpose serializer. MessagePack for C# is a good choice if you are looking for a JSON-like, general purpose fast binary serializer. Built-in LZ4 support makes it suitable for network communication and storage in Redis. If you need infintely fast deserializer, ZeroFormatter is good choice.

ZeroFormatterSerializer API
---
We usually use `Serialize<T>` and `Deserialize<T>`, but there are other APIs as well. `Convert<T>` is converted T to T but the return value is wrapped data. It is fast when reserialization so if you store the immutable data and serialize frequently, very effective. `IsFormattedObject<T>` can check the data is wrapped data or not.

`Serialize<T>` has some overload, the architecture of ZeroFormatter is to write to byte [], read from byte [] so byte[] method is fast, first-class method. Stream method is helper API. ZeroFormatter has non-allocate API, as well. `int Serialize<T>(ref byte[] buffer, int offset, T obj)` expands the buffer but do not shrink. Return value int is size so you can pass the buffer from array pooling, ZeroFormatter does not allocate any extra memory.

If you want to use non-generic API, there are exists under `ZeroFormatterSerializer.NonGeneric`. It can pass Type on first-argument instead of `<T>`.

> NonGeneric API is not supported in Unity. NonGeneric API is a bit slower than the generic API. Because of the lookup of the serializer by type and the cost of boxing if the value is a value type are costly. We recommend using generic API if possible.

`ZeroFormatterSerializer.MaximumLengthOfDeserialize` is max length of array(collection) length when deserializing. The default is 67108864, it includes `byte[]`(67MB). This limitation is for security issue(block of OutOfMemory). If you want to expand this limitation, set the new size.

Extensibility
---
ZeroFormatter can become custom binary layout framework. You can create own typed formatter. For example, add supports `Uri`.

```csharp
// "<TTypeResolver> where TTypeResolver : ITypeResolver, new()" is a common rule. in details, see: configuration section.
public class UriFormatter<TTypeResolver> : Formatter<TTypeResolver, Uri>
    where TTypeResolver : ITypeResolver, new()
{
    public override int? GetLength()
    {
        // If size is variable, return null.
        return null;
    }

    public override int Serialize(ref byte[] bytes, int offset, Uri value)
    {
        // Formatter<T> can get child serializer
        return Formatter<TTypeResolver, string>.Default.Serialize(ref bytes, offset, value.ToString());
    }

    public override Uri Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
    {
        var uriString = Formatter<TTypeResolver, string>.Default.Deserialize(ref bytes, offset, tracker, out byteSize);
        return (uriString == null) ? null : new Uri(uriString);
    }
}
```

You need to register formatter on application startup. 

```csharp
// What is DefaultResolver? see: configuration section. 
ZeroFormatter.Formatters.Formatter<DefaultResolver, Uri>.Register(new UriFormatter<DefaultResolver>());
```

One more case, how to create generic formatter. For example, If implements `ImmutableList<T>`?

```csharp
public class ImmutableListFormatter<TTypeResolver, T> : Formatter<TTypeResolver, ImmutableList<T>>
    where TTypeResolver : ITypeResolver, new()
{
    public override int? GetLength()
    {
        return null;
    }

    public override int Serialize(ref byte[] bytes, int offset, ImmutableList<T> value)
    {
        // use sequence format.
        if (value == null)
        {
            BinaryUtil.WriteInt32(ref bytes, offset, -1);
            return 4;
        }

        var startOffset = offset;
        offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

        var formatter = Formatter<TTypeResolver, T>.Default;
        foreach (var item in value)
        {
            offset += formatter.Serialize(ref bytes, offset, item);
        }

        return offset - startOffset;
    }

    public override ImmutableList<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
    {
        byteSize = 4;
        var length = BinaryUtil.ReadInt32(ref bytes, offset);
        if (length == -1) return null;

        var formatter = Formatter<TTypeResolver, T>.Default;
        var builder = ImmutableList<T>.Empty.ToBuilder();
        int size;
        offset += 4;
        for (int i = 0; i < length; i++)
        {
            var val = formatter.Deserialize(ref bytes, offset, tracker, out size);
            builder.Add(val);
            offset += size;
        }
            
        return builder.ToImmutable();
    }
}
```

And register generic resolver on startup.

```csharp
// append to default resolver.
ZeroFormatter.Formatters.Formatter.AppendFormatterResolver(t =>
{
    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ImmutableList<>))
    {
        var formatter = typeof(ImmutableListFormatter<>).MakeGenericType(t.GetGenericArguments());
        return Activator.CreateInstance(formatter);
    }

    return null; // fallback to the next resolver
});
```

Configuration
---
If you want to create Formatter based on special rules generated by ResolveFormatter and RegisterDynamicUnion with the same AppDomain, you need to implement ITypeResolver.

```csharp
public class CustomSerializationContext : ITypeResolver
{
    public bool IsUseBuiltinDynamicSerializer
    {
        get
        {
            return true;
        }
    }

    public object ResolveFormatter(Type type)
    {
        // same as Formatter.AppendFormatResolver.
        return null;
    }

    public void RegisterDynamicUnion(Type unionType, DynamicUnionResolver resolver)
    {
        // same as Formatter.AppendDynamicUnionResolver
    }
}
```

`ZeroFormatterSerializer.CustomSerializer<CustomSerializationContext>.Serialize/Deserialize` methods use those contexts. By default, `DefaultResolver` is used.

WireFormat Specification
---
All formats are represented in little endian. There are two lengths of binary, fixed-length and variable-length, which affect the `List Format`.

**Primitive Format**

Primitive format is fixed-length(except string), eager-evaluation. C# `Enum` is serialized there underlying type. TimeSpan, DateTime is serialized UniversalTime and serialized format is same as Protocol Buffers's [timestamp.proto](https://github.com/google/protobuf/blob/master/src/google/protobuf/timestamp.proto).

| Type | Layout | Note |
| ---- | ------ | ---- |
| Int16 | [short(2)] |
| Int32 | [int(4)] |
| Int64 | [long(8)] |
| UInt16 | [ushort(2)] |
| UInt32 | [uint(4)] |
| UInt64 | [ulong(8)] |
| Single | [float(4)] |
| Double | [double(8)] |
| Boolean | [bool(1)] |
| Byte | [byte(1)] |
| SByte | [sbyte(1)] |
| Char | [ushort(2)] | UTF16-LE |
| TimeSpan | [seconds:long(8)][nanos:int(4)] | seconds represents time from 00:00:00 |
| DateTime | [seconds:long(8)][nanos:int(4)] | seconds represents UTC time since Unix epoch(0001-01-01T00:00:00Z to 9999-12-31T23:59:59Z) |
| DateTimeOffset | [seconds:long(8)][nanos:int(4)][offsetMinutes:short(2)] | DateTime with a time difference |
| String | [utf8Bytes:(length)] | currently no used but reserved for future |
| Int16? | [hasValue:bool(1)][short(2)] |
| Int32? | [hasValue:bool(1)][int(4)] |
| Int64? | [hasValue:bool(1)][long(8)] |
| UInt16? | [hasValue:bool(1)][ushort(2)] |
| UInt32? | [hasValue:bool(1)][uint(4)] |
| UInt64? | [hasValue:bool(1)][ulong(8)] |
| Single? | [hasValue:bool(1)][float(4)] |
| Double? | [hasValue:bool(1)][double(8)] |
| Boolean? | [hasValue:bool(1)][bool(1)] |
| Byte? | [hasValue:bool(1)][byte(1)] |
| SByte? | [hasValue:bool(1)][sbyte(1)] |
| Char? | [hasValue:bool(1)][ushort(2)] | UTF16-LE |
| TimeSpan? | [hasValue:bool(1)][seconds:long(8)][nanos:int(4)] | seconds represents time from 00:00:00 |
| DateTime? | [hasValue:bool(1)][seconds:long(8)][nanos:int(4)] | seconds represents UTC time since Unix epoch(0001-01-01T00:00:00Z to 9999-12-31T23:59:59Z) |
| DateTimeOffset? | [hasValue:bool(1)][seconds:long(8)][nanos:int(4)][offsetMinutes:short(2)] | DateTime with a time difference |
| String? | [length:int(4)][utf8Bytes:(length)] | representes `String`, if length = -1, indicates null. This is only variable-length primitive. |

**Sequence Format**

Sequence is variable-length, eager-evaluation. Sequence represents a multiple object. If field is declared collection type(except `IList<T>, IReadOnlyList<T>`), used this format.

| Type | Layout | Note |
| ---- | ------ | ---- |
| `Sequence<T>` | [length:int(4)][elements:T...] | if length = -1, indicates null |

**List Format**

List is variable-length, lazy-evaluation. If field is declared `IList<T>` or `IReadOnlyList<T>`, used this format.

| Type | Layout | Note |
| ---- | ------ | ---- |
| FixedSizeList | [length:int(4)][elements:T...] | T is fixed-length format. if length = -1, indicates null |
| VariableSizeList | [byteSize:int(4)][length:int(4)][elementOffset...:int(4 * length)][elements:T...] | T is variable-length format. if byteSize = -1, indicates null. indexOffset is relative position from list start offset |

**Object Format**

Object Format is a user-defined type.

Object is variable-length, lazy-evaluation which has index header.

Struct is eager-evaluation, if all field types are fixed-length which struct is marked fixed-length, else variable-length. This format is included `KeyTuple`, `Tuple`, `KeyValuePair(used by Dictionary)`, `IGrouping(used by ILookup)`.

| Type | Layout | Note |
| ---- | ------ | ---- |
| Object | [byteSize:int(4)][lastIndex:int(4)][indexOffset...:int(4 * lastIndex)][Property1:T1, Property2:T2, ...] | used by class in default. if byteSize = -1, indicates null, indexOffset = 0, indicates blank. indexOffset is relative position from object start offset |
| Struct | [Index1Item:T1, Index2Item:T2,...] | used by struct in default. This format can be fixed-length. versioning is not supported. |
| Struct? | [hasValue:bool(1)][Index1Item:T1, Index2Item:T2,...] | used by struct in default. This format can be fixed-length. versioning is not supported. |

**Union Format**

Union is variable-length, eager-evaluation, discriminated by key type to each value type.

| Type | Layout | Note |
| ---- | ------ | ---- |
| Union | [byteSize:int(4)][unionKey:TKey][value:TValue] | if byteSize = -1, indicates null |

**Extension Format**

Not a standard format but builtin on C# implementation.

| Type | Layout | Note |
| ---- | ------ | ---- |
| Decimal | [lo:int(4)][mid:int(4)][hi:int(4)][flags:int(4)] | fixed-length, eager-evaluation. If you need to language-wide cross platform, use string instead.  |
| Decimal? | [hasValue:bool(1)][lo:int(4)][mid:int(4)][hi:int(4)][flags:int(4)] | fixed-length, eager-evaluation. If you need to language-wide cross platform, use string instead. |
| Guid | [bytes:byteArray(16)] | fixed-length, eager-evaluation. If you need to language-wide cross platform, use string instead.  |
| Guid? | [hasValue:bool(1)][bytes:byteArray(16)] | fixed-length, eager-evaluation. If you need to language-wide cross platform, use string instead. |
| LazyDictionary | [byteSize:int(4)][length:int(4)][buckets:`FixedSizeList<int>`][entries:`VariableSizeList<DictionaryEntry>`] | represents `ILazyDictionary<TKey, TValue>`, if byteSize == -1, indicates null, variable-length, lazy-evaluation  |
| DictionaryEntry | [hashCode:int(4)][next:int(4)][key:TKey][value:TValue] | substructure of LazyDictionary | 
| LazyMultiDictionary | [byteSize:int(4)][length:int(4)][groupings:`VariableSizeList<VariableSizeList<GroupingSemengt>>`] | represents `ILazyLookup<TKey, TElement>`, if byteSize == -1, indicates null, variable-length, lazy-evaluation | 
| GroupingSegment | [key:TKey] [hashCode:int(4)][elements:`VariableSizeList<TElement>`] | substructure of LazyMultiDictionary 

**EqualityComparer**

ZeroFormatter's EqualityComparer calculates stable hashCode for serialize LazyDictionary/LazyMultiDictionary. LazyDictionary and LazyMultiDictionary keys following there `GetHashCode` function. 

* [WireFormatEqualityComparers](https://github.com/neuecc/ZeroFormatter/blob/master/src/ZeroFormatter/Comparers/WireFormatEqualityComparers.cs)
* [KeyTupleEqualityComparer](https://github.com/neuecc/ZeroFormatter/blob/master/src/ZeroFormatter/Comparers/KeyTupleEqualityComparer.cs)

C# Schema
---
The schema of ZeroFormatter is C# itself. You can define the schema in C# and analyze it with Roslyn to generate in another language or C#(such as zfc.exe).

```csharp
namespace /* Namespace */
{
    // Fomrat Schemna
    [ZeroFormattable]
    public class /* FormatName */
    {
        [Index(/* Index Number */)]
        public virtual /* FormatType */ Name { get; set; }
    }

    // UnionSchema
    [Union(typeof(/* Union Subtypes */))]
    public abstract class UnionSchema
    {
        [UnionKey]
        public abstract /* UnionKey Type */ Key { get; }
    }
}
```

Cross Platform
---
Currently, No and I have no plans. Welcome to contribute port to other languages, I want to help your work!

ZeroFormatter spec has two stages + ex.

* Stage1: All formats are eager-evaluation, does not support Extension Format.
* Stage2: FixedSizeList, VariableSizeList and Object supports lazy-evaluation, does not support Extension Format.
* StageEx: Supports C# Extension Format

List of port libraries

* Go, [shamaton/zeroformatter](https://github.com/shamaton/zeroformatter)
* Ruby, [aki017/zero_formatter](https://github.com/aki017/zero_formatter)
* Swift, [yaslab/ZeroFormatter.swift](https://github.com/yaslab/ZeroFormatter.swift)
* Scala, [pocketberserker/scala-zero-formatter](https://github.com/pocketberserker/scala-zero-formatter/)
* Rust, [pocketberserker/zero-formatter.rs](https://github.com/pocketberserker/zero-formatter.rs)
* F#, [pocketberserker/ZeroFormatter.FSharpExtensions](https://github.com/pocketberserker/ZeroFormatter.FSharpExtensions)

Author Info
---
Yoshifumi Kawai(a.k.a. neuecc) is a software developer in Japan.  
He is the Director/CTO at Grani, Inc.  
Grani is a top social game developer in Japan.  
He is awarding Microsoft MVP for Visual C# since 2011.  
He is known as the creator of [UniRx](http://github.com/neuecc/UniRx/)(Reactive Extensions for Unity)  

Blog: https://medium.com/@neuecc (English)  
Blog: http://neue.cc/ (Japanese)  
Twitter: https://twitter.com/neuecc (Japanese)   

License
---
This library is under the MIT License.
