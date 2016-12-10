using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationAboutPerson
{
    public class Person
    {
        private string _name; // Name of the person
        private int _age; // Age of the person

        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }

        public override string ToString()
        {
            return $"\nName is {this._name}, age is {this._age}.";
        }
    }
}
