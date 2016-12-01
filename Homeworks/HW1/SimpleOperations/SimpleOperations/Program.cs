using System;

namespace SimpleOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Input integer values");
            Console.WriteLine("a = ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("b = ");
            b = Convert.ToInt32(Console.ReadLine());
            int sum, diff, mult, div;
            sum = a + b;
            diff = a - b;
            mult = a * b;
            div = a / b;
            Console.WriteLine("a + b = {0};\na - b = {1};\na * b = {2};\na / b = {3};", sum, diff, mult, div);
            Console.ReadLine();
        }
    }
}
