using System;

namespace AppropriateFunctions
{
    public class Function
    {
        public static void InformationAboutPerson()
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            Console.WriteLine("How old are you, {0}?", name);
            var input = Console.ReadLine();
            int age;

            var isInputValid = int.TryParse(input, out age);
            var isAgeValid = age > 0;



            if (isInputValid && isAgeValid)
            {
                Console.WriteLine("\nYour name is {0}", name);
                Console.WriteLine("You are {0} years old\n", age);
            }
            else
            {
                Console.WriteLine("Incorrect value!\n");
            }
            Console.ReadLine();

        }
    }
}