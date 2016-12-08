using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person
    {
        //fields
        private string name;
        private DateTime birthDate;

        /// <summary>
        /// Property Name for Person
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Property BirthDate for Person
        /// </summary>
        public DateTime BirthDate
        {
            get { return birthDate; }
        }

        /// <summary>
        /// Constructor for Person 
        /// </summary>
        /// <param name="name">name of person</param>
        /// <param name="birthYear">birthYear of person</param>
        public Person(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
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
            return DateTime.Now.Year - BirthDate.Year;
        }

        /// <summary>
        /// To input info about person
        /// </summary>
        /// <returns></returns>
        public static Person Input()
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the birth date in format day-month-year: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            return new Person(name, birthDate);
        }

        /// <summary>
        /// Output information about person
        /// </summary>
        public void Output()
        {
            int age = Age();
            Console.WriteLine("{0}, {1} years old. Birthday: {2}", Name, age, BirthDate.ToShortDateString());
        }

        /// <summary>
        /// Change the name of persons, 
        /// which Age is less then 16, to "Very Young"
        /// </summary>
        public void ChangeName()
        {
            if (Age() < 16)
            {
                name = "Very Young";
            }
        }
    }
}
