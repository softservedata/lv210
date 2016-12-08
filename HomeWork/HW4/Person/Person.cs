using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person
    {
        private string Name;
        private int birthYear;

        public string GetName
        {
            get
            {
                return Name;
            }
        }

        public int GetYear
        {
            get
            {
                return birthYear;
            }
        }

        public Person()
        {

        }

        public Person(string Name, int birthYear)
        {
            this.Name = Name;
            this.birthYear = birthYear;
        }

        public int Age()
        {
            return DateTime.Now.Year - birthYear;
        }

        public void Input(string Name, int birthYear)
        {
            this.Name = Name;
            this.birthYear = birthYear;
        }

        public void Output()
        {
            Console.WriteLine("Name is: {0} \nAge is {1}\n", Name, Age());
        }

        public void ChangeName(string Name)
        {
            this.Name = Name;
        }
    }
}
