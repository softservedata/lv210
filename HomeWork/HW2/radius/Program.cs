using System;


namespace radius
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the radius of the circle: ");

            int radius = int.Parse(Console.ReadLine());
            double pi = 3.141592;

            Console.WriteLine("Length of the circle: {0}", (radius* pi));
            Console.WriteLine("Square of the circle: {0}", radius * radius * pi);
            Console.WriteLine("Volume of the circle: {0}", 4/3 * pi * radius * radius * radius);

            Console.ReadKey();
        }
    }
}
