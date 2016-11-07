using System;
using System.Runtime.Serialization;
using ZeroFormatter;

namespace Sandbox.Shared
{
    [Serializable]
    [ZeroFormattable]
    [DataContract]
    public class Person : IEquatable<Person>
    {
        [Index(0)]
        [DataMember(Order = 0)]
        public virtual int Age { get; set; }
        [Index(1)]
        [DataMember(Order = 1)]
        public virtual string FirstName { get; set; }
        [Index(2)]
        [DataMember(Order = 2)]
        public virtual string LastName { get; set; }
        [Index(3)]
        [DataMember(Order = 3)]
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
}
