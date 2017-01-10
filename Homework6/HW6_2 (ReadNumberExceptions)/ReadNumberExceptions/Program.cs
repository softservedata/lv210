using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadNumberExceptions
{
    public class Program
    {
        // Write a method ReadNumber(int start, int end), that reads from Console(or from file) integer number and return it, if it is in the range[start...end]. 
        // If an invalid number or non-number text is read, the method should throw an exception.
        // Using this method write a method Main(), that has to enter 10 numbers:
        // a1, a2, ..., a10, such that 1 < a1< ... < a10< 100

       public static double ReadNumber(double number, int start, int end)
        {
           if ((number >= start) && (number <= end))
            {
                return number;
            }
           else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static double IsEnteredNumber(string inputedData)
        {
            double readVariable;
            bool parseAtempt = double.TryParse(inputedData, out readVariable);

            if (!parseAtempt)
            {
                throw new FormatException("Please, input positive <int> number");
            }
            else
            {
                return readVariable;
            }
        }
            static void Main(string[] args)
        {
            Console.Write("Enter low boundary: ");
            int lowBound = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter hihg boundary: ");
            int highBound = Convert.ToInt32(Console.ReadLine());

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("Enter numbe {0}: ", i + 1);
                    double number = Convert.ToDouble(Console.ReadLine());
                    double result = ReadNumber(number, lowBound, highBound);
                    Console.WriteLine("Entered number {0} is in range [{1}, {2}]",result, lowBound, highBound);
                    Console.WriteLine();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
