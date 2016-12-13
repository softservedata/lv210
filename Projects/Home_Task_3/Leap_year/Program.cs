using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leap_year
{
    /// <summary>
    /// Check if entered year is leap or not.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            bool isLeap = IsLeapYear(year);
            Console.WriteLine("{0} is leap year: {1}", year, isLeap);
        }

        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0);
        }
    }
}
