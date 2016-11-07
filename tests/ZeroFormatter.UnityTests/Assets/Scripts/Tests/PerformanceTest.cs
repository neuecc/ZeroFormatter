using MsgPack.Serialization;
using Sandbox.Shared;
using Sandbox.Shared.GeneratedSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ZeroFormatter;

namespace ZeroFormatter.Tests
{
    public class PerformanceTest
    {
        const int Iteration = 1000; // 1000 iteration.

        Person p;
        IList<Person> l;
        byte[] zeroFormatterSingleBytes;
        byte[] zeroFormatterArrayBytes;
        byte[] msgpackSingleBytes;
        byte[] msgpackArrayBytes;

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
            this.l = Enumerable.Range(1000, 1000).Select(x => new Person { Age = x, FirstName = "Windows", LastName = "Server", Sex = Sex.Female }).ToArray();

            zeroFormatterSingleBytes = ZeroFormatterSerializer.Serialize(p);
            zeroFormatterArrayBytes = ZeroFormatterSerializer.Serialize(l);
            var serializer1 = this.msgPackContext.GetSerializer<Person>();
            msgpackSingleBytes = serializer1.PackSingleObject(p);
            var serializer2 = this.msgPackContext.GetSerializer<IList<Person>>();
            msgpackArrayBytes = serializer2.PackSingleObject(l);
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
    }
}
