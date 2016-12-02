using System;

namespace HomeWork1_Task2
{
    class Program
    {
        /// <summary>
        /// Task Description: define string variable name and integer value age. 
        /// Output question "What is your name?"; Read the value name and output next 
        /// question: "How old are you,(name)?". Read age and write whole information
        /// </summary>

        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("How old are you, {0}?", name);
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Person name is : {0} and age is : {1}", name, age);

            Console.ReadKey();
        }
    }
}
