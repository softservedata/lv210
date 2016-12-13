using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullHomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a: ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Perimetr is: {0} \nSquare is: {1}", Methods.Perimetr(a), Methods.Square(a));
            Console.ReadKey();
        }
    }
}
