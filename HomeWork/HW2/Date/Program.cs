using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date
{
    class Program
    {
        struct Date
        {
            public int day;
            public int month;
            public int year;

            public void Print()
            {
                Console.WriteLine("Day is: {0}", day);
                Console.WriteLine("Month is: {0}", month);
                Console.WriteLine("Year is: {0}", year);
            }

            public bool Check()
            {
                if (day < 1 || day > 31) return false;
                if (month < 1 || month > 12) return false;
                return true;
            }
        }
        static void Main()
        {
            Date today;
            int temp;

            Console.Write("Enter day: ");
            today.day = int.Parse(Console.ReadLine());
            Console.Write("\nEnter month: ");
            today.month = int.Parse(Console.ReadLine());
            Console.Write("\nEnter year: ");
            today.year = int.Parse(Console.ReadLine());

            if(today.Check())
            today.Print();
            else
            {
                Console.WriteLine("Wrong data. Try again.");
                Main();
            }

            Console.ReadKey();

        }
    }
}
