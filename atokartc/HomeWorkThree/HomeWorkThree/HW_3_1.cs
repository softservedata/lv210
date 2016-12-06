using System;
using System.Linq;

namespace HomeWorkThree
{
    public class HW_3_1
    {
        /// <summary>
        /// Read the text as a string value and culculate the counts of characters 'a', 'o', 'i', 'e' in this text.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Enter string value!");
            string value = Console.ReadLine();
            char[] charsToCount = { 'a', 'o', 'i', 'e' };

            int counter = value.Count(a => charsToCount.Contains(a));

            Console.WriteLine("Total number: {0}", counter);
            Console.ReadKey();
        }
    }
}
