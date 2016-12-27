using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 50;
            int numberCount = 2;
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
