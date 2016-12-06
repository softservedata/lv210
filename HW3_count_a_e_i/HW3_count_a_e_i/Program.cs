using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_count_a_e_i
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text=Console.ReadLine();
            int countOfA=0, countOfE=0, countOfO=0, countOfI = 0;
            foreach (char symbol in text)
            {
                if (symbol == Convert.ToChar("a"))
                {
                    countOfA += 1;
                }
                if (symbol == Convert.ToChar("e"))
                {
                    countOfE += 1;
                }
                if (symbol == Convert.ToChar("o"))
                {
                    countOfO += 1;
                }
                if (symbol == Convert.ToChar("i"))
                {
                    countOfI += 1;
                }
            }
            Console.WriteLine("Count of A = {0}",countOfA);
            Console.WriteLine("Count of E = {0}", countOfE);
            Console.WriteLine("Count of O = {0}", countOfO);
            Console.WriteLine("Count of I = {0}", countOfI);
            Console.ReadKey();
        }
    }
}
