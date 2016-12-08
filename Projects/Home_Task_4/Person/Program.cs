using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating collection of persons
            int numbberOfPersons = 3;
            Person[] arr = new Person[numbberOfPersons];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Person.Input();
                arr[i].ChangeName();
            }

            //Output results
            Console.Clear();

            foreach (Person p in arr)
            {
                p.Output();
            }
        }
    }
}
