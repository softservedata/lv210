using System;

namespace Pres2_Task2_2
{
    class Program
    {
        struct Date
        {
        public int day;
        public int month;
        public int year;
}
        static void Main(string[] args)
        {
            Date currentDate;
            currentDate.day =DateTime.Now.Day;
            currentDate.month = DateTime.Now.Month;
            currentDate.year = DateTime.Now.Year;
            Console.WriteLine("Current Date {0}.{1}.{2}", currentDate.day, currentDate.month, currentDate.year);
            Console.ReadKey();
        }
    }
}
