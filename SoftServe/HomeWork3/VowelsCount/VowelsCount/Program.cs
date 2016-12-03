using System;
using System.Linq;

namespace VowelsCount
{
    class Program
    {
        /// <summary>
        /// Read the text as a string value 
        /// and culculate the counts of characters 'a', 'o', 'i', 'e' in this text.
        /// </summary>
        
        static void Main(string[] args)
        {
            Console.Write("Input some text : ");
            string text = Console.ReadLine();

            char[] vowels = new char[] { 'a', 'o', 'i', 'e' };

            int vowelsCount = text.Count(t => vowels.Contains(t));

            Console.WriteLine("Total number of vowels are : {0}", vowelsCount);

            Console.ReadKey();
        }
    }
}
