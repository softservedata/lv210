using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pres2_Task2_1
{

    class Program
    {
        enum Colors { Red, Blue, Green, Yellow };
        static void Main(string[] args)
        {
            Colors myColor = Colors.Red;
            Console.WriteLine("My favourite color is {0}.", myColor);
            Console.ReadKey();
        }
    }
}
