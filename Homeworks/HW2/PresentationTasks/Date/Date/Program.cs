using System;

namespace Date
{
    struct Date
    {
        public int Day;
        public string Month;
        public int Year;

        public void toString()
        {
            Console.WriteLine("Today is {0} {1} {2}", Day, Month, Year);
        } 
    };
    class Program
    {
        static void Main(string[] args)
        {
            Date today = new Date();
            today.Day = 1;
            today.Month = "December";
            today.Year = 2016;
            today.toString();
            Console.ReadLine();
        }
    }
}
