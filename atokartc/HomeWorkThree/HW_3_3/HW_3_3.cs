using System;

namespace HomeWorkThree
{
    public class MethodsForIntArr
    {
        /// <summary>
        /// Enter 10 integer numbers. Culculate the sum of first 5 elements if they are posetive or product of last 5 element in  the other case.
        /// </summary>
        public static bool IsPositiveInt(int[] arr, int arrCounter)
        {
            bool isPositive = true;

            for (int i = 0; i < arrCounter; i++)
            {
                if ((arr[i] <= 0))
                {
                    isPositive = false;
                    break;
                }
            }
            return isPositive;
        }


        public static int IntArrayElementsSum(int[] arr, int arrCounter)
        {
            int arrElemeSum = 0;


            for (int i = 0; i < arr[arrCounter]; i++)
            {
                arrElemeSum += arr[i];
            }
            return arrElemeSum;
        }


        public static int IntArrayElementsProduct(int[] arr, int arrCounter = 5)
        {
            int product = 1;


            for (int i = arr.Length - 1; i >= arrCounter; i--)
            {
                product *= arr[i];
            }
            return product;
        }
    }

    public class HW_3_3
    {
        public static void Main()
        {
            int[] arr = new int[10];
            bool isInt = true;

            Console.WriteLine("Enter 10 integers: ");
            for (int i = 0; i < arr.Length; i++)
            {
                isInt = int.TryParse(Console.ReadLine(), out arr[i]);


                if (isInt != true)
                {
                    Console.WriteLine("You didn't enter integer. All inputed values should be integers!");
                    isInt = false;
                }
            }

            int firstFivenumbsOfArr = 5;
            if (isInt)
            {
                if (MethodsForIntArr.IsPositiveInt(arr, firstFivenumbsOfArr))
                {
                    Console.WriteLine("First 5 integers are positive. Sum og first five integers are: {0}", 
                        MethodsForIntArr.IntArrayElementsSum(arr, firstFivenumbsOfArr));
                }
                else
                {
                    Console.WriteLine("One or few of first 5 integers are negative. Product of the last 5 elements are: {0}", 
                        MethodsForIntArr.IntArrayElementsProduct(arr, firstFivenumbsOfArr));
                }
            }
        }
    }
}

