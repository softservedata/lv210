using System;
using System.Collections;
using System.Collections.Generic;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary dictionary = new Dictionary<uint, string>();

            dictionary.Add(1u, "Roman");
            dictionary.Add(2u, "Andrii");
            dictionary.Add(3u, "Ihor");

            Console.WriteLine("Please enter id:");
            uint id = uint.Parse(Console.ReadLine());
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
