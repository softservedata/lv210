using System;

namespace HomeWorkTwo
{
    /// <summary>
    /// Ввести дійсне число r і обчислити довжину кола, площу круга та об’єм кулі цього радіуса
    /// </summary>
    public class HW_2_2
    {
        public static void Main()
        {
            Console.Write("Enter value of r - radius: ");

            int r = Convert.ToInt32(Console.ReadLine());
            double pi = 3.141592;

            Console.WriteLine("Length of the circle ( S = r * pi )): {0}", (r* pi));
            Console.WriteLine("Square of the circle( S = pi * (r*r)): {0}", (r * r) * pi);
            Console.WriteLine("Volume of the circle( V = 4/3*pi*(r*r*r)): {0}", 4/3 *pi*r*r*r);

            Console.ReadKey();
        }
    }
}
