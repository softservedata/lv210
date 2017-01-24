using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate double FunctionDelegate(double value);
    class Tabulate
    {
        public Dictionary<double, double> Tabulation(FunctionDelegate method, double a, double b, uint n)
        {
            Dictionary<double, double> tabulationResult = new Dictionary<double, double>();

            for (int k = 0; k <= n; k++)
            {
                var x = a + k * (b - a) / n;
                var y = method(x);

                tabulationResult.Add(x, y);
            }

            return tabulationResult;
        }
    }
}
