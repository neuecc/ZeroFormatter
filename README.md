# ZeroFormatter
Fastest C# Serializer and Infinitly Fast Deserializer for .NET, .NET Core and Unity.

![image](https://cloud.githubusercontent.com/assets/46207/20072942/ba760e70-a56d-11e6-918f-edf84f0187da.png)

Why use ZeroFormatter?
---
* Fastest C# Serializer, code is extremely tuned by both sides of implementation and binary layout(see: [performance](https://github.com/neuecc/ZeroFormatter#performance))
* Deserialize/Reserialize is infinitly fast because formatter can access to serialized data without parsing/packing(see: [architecture](https://github.com/neuecc/ZeroFormatter#architecture))
* Strongly Typed and C# Code as schema, no needs to other IDL like `.proto`, `.fbs`...
* Smart API, only to use `Serialize<T>` and `Deserialize<T>`
* Native support of Dictionary, MultiDictionary(ILookup)
* First-class support to Unity(IL2CPP), it's faster than native JsonUtility

ZeroFormatter is similar as [FlatBuffers](http://google.github.io/flatbuffers/) but ZeroFormatter has clean API(FlatBuffers API is too ugly, [see: sample](https://github.com/google/flatbuffers/blob/master/samples/SampleBinary.cs); we can not use reguraly) and C# specialized. If you need to performance such as Game, Distributed Computing, Microservices etc..., ZeroFormatter will help you.

Install
---
for .NET, .NET Core

* PM> Install-Package [ZeroFormatter](https://www.nuget.org/packages/ZeroFormatter)

for Unity(Interfaces can reference both .NET 3.5 and Unity for share types)

* PM> Install-Package [ZeroFormatter.Interfaces](https://www.nuget.org/packages/ZeroFormatter.Interfaces/)
* PM> Install-Package [ZeroFormatter.Unity](https://www.nuget.org/packages/ZeroFormatter.Unity)

Visual Studio Analyzer

* PM> Install-Package [ZeroFormatter.Analyzer](https://www.nuget.org/packages/ZeroFormatter.Analyzer)

Quick Start
---
Define class and mark as `[ZeroFormattable]`.

Sample
---
```csharp
[ZeroFormattable]
public class MyClass
{
    [Index(0)]
    public virtual int Age { get; set; }

    [Index(1)]
    public virtual string FirstName { get; set; }

    [Index(2)]
    public virtual string LastName { get; set; }

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
![zeroformatteranalyzer](https://cloud.githubusercontent.com/assets/46207/20078766/3ea54f14-a585-11e6-9873-b99cb5d9efe5.gif)



Supported Type
---
Primitive, Enum, TimeSpan, DateTime, DateTimeOffset, `IList<>`, `IDictionary<>`, `IReadOnlyList<>`, `IReadOnlyDictionary<>`, `ILookup<>`, `byte[]`, `ZeroFormatter.KeyTuple` and there nullable.

`T[]`, `List<T>`, `Dictionary<TKey, TValue>` is not supported type. You should use `IList<>`, `IDictionary<>` instead.

Dictionary's key is native serialized in binary, but has limitation of keys. Key can use Primitive, Enum and ZeroFormatter.KeyTuple for mulitple keys.



Object Define Rules
---
TODO...


Serialize Dictionary/Lookup
---
TODO:...



Versioning
---
TODO...


for Unity
---
ZeroFormatter.Unity works on all platforms(PC, Android, iOS, etc...). But it can 'not' use dynamic serializer generation due to IL2CPP issue. But pre code generate helps it. Code Generator is located in `packages\ZeroFormatter.Interfaces.*.*.*\tools\zfc\zfc.exe`. zfc is using [Roslyn](https://github.com/dotnet/roslyn) so analyze source code, pass the target `csproj`. 

```
zfc arguments help:
  -i, --input=VALUE          [required]Input path of analyze csproj
  -o, --output=VALUE         [required]Output path(file) or directory base(in separated mode)
  -s, --separate             [optional, default=false]Output files are separated
  -u, --unuseunityattr       [optional, default=false]Unuse UnityEngine's RuntimeInitializeOnLoadMethodAttribute on ZeroFormatterInitializer
```

Generated formatters must needs register on Startup. By default, zfc generate automatic register code on `RuntimeInitializeOnLoad` timing.


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

`INCLUDE_ONLY_CODE_GENERATION` is special symbol of zfc, include generator target but does not includes compile.



Performance
---
Benchmarks comparing to other serializers.

![](https://cloud.githubusercontent.com/assets/46207/20078590/81b890aa-a584-11e6-838b-5f2a4f1a11f8.png)

![](https://cloud.githubusercontent.com/assets/46207/20077970/f3ce8044-a581-11e6-909d-e30b2a33e991.png)

ZeroFormatter is fastest(compare to protobuf-net, 2~3x fast) and has infinitely fast deserializer.


Architecture
---

![](https://cloud.githubusercontent.com/assets/46207/20078613/9f9ddfda-a584-11e6-9d7c-b98f8a6ac70e.png)

Extensibility
---
ZeroFormatter can become custom binary layout framework. You can create own typed formatter. For example, add supports `Guid` and `Uri`.

```csharp
public class GuidFormatter : Formatter<Guid>
{
    public override int? GetLength()
    {
        // If size is fixed, return fixed size.
        return 16;
    }

    public override int Serialize(ref byte[] bytes, int offset, Guid value)
    {
        // BinaryUtil is helpers of byte[] operation 
        return BinaryUtil.WriteBytes(ref bytes, offset, value.ToByteArray());
    }

    public override Guid Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
    {
        byteSize = 16;
        var guidBytes = BinaryUtil.ReadBytes(ref bytes, offset, 16);
        return new Guid(guidBytes);
    }
}

public class UriFormatter : Formatter<Uri>
{
    public override int? GetLength()
    {
        // If size is variable, return null.
        return null;
    }

    public override int Serialize(ref byte[] bytes, int offset, Uri value)
    {
        // Formatter<T> can get child serializer
        return Formatter<string>.Default.Serialize(ref bytes, offset, value.ToString());
    }

    public override Uri Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
    {
        var uriString = Formatter<string>.Default.Deserialize(ref bytes, offset, tracker, out byteSize);
        return (uriString == null) ? null : new Uri(uriString);
    }
}
```

You need to register formatter on application startup. 

```csharp
ZeroFormatter.Formatters.Formatter<Guid>.Register(new GuidFormatter());
ZeroFormatter.Formatters.Formatter<Uri>.Register(new UriFormatter());
```

One more case, how to create generic formatter. `KeyValuePair<TKey, TValue>` is also not suppoted type by default. Let's add support.

```csharp
public class KeyValuePairFormatter<TKey, TValue> : Formatter<KeyValuePair<TKey, TValue>>
{
    public override int? GetLength()
    {
        return null;
    }

    public override int Serialize(ref byte[] bytes, int offset, KeyValuePair<TKey, TValue> value)
    {
        var startOffset = offset;
        offset += Formatter<TKey>.Default.Serialize(ref bytes, offset, value.Key);
        offset += Formatter<TValue>.Default.Serialize(ref bytes, offset, value.Value);
        return offset - startOffset;
    }

    public override KeyValuePair<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
    {
        int size;
        byteSize = 0;

        var key = Formatter<TKey>.Default.Deserialize(ref bytes, offset, tracker, out size);
        offset += size;
        byteSize += size;

        var value = Formatter<TValue>.Default.Deserialize(ref bytes, offset, tracker, out size);
        offset += size;
        byteSize += size;

        return new KeyValuePair<TKey, TValue>(key, value);
    }
}
```

And register generic resolver on startup.

```csharp
ZeroFormatter.Formatters.Formatter.AppendFormatterResolver(t =>
{
    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
    {
        var formatterType = typeof(KeyValuePairFormatter<,>).MakeGenericType(t.GetGenericArguments());
        return Activator.CreateInstance(formatterType);
    }

    // return null means type is not supported.
    return null;
});
```

WireFormat Specification
---
**Fixed Length Format**

Fixed Length formats is eager evaluation. C# `Enum` is serialized there underlying type. DateTime, DateTimeOffset is serialized UniversalTime.

| Type | Layout |
| ---- | ------ | 
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
| Char | [ushort(2)] |
| Decimal | [lo:int(4)][mid:int(4)][hi:int(4)][flags:int(4)] |
| TimeSpan | [seconds:long(8)][nanos:int(4)] |
| DateTime | [seconds:long(8)][nanos:int(4)] |
| DateTimeOffset | [seconds:long(8)][nanos:int(4)] |
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
| Char? | [hasValue:bool(1)][ushort(2)] |
| Decimal? | [hasValue:bool(1)][lo:int(4)][mid:int(4)][hi:int(4)][flags:int(4)] |
| TimeSpan? | [hasValue:bool(1)][seconds:long(8)][nanos:int(4)] |
| DateTime? | [hasValue:bool(1)][seconds:long(8)][nanos:int(4)] |
| DateTimeOffset? | [hasValue:bool(1)][seconds:long(8)][nanos:int(4)] |

**Variable Length Format**

byte[], String, KeyTuple, KeyTuple? are eager evalution. FixedSizeList and VariableSizeList are lazy evaluation.

| Type | Layout | Note |
| ---- | ------ | ---- |
| byte[] | [length:int(4)][byte(length)] | if length = -1, indicates null, byte[] is mutable but can not track mutate(should not mutate). |
| String | [length:int(4)][utf8Bytes:(length)] | if length = -1, indicates null |
| KeyTuple | [Item1:T1, Item2:T2,...] | T is generic type, T1 ~ T8, mainly used for Dictionary Key |
| KeyTuple? | [hasValue:bool(1)][Item1:T1, Item2:T2 ...] | T is T1 ~ T8 |
| FixedSizeList | [length:int(4)][elements:T...] | represents `IList<T>` where T is fixed length format. if length = -1, indicates null
| VariableSizeList | [byteSize:int(4)][length:int(4)][elementOffset...:int(4 * length)][elements:T...] | represents `IList<T>` where T is variable length format. if length = -1, indicates null

**Object Format**

Object is defined user own type. Class is lazy evaluation which has index header(variant of VariableSizeList in wireformat). 

Struct is eager evaluation, if all property/field types are fixed length which struct is marked fixed-length, else variable-length.

| Type | Layout | Note |
| ---- | ------ | ---- |
| Class | [byteSize:int(4)][lastIndex:int(4)][indexOffset...:int(4 * lastIndex)][Property1:T1, Property2:T2, ...] | if length = -1, indicates null, indexOffset = 0, indicates blank |
| Struct | [Index1Item:T1, Index2Item:T2,...] | Index is required begin from 0 and sequential |
| Struct? | [hasValue:bool(1)][Index1Item:T1, Index2Item:T2,...] ||

**Dictionary Format**

Dictionary/MultiDictionary is eager evaluation. LazyDictionary/LazyMultiDictionary is lazy evaluation.

| Type | Layout | Note |
| ---- | ------ | ---- |
| Dictionary | [length:int(4)][`(key:TKey, value:TValue)`...] | represents `IDictionary<TKey, TValue>`, if length == -1, indicates null |
| MultiDictionary | [length:int(4)][`(key:TKey, elements:List<TElement>)`...] | represents `ILookup<TKey, TElement>`, if length == -1, indicates null |
| LazyDictionary | [byteSize:int(4)][length:int(4)][buckets:`FixedSizeList<int>`][entries:`VariableSizeList<DictionaryEntry>`] | represents `ILazyDictionary<TKey, TValue>`, if byteSize == -1, indicates null |
| DictionaryEntry | [hashCode:int(4)][next:int(4)][key:TKey][value:TValue] | substructure of LazyDictionary | 
| LazyMultiDictionary | [byteSize:int(4)][length:int(4)][groupings:`VariableSizeList<VariableSizeList<GroupingSemengt>>`] | represents `ILazyLookup<TKey, TElement>`, if byteSize == -1, indicates null | 
| GroupingSegment | [key:TKey] [hashCode:int(4)][elements:`VariableSizeList<TElement>`] | substructure of LazyMultiDictionary 

**EqualityComparer**

TODO:...

https://github.com/neuecc/ZeroFormatter/blob/master/src/ZeroFormatter/Comparers/WireFormatEqualityComparers.cs
https://github.com/neuecc/ZeroFormatter/blob/master/src/ZeroFormatter/Comparers/KeyTupleEqualityComparer.cs


Cross Plaftorm
---
Currently No and I have no plans. Welcome to contribute port to other languages.

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
