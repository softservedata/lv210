using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person
    {
        //fields
        private string name;
        private int birthYear;

        /// <summary>
        /// Property Name for Person
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Property BirthYear for Person
        /// </summary>
        public int BirthYear
        {
            get { return birthYear; }
        }

        /// <summary>
        /// Constructor for Person 
        /// </summary>
        /// <param name="name">name of person</param>
        /// <param name="birthYear">birthYear of person</param>
        public Person(string name, int birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        /// <summary>
        /// Default constructor for Person
        /// </summary>
        public Person() { }

        //Methods

        /// <summary>
        /// Calculate the age of person
        /// </summary>
        /// <returns></returns>
        public int Age()
        {
            return DateTime.Now.Year - BirthYear;
        }

        /// <summary>
        /// To input info about person
        /// </summary>
        /// <returns></returns>
        public static Person Input()
        {
            Console.WriteLine("-----Creating new Person-----");
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the birth year: ");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("-----Person saved-----\n");

            return new Person(name, birthYear);
        }

        /// <summary>
        /// Output information about person
        /// </summary>
        public void Output()
        {
            int age = Age();
            Console.WriteLine("{0}, {1} years old", Name, age);
        }

        /// <summary>
        /// Change the name of persons, 
        /// which Age is less then 16, to "Very Young"
        /// </summary>
        public void ChangeName()
        {
            if (Age() < 16)
                name = "Very Young";
        }
    }
}
