using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Enter the length of square: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Perimetr is {0}; \nSquare is {1};", a*4, a * a);

            Console.ReadKey();

        }
    }
}
