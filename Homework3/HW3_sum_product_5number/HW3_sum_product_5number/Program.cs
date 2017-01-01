using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_sum_product_5number
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int product = 1;
            bool flag = false;
            int[] Array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter {0} numer:", i + 1);
                Array[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < 5; i++)
            {
                if (Array[i] >= 0)
                    sum += Array[i];
                else
                {
                    sum = 0;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                for (int i = 5; i < Array.Length; i++)
                {
                    product *= Array[i];
                }   
            }    
            if(!flag)      
                Console.WriteLine("Sum of numbers ={0}",sum);
            else
               Console.WriteLine("Product of numbers ={0}", product);
                Console.ReadKey();
        }
    }
}
