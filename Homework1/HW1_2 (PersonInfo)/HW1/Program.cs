using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define string variable name and integer value age
            Console.WriteLine("What is your name? ");
            string name = Console.ReadLine();
            Console.WriteLine("How old are you? ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yor are {0} and you are {1} years old.", name, age);
            Console.ReadKey();
        }
    }
}
