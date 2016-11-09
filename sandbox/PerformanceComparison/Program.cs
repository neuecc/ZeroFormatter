// Install-Package MsgPack.Cli -Pre
// Install-Package Newtonsoft.Json -Pre
// Install-Package protobuf-net -Pre
// Install-Package ZeroFormatter -Pre
// Install-Package FsPickler.CSharp -Pre
// Install-Package FSharp.Core -Pre
// Install-Package Jil -Pre
// Install-Package Google.Protobuf -Pre

using MsgPack.Serialization;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using ZeroFormatter;

[ZeroFormattable]
[Serializable]
[ProtoContract]
[DataContract]
public class Person : IEquatable<Person>
{
    [Index(0)]
    [MessagePackMember(0)]
    [ProtoMember(1)]
    [DataMember]
    public virtual int Age { get; set; }
    [Index(1)]
    [MessagePackMember(1)]
    [ProtoMember(2)]
    [DataMember]
    public virtual string FirstName { get; set; }
    [Index(2)]
    [MessagePackMember(2)]
    [ProtoMember(3)]
    [DataMember]
    public virtual string LastName { get; set; }
    [Index(3)]
    [MessagePackMember(3)]
    [ProtoMember(4)]
    [DataMember]
    public virtual Sex Sex { get; set; }

    public bool Equals(Person other)
    {
        return Age == other.Age && FirstName == other.FirstName && LastName == other.LastName && Sex == other.Sex;
    }
}

public enum Sex : sbyte
{
    Unknown, Male, Female,
}

[ZeroFormattable]
[Serializable]
[ProtoContract]
[DataContract]
public struct Vector3
{
    [Index(0)]
    [MessagePackMember(0)]
    [ProtoMember(1)]
    [DataMember]
    public float x;

    [Index(1)]
    [MessagePackMember(1)]
    [ProtoMember(2)]
    [DataMember]
    public float y;

    [Index(2)]
    [MessagePackMember(3)]
    [ProtoMember(3)]
    [DataMember]
    public float z;

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

class Program
{
    const int Iteration = 10000;
    static bool dryRun = true;

