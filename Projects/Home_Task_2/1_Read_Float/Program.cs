using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_Float
{
    /// <summary>
    /// Read 3 float numbers and check: are they all belong to the range [-5,5]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Initialization of variables
            float a, b, c;

            //Reading of values
            Console.Write("Entert first number: ");
            a = Convert.ToSingle(Console.ReadLine());

            Console.Write("Entert second number: ");
            b = Convert.ToSingle(Console.ReadLine());

            Console.Write("Entert third number: ");
            c = Convert.ToSingle(Console.ReadLine());

            //Checking conditions
            bool res = (a >= -5 && a <= 5) && (b >= -5 && b <= 5) && (c >= -5 && c <= 5);

            //Result print
            Console.WriteLine("------------------------");
            Console.WriteLine("All numbers belong to range [-5;5]: {0}", res);

        }
    }
}
