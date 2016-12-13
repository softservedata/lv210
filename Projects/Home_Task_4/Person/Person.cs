using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        //Fields
        private string nameOfPerson;
        private DateTime birthDateOfPerson;

        //Properties
        public string NameOfPerson
        {
            get { return nameOfPerson; }
        }

        public DateTime BirthDateOfPerson
        {
            get { return birthDateOfPerson; }
        }

        public Person(string name, DateTime birthDate)
        {
            nameOfPerson = name;
            birthDateOfPerson = birthDate;
        }

        public Person() { }

        /// <summary>
        /// Calculate the age of person
        /// </summary>
        /// <returns></returns>
        public int AgeOfPerson()
        {
            return DateTime.Now.Year - BirthDateOfPerson.Year;
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
            int age = AgeOfPerson();
            Console.WriteLine("{0}, {1} years old. Birthday: {2}", NameOfPerson, age, BirthDateOfPerson.ToShortDateString());
        }

        /// <summary>
        /// Change the name of persons, 
        /// which Age is less then 16, to "Very Young"
        /// </summary>
        public void ChangeName()
        {
            if (AgeOfPerson() < 16)
            {
                nameOfPerson = "Very Young";
            }
        }
    }
}
