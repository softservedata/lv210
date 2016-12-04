using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfCharacters
{
   
    class LettersInText
    {
        public static int findCharacterCount(string text, char letter)
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
            char []letters = new char[] { 'a', 'o', 'i', 'e' };
            Console.WriteLine("Letter\tCount");
            for (int i=0;i<letters.Length;i++)
            {
                Console.WriteLine("{0}\t{1}", letters[i], findCharacterCount(text, letters[i]));
            }
                Console.ReadKey();
        }
    }
}
