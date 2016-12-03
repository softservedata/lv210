using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCountOfAppropriateSymbols
{
    using AppropriateFunctions;
    class Program
    {
        static void Main(string[] args)
        {
            char[] char_collection = { 'a', 'o', 'i', 'e' };

            Console.WriteLine("Please, enter some string:");

            var input = Console.ReadLine();

            Console.WriteLine("\nCount of characters 'a', 'o', 'i', 'e' in current string is {0}.", Functions.FindCountOfSomeCharactersInString(input, char_collection));

            Console.ReadLine();
        }
    }
}
