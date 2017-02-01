using System;
using System.Collections;
using System.Collections.Generic;

namespace Tabulation
{
    class Program
    {
        public delegate double Func(double x);

        public static double ComplexFunc(double x)
        {
            return 2 * x * x + 3 * x * Math.Cos(x * x * x);
        }

        public static IDictionary<double, double> Tabulation(Func func, double a, double b, int n)
        {
            var result = new Dictionary<double, double>();

            for (var k = 0; k <= n; k++)
            {
                var x = a + (k * (b - a)) / n;
                result.Add(x, func(x));
            }

            return result;
        }

        public static void WriteToConsole(IDictionary<double, double> dictionary, string funcName)
        {
            Console.WriteLine($"Fuction {funcName}");
            foreach (var value in dictionary)
            {
                Console.WriteLine($"in point {value.Key} = {value.Value}");
            }
            Console.WriteLine(string.Empty);
        }

        static void Main(string[] args)
        {
            var tabulatedFunction = Tabulation(Math.Sin, 0, Math.PI, 10);
            WriteToConsole(tabulatedFunction, "sin");
            tabulatedFunction = Tabulation(ComplexFunc, 0, Math.PI, 10);
            WriteToConsole(tabulatedFunction, "2 * x * x + 3 * x * Math.Cos(x * x * x)");
            Console.ReadLine();
        }
    }
}