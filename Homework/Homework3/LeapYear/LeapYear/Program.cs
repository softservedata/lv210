using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapYear
{
    /*
        Current program has to inform whether
        the inputed year is leap.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the year you want to learn information about:");
            var input_year = Console.ReadLine();

            int year;

            bool isInputYearValid = int.TryParse(input_year, out year);
            bool isYearValid = year > 0;

            if (isInputYearValid && isYearValid)
            {
                if (DateTime.IsLeapYear(year)) Console.WriteLine("\nYear {0} is leap", year);
                else Console.WriteLine("\nYear {0} is not leap", year);
            }
            else
            {
                Console.WriteLine("\nIncorrect value!\n");
            }

            Console.ReadLine();
        }
    }
}
