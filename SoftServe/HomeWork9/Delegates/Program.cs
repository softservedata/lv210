using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    /// <summary>
    /// 1. Створити делегат, який отримує і повертає дійсне число.
    /// 2. Створити метод Tabulation, який отримує цей делегат та два числа a, b, n  і видруковує значення делегату в точках: a+k*(b-a)/n, k=0,1,2,…n 
    /// 3. Викликати метод Tabulation для табуляції функції sin(x), 2x^2+3x* cos(x^3);
    /// </summary>
    class Program
    {
        private const double START_POINT = 1;
        private const double END_POINT = 5;
        private const int STEPS_COUNT = 5;

        static void Main(string[] args)
        {
            Tabulate tabulate = new Tabulate();
            Functions functions = new Functions();
            Dictionary<double, double> tabulationResult = new Dictionary<double, double>();

            FunctionDelegate sinFunc = functions.SinFunc;
            tabulationResult = tabulate.Tabulation(sinFunc, START_POINT, END_POINT, STEPS_COUNT);
            DisplayDictionaryOnConsole(tabulationResult);
            Console.WriteLine();

            FunctionDelegate cosFunc = functions.CosFunc;
            tabulationResult = tabulate.Tabulation(cosFunc, START_POINT, END_POINT, STEPS_COUNT);
            DisplayDictionaryOnConsole(tabulationResult);
            Console.WriteLine();

            Console.ReadKey();
        }

        private static void DisplayDictionaryOnConsole(Dictionary<double, double> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine("F({0}) = {1}", item.Key, item.Value);
            }
        }
    }
}
