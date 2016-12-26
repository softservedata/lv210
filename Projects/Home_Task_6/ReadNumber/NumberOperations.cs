using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadNumbers
{
    class NumberOperations
    {
        public static int ReadNumber()
        {
            Console.Write("Enter number: ");
            string inputValue = Console.ReadLine();

            int number;

            if (!int.TryParse(inputValue, out number))
                throw new FormatException("It's not integer number!");

            return number;
        }

        public static bool IsInRange(int start, int end, int number)
        {
            if (start > end)
                throw new Exception("Incorrect range! Start bound should be less than End!");

            return (number >= start) && (number <= end);
        }

        public static void ConsoleDisplay(List<int> numbersList)
        {
            foreach (var number in numbersList)
            {
                Console.Write("{0} - ", number);
            }
        }
    }
}
