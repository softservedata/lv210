using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysInMonth
{
    class Program
    {
        public static bool isMonth(int MonthNumber)
        {
            //if (MonthNumber > 12 || MonthNumber <= 0) return false;
            return (MonthNumber <= 12 && MonthNumber > 0);
        }
        
        static void Main(string[] args)
        {
            int []DaysPerMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Console.Write("Input month number:");
            int MonthNumber = Convert.ToInt32(Console.ReadLine());
            if (!isMonth(MonthNumber)) Console.WriteLine("Month number must be in range 1-12");
            else Console.WriteLine("Month {0} has {1} days", MonthNumber,DaysPerMonth[MonthNumber-1]);
            Console.ReadKey();

        }

    }
}
