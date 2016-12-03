using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingClassPerson
{
    class Person
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public Person(){}

        public Person(string Name, DateTime Date)
        {
            this.Name = Name;
            this.DateOfBirth = Date;
        }

        public int Age()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public override string ToString()
        {
            return string.Format("Name - {0}, age - {1}", this.Name, this.Age());
        }

        public void ChangeName(string Name)
        {
            this.Name = Name;
        }
    }
}
