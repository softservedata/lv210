using System;
using System.Linq;

namespace StringCount
{
    class Program
    {
	///<summary>
	///	Read the text as a string value and culculate the counts of characters 'a', 'o', 'i', 'e' in this text.
	///</summary>
        static void Main(string[] args)
        {
            char[] characters = new char[] { 'a', 'o', 'i', 'e' };
            Console.WriteLine("Input text:");
            string inputText = Console.ReadLine();
            int count = inputText.Count(c => characters.Contains(c));
            Console.WriteLine("Count of ('a', 'o', 'i', 'e') characters: {0}", count);
            Console.ReadLine();
        }
    }
}
