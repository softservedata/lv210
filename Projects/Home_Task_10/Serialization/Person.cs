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
        public Person(int id, string fName, string lName, int age, string city)
        {
            ID = id;
            FirstName = fName;
            LastName = lName;
            Age = age;
            City = city;
        }

        public Person() { }             // default constr. is mandatory for XmlSerialization

        [DataMember(Order = 1)]         // for JSON Serialization
        private int ID { get; set; }    // due private modifier ID will be ignored in Xml 

        [XmlIgnore]                     // due this attribute FirstName will be ignored in Xml
        [DataMember (Order = 2)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataMember (Order = 3)]
        public int Age { get; set; }

        [DataMember(Order = 4)]
        public string City { get; set; }

        private string GetFullName()
        {
            return String.Format($"{FirstName} {LastName}");
        }

        public override string ToString()
        {
            return String.Format($"[{ID}] {GetFullName()} {Age} old. Lives in {City}");
        }
    }
}
