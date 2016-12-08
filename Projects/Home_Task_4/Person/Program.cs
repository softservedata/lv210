using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    /// <summary>
    /// Add class Person to the project. Class Person should consists of
    /// a) two private fields: name and birthYear(the birthday year) .
    /// b) two properties for access to these fields(only get)
    /// c) default constructor and constructor with 2 parameters
    /// d) methods:
    ///     Age - to calculate the age of person
    ///     Input - to input information about person
    ///     Output - to output information about person
    ///     ChangeName - to change the name of person
    /// 
    /// In the method Main() create 5 objects of Person type and input information about them.
    /// Then calculate and write to console the name and Age of each person;
    /// Change the name of persons, which Age is less then 16, to "Very Young".
    /// Output information about all persons.
    /// 
    /// B*) In the previos class use birthDate field(full Date of birthday: day, month, year) instead of birthYear field.
    /// As a type for this field use DataTime type. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Creating collection of persons
            int numbberOfPersons = 5;
            Person[] arrayOfPersons = new Person[numbberOfPersons];

            for (int i = 0; i < arrayOfPersons.Length; i++)
            {
                arrayOfPersons[i] = Person.Input();
                arrayOfPersons[i].ChangeName();
            }

            //Output results
            Console.Clear();

            foreach (Person person in arrayOfPersons)
            {
                person.Output();
            }
        }
    }
}
