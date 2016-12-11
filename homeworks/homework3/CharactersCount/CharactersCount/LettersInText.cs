using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Read the text as a string value and calculate the counts
of characters 'a', 'o', 'i', 'e' in this text.*/
namespace CountOfCharacters
{
   
    class LettersInText
    { 
       //Find character count in string 
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
            char []letters = new char[] { 'a', 'o', 'i', 'e' };
            Console.WriteLine("Letter\tCount");
            for (int i=0;i<letters.Length;i++)
            {
                Console.WriteLine("{0}\t{1}", letters[i], FindCharacterCount(text, letters[i]));
            }
                Console.ReadKey();
        }
    }
}
