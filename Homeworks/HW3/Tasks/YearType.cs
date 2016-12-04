using System;

namespace YearType
{
    class Program
    {
        static void Main(string[] args)
        {
            int year;
            Console.WriteLine("Input year:");
            year = Convert.ToInt32(Console.ReadLine());
            if (DateTime.IsLeapYear(year))
                Console.WriteLine("Year is leap");
            else
                Console.WriteLine("Year is not leap");
            Console.ReadLine();
        }
    }
}
