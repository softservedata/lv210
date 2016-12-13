using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Ask user to enter the number of mounth.
Read the value and write the amount of days in this mounth.*/
namespace DaysInMonthApp
{
    public class DaysOfMonth
    {
        //check if entered number of month is in range 1-12.
        public static bool IsMonth(int monthNumber)
        {
            
            return (monthNumber <= 12 && monthNumber > 0);
        }

        //returns count of days in month
        public static int CountDaysInMonth(int monthNumber)
        {
            if (!IsMonth(monthNumber)) return -1;
            return DateTime.DaysInMonth(DateTime.Now.Year, monthNumber);
        }
        static void Main(string[] args)
        {
           
            Console.Write("Input month number:");
            int monthNumber = Convert.ToInt32(Console.ReadLine());
            if (!IsMonth(monthNumber))
                Console.WriteLine("Month number must be in range 1-12");
            else
                Console.WriteLine("Month {0} has {1} days", monthNumber,CountDaysInMonth(monthNumber));

            Console.ReadKey();

        }

    }
}
