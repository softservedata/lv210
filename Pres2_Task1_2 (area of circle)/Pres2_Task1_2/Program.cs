using System;

namespace Pres2_Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter radius: ");
            double r = Convert.ToDouble(Console.ReadLine());
            double circleLength = 2*Math.PI*r;
            double circleSquare = Math.PI * Math.Pow(r, 2);
            double sphereVolume = 4*Math.PI* Math.Pow(r, 2);
            Console.WriteLine("Length of circle = {0}", circleLength);
            Console.WriteLine("Square of circle = {0}", circleSquare);
            Console.WriteLine("Volume of sphere = {0}", sphereVolume);
            Console.ReadKey();
        }
    }
}
