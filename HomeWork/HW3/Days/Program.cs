using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] DaysOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            Console.Write("Enter month number: ");
            int num = int.Parse(Console.ReadLine());
            if (num >= 1 && num <= 12)
                Console.WriteLine("This month has {0} days", DaysOfMonth[num - 1]);
            else
                Console.WriteLine("Month number must be in range 1-12");

            Console.ReadKey();
        }
        
    }
}
