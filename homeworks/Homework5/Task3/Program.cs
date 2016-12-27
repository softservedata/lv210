using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3
{
    public class Program
    {
        private static Dictionary<uint, string> ConsoleInput(int counOfElements)
        {
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();

            Console.WriteLine("Input id and name.");
            string[] input;
            try
            {
                for (int i = 0; i < counOfElements; i++)
                {
                    input = Console.ReadLine().Split(new char[] {' ', ','});
                    dictionary.Add(uint.Parse(input[0]), input[1]);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect format of data");
            }

            return dictionary;
        }

        static void Main(string[] args)
        {
            IDictionary dictionary = ConsoleInput(7);

            Console.WriteLine("Please enter id:");
            string input = Console.ReadLine();
            uint id = 0;
            try
            {
                id = uint.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Id must be unsigned integer number");
            }

            if (!dictionary.Contains(id))
            {
                Console.WriteLine("Person with such id can't be found");
            }
            else
            {
                Console.WriteLine("name: {0}", dictionary[id]);
            }

            Console.ReadKey();
        }
    }
}
