using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten_int_numb
{
    /// <summary>
    /// Enter 10 integer numbers. 
    /// Culculate the sum of first 5 elements if they are posetive or product of last 5 element in  the other case.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            bool flag = true;
            int sum = 0, prod = 1;
            int[] arr1 = new int[5];
            int[] arr2 = new int[5];

            //Entering elements
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter {0} number: ", i + 1);

                //For first 5 elements
                if (i < 5)
                {
                    arr1[i] = Convert.ToInt32(Console.ReadLine());

                    //Checking for negativ value
                    if (arr1[i] < 0)
                        flag = false;
                }

                //For last 5 elements
                else
                    arr2[i - 5] = Convert.ToInt32(Console.ReadLine());
            }

            //Cheking condition: If 'True' would be culc sum of first 5, either - product of last 5
            if (flag)
            {
                foreach (int item in arr1)
                {
                    sum += item;
                }

                Console.WriteLine("\nSum of first 5 elements = {0}", sum);
            }

            else
            {
                foreach (int item in arr2)
                {
                    prod *= item;
                }

                Console.WriteLine("\nProduct of last 5 elements = {0}", prod);
            }

        }
    }
}
