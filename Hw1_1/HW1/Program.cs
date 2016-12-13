using System;

namespace HW1_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the square: ");
            int Length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Area of square = {0}", AreaOfSquare(Length));
            Console.WriteLine("Perimeter of square = {0}", PerimeterOfSquare(Length));
            Console.ReadKey();
        }

        public static double AreaOfSquare (double Length)
        {
            return Length * Length;
        }

        public static double PerimeterOfSquare(double Length)
        {
            return 4 * Length;
        }

    }
}
