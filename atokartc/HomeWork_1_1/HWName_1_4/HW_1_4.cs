using System;

namespace HomeWorkOne
{
    /// <summary>
    /// Create Console Application project in VS.
    /// In method Main() write code for solving next tasks:
    /// define string variable name and integer value age. Output question "What is your name?"
    /// Read the value name and output next question: "How old are you,(name)?". Read age and write whole information
    /// </summary>
    public class HW_1_4
    {
        public static int GetPositiveValueFromConsole()
        {
            int readedVar = 0;
            bool isIntEntered = Int32.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered && readedVar >= 0)
            {
                return readedVar;
            }
            else
            {
                Console.WriteLine("Please, enter a positive integer");
                return GetPositiveValueFromConsole();
            }
        }

        public static void Main()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("How old are you?");
            int age = GetPositiveValueFromConsole();

            Console.WriteLine("My name is: {0}", name);
            Console.WriteLine("I am {0} years old", age);

            Console.ReadKey();
        }
    }
}
