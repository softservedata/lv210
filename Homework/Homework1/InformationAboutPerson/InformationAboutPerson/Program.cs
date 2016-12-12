using System;
using System.Linq;

namespace InformationAboutPerson
{
    class Program
    {
        public static string ReadName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine()?.Replace(" ", "");
        }

        public static int ReadAge(string name)
        {
            Console.WriteLine("\nHow old are you, {0}?", name);
            var age = Console.ReadLine();
            DataParser parser = new DataParser();

            return parser.Parse(age);
        }

        static void Main(string[] args)
        {
            var readedName = ReadName();
            var readedAge = ReadAge(readedName);
            var person = new Person(readedName, readedAge);
            var validationResults = person.Validate();
            if (validationResults.Any())
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine(person);
            }

            Console.ReadLine();
        }
    }
}

