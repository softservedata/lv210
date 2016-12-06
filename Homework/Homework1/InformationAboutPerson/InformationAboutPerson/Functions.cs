using System;

namespace AppropriateFunctions
{
    public class ProgramPerson
    {
        public void Run()
        {
            try
            {
                var name = ReadName();
                var readedAge = ReadAge(name);

                var age = ParseData(readedAge);
                DisplayInformationAboutPerson(name, age);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public string ReadName()
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            return name;
        }

        public string ReadAge(string name)
        {
            Console.WriteLine("\nHow old are you, {0}?", name);
            var age = Console.ReadLine();

            return age;
        }

        public void DisplayInformationAboutPerson(string name, int age)
        {
            if (age <= 0)
                throw new ArgumentException("\nAge can't be less or equal zero!");

            Console.WriteLine("\nYour name is {0}", name);
            Console.WriteLine("You are {0} years old\n", age);
        }

        public int ParseData(string data)
        {
            int parsedValue;

            var isParseSuccessful = int.TryParse(data, out parsedValue);

            if (!isParseSuccessful)
                throw new FormatException("Can't parse data to <int>");

            return parsedValue;
        }
    }
}