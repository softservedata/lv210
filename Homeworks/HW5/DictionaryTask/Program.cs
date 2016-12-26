using System;
using System.Collections.Generic;

namespace DictionaryTask
{
    public class Program
    {
        public static int ParseAtempt(string inputedData)
        {
            int readVariable;
            bool parseAtempt = int.TryParse(inputedData, out readVariable);
            if (parseAtempt && readVariable > 0)
            {
                return readVariable;
            }
            else
            {
                throw new FormatException("Please, input positive <int> number for ID");
            }
        }

        private static Dictionary<uint, string> InputDictionaryValues()
        {
            Dictionary<uint, string> personsDictionary = new Dictionary<uint, string>();
            Console.Write("Input dictionary size: ");
            int pairsCount =  ParseAtempt(Console.ReadLine());

            Console.WriteLine("Input pairs of ID and string value devided by space: ");
            string[] inputedData;

            for (int i = 0; i < pairsCount; i++)
            {
                inputedData = Console.ReadLine().Split(' ');
                personsDictionary.Add((uint)ParseAtempt(inputedData[0]), inputedData[1]);
            }

            return personsDictionary;
        }

        private static void FindValueInDictionaty(Dictionary<uint, string> personsDictionary)
        {
            Console.Write("Input ID: ");
            var findId = (uint)ParseAtempt(Console.ReadLine());

            string personName;

            if (personsDictionary.TryGetValue(findId, out personName))
            {
                Console.WriteLine("Person that you asking for is {0}", personName);
            }
            else
            {
                Console.WriteLine("There is no person in dictionary with such id");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                FindValueInDictionaty(InputDictionaryValues());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
