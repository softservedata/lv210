using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCompare
{
    public class Methods
    {
        public static bool Compare(int a, int b)
        {
            if (Math.Abs(a % 2) == Math.Abs(b % 2))
                return true;
            else
                return false;
        }
    }
}
