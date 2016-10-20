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

Interfaces can reference both .NET 3.5 and Unity. ZeroFormatter.Unity is binary for Unity, it can 'not' use dynamic serializer generation. Code Generator is in `packages\ZeroFormatter.Interfaces.*.*.*\tools\zfc\zfc.exe`. Commandline arguments are `[csproj path] [output path] [-unuseunityattr]`.

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
Primitive, Enum, Enum, TimeSpan, DateTime, DateTimeOffset, `IList<>`, `IDictionary<>`, `IReadOnlyList<>`, `IReadOnlyDictionary<>`, `ILookup<>`, `byte[]` and there nullable.

`T[]`, `List<T>`, `Dictionary<TKey, TValue>` is not supported type. You should use `IList<>`, `IDictionary<>` instad.

Analyzer
---
![image](https://cloud.githubusercontent.com/assets/46207/19561566/291e4fda-9714-11e6-9633-e330a1430318.png)
