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
            if ((name == string.Empty) || (name.Any(c => char.IsDigit(c))) ||
                    (name.Any(c => ! char.IsLetterOrDigit(c))))
            {
                throw new ArgumentException("\nPerson's name cannot be empty, contain digits or specific characters");
            }

            this._name = name;

            if (age <= 0)
            {
                throw new ArgumentException("\nPerson's age cannot be less or equal zero!");
            }

            this._age = age;
        }

        public override string ToString()
        {
            return string.Format("\nName is {0}, age is {1}.", this._name, this._age);
        }
    }
}
