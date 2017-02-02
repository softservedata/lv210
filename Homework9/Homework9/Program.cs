using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    // 1. Створити делегат, який отримує і повертає дійсне число.
    // 2. Створити метод Tabulation, який отримує цей делегат та два числа a, b, n  і 
    // видруковує значення делегату в точках: a+k*(b-a)/n, k=0,1,2,…n 
    // 3. Викликати метод Tabulation для табуляції функції sin(x), 2x^2+3x* cos(x^3);

    class Program
    {
        public delegate double TabDelegat(double x);

        static void Main(string[] args)
        {
            Console.WriteLine("\tResult for function SIN:");
            Tabulation(Math.Sin, 0, 15, 10);
            Console.WriteLine("\n\tResult for function 2x^2+3x* cos(x^3):");
            Tabulation(Function, 0, 10, 10);
            Console.ReadKey();
        }

        public static void Tabulation(TabDelegat del, double a, double b, int n)
        {
            for (int k = 0; k < n; k++)
            {
                double x;
                x = a + k * (b - a) / n;
                Console.WriteLine("Function in point {0} = {1}", x, del(x));
            }
        }

        public static double Function(double x)
        {
            return 2 * x * x + 3 * x * Math.Cos(x * x * x);
        }
    }
}
