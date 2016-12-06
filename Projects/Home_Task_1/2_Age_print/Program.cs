using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_age
{
    /// <summary>
    /// Define string variable name and integer value age. 
    /// Output question "What is your name?";
    /// Read the value name and output next question: "How old are you,(name)?". 
    /// Read age and write whole information
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Entering info
            Console.WriteLine("What is your name? ");
            string name = Console.ReadLine();

            Console.WriteLine("How old are you, {0}? ", name);
            int age = Convert.ToInt32(Console.ReadLine());

            //Result
            Console.WriteLine("\n{0} is {1}.", name, age);
        }
    }
}
