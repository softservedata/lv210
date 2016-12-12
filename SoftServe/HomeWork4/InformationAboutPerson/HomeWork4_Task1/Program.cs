using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4_Task1
{
    class Program
    {
        /// <summary>
        /// Create Console Application project in VS.
        /// Add class Person to the project.
        /// Class Person should consists of
        /// a) two private fields: name and birthYear(the birthday year) .
	    /// b) two properties for access to these fields(only get)
        /// c) default constructor and constructor with 2 parameters
        /// d) methods:
        ///         Age - to calculate the age of person
        ///         Input - to input information about person
        ///         Output - to output information about person
        ///         ChangeName - to change the name of person
        /// In the method Main() create 5 objects of Person type and input information about them.
        /// Then calculate and write to console the name and Age of each person;
        /// Change the name of persons, which Age is less then 16, to "Very Young".
        /// Output information about all persons.
        /// </summary>
        
        static void Main(string[] args)
        {
            var personCount = 5;
            var persons = new List<Person>();

            for(int i = 0; i < personCount; i++)
            {
                persons.Add(Person.Input());
            }

            persons.ForEach(p => p.Output());

            persons.ForEach(p => p.ChangeName());

            Console.WriteLine("Change name (if neccessary).");

            persons.ForEach(p => p.Output());

            Console.ReadKey();
        }
    }
}
