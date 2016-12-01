using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4_Task1
{
    class Person
    {
        private string name;
        private int birthYear;

        public Person() { }

        public Person(string _name, int _birthYear)
        {
            name = _name;
            birthYear = _birthYear;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int BirthYear
        {
            get
            {
                return birthYear;
            }
        }

        public int Age()
        {
            int presentYear = DateTime.Now.Year;

            return presentYear - BirthYear;
        }

        public static Person Input()
        {
            Console.WriteLine("Information about person.");
            Console.Write("Input name for person: ");
            var name = Console.ReadLine();

            Console.Write("Input year of person's birth: ");
            var birthYear = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return new Person(name, birthYear);
        }

        public void Output()
        {
            Console.WriteLine("Person's name: {0}, age: {1}", Name, Age());
        }

        public void ChangeName()
        {
            if(Age() < 16)
            {
                name = "Very Young";
            }   
        }
    }
}
