using System;
using System.Collections.Generic;

namespace ExceptionsTask
{
    public class Program
    {
        public const int start = 1;
        public const int end = 100;

        public static bool IsValueInRange(int start, int end, int value)
        {
            return (value >= start) && (value <= end);
        }

        public static int ReadNumber(string inputedData)
        {
            int readVariable;
            bool parseAtempt = int.TryParse(inputedData, out readVariable);
            if (!parseAtempt)
            {
                throw new FormatException("Please, input positive <int> number");
            }
            if (!IsValueInRange(start, end, readVariable))
            {
                throw new ArgumentOutOfRangeException();
            }
            return readVariable;
        }

        static void Main(string[] args)
        {
            int numberCount = 10;
            List<int> valuesList = new List<int>();
            Console.WriteLine("Input 10 int number in range of [0, 100]");
            try
            {
                for (int i = 0; i < numberCount; i++)
                {
                    valuesList.Add(ReadNumber(Console.ReadLine()));
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
