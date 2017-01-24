using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    public class Application
    {
        static void Main(string[] args)
        {
            Tabulator.Tabulate(Math.Sin, -1, 1, 7);
            Tabulator.Tabulate(MathCustomFunctions.TrygonometricFunction, -1, 1, 7);
            Console.ReadKey();
        }
    }
}
