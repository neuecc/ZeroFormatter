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

        byte[] zeroFormatterSingleBytes;
        byte[] zeroFormatterArrayBytes;
        byte[] msgpackSingleBytes;
        byte[] msgpackArrayBytes;
        byte[] jsonSingleBytes;
        byte[] jsonArrayBytes;

        SerializationContext msgPackContext;

        // Test Initialize:)
        public void _Init()
        {
            // ZeroFormatter Prepare
            ZeroFormatter.Formatters.Formatter.RegisterList<Person>();

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

    }
}
