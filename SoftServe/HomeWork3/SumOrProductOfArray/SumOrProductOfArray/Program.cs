using System;

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

            if (IsFirstFiveElementsPositive(inputIntegerData))
            {
                Console.WriteLine("Sum of first 5 elements : {0}", ArraySum(inputIntegerData));
            }
            else
            {
                Console.WriteLine("Product of last 5 elements : {0}", ArrayProduct(inputIntegerData));
            }

            Console.ReadKey();
        }

        private static bool IsFirstFiveElementsPositive(string[] inputData)
        {
            int[] positiveArray = new int[5];
            bool isPositive = true;

            for (int i = 0; i < positiveArray.Length; i++)
            {
                positiveArray[i] = int.Parse(inputData[i]);
                if (positiveArray[i] <= 0)
                {
                    isPositive = false;
                    break;
                }
            }
            
            return isPositive;
        }

        private static int ArraySum(string[] inputData)
        {
            int[] sumOfArray = new int[5];
            int sum = 0;

            for (int i = 0; i < sumOfArray.Length; i++)
            {
                sumOfArray[i] = int.Parse(inputData[i]);
                sum += sumOfArray[i]; 
            }
            return sum;
        }

        private static int ArrayProduct(string[] inputData)
        {
            int[] productOfArray = new int[5];
            int product = 1;

            for (int i = 0; i < productOfArray.Length; i++)
            {
                productOfArray[i] = int.Parse(inputData[productOfArray.Length + i]);
                product *= productOfArray[i]; 
            }

            return product;
        }
    }
}
