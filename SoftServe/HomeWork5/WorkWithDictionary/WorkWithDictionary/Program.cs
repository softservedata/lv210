using System;
using System.Collections.Generic;

namespace WorkWithDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();

            dictionary = GetDictionaryFromConsole();
            GetValueFromDictionary(dictionary);

            Console.ReadKey();
        }

        private static Dictionary<uint, string> GetDictionaryFromConsole()
        {
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();

            Console.Write("Input amount of pairs in dictionary : ");
            var amountOfPairs = int.Parse(Console.ReadLine());

            Console.WriteLine("Input first value for ID (can't be < 1), second value for value (separate by space), than press enter : ");
            string[] inputData;

            for (int i = 0; i < amountOfPairs; i++)
            {
                inputData = Console.ReadLine().Split(' ');
                dictionary.Add(uint.Parse(inputData[0]), inputData[1]);
            }

            return dictionary;
        }

        private static void GetValueFromDictionary(Dictionary<uint, string> dictionary)
        {
            Console.Write("Input ID what you want : ");
            var id = uint.Parse(Console.ReadLine());

            string value;

            if (dictionary.TryGetValue(id, out value))
            {
                Console.WriteLine("Name for inputed ID is : {0}", value);
            }
            else
            {
                Console.WriteLine("Can't get value for this ID : {0}", id);
            }
        }
    }
}
