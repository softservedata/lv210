using System;

namespace HomeWorkTwo
{
    /// <summary>
    /// Ввести два цілих числа a та b і перевірити чи вони є однієї парності – вивести true чи false
    /// </summary>
    public class HW_2_1
    {
        public static void Main()
        {
            Console.Write("Enter 'a' value:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter 'b' value:");
            int b = Convert.ToInt32(Console.ReadLine());

            if (a % 2 == 0 && b % 2 == 0)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
            Console.ReadKey();
        }
    }
}
