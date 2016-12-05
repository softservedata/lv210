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
            int a;
            Console.WriteLine("Define integer variable: ");

            if (int.TryParse(Console.ReadLine(), out a) && a >= 0)
            {
                Console.WriteLine("Area of Square is:{0}", Math.Pow(a, 2));
                Console.WriteLine("Perimeter of Square is:{0}", 4 * a);
            }
            else
            {
                Console.WriteLine("You should enter an integer! ");
                Main();
            }

            Console.ReadKey();
        }
    }
}
