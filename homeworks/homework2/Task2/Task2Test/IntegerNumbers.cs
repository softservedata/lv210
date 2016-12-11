using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class IntegerNumbers
    {
        public static int FindMin(int[] numbers)
        {
            int min = numbers[0];
            for(int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min) min = numbers[i];
                            }
            return min;
        }

        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max) max = numbers[i];
            }
            return max;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input 3 integer numbers.Use ',' as delimiter");
            string[] input = Console.ReadLine().Split(',');
            int[] integerNumbers = new int[3];
            for (int i = 0; i < integerNumbers.Length; i++)
            {
                  integerNumbers[i] = Convert.ToInt32(input[i]);
            }

            int min = FindMin(integerNumbers);
            int max = FindMax(integerNumbers);
            Console.WriteLine("Maximal number={0}. Minimal number={1}", max, min);
            Console.ReadKey();
        }
    }
}
