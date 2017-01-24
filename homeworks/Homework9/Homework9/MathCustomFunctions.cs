using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    public class MathCustomFunctions
    {
        public static double TrygonometricFunction(double x)
        {
            return 2 * Math.Pow(x, 2) + 3 * x * Math.Cos(Math.Pow(x, 3));
        }
    }
}
