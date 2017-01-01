using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Сalculate area and perimetr of square with length a
            Console.WriteLine("Enter the length of the square: ");
            String a_s = Console.ReadLine();
            int a = Convert.ToInt32(a_s);
            Console.WriteLine("Area of square = {0}", a * a);
            Console.WriteLine("Perimeter of square = {0}", 4 * a);
            Console.ReadKey();
        }
    }
}
