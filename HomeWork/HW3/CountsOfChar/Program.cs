using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountsOfChar
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] characters = { 'a', 'o', 'i', 'e' };

            Console.Write("Enter the text: ");
            string text = Console.ReadLine();
            Console.WriteLine("There are {0} characteres", Count(characters, text));

            Console.ReadKey();
            
        }

        static int Count(char[] characters, string text)
        {
            char[] temp = text.ToCharArray();
            int count = 0;

            foreach(char ch in characters)
            {
                for (int i = 0; i < temp.Length; i++)
                    if (ch == temp[i])
                        count++;

            }

            return count;
        }
    }
}
