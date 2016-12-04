using System;

namespace HomeWorkOne
{
    /// <summary>
    /// Create Console Application project in VS.
    /// In method Main() write code for solving next tasks:
    /// define integer variable a.Read the value of a from console and calculate area and perimetr of square with length a. 
    /// Output obtained results.
    /// </summary>
    public class HW_1_3
    {
        public static void Main()
        {
            Console.WriteLine("Define integer variable: ");

            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Area of Square is:{0}", a * a);
            Console.WriteLine("Perimeter of Square is:{0}", 4 * a);

            Console.ReadKey();
        }
    }
}
