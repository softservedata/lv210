using System;

namespace DaysInMonth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input number of month:");
            int monthNumber = Convert.ToInt32((Console.ReadLine()));
            int daysCount = DateTime.DaysInMonth(2016, monthNumber);
            Console.WriteLine("Amount of days in this month: {0}", daysCount);
            Console.ReadLine();
        }
    }
}
