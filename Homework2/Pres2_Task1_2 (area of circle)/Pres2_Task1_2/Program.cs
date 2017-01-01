using System;

namespace Pres2_Task1_2
{
    public class Program
    {
        public static double CircleLength (double radius)
        {
            return 2 * Math.PI * radius;
        }

        public static double CircleArea (double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public static double SphereVolume (double radius)
        {
            return 4 * Math.PI * Math.Pow(radius, 2);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            double circleLength = CircleLength(radius);
            double circleArea = CircleArea(radius);
            double sphereVolume = SphereVolume(radius);
            Console.WriteLine("Length of circle = {0}", circleLength);
            Console.WriteLine("Square of circle = {0}", circleArea);
            Console.WriteLine("Volume of sphere = {0}", sphereVolume);
            Console.ReadKey();
        }
    }
}
