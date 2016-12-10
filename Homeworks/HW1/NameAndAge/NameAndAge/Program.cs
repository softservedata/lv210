using System;

namespace NameAndAge
{
    class Program
    {
        ///<summary>
        ///	Define string variable name and integer value age. 
        ///	Output question "What is your name?";
        ///	Read the value name and output next question: "How old are you,(name)?". 
        ///	Read age and write whole information
        ///</summary>
        public static int ParseAtempt()
        {
            int ReadVariable;
            bool ParseAtempt = Int32.TryParse(Console.ReadLine(), out ReadVariable);
            if (ParseAtempt)
            {
                return ReadVariable;
            }
            else
            {
                throw new FormatException("Wrong data type.");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            Console.Write("How old are you, {0}? ", name);
            try
            {
                int age = ParseAtempt();
                Console.WriteLine("Your name is {0} and you are {1} years old.", name, age);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
