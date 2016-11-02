// Install-Package MsgPack.Cli -Pre
// Install-Package Newtonsoft.Json -Pre
// Install-Package protobuf-net -Pre
// Install-Package ZeroFormatter -Pre
// Install-Package FsPickler.CSharp -Pre
// Install-Package FSharp.Core -Pre

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

class Program
{
    const int Iteration = 10000;
    static bool dryRun = true;

    static void Main(string[] args)
    {
        var p = new Person
        {
            Age = 9999,
            FirstName = "hoge",
            LastName = "huga",
            Sex = Sex.Male,
        };
        IList<Person> l = Enumerable.Range(1000, 1000).Select(x => new Person { Age = x, FirstName = "abc", LastName = "def", Sex = Sex.Female }).ToArray();

        Console.WriteLine("Warming-up");
        SerializeZeroFormatter(p); SerializeZeroFormatter(l);
        SerializeProtobuf(p); SerializeProtobuf(l);
        SerializeMsgPack(p); SerializeMsgPack(l);
        SerializeJsonNet(p); SerializeJsonNet(l);
        SerializeFsPickler(p); SerializeFsPickler(l);
        SerializeBinaryFormatter(p); SerializeBinaryFormatter(l);
        SerializeDataContract(p); SerializeDataContract(l);
        SerializeSingleFlatBuffers(); SerializeArrayFlatBuffers();

        dryRun = false;

        Console.WriteLine();
        Console.WriteLine("Small Object"); Console.WriteLine();

        var a = SerializeZeroFormatter(p); Console.WriteLine();
        var b = SerializeProtobuf(p); Console.WriteLine();
        var c = SerializeMsgPack(p); Console.WriteLine();
        var d = SerializeJsonNet(p); Console.WriteLine();
        var e = SerializeFsPickler(p); Console.WriteLine();
        var f = SerializeBinaryFormatter(p); Console.WriteLine();
        var g = SerializeDataContract(p); Console.WriteLine();
        var h = SerializeSingleFlatBuffers(); Console.WriteLine();

        Console.WriteLine("Large Array"); Console.WriteLine();

        var A = SerializeZeroFormatter(l); Console.WriteLine();
        var B = SerializeProtobuf(l); Console.WriteLine();
        var C = SerializeMsgPack(l); Console.WriteLine();
        var D = SerializeJsonNet(l); Console.WriteLine();
        var E = SerializeFsPickler(l); Console.WriteLine();
        var F = SerializeBinaryFormatter(l); Console.WriteLine();
        var G = SerializeDataContract(l); Console.WriteLine();
        var H = SerializeArrayFlatBuffers(); Console.WriteLine();

        Validate("ZeroFormatter", p, l, a, A);
        Validate("protobuf-net", p, l, b, B);
        Validate("MsgPack-CLI", p, l, c, C);
        Validate("JSON.NET", p, l, d, D);
        Validate("FsPickler", p, l, e, E);
        Validate("BinaryFormatter", p, l, f, F);
        Validate("DataContract", p, l, g, G);
        ValidateFlatBuffers(p, l, h, H);
    }

    static void Validate(string label, Person original, IList<Person> originalList, Person copy, IList<Person> copyList)
    {
        if (!EqualityComparer<Person>.Default.Equals(original, copy)) Console.WriteLine(label + " Invalid Deserialize Small Object");
        if (!originalList.SequenceEqual(copyList)) Console.WriteLine(label + " Invalid Deserialize Large Array");
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

                var person = FlatBuffersObject.Person.CreatePerson(builder, 9999, builder.CreateString("hoge"), builder.CreateString("huga"), FlatBuffersObject.Sex.Male);
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
                var person = FlatBuffersObject.Person.CreatePerson(b, j, b.CreateString("abc"), b.CreateString("def"), FlatBuffersObject.Sex.Female);
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
