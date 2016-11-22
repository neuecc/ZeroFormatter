using MsgPack.Serialization;
using Sandbox.Shared;
using Sandbox.Shared.GeneratedSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;
using ZeroFormatter;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [Serializable]
    public class PersonLike
    {
        public int Age;
        public string FirstName;
        public string LastName;
        public Sex2 Sex;
    }

    [Serializable]
    public class PersonLikeVector
    {
        public PersonLike[] List;
    }

    public enum Sex2 : int
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }

    public class PerformanceTest
    {
        const int Iteration = 500; // 500 iteration.

        Person p;
        IList<Person> l;
        PersonLike p2;
        PersonLikeVector l2;

        //Vector3 v3;
        //Vector3[] v3Array;

        byte[] zeroFormatterSingleBytes;
        byte[] zeroFormatterArrayBytes;
        byte[] msgpackSingleBytes;
        byte[] msgpackArrayBytes;
        byte[] jsonSingleBytes;
        byte[] jsonArrayBytes;

        //byte[] zeroFormatterv3Bytes;
        //byte[] zeroFormatterv3ArrayBytes;
        //byte[] msgpackv3Bytes;
        //byte[] msgpackv3ArrayBytes;
        //byte[] jsonv3Bytes;
        //byte[] jsonv3ArrayBytes;

        SerializationContext msgPackContext;

        // Test Initialize:)
        public void _Init()
        {
            // ZeroFormatter Prepare
            ZeroFormatter.Formatters.Formatter.RegisterList<DefaultResolver, Person>();

            // MsgPack Prepare
            MsgPack.Serialization.MessagePackSerializer.PrepareType<Sex>();
            this.msgPackContext = new MsgPack.Serialization.SerializationContext();
            this.msgPackContext.ResolveSerializer += SerializationContext_ResolveSerializer;

            this.p = new Person
            {
                Age = 99999,
                FirstName = "Windows",
                LastName = "Server",
                Sex = Sex.Male,
            };
            this.p2 = new PersonLike
            {

                Age = 99999,
                FirstName = "Windows",
                LastName = "Server",
                Sex = Sex2.Male
            };

            this.l = Enumerable.Range(1000, 1000).Select(x => new Person { Age = x, FirstName = "Windows", LastName = "Server", Sex = Sex.Female }).ToArray();
            this.l2 = new PersonLikeVector { List = Enumerable.Range(1000, 1000).Select(x => new PersonLike { Age = x, FirstName = "Windows", LastName = "Server", Sex = Sex2.Female }).ToArray() };

            zeroFormatterSingleBytes = ZeroFormatterSerializer.Serialize(p);
            zeroFormatterArrayBytes = ZeroFormatterSerializer.Serialize(l);
            var serializer1 = this.msgPackContext.GetSerializer<Person>();
            msgpackSingleBytes = serializer1.PackSingleObject(p);
            var serializer2 = this.msgPackContext.GetSerializer<IList<Person>>();
            msgpackArrayBytes = serializer2.PackSingleObject(l);

            jsonSingleBytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(p2));
            jsonArrayBytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(l2));

            // vector?

            //MsgPack.Serialization.MessagePackSerializer.PrepareType<Vector3>();
            //MsgPack.Serialization.MessagePackSerializer.PrepareType<Vector3[]>();

            //v3 = new Vector3 { x = 12345.12345f, y = 3994.35226f, z = 325125.52426f };
            //v3Array = Enumerable.Range(1, 100).Select(_ => new Vector3 { x = 12345.12345f, y = 3994.35226f, z = 325125.52426f }).ToArray();
            //zeroFormatterv3Bytes = ZeroFormatterSerializer.Serialize(v3);
            //zeroFormatterv3ArrayBytes = ZeroFormatterSerializer.Serialize(v3Array);
            //var serializer3 = this.msgPackContext.GetSerializer<Vector3>();
            //msgpackv3Bytes = serializer3.PackSingleObject(v3);
            //var serializer4 = this.msgPackContext.GetSerializer<Vector3[]>();
            //msgpackv3ArrayBytes = serializer4.PackSingleObject(v3Array);

            //jsonv3Bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(v3));
            //jsonv3ArrayBytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(v3Array));
        }

        private void SerializationContext_ResolveSerializer(object sender, ResolveSerializerEventArgs e)
        {
            if (e.TargetType == typeof(Person)) { e.SetSerializer(new PersonSerializer(e.Context)); return; }
            if (e.TargetType == typeof(Sex)) { e.SetSerializer(new SexSerializer(e.Context)); return; }
        }

        public void ZeroFormatterSerializeSingle()
        {
            for (int i = 0; i < Iteration; i++)
            {
                ZeroFormatterSerializer.Serialize(p);
            }
        }

        public void ZeroFormatterSerializeArray()
        {
            for (int i = 0; i < Iteration; i++)
            {
                ZeroFormatterSerializer.Serialize(l);
            }
        }

        public void ZeroFormatterDeserializeSingle()
        {
            for (int i = 0; i < Iteration; i++)
            {
                ZeroFormatterSerializer.Deserialize<Person>(zeroFormatterSingleBytes);
            }
        }

        public void ZeroFormatterDeserializeArray()
        {
            for (int i = 0; i < Iteration; i++)
            {
                ZeroFormatterSerializer.Deserialize<IList<Person>>(zeroFormatterArrayBytes);
            }
        }

        public void MsgPackSerializeSingle()
        {
            var serializer = this.msgPackContext.GetSerializer<Person>();
            for (int i = 0; i < Iteration; i++)
            {
                serializer.PackSingleObject(p);
            }
        }

        public void MsgPackSerializeArray()
        {
            var serializer = this.msgPackContext.GetSerializer<IList<Person>>();
            for (int i = 0; i < Iteration; i++)
            {
                serializer.PackSingleObject(l);
            }
        }

        public void MsgPackDeserializeSingle()
        {
            var serializer = this.msgPackContext.GetSerializer<Person>();
            for (int i = 0; i < Iteration; i++)
            {
                serializer.UnpackSingleObject(msgpackSingleBytes);
            }
        }

        public void MsgPackDeserializeArray()
        {
            var serializer = this.msgPackContext.GetSerializer<IList<Person>>();
            for (int i = 0; i < Iteration; i++)
            {
                serializer.UnpackSingleObject(msgpackArrayBytes);
            }
        }

        public void JsonUtilitySerializeSingle()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var str = JsonUtility.ToJson(p2);
                Encoding.UTF8.GetBytes(str); // testing with binary...
            }
        }

        public void JsonUtilitySerializeArray()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var str = JsonUtility.ToJson(l2);
                Encoding.UTF8.GetBytes(str); // testing with binary...
            }
        }

        public void JsonUtilityDeserializeSingle()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var str = Encoding.UTF8.GetString(jsonSingleBytes);
                JsonUtility.FromJson<PersonLike>(str);
            }
        }

        public void JsonUtilityDeserializeArray()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var str = Encoding.UTF8.GetString(jsonArrayBytes);
                JsonUtility.FromJson<PersonLikeVector>(str);
            }
        }


        // more...

        //public void ZeroFormatterSerializeVector3()
        //{
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        ZeroFormatterSerializer.Serialize(v3);
        //    }
        //}

        //public void ZeroFormatterSerializeVector3Array()
        //{
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        ZeroFormatterSerializer.Serialize(v3Array);
        //    }
        //}

        //public void ZeroFormatterDeserializeVector3()
        //{
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        ZeroFormatterSerializer.Deserialize<Vector3>(zeroFormatterv3Bytes);
        //    }
        //}

        //public void ZeroFormatterDeserializeVector3Array()
        //{
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        ZeroFormatterSerializer.Deserialize<Vector3[]>(zeroFormatterv3ArrayBytes);
        //    }
        //}

        //public void MsgPackSerializeVector3()
        //{
        //    var serializer = this.msgPackContext.GetSerializer<Vector3>();
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        serializer.PackSingleObject(v3);
        //    }
        //}

        //public void MsgPackSerializeVector3Array()
        //{
        //    var serializer = this.msgPackContext.GetSerializer<Vector3[]>();
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        serializer.PackSingleObject(v3Array);
        //    }
        //}

        //public void MsgPackDeserializeVector3()
        //{
        //    var serializer = this.msgPackContext.GetSerializer<Vector3>();
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        serializer.UnpackSingleObject(msgpackv3Bytes);
        //    }
        //}

        //public void MsgPackDeserializeVector3Array()
        //{
        //    var serializer = this.msgPackContext.GetSerializer<Vector3[]>();
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        serializer.UnpackSingleObject(msgpackv3ArrayBytes);
        //    }
        //}

        //public void JsonUtilitySerializeVector3()
        //{
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        var str = JsonUtility.ToJson(v3);
        //        Encoding.UTF8.GetBytes(str); // testing with binary...
        //    }
        //}

        //public void JsonUtilitySerializeVector3Array()
        //{
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        var str = JsonUtility.ToJson(v3Array);
        //        Encoding.UTF8.GetBytes(str); // testing with binary...
        //    }
        //}

        //public void JsonUtilityDeserializeVector3()
        //{
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        var str = Encoding.UTF8.GetString(jsonv3Bytes);
        //        JsonUtility.FromJson<Vector3>(str);
        //    }
        //}

        //public void JsonUtilityDeserializeVector3Array()
        //{
        //    for (int i = 0; i < Iteration; i++)
        //    {
        //        var str = Encoding.UTF8.GetString(jsonv3ArrayBytes);
        //        JsonUtility.FromJson<Vector3[]>(str);
        //    }
        //}
    }
}
