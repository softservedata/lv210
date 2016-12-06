using System;
using System.Collections.Generic;

namespace SumOrProductOfArray
{
    class Program
    {
        /// <summary>
        /// Enter 10 integer numbers. 
        /// Culculate the sum of first 5 elements if they are posetive 
        /// or product of last 5 element in  the other case.
        /// </summary>

        static void Main(string[] args)
        {
            Console.WriteLine("Input 10 integer numbers divided by space: ");
            string[] inputIntegerData = Console.ReadLine().Split(' ');

            int[] inputData = new int[inputIntegerData.Length];

            for (int i = 0; i < inputIntegerData.Length; i++)
            {
                inputData[i] = int.Parse(inputIntegerData[i]);
            }

            if (IsFirstFiveElementsPositive(inputData))
            {
                Console.WriteLine("Sum of first 5 elements : {0}", ArraySum(inputData));
            }
            else
            {
                Console.WriteLine("Product of last 5 elements : {0}", ArrayProduct(inputData));
            }

            Console.ReadKey();
        }

        private static bool IsFirstFiveElementsPositive(int[] inputData)
        {
            bool isPositive = true;

            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i] < 0)
                {
                    isPositive = false;
                    break;
                }
            }

            return isPositive;
        }

        private static int ArraySum(int[] inputData)
        {
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                sum += inputData[i];
            }

            return sum;
        }

        private static int ArrayProduct(int[] inputData)
        {
            int product = 1;

            for (int i = inputData.Length - 1; i >= 5; i--)
            {
                product *= inputData[i];
            }

            return product;
        }
    }
}
