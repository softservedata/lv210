using System;

namespace HW1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Input length");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Perimetr = {0};\nSquare = {1};", a * 4, a*a);
            Console.ReadLine();
        }
    }
}
