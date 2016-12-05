using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leap_year
{
    /// <summary>
    /// Перевірити чи введений рік є високосним.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the year: ");
            int i = Convert.ToInt32(Console.ReadLine());
            bool b = i % 4 == 0;
            Console.WriteLine("-----------------------");
            Console.WriteLine("{0} is leap year: {1}", i, b);
        }
    }
}
