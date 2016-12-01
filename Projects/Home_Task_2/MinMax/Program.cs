using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            // read 3 integres and write max and min of them.

            int max = Int32.MinValue;
            int min = Int32.MaxValue;
            int[] arr = new int[3];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Entert #{0} number: ", i + 1);
                arr[i] = Int32.Parse(Console.ReadLine());

                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
            }
            Console.WriteLine("Max Value: " + max);
            Console.WriteLine("Min Value: " + min);

        }
    }
}
