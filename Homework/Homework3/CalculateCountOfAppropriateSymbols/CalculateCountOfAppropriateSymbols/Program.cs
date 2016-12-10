using System;

namespace CalculateCountOfAppropriateSymbols
{
    ///<summary>
    ///This program finds count of some symbols in entered string.
    /// </summary>
    
    class Program
    {
        static void Main(string[] args)
        {
            char[] charCollection = { 'a', 'o', 'i', 'e' };

            Console.WriteLine("Please, enter some string:");

            var input = Console.ReadLine();
            var countOfCharacters = input.FindCountOf(charCollection);

            Console.WriteLine("\nCount of characters 'a', 'o', 'i', 'e' in current string is {0}.", countOfCharacters);

            Console.ReadLine();
        }
    }
}
