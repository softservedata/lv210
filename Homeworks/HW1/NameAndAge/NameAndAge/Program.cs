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
        static void Main(string[] args)
        {
            string name;
            int age;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("How old are you, {0}?", name);
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your name is {0} and you are {1} years old.", name, age);
            Console.ReadLine();
        }
    }
}
