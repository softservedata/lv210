using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class PersonNEw
    {
        private string Name;
        private DateTime birthYear;

        public string GetName
        {
            get
            {
                return Name;
            }
        }

        public DateTime GetYear
        {
            get
            {
                return birthYear;
            }
        }

        public PersonNEw()
        {

        }

        public PersonNEw(string Name, DateTime birthYear)
        {
            this.Name = Name;
            this.birthYear = birthYear;
        }

        public int Age()
        {
            return DateTime.Now.Year - birthYear.Year;
        }

        public void Input(string Name, DateTime birthYear)
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
