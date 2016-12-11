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
        public static bool IsPositive(int []array,int countOfElements)
        {
          for (int i=0; i< countOfElements; i++)
            {
                if (Array[i]<= 0)   return false;
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
            int[] Array = new int[10];
            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write("Number[{0}]=", i+1);
                Array[i] = Convert.ToInt32(Console.ReadLine());
            }
            int numbersToCheck=5;
            if (isPositive(Array,numbersToCheck))
                Console.WriteLine("Sum of first 5 elements {0}", CalcSumOfElements(numbersToCheck, Array));
            else
                Console.WriteLine("Product of last 5 elements {0}", CalcProductOfElements(numbersToCheck, Array));
            Console.ReadKey();
        }
    }
}
