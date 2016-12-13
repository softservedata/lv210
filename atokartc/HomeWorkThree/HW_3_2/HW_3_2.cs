using System;
using System.Linq;

namespace HomeWorkThree
{
    public class HW_3_2
    {
        /// <summary>
        /// Ask user to enter the number of month. Read the value and write the amount of days in this month. Year 2016; Using switch-case;
        /// </summary>
        public static int IsIntEntered()
        {
            int readedVar = 0;
            bool isIntEntered = int.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered && readedVar != 0)
            {
                return readedVar;
            }
            else
            {
                throw new FormatException("Please, enter integer");
            }
        }

        public static bool IsIntEnteredIntInRangeMonth(int month)
        {
            bool isIntEnteredIntinRangeMonth;

            if (Enumerable.Range(1, 12).Contains(month))
            {
                isIntEnteredIntinRangeMonth = true;
            }
            else
            {
                isIntEnteredIntinRangeMonth = false;
            }
            return isIntEnteredIntinRangeMonth;
        }

        private static void DaysInMonth()
        {
            Console.WriteLine("Enter month from 1 to 12");
            int month = IsIntEntered();

            if (IsIntEnteredIntInRangeMonth(month))
            {
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        Console.WriteLine("This month has: 31 day"); break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        Console.WriteLine("This month has: 30 days"); break;
                    case 2:
                        Console.WriteLine("This month has: 29 days"); break;
                }
            }
            else
            {
                Console.WriteLine("Please enter correct value!");
            }

            Console.ReadKey();
        }

        public static void Main()
        {
            DaysInMonth();
        }
    }
}
