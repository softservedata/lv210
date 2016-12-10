using System;
using System.Linq;

namespace InformationAboutPerson
{
    public class PersonBuilder
    {
        public static Person BuildPerson()
        {
            var name = NameValidation(ReadName());
            var age = AgeValidation(ReadAge(name));

            return new Person(name, age);
        }

        public static string ReadName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine()?.Replace(" ","");    
        }

        public static string NameValidation(string name)
        {
            if ((name == string.Empty) || (name.Any(char.IsDigit)) ||
                  (name.Any(c => !char.IsLetterOrDigit(c))))
            {
                throw new ArgumentException("\nPerson's name cannot be empty, contain digits or specific characters");
            }
            else return name;
        }

        public static int ReadAge(string name)
        {
            Console.WriteLine("\nHow old are you, {0}?", name);
            var age = Console.ReadLine();
            DataParser parser = new DataParser();

            return parser.Parse(age);
        }

        public static int AgeValidation(int age)
        {
            if (age <= 0)
            {
                throw new ArgumentException("\nPerson's age cannot be less or equal zero!");
            }
            else return age;
        }
    }
}
