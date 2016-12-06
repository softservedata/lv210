using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name;
            int Age;

            Console.WriteLine("What is yor name?");
            Name = Console.ReadLine();

            Console.WriteLine("How old are you, {0}?", Name);
            Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Your name is: {0}; \nYour age is: {1};", Name, Age);

            Console.ReadKey();
        }
    }
}
