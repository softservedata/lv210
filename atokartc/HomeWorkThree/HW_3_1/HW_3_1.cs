using System;
using System.Linq;

namespace HomeWorkThree
{
    public class HW_3_1
    {
        /// <summary>
        /// Read the text as a string value and culculate the counts of characters 'a', 'o', 'i', 'e' in this text.
        /// </summary>
        class Program
        {
            public int CharElementCount(string text, char symbolToCount)
            {
                int symbolCounter = 0;
                foreach (char symbol in text)
                {
                    if (symbol == symbolToCount)
                    {
                        symbolCounter += 1;
                    }
                }
                return symbolCounter;
            }

            static void Main(string[] args)
            {
                Program program = new Program();

                Console.Write("Enter text: ");
                string text = Console.ReadLine().ToLower();

                char symbolToCountA = 'a';
                char symbolToCountO = 'o';
                char symbolToCountI = 'i';
                char symbolToCountE = 'e';

                int countOfA = program.CharElementCount(text, symbolToCountA);
                int countOfO = program.CharElementCount(text, symbolToCountO);
                int countOfI = program.CharElementCount(text, symbolToCountI);
                int countOfE = program.CharElementCount(text, symbolToCountE);

                Console.WriteLine("Count of A = {0}", countOfA);
                Console.WriteLine("Count of E = {0}", countOfE);
                Console.WriteLine("Count of O = {0}", countOfO);
                Console.WriteLine("Count of I = {0}", countOfI);
                Console.ReadKey();
            }
        }
    }
}