    static void Main(string[] args)
    {
        var p = new Person
        {
            Age = 99999,
            FirstName = "Windows",
            LastName = "Server",
            Sex = Sex.Male,
        };
        IList<Person> l = Enumerable.Range(1000, 1000).Select(x => new Person { Age = x, FirstName = "Windows", LastName = "Server", Sex = Sex.Female }).ToArray();

        var integer = 1;
        var v3 = new Vector3 { x = 12345.12345f, y = 3994.35226f, z = 325125.52426f };
        IList<Vector3> v3List = Enumerable.Range(1, 100).Select(_ => new Vector3 { x = 12345.12345f, y = 3994.35226f, z = 325125.52426f }).ToList();
        var largeString = File.ReadAllText("CSharpHtml.txt");

        Console.WriteLine("Warming-up"); Console.WriteLine();
        SerializeZeroFormatter(p); SerializeZeroFormatter(l); 
        SerializeZeroFormatter(integer); SerializeZeroFormatter(v3); SerializeZeroFormatter(largeString); SerializeZeroFormatter(v3List);
        SerializeProtobuf(p); SerializeProtobuf(l); 
        SerializeProtobuf(integer); SerializeProtobuf(v3); SerializeProtobuf(largeString); SerializeProtobuf(v3List);
        SerializeMsgPack(p); SerializeMsgPack(l);
        SerializeMsgPack(integer); SerializeMsgPack(v3); SerializeMsgPack(largeString); SerializeMsgPack(v3List);
        SerializeJsonNet(p); SerializeJsonNet(l);
        SerializeJil(p); SerializeJil(l);
        SerializeFsPickler(p); SerializeFsPickler(l);
        SerializeBinaryFormatter(p); SerializeBinaryFormatter(l);
        SerializeDataContract(p); SerializeDataContract(l);
        SerializeSingleFlatBuffers(); SerializeArrayFlatBuffers();
        SerializeSingleProto3(p); SerializeArrayProto3(l);

        dryRun = false;

        Console.WriteLine();
        Console.WriteLine($"Small Object(int,string,string,enum) {Iteration} Iteration"); Console.WriteLine();

        var a = SerializeZeroFormatter(p); Console.WriteLine();
        var b = SerializeProtobuf(p); Console.WriteLine();
        var c = SerializeMsgPack(p); Console.WriteLine();
        var d = SerializeJsonNet(p); Console.WriteLine();
        var e = SerializeJil(p); Console.WriteLine();
        var f = SerializeFsPickler(p); Console.WriteLine();
        var g = SerializeBinaryFormatter(p); Console.WriteLine();
        var h = SerializeDataContract(p); Console.WriteLine();
        var i = SerializeSingleFlatBuffers(); Console.WriteLine();
        var j = SerializeSingleProto3(p); Console.WriteLine();

        Console.WriteLine($"Large Array(SmallObject[1000]) {Iteration} Iteration"); Console.WriteLine();

        var A = SerializeZeroFormatter(l); Console.WriteLine();
        var B = SerializeProtobuf(l); Console.WriteLine();
        var C = SerializeMsgPack(l); Console.WriteLine();
        var D = SerializeJsonNet(l); Console.WriteLine();
        var E = SerializeJil(l); Console.WriteLine();
        var F = SerializeFsPickler(l); Console.WriteLine();
        var G = SerializeBinaryFormatter(l); Console.WriteLine();
        var H = SerializeDataContract(l); Console.WriteLine();
        var I = SerializeArrayFlatBuffers(); Console.WriteLine();
        var J = SerializeArrayProto3(l); Console.WriteLine();

        Validate("ZeroFormatter", p, l, a, A);
        Validate("protobuf-net", p, l, b, B);
        Validate("MsgPack-CLI", p, l, c, C);
        Validate("JSON.NET", p, l, d, D);
        Validate("Jil", p, l, e, E);
        Validate("FsPickler", p, l, f, F);
        Validate("BinaryFormatter", p, l, g, G);
        Validate("DataContract", p, l, h, H);
        ValidateFlatBuffers(p, l, i, I);
        ValidateProto3(p, l, j, J);

        Console.WriteLine();
        Console.WriteLine("Additional Benchmarks"); Console.WriteLine();

        Console.WriteLine($"Int32(1) {Iteration} Iteration"); Console.WriteLine();

        var W1 = SerializeZeroFormatter(integer); Console.WriteLine();
        var W2 = SerializeMsgPack(integer); Console.WriteLine();
        var W3 = SerializeProtobuf(integer); Console.WriteLine();

        Console.WriteLine($"Vector3(float, float, float) {Iteration} Iteration"); Console.WriteLine();

        var X1 = SerializeZeroFormatter(v3); Console.WriteLine();
        var X2 = SerializeMsgPack(v3); Console.WriteLine();
        var X3 = SerializeProtobuf(v3); Console.WriteLine();

        Console.WriteLine($"HtmlString({Encoding.UTF8.GetByteCount(largeString)}bytes) {Iteration} Iteration"); Console.WriteLine();

        var Y1 = SerializeZeroFormatter(largeString); Console.WriteLine();
        var Y2 = SerializeMsgPack(largeString); Console.WriteLine();
        var Y3 = SerializeProtobuf(largeString); Console.WriteLine();

        Console.WriteLine($"Vector3[100] {Iteration} Iteration"); Console.WriteLine();

        var Z1 = SerializeZeroFormatter(v3List); Console.WriteLine();
        var Z2 = SerializeMsgPack(v3List); Console.WriteLine();
        var Z3 = SerializeProtobuf(v3List); Console.WriteLine();

        Validate2("ZeroFormatter", W1, integer); Validate2("MsgPack-Cli", W2, integer); Validate2("MsgPack", W3, integer);
        Validate2("ZeroFormatter", X1, v3); Validate2("MsgPack-Cli", X2, v3); Validate2("MsgPack", X3, v3);
        Validate2("ZeroFormatter", Y1, largeString); Validate2("MsgPack-Cli", Y2, largeString); Validate2("MsgPack", Y3, largeString);
        Validate2("ZeroFormatter", Z1, v3List); Validate2("MsgPack-Cli", Z2, v3List); Validate2("MsgPack", Z3, v3List);
    }

    static void Validate(string label, Person original, IList<Person> originalList, Person copy, IList<Person> copyList)
    {
        if (!EqualityComparer<Person>.Default.Equals(original, copy)) Console.WriteLine(label + " Invalid Deserialize Small Object");
        if (!originalList.SequenceEqual(copyList)) Console.WriteLine(label + " Invalid Deserialize Large Array");
    }

    static void Validate2<T>(string label, T original, T copy)
    {
        if (!EqualityComparer<T>.Default.Equals(original, copy)) Console.WriteLine(label + " Invalid Deserialize");
    }

