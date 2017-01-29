using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    [DataContract]
    public class Me
    {

        private int age;

        [OptionalField]
        private string name;

        [NonSerialized]
        private string profession;

        [XmlElement("MyAge")]
        [DataMember(Order = 1)]
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        [XmlAttribute("MyName")]
        [DataMember(Order = 2)]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        [XmlIgnore]
        [DataMember(Order = 3)]
        public string Profession
        {
            get
            {
                return this.profession;
            }
            set
            {
                this.profession = value;
            }
        }

        public Me()
        {
        }

        public Me(string name, string profession, int age)
        {
            this.Name = name;
            this.Profession = profession;
            this.Age = age;
        }

        public void GetAge()
        {
            Console.WriteLine("My Age is: {0}", age);
        }

        public void GetName()
        {
            Console.WriteLine("My Name is: {0}", name);
        }

        public void ChangeProfession(string newProf)
        {
            this.Profession = newProf;
        }
    }
}
