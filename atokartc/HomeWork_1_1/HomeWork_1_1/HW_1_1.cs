using System;

namespace HomeWorkOne
{
    /// <summary>
    /// Task 1_1
    /// Create Console Application project in VS.
    /// In method Main() write code for solving next tasks:
    /// define integer variables a and b.Read values a and b from Console and calculate: a+b, a-b, a*b, a/b.
    /// Output obtained results.
    /// </summary>
    public class HW_1_1
    {
        public static void Main()
        {
            Console.WriteLine("Enter a value: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter b value: ");
            int b = Convert.ToInt32(Console.ReadLine());

            if (b == 0)
            {
                Console.WriteLine("Enter b value once again. b shouldn't be 0");
                Main();
            }
            else
            {
                Console.WriteLine("a + b = {0}", a + b);
                Console.WriteLine("a - b = {0}", a - b);
                Console.WriteLine("a * b = {0}", a * b);
                Console.WriteLine("a / b = {0}", a / b);
            }

            Console.ReadKey();
        }
    }
}
