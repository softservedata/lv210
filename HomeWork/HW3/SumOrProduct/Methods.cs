using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOrProduct
{
    public class Methods
    {
        public static bool IsPositive(int[] Arr, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (Arr[i] <= 0) return false;
            }
            return true;
        }
        public static int Sum(int[] Arr, int count)
        {
            int result = 0;
            for (int i = 0; i < count; i++)
            {
                result += Arr[i];
            }
            return result;
        }
        public static int Product(int[] Arr, int count)
        {
            int product = 1;
            for (int i = count; i < Arr.Length; i++)
            {
                product *= Arr[i];
            }
            return product;
        }
    }
}
