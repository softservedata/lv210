using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    /// <summary>
    /// Read 3 integres and write max and min of them.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration and Initialization
            int max = Int32.MinValue;
            int min = Int32.MaxValue;
            int[] arr = new int[3];

            //Declare Loop
            for (int i = 0; i < arr.Length; i++)
            {
                //Initialization for element of array
                Console.Write("Entert #{0} number: ", i + 1);
                arr[i] = Int32.Parse(Console.ReadLine());

                //Conditions
                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
            }

            //Result print
            Console.WriteLine("---------Result-------------");
            Console.WriteLine("Max Value: {0}", max);
            Console.WriteLine("Min Value: {0}", min);
        }
    }
}
