using System;

namespace HowAreYou
{
    class Program
    {
	///<summary>
	///	Output question “How are you?“. 
	///	Define string variable answer. 
	///	Read the value answer and output: “You are (answer)". 
	///</summary>
        static void Main(string[] args)
        {
            Console.Write("How are you? ");
            string answer = Console.ReadLine();
            Console.WriteLine("You are {0}", answer);
            Console.ReadLine();
        }
    }
}
