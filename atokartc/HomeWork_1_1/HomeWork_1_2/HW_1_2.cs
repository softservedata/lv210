using System;

namespace HomeWorkOne
{
    /// <summary>
    /// Create Console Application project in VS.
    /// In method Main() write code for solving next tasks:
    /// Output question “How are you?“. Define string variable answer.
    /// Read the value answer and output: “You are (answer)". 
    /// </summary>
    public class HW_1_2
    {
        public static void Main()
        {
            Console.WriteLine("Who are you: ");

            string s = Console.ReadLine();

            Console.WriteLine("I am {0}", s);
            Console.ReadKey();
        }
    }
}
