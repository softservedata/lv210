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
            Person[] arr = new Person[5];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Person.Input();
            }

            //Output results
            Console.Clear();
            Console.WriteLine("-----Information about Persons-----\n");
            foreach (Person p in arr)
            {
                p.ChangeName();
                p.Output();
            }



        }
    }
}
