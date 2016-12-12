using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pres3_int_div3
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            Console.Write("Enter number 1: ");
            int a=Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number 2: ");
            int b = Convert.ToInt32(Console.ReadLine());
            for (int i=a; i<=b; i++)
            {

                if (i % 3 == 0)
                {
                    k = k+1;
                }
                Console.WriteLine("i={0}", i);
                Console.WriteLine("k={0}", k);

            }
            Console.WriteLine("Quantity of number= {0}", k);
            Console.ReadKey();

        }
    }
}
