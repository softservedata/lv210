using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("How old are you, {0}?", name);
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Person name is : {0} and age is : {1}", name, age);

            Console.ReadKey();
        }
    }
}