    static void Validate2<T>(string label, IList<T> original, IList<T> copy)
    {
        if (!original.SequenceEqual(copy)) Console.WriteLine(label + " Invalid Deserialize");
    }

    static T SerializeZeroFormatter<T>(T original)
    {
        Console.WriteLine("ZeroFormatter");

        T copy = default(T);
        byte[] bytes = null;

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                bytes = ZeroFormatterSerializer.Serialize(original);
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                copy = ZeroFormatterSerializer.Deserialize<T>(bytes);
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                bytes = ZeroFormatterSerializer.Serialize(copy);
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(bytes.Length)));
        }

        return copy;
    }

    static T SerializeProtobuf<T>(T original)
    {
        Console.WriteLine("protobuf-net");

        T copy = default(T);
        MemoryStream stream = null;

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                ProtoBuf.Serializer.Serialize<T>(stream = new MemoryStream(), original);
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream.Position = 0;
                copy = ProtoBuf.Serializer.Deserialize<T>(stream);
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                ProtoBuf.Serializer.Serialize<T>(stream = new MemoryStream(), copy);
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(stream.Position)));
        }

        return copy;
    }

    static T SerializeMsgPack<T>(T original)
    {
        Console.WriteLine("MsgPack-CLI");

        T copy = default(T);
        byte[] bytes = null;

        // Note:We should check MessagePackSerializer.Get<T>() on every iteration
        // But currenly MsgPack-Cli has bug of get serializer
        // https://github.com/msgpack/msgpack-cli/issues/191
        // so, get serializer at first.
        // and If enum serialization options to ByUnderlyingValue, gets more fast but we check default option only.

        var serializer = MessagePackSerializer.Get<T>();

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                bytes = serializer.PackSingleObject(original);
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                copy = serializer.UnpackSingleObject(bytes);
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                bytes = serializer.PackSingleObject(copy);
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(bytes.Length)));
        }

        return copy;
    }

    static T SerializeJsonNet<T>(T original)
    {
        Console.WriteLine("JSON.NET");

        var jsonSerializer = new JsonSerializer();
        T copy = default(T);
        MemoryStream stream = null;

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream = new MemoryStream();
                using (var tw = new StreamWriter(stream, Encoding.UTF8, 1024, true))
                using (var jw = new JsonTextWriter(tw))
                {
                    jsonSerializer.Serialize(jw, original);
                }
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream.Position = 0;
                using (var tr = new StreamReader(stream, Encoding.UTF8, false, 1024, true))
                using (var jr = new JsonTextReader(tr))
                {
                    copy = jsonSerializer.Deserialize<T>(jr);
                }
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream = new MemoryStream();
                using (var tw = new StreamWriter(stream, Encoding.UTF8, 1024, true))
                using (var jw = new JsonTextWriter(tw))
                {
                    jsonSerializer.Serialize(jw, copy);
                }
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(stream.Position)));
        }

        return copy;
    }

    static T SerializeJil<T>(T original)
    {
        Console.WriteLine("Jil");

        var jsonSerializer = new JsonSerializer();
        T copy = default(T);
        MemoryStream stream = null;

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream = new MemoryStream();
                using (var tw = new StreamWriter(stream, Encoding.UTF8, 1024, true))
                {
                    Jil.JSON.Serialize(original, tw);
                }
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream.Position = 0;
                using (var tr = new StreamReader(stream, Encoding.UTF8, false, 1024, true))
                {
                    copy = Jil.JSON.Deserialize<T>(tr);
                }
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream = new MemoryStream();
                using (var tw = new StreamWriter(stream, Encoding.UTF8, 1024, true))
                {
                    Jil.JSON.Serialize(original, tw);
                }
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(stream.Position)));
        }

        return copy;
    }

    static T SerializeBinaryFormatter<T>(T original)
    {
        Console.WriteLine("BinaryFormatter");

        var serializer = new BinaryFormatter();
        T copy = default(T);
        MemoryStream stream = null;

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                serializer.Serialize(stream = new MemoryStream(), original);
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream.Position = 0;
                copy = (T)serializer.Deserialize(stream);
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                serializer.Serialize(stream = new MemoryStream(), copy);
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(stream.Position)));
        }

        return copy;
    }

    static T SerializeDataContract<T>(T original)
    {
        Console.WriteLine("DataContractSerializer");

        T copy = default(T);
        MemoryStream stream = null;

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                new DataContractSerializer(typeof(T)).WriteObject(stream = new MemoryStream(), original);
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream.Position = 0;
                copy = (T)new DataContractSerializer(typeof(T)).ReadObject(stream);
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                new DataContractSerializer(typeof(T)).WriteObject(stream = new MemoryStream(), copy);
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(stream.Position)));
        }

        return copy;
    }

    static T SerializeFsPickler<T>(T original)
    {
        Console.WriteLine("FsPickler");

        T copy = default(T);
        MemoryStream stream = null;
        var serializer = MBrace.CsPickler.CsPickler.CreateBinarySerializer();

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                serializer.Serialize<T>(stream = new MemoryStream(), original, leaveOpen: true);
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                stream.Position = 0;
                copy = serializer.Deserialize<T>(stream, leaveOpen: true);
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                serializer.Serialize<T>(stream = new MemoryStream(), copy, leaveOpen: true);
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(stream.Position)));
        }

        return copy;
    }

    static FlatBuffersObject.Person SerializeSingleFlatBuffers()
    {
        Console.WriteLine("FlatBuffers");

        FlatBuffersObject.Person copy = default(FlatBuffersObject.Person);
        byte[] bytes = null;

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                var builder = new FlatBuffers.FlatBufferBuilder(1);

                var person = FlatBuffersObject.Person.CreatePerson(builder, 99999, builder.CreateString("Windows"), builder.CreateString("Server"), FlatBuffersObject.Sex.Male);
                builder.Finish(person.Value);

                bytes = builder.SizedByteArray();
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                copy = FlatBuffersObject.Person.GetRootAsPerson(new FlatBuffers.ByteBuffer(bytes));
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                var bb = copy.ByteBuffer;
                var newbytes = new byte[bb.Length];
                Buffer.BlockCopy(bb.Data, 0, newbytes, 0, bb.Length);
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(bytes.Length)));
        }

        return copy;
    }

    static FlatBuffersObject.PersonVector SerializeArrayFlatBuffers()
    {
        Console.WriteLine("FlatBuffers");

        FlatBuffersObject.PersonVector copy = default(FlatBuffersObject.PersonVector);
        byte[] bytes = null;

        Func<FlatBuffers.FlatBufferBuilder, FlatBuffers.Offset<FlatBuffersObject.Person>[]> makeVector = b =>
        {
            var array = new FlatBuffers.Offset<FlatBuffersObject.Person>[1000];
            var count = 0;
            for (int j = 1000; j < 2000; j++)
            {
                var person = FlatBuffersObject.Person.CreatePerson(b, j, b.CreateString("Windows"), b.CreateString("Server"), FlatBuffersObject.Sex.Female);
                array[count++] = person;
            }
            return array;
        };

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                var builder = new FlatBuffers.FlatBufferBuilder(1);

                var personVector = FlatBuffersObject.PersonVector.CreatePersonVector(builder, FlatBuffersObject.PersonVector.CreateListVector(builder, makeVector(builder)));
                builder.Finish(personVector.Value);

                bytes = builder.SizedByteArray();
            }
        }

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                copy = FlatBuffersObject.PersonVector.GetRootAsPersonVector(new FlatBuffers.ByteBuffer(bytes));
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                var bb = copy.ByteBuffer;
                var newbytes = new byte[bb.Length];
                Buffer.BlockCopy(bb.Data, 0, newbytes, 0, bb.Length);
            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(bytes.Length)));
        }

        return copy;
    }

    static void ValidateFlatBuffers(Person original, IList<Person> list, FlatBuffersObject.Person p, FlatBuffersObject.PersonVector l)
    {
        if (!(p.Age == original.Age && p.FirstName == original.FirstName && p.LastName == original.LastName && (sbyte)p.Sex == (sbyte)original.Sex))
        {
            throw new Exception("Validation failed");
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (!(l.GetList(i).Age == list[i].Age && l.GetList(i).FirstName == list[i].FirstName && l.GetList(i).LastName == list[i].LastName && (sbyte)l.GetList(i).Sex == (sbyte)list[i].Sex))
            {
                throw new Exception("Validation failed");
            }
        }
    }

    static Proto3Objects.Person SerializeSingleProto3(Person original)
    {
        Console.WriteLine("Google.Protobuf");

        Proto3Objects.Person copy = default(Proto3Objects.Person);
        MemoryStream stream = null;

        var person = new Proto3Objects.Person
        {
            Age = original.Age,
            FirstName = original.FirstName,
            LastName = original.LastName,
            Sex = (Proto3Objects.Sex)(int)original.Sex
        };

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                using (var writeStream = new Google.Protobuf.CodedOutputStream(stream = new MemoryStream(), true))
                {
                    person.WriteTo(writeStream);
                }
            }
        }

        byte[] inputBytes = stream.ToArray();

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                copy = Proto3Objects.Person.Parser.ParseFrom(inputBytes);
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                using (var writeStream = new Google.Protobuf.CodedOutputStream(stream = new MemoryStream(), true))
                {
                    copy.WriteTo(writeStream);
                }

            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(stream.Position)));
        }

        return copy;
    }

    static Proto3Objects.PersonVector SerializeArrayProto3(IList<Person> original)
    {
        Console.WriteLine("Google.Protobuf");

        Proto3Objects.PersonVector copy = default(Proto3Objects.PersonVector);
        MemoryStream stream = null;

        var person = new Proto3Objects.PersonVector();
        person.List.AddRange(original.Select(x => new Proto3Objects.Person
        {
            Age = x.Age,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Sex = (Proto3Objects.Sex)(int)x.Sex
        }));

        using (new Measure("Serialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                using (var writeStream = new Google.Protobuf.CodedOutputStream(stream = new MemoryStream(), true))
                {
                    person.WriteTo(writeStream);
                }
            }
        }

        byte[] inputBytes = stream.ToArray();

        using (new Measure("Deserialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                copy = Proto3Objects.PersonVector.Parser.ParseFrom(inputBytes);
            }
        }

        using (new Measure("ReSerialize"))
        {
            for (int i = 0; i < Iteration; i++)
            {
                using (var writeStream = new Google.Protobuf.CodedOutputStream(stream = new MemoryStream(), true))
                {
                    copy.WriteTo(writeStream);
                }

            }
        }

        if (!dryRun)
        {
            Console.WriteLine(string.Format("{0,15}   {1}", "Binary Size", ToHumanReadableSize(stream.Position)));
        }

        return copy;
    }

    static void ValidateProto3(Person original, IList<Person> list, Proto3Objects.Person p, Proto3Objects.PersonVector l)
    {
        if (!(p.Age == original.Age && p.FirstName == original.FirstName && p.LastName == original.LastName && (sbyte)p.Sex == (sbyte)original.Sex))
        {
            throw new Exception("Validation failed");
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (!(l.List[i].Age == list[i].Age && l.List[i].FirstName == list[i].FirstName && l.List[i].LastName == list[i].LastName && (sbyte)l.List[i].Sex == (sbyte)list[i].Sex))
            {
                throw new Exception("Validation failed");
            }
        }
    }

    static void GenerateMsgPackSerializers()
    {
        var settings = new SerializerCodeGenerationConfiguration
        {
            OutputDirectory = Path.GetTempPath(),
            SerializationMethod = SerializationMethod.Array,
            Namespace = "Sandbox.Shared.GeneratedSerializers",
            IsRecursive = true,
            PreferReflectionBasedSerializer = false,
            WithNullableSerializers = true,
            EnumSerializationMethod = EnumSerializationMethod.ByName
        };

        var result = SerializerGenerator.GenerateSerializerSourceCodes(settings, typeof(Person));
        foreach (var item in result)
        {
            Console.WriteLine(item.FilePath);
        }
    }

    struct Measure : IDisposable
    {
        string label;
        Stopwatch s;

        public Measure(string label)
        {
            this.label = label;
            this.s = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            s.Stop();
            if (!dryRun)
            {
                Console.WriteLine($"{ label,15}   {s.Elapsed.TotalMilliseconds} ms");
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    static string ToHumanReadableSize(long size)
    {
        return ToHumanReadableSize(new Nullable<long>(size));
    }

    static string ToHumanReadableSize(long? size)
    {
        if (size == null) return "NULL";

        double bytes = size.Value;

        if (bytes <= 1024) return bytes.ToString("f2") + " B";

        bytes = bytes / 1024;
        if (bytes <= 1024) return bytes.ToString("f2") + " KB";

        bytes = bytes / 1024;
        if (bytes <= 1024) return bytes.ToString("f2") + " MB";

        bytes = bytes / 1024;
        if (bytes <= 1024) return bytes.ToString("f2") + " GB";

        bytes = bytes / 1024;
        if (bytes <= 1024) return bytes.ToString("f2") + " TB";

        bytes = bytes / 1024;
        if (bytes <= 1024) return bytes.ToString("f2") + " PB";

        bytes = bytes / 1024;
        if (bytes <= 1024) return bytes.ToString("f2") + " EB";

        bytes = bytes / 1024;
        return bytes + " ZB";
    }
}
