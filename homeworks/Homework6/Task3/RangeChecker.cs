using System;
using System.Collections.Generic;


namespace Task3
{
    /// <summary>
    /// Write a method ReadNumber(int start, int end), that reads from Console (or from file) integer number and return it, if it is in the range [start...end]. 
    /// If an invalid number or non-number text is read, the method should throw an exception.
    /// Using this method write a method Main(), that has to enter 10 numbers:
    /// a1, a2, ..., a10, such that [1,a1,...,a10,100]
    /// </summary>
    class RangeChecker
    {
        public static int ReadNumber(int start, int end)
        {
            Console.WriteLine("Enter integer number");
            string input = Console.ReadLine();
            int number;

            if (!int.TryParse(input, out number))
            {
                throw new FormatException("Not a number");
            }

            if (!IsInRange(start, end, number))
            {
                throw new ArgumentOutOfRangeException("Number is out of range");
            }

            return number;
        }

        public static bool IsInRange(int start, int end, int number)
        {
            if (start > end)
            {
                throw new ArgumentException("Lower bound can not be greater than upper");
            }

            return (number >= start && number <= end);
        }

        static void Main(string[] args)
        {
            int leftBound = 0;
            int rightBound = 100;
            int numbersCount = 10;
            List<int> numbers = new List<int>();

            try
            {
                numbers.Add(ReadNumber(leftBound, rightBound));
                for (int i = 0; i < numbersCount - 1; i++)
                {
                    numbers.Add(ReadNumber(numbers[i], rightBound));
                }
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex.Message);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            finally
            {
                Console.WriteLine("Numbers in range [{0},{1}]", leftBound, rightBound);
                foreach (int number in numbers)
                {
                    Console.Write("{0}, ", number);
                }
            }

            Console.ReadKey();
        }
    }
}
