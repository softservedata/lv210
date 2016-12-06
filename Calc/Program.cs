using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Numeric
    {

        public double add(double arg0, double arg1)
        {
            return arg0 + arg0;
        }

        public double div(double arg0, double arg1)
        {
            return arg0 / arg1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Numeric numeric = new Numeric();
            double arg0;
            double arg1;
            //
            Console.Write("arg0 = ");
            Double.TryParse(Console.ReadLine(), out arg0);
            //
            Console.Write("arg0 = ");
            Double.TryParse(Console.ReadLine(), out arg1);
            //
            Console.WriteLine("arg0 + arg1 = " + numeric.add(arg0, arg1));
            Console.WriteLine("arg0 / arg1 = " + numeric.div(arg0, arg1));
        }
    }
}
