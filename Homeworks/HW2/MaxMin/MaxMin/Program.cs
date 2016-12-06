using System;

namespace MaxMin
{
    class Program
    {
		///<summary>
		///	Read 3 integres and write max and min of them.
		///</summary>
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Input 3 integer numbers:");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());
            int min = 10000000;
            int max = -10000000;
            if (a > max)
                max = a;
            if (b > max)
                max = b;
            if (c > max)
                max = c;
            Console.WriteLine("Max = {0}", max);
            if (a < min)
                min = a;
            if (b < min)
                min = b;
            if (c < min)
                min = c;
            Console.WriteLine("Min = {0}", min);
            Console.ReadLine();
        }
    }
}
