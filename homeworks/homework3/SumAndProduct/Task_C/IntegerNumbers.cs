using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    class IntegerNumbers
    {
        public static bool isPositive(int []Array,int countOfElements)
        {
            for(int i=0;i< countOfElements; i++)
            {
                if (Array[i]<= 0)   return false;
            }     
            return true;
        }

        public static int calcSumOfElements(int elementCount, int[] array)
        {
            
            int sum = 0;
            for (int i = 0; i < elementCount; i++) sum += array[i];
            return sum;
        }
        
        public static int calcProductOfElements(int elementCount, int[] array)
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
            if (isPositive(Array,5))
                Console.WriteLine("Sum of first 5 elements {0}", calcSumOfElements(5, Array));
            else
                Console.WriteLine("Product of last 5 elements {0}", calcProductOfElements(5, Array));
            Console.ReadKey();
        }
    }
}
