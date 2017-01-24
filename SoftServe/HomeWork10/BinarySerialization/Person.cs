using System;
using System.Runtime.Serialization;

namespace BinarySerialization
{
    [Serializable]
    [DataContract]
    public class Person
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string City { get; set; }
    }
}
