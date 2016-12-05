using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_Float
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Task #1
            //// Read 3 float numbers and check: are they all belong to the range [-5,5]
            float a, b, c;
            Console.Write("Entert first number: ");
            a = Convert.ToSingle(Console.ReadLine());
            Console.Write("Entert second number: ");
            b = Convert.ToSingle(Console.ReadLine());
            Console.Write("Entert third number: ");
            c = Convert.ToSingle(Console.ReadLine());

            string res = ((a >= -5 && a <= 5) && (b >= -5 && b <= 5) && (c >= -5 && c <= 5)) ? "true":"false";
            Console.WriteLine("All numbers belong to range [-5;5]: " + res);

        }
    }
}
