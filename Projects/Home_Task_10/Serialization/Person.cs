using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Serialization
{
    [Serializable] // for Binary and Xml Serialization
    [DataContract] // for JSON Serialization
    public class Person
    {
        [NonSerialized]             // due this attribute ID will be ignored in Binary 
        [DataMember (Order = 1)]    // for JSON Serialization
        private int _id;            // due private modifier ID will be ignored in Xml 

        public Person(int id, string fName, string lName, int age, string city)
        {
            _id = id;
            FirstName = fName;
            LastName = lName;
            Age = age;
            City = city;
        }

        public Person() { } // default constr. is mandatory for XmlSerialization

        [XmlIgnore]         // due this attribute FirstName will be ignored in Xml
        [DataMember (Order = 2)]
        public string FirstName { get; set; }
        [DataMember (Order = 3)]
        public string LastName { get; set; }
        [DataMember (Order = 4)]
        public int Age { get; set; }
        [DataMember(Order = 5)]
        public string City { get; set; }

        private string GetFullName()
        {
            return String.Format($"{FirstName} {LastName}");
        }

        public override string ToString()
        {
            return String.Format($"[{_id}] {GetFullName()} {Age} old. Lives in {City}");
        }
    }
}
