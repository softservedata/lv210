using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class IntegerNumbers
    {
        public static int findMin(int []numbers)
        {
            int min = numbers[0];
            for(int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min) min = numbers[i];
                            }
            return min;
        }

        public static int findMax(int[] numbers)
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
            int[] integerNumbers = new int[3];
            Console.WriteLine("Input 3 integer numbers.");
            for (int i = 0; i < integerNumbers.Length; i++)
            {
                Console.Write("Number[{0}]=",i+1);
                integerNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Maximal number={0}. Minimal number={1}", findMax(integerNumbers), findMin(integerNumbers));
            Console.ReadKey();
        }
    }
}
