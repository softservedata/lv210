using System;
using System.Collections.Generic;

namespace DictionaryTask
{
    class Program
    {
        static List<string> ReadPerson()
        {
            var listOfData = new List<string>();

            Console.WriteLine("Input person's data:\n");
            Console.Write("ID: ");
            listOfData.Add(Console.ReadLine());
            Console.Write("Name: ");
            listOfData.Add(Console.ReadLine());
            Console.WriteLine();

            return listOfData;
        }

        static void PrintPerson(Dictionary<uint, string> person, uint id)
        {
            if (person.ContainsKey(id))
            {
                Console.WriteLine("\nPerson's data: \n");
                Console.WriteLine("ID: {0}", id);
                Console.WriteLine("Name: {0}", person[id]);
            }
            else
            {
                Console.WriteLine("\nThere is no person with such ID!");
            }

        }

        static void FindPerson(Dictionary<uint, string> person)
        {
            Console.Write("Please, enter ID of the person you want to find: ");
            var testId = Console.ReadLine();
            var id = uint.Parse(testId);
            PrintPerson(person, id);
        }

        static Dictionary<uint, string> ReadAllPersons(int count)
        {
            var person = new Dictionary<uint, string>();

            for (var i = 0; i < count; i++)
            {
                var dataAboutPerson = ReadPerson();
                var id = uint.Parse(dataAboutPerson[0]);

                if (person.ContainsKey(id))
                {
                    throw new ArgumentException($"Person with such id - {id} already exists!");
                }

                person.Add(id, dataAboutPerson[1]);
            }

            return person;
        }

        static void Main(string[] args)
        {
            try
            {
                const int count = 7;
                var person = ReadAllPersons(count);

                FindPerson(person);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
