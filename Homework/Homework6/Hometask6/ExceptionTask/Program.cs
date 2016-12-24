using System;
using System.Collections.Generic;

namespace ExceptionTask
{
    internal class Program
    {
        public const double Start = 1;
        public const double End = 100;
        public const int Count = 10;

        private static bool IsInRange(double start, double end, double value)
        {
            return ((value >= start) && (value <= end));
        }

        private static double ReadNumber()
        {
            Console.Write("Number = ");
            var value = Console.ReadLine();

            double number;
            var isParsed = double.TryParse(value, out number);

            if (!isParsed)
            {
                throw new FormatException($"Can not convert {value} to <double>!");
            }

            if (!IsInRange(Start, End, number))
            {
                throw new ArgumentOutOfRangeException($"Number {number} is not in expected range [{Start},{End}]!");
            }

            return number;
        }

        private static void PrintList<T>(IEnumerable<T> list)
        {
            Console.WriteLine("\nList:");

            foreach (var value in list)
            {
                Console.Write($"{value} ");
            }
        }

        private static void Main()
        {
            Console.WriteLine($"Please, enter {Count} numbers:\n");
            var listOfNumbers = new List<double>();

            try
            {
                for (var i = 0; i < Count; i++)
                {
                    listOfNumbers.Add(ReadNumber());
                }

                PrintList(listOfNumbers);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}