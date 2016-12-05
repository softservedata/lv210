using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_age
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            Console.Write("How old are you, "+name+" ? ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine(name+" is "+age);
        }
    }
}
