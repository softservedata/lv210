using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Person
    {
        private string name;
        private int birthYear;
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
       public Person() { }
        public Person(string name,int birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        public int Age()
        {
            return DateTime.Now.Year - birthYear;
        }
        public void Input()
        {
            Console.Write("Input name:");
            name = Console.ReadLine();
            Console.Write("Input bith year:");
            birthYear = Convert.ToInt32(Console.ReadLine());
        }
        public void Output()
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("birth year: {0}", birthYear);
            Console.WriteLine("Age: {0}", Age());
                    }
        public void ChangeName(string newName)
        {
            name = newName;
        }
    }
}
