using System;
using System.Runtime.Serialization;

namespace Serialization
{
    [Serializable]
    [DataContract]
    public class Person
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public DateTime BirthDate { get; set; }
        
        public Person()
        {
        }
             
        public Person(string name, DateTime birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public int Age()
        {
            return DateTime.Now.Year - BirthDate.Year;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
