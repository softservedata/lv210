using System;
using System.Linq;

namespace HomeWorkThree
{
    public class HW_3_1
    {
        /// <summary>
        /// Read the text as a string value and culculate the counts of characters 'a', 'o', 'i', 'e' in this text.
        /// </summary>
        class LettersInText
        {
            public static int FindCharacterCount(string text, char letter)
            {
                int count = 0;

                foreach (char symbol in text)
                {
                    if (symbol == letter) count++;
                }

                return count;
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Input string:");
                string text = Console.ReadLine();
                char[] letters = new char[] { 'a', 'o', 'i', 'e' };

                Console.WriteLine("Letter\tCount");

                for (int i = 0; i < letters.Length; i++)
                {
                    Console.WriteLine("{0}\t{1}", letters[i], FindCharacterCount(text, letters[i]));
                }

                Console.ReadKey();
            }
        }
    }
}
