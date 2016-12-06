using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOrProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 10 integer numbers:");

            int[] Arr = new int[10];

            for (int i = 0; i < Arr.Length; i++)
            {
                Console.Write("Enter {0} number: ", i + 1);
                Arr[i] = int.Parse(Console.ReadLine());
            }

            if (IsPositive(Arr, 5))
                Console.WriteLine("Sum of first 5 elements is {0}", Sum(Arr));
            else
                Console.WriteLine("Product of last 5 elements is {0}",Product(Arr));


            Console.ReadKey();
        }

        public static bool IsPositive(int[] Arr, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (Arr[i] <= 0) return false;
            }
            return true;
        }

        public static int Sum(int[] Arr)
        {
            int result = 0;
            for (int i = 0; i < 5; i++) result += Arr[i];
            return result;
        }

        public static int Product(int[] Arr)
        {
            int product = 1;
            for (int i = 5; i < Arr.Length; i++)
                product *= Arr[i];
            return product;
        }
    }
}
