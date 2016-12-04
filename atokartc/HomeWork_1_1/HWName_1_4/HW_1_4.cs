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
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is your name?");
            Console.WriteLine("My name is: {0}", name);
            Console.WriteLine("How old are you?");
            Console.WriteLine("I am {0} years old", age);

            Console.ReadKey();
        }
    }
}
