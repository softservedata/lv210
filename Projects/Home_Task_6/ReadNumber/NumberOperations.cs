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
        /// <summary>
        /// Read number from console and check if it's integer
        /// </summary>
        /// <returns></returns>
        public static int ReadNumber()
        {
            Console.Write("Enter number: ");
            string inputValue = Console.ReadLine();

            int number;

            if (!int.TryParse(inputValue, out number))
                throw new FormatException("It's not integer number!");

            return number;
        }

        /// <summary>
        /// Check whether the number is in a given range
        /// </summary>
        /// <param name="start">Lower bound of range</param>
        /// <param name="end">Upper bound of range</param>
        /// <param name="number">Number to find in range</param>
        /// <returns>True if number is in the range, if not - false</returns>
        public static bool IsInRange(int start, int end, int number)
        {
            if (start > end)
                throw new Exception("Incorrect range! Start bound should be less than End!");

            return (number >= start) && (number <= end);
        }

        /// <summary>
        /// Represent given list on console
        /// </summary>
        /// <param name="numbersList">Given list</param>
        public static void ConsoleDisplay(List<int> numbersList)
        {
            foreach (var number in numbersList)
            {
                Console.Write("{0} - ", number);
            }
        }
    }
}
