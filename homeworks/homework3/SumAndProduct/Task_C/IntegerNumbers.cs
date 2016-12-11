using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Enter 10 integer numbers. 
//Calculate the sum of first 5 elements if they are posetive
//or product of last 5 element in  the other case.
namespace Task_C
{
    class IntegerNumbers
    {
        //Check if elements are positive.
        //countOfElements - number of elements to be checked
        public static bool IsPositive(int[] array, int countOfElements)
        {
            for (int i = 0; i < countOfElements; i++)
            {
                if (array[i] <= 0) return false;
            }
            return true;
        }

        public static int CalcSumOfElements(int elementCount, int[] array)
        {

            int sum = 0;
            for (int i = 0; i < elementCount; i++) sum += array[i];
            return sum;
        }

        public static int CalcProductOfElements(int elementCount, int[] array)
        {
            int product = 1;
            for (int i = elementCount; i < array.Length; i++) product *= array[i];
            return product;
        }



        static void Main(string[] args)
        {

            Console.WriteLine("Input 10 integer numbers:");
            string[] input = Console.ReadLine().Split(',');
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {

                array[i] = Convert.ToInt32(input[i]);
            }
            int numbersToCheck = 5;
            if (IsPositive(array, numbersToCheck))
                Console.WriteLine("Sum of first 5 elements {0}", CalcSumOfElements(numbersToCheck, array));
            else
                Console.WriteLine("Product of last 5 elements {0}", CalcProductOfElements(numbersToCheck, array));
            Console.ReadKey();
        }
    }
}
