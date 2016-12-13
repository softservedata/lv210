using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Enter 10 integer numbers. 
Culculate the sum of first 5 elements if they are posetive or product of last 5 element in  the other case.
*/

namespace SumOrProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 10 integer numbers:");

            int[] Arr = new int[10];
            int count = 5;

            for (int i = 0; i < Arr.Length; i++)
            {
                Console.Write("Enter {0} number: ", i + 1);
                Arr[i] = int.Parse(Console.ReadLine());
            }

            if (Methods.IsPositive(Arr, 5))
            {
                Console.WriteLine("Sum of first 5 elements is {0}", Methods.Sum(Arr, count));
            }
            else
            {
                Console.WriteLine("Product of last 5 elements is {0}", Methods.Product(Arr, count));
            }

            Console.ReadKey();
        }

      
    }
}
