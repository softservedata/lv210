using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///<summary>Enter 10 integer numbers. 
//Calculate the sum of first 5 elements if they are posetive
//or product of last 5 element in  the other case.
///</summary>
namespace Task_C
{
   public class IntegerNumbers
    {
        //Check if elements are positive.
        //countOfElements - number of elements to be checked
        public static bool IsPositive(int[] array, int countOfElementsToCheck)
        {
            for (int i = 0; i < countOfElementsToCheck; i++)
            {
                if (array[i] <= 0) return false;
            }
            return true;
        }

        //Calculates sum of elements
        public static int CalcSumOfElements(int elementsToCalc, int[] array)
        {
            int sum = 0;
            for (int i = 0; i < elementsToCalc; i++) sum += array[i];
            return sum;
        }

        //Calculates product of elements
        public static int CalcLastElementsProduct(int endElement, int[] array)
        {
            int product = 1;
            for (int i = array.Length-1; i > endElement-1; i--) product *= array[i];
            return product;
        }

        //Reads string from console
        public static string Input()
        {
            string input = Console.ReadLine();
            return input;
        }

        //Converts string to  array of integer numbers
        public static int [] ConvertToIntegerArray(string  input)
        {
            string[] arrayToConvert=input.Split(',');
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {

                array[i] = Convert.ToInt32(arrayToConvert[i]);
            }

            return array;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Input 10 integer numbers:");
            string input = Input();
            int[] array = ConvertToIntegerArray(input);
            int numbersToCheck = 5;
            int result = 0;
            if (IsPositive(array, numbersToCheck))
            {
                result = CalcSumOfElements(numbersToCheck, array);
                Console.WriteLine("Sum of first 5 elements {0}", result);
            }
            else
            {
                result = CalcLastElementsProduct(numbersToCheck, array);
                Console.WriteLine("Product of last 5 elements {0}", result);
            }
            Console.ReadKey();
        }
    }
}
