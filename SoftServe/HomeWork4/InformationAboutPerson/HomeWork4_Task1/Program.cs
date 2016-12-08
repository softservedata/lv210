using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var personCount = 5;
            var persons = new List<Person>();

            for(int i = 0; i < personCount; i++)
            {
                persons.Add(Person.Input());
            }

            persons.ForEach(p => p.Output());

            persons.ForEach(p => p.ChangeName());

            Console.WriteLine();

            persons.ForEach(p => p.Output());

            Console.ReadKey();
        }
    }
}
