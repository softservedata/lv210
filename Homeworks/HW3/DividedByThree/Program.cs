using System;

namespace DividedByThree
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Input two integer numbers: ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            for (int i = a; i <= b; i++)
            {
                if (i % 3 == 0)
                    count += 1;
            }
            Console.WriteLine("Amount of numbers which are divided into 3 entirely {0}", count);
            Console.ReadLine();
        }
    }
}
