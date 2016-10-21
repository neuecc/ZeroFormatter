# ZeroFormatter
Infinitly fast serializer for .NET and Unity.

(Work in progress..)

Install
---
for .NET, .NET Core

* PM> Install-Package [ZeroFormatter](https://www.nuget.org/packages/ZeroFormatter)
* PM> Install-Package [ZeroFormatter.Analyzer](https://www.nuget.org/packages/ZeroFormatter.Analyzer)

for Unity

* PM> Install-Package [ZeroFormatter.Interfaces](https://www.nuget.org/packages/ZeroFormatter.Interfaces/)
* PM> Install-Package [ZeroFormatter.Unity](https://www.nuget.org/packages/ZeroFormatter.Unity)

Interfaces can reference both .NET 3.5 and Unity.

ZeroFormatter.Unity is binary for Unity, it can 'not' use dynamic serializer generation but pre code generate helps it. Code Generator is located in `packages\ZeroFormatter.Interfaces.*.*.*\tools\zfc\zfc.exe`.

```
zfc arguments help:
  -i, --input=VALUE          [required]Input path of analyze csproj
  -o, --output=VALUE         [required]Output path(file) or directory base(in separated mode)
  -s, --separate             [optional, default=false]Output files are separated
  -u, --unuseunityattr       [optional, default=false]Unuse UnityEngine's RuntimeInitializeOnLoadMethodAttribute on ZeroFormatterInitializer
```

Why use ZeroFormatter?
---
* Access to serialized data without parsing/unpacking
* Strongly Typed and Code as schema
no needs to other IDL.
* Native support for Dictionary, MultiDictionary(ILookup)

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

Supported Type
---
Primitive, Enum, TimeSpan, DateTime, DateTimeOffset, `IList<>`, `IDictionary<>`, `IReadOnlyList<>`, `IReadOnlyDictionary<>`, `ILookup<>`, `byte[]`, `ZeroFormatter.KeyTuple` and there nullable.

`T[]`, `List<T>`, `Dictionary<TKey, TValue>` is not supported type. You should use `IList<>`, `IDictionary<>` instead.

Dictionary's key is native serialized in binary, but has limitation of keys. Key can use Primitive, Enum and ZeroFormatter.KeyTuple for mulitple keys.

Analyzer
---
![image](https://cloud.githubusercontent.com/assets/46207/19561566/291e4fda-9714-11e6-9633-e330a1430318.png)



WireFormat Specification
---
**Fixed Length Format**

Fixed Length formats is ... (TODO:write description)

Enum is serialized there underlying type.

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

TODO:...


| Type | Layout | Note |
| ---- | ------ | ---- |
| byte[] | [length:int(4)][byte(length)] | if length = -1, indicates null |
| String | [length:int(4)][utf8Bytes:(length)] | if length = -1, indicates null |
| KeyTuple | [Item1:T1, Item2:T2,...] | T is generic type, T1 ~ T8, mainly used for Dictionary Key |
| KeyTuple? | [hasValue:bool(1)][Item1:T1, Item2:T2 ...] | T is T1 ~ T8 |
| FixedSizeList | [length:int(4)][elements:T...] | represents `IList<T>` where T is fixed length format. if length = -1, indicates null
| VariableSizeList | [byteSize:int(4)][length:int(4)][elementOffset...:int(4 * length)][elements:T...] | represents `IList<T>` where T is variable length format. if length = -1, indicates null
| Dictionary | [byteSize:int(4)][length:int(4)][buckets:`FixedSizeList<int>`][entries:`VariableSizeList<DictionaryEntry>`] | represents `IDictionary<TKey, TValue>`, if byteSize == -1, indicates null |
| DictionaryEntry | [hashCode:int(4)][next:int(4)][key:TKey][value:TValue] | substructure of Dictionary | 
| MultiDictionary | [byteSize:int(4)][length:int(4)][groupings:`VariableSizeList<VariableSizeList<GroupingSemengt>>`] |  represents `ILookup<TKey, TElement>`, if byteSize == -1, indicates null | 
| GroupingSegment | [key:TKey] [hashCode:int(4)][elements:`VariableSizeList<TElement>`] | substructure of MultiDictionary
| Object | [byteSize:int(4)][lastIndex:int(4)][indexOffset...:int(4 * lastIndex)][Property1:T1, Property2:T2, ...] | define from `[ZeroFormattable]` class. if byteSize = -1, indicates null |

**EqualityComparer**

TODO:...

https://github.com/neuecc/ZeroFormatter/blob/master/src/ZeroFormatter/Comparers/WireFormatEqualityComparers.cs
https://github.com/neuecc/ZeroFormatter/blob/master/src/ZeroFormatter/Comparers/KeyTupleEqualityComparer.cs


Cross Plaftorm
---
Currently No and I have no plans. Welcome to contribute to port other languages.