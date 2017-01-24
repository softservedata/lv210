using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Functions
    {
        public double SinFunc(double x)
        {
            return Math.Sin(x);
        }

        public double CosFunc(double x)
        {
            return 2 * x * x + 3 * x * Math.Cos(x * x * x);
        }
    }
}
