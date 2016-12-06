using System;
using System.Linq;

namespace HomeWorkThree
{
    public class HW_3_2
    {
        /// <summary>
        /// Ask user to enter the number of month. Read the value and write the amount of days in this month. Year 2016; Using switch-case;
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Enter month from 1 to 12");
            int month = Convert.ToInt32(Console.ReadLine());

            if (Enumerable.Range(1, 12).Contains(month))
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
                Main();
            }
            Console.ReadKey();
        }
    }
}
