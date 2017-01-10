using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            uint id;
            string name;
            int personNumber;
            uint wonderedNumber;
            Dictionary<uint, string> persons = new Dictionary<uint, string>();
            Console.Write("How much people will be entere? ");
            personNumber = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < personNumber; i++)
            {
                Console.Write("Enter person ID ");
                id = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Enter person name ");
                name = Console.ReadLine();
                persons.Add(id, name);
            }
            Console.Write("What person do you want to find? ");
            wonderedNumber= Convert.ToUInt32(Console.ReadLine());

            string nameForWonderedNumber;
            if (! persons.TryGetValue(wonderedNumber, out nameForWonderedNumber))
            {
                Console.WriteLine("Person with such number does not exist");
            }
            else
            {
                Console.WriteLine(persons[wonderedNumber]);
            }
            Console.ReadKey();
        }
    }
}

