using System;

namespace DaysInMonth
{
    class Program
    {
        /// <summary>
        /// Ask user to enter the number of mounth. 
        /// Read the value and write the amount of days in this mounth. 
        /// </summary>

        static void Main(string[] args)
        {
            Console.Write("Input year : ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Input number of month : ");
            int month = int.Parse(Console.ReadLine());

            int days = DateTime.DaysInMonth(year, month);

            Console.WriteLine("Year : {0}, month : {1}, amount of days in this month : {2}", year, month, days);

            Console.ReadKey();
        }
    }
}
