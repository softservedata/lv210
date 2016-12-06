using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            Console.WriteLine("Enter 3 integer numbers: ");

            numbers[0] = int.Parse(Console.ReadLine());
            numbers[1] = int.Parse(Console.ReadLine());
            numbers[2] = int.Parse(Console.ReadLine());



            Console.WriteLine("The min number is: {0}; \nThe max number is: {1};", Min(numbers), Max(numbers));

            Console.ReadKey();
        }

        public static int Max(int[] num)
        {
            int max = int.MinValue;

            for (int i = 0; i < num.Length; i++)
                if (num[i] > max)
                    max = num[i];

            return max;
        }

        public static int Min(int[] num)
        {
            int min = int.MaxValue;

            for (int i = 0; i < num.Length; i++)
                if (num[i] < min)
                    min = num[i];

            return min;
        }
    }
}
