using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadNumbers
{
    /// <summary>
    /// Write a method ReadNumber(int start, int end), that reads from Console (or from file) integer number 
    /// and return it, if it is in the range [start...end]. 
    /// If an invalid number or non-number text is read, the method should throw an exception.
    /// Using this method write a method Main(), that has to enter 10 numbers
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 50;
            int numberCount = 10;
            List<int> integerNumbers = new List<int>();

            try
            {
                for (int i = 0; i < numberCount; i++)
                {
                    int number = NumberOperations.ReadNumber();

                    if (NumberOperations.IsInRange(start, end, number))
                        integerNumbers.Add(number);
                }
            }

            catch (FormatException exception)
            {
                Console.Error.WriteLine(exception.Message);
            }

            catch (Exception exception)
            {
                Console.Error.WriteLine(exception.Message);
            }

            Console.WriteLine($"\nNumbers in range [{start};{end}]");
            NumberOperations.ConsoleDisplay(integerNumbers);
        }
    }
}
