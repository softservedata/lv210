using System;

namespace FunctionsWithArray
{
    public class Functions
    {
        public static int SumOfFirstElements(int[] array, int count)
        {
            int suma = 0;
            for(int i =0; i<count; i++)
            {
                suma += array[i];
            }
            return suma;
        }

        public static int ProductOfLastElements(int[] array, int count)
        {
            int product = 1;
            for (int i = array.Length - 1; i >= count; i--)
            {
                product *= array[i];
            }
            return product;
        }

        public static bool ArePositive(int [] array, int count)
        {
            bool arePositive = true;
            for(int i =0; i<count; i++)
            {
                if (array[i] <= 0)
                {
                    arePositive = false;
                    break;
                }
            }
            return arePositive;
        }
    }
}