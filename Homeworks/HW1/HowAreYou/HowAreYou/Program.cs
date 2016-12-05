using System;

namespace HowAreYou
{
    class Program
    {
	/*
		Output question “How are you?“. 
		Define string variable answer. 
		Read the value answer and output: “You are (answer)". 
	*/
        static void Main(string[] args)
        {
            string answer;
            Console.WriteLine("How are you?");
            answer = Console.ReadLine();
            Console.WriteLine("You are {0}", answer);
            Console.ReadLine();
        }
    }
}
