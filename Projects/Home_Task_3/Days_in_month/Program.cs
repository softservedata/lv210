using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days_in_month
{
    /// <summary>
    /// Ask user to enter the number of mounth. Read the value and write the amount of days in this mounth.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of month: ");
            int numberOfMonth;
            Int32.TryParse(Console.ReadLine(), out numberOfMonth);

            NumberOfDaysInMonth(numberOfMonth);
        }

        static void NumberOfDaysInMonth(int numberOfMonth)
        {
            switch (numberOfMonth)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("In this month are 31 days");
                    break;

                case 2:
                    Console.WriteLine("In this month are 28 days during most years and 29 days during leap years.");
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("In this month are 30 days");
                    break;

                default:
                    Console.WriteLine("Incorrect number of month!");
                    break;
            }
        }
    }
}
