using System;

namespace ComplexTaskAboutShape
{
    class Program
    {
        static void Main(string[] args)
        {
            Point firstPoint = InputCoordinates();
            Point secondPoint = InputCoordinates();
            Point thirdPoint = InputCoordinates();
            IShape triangle = new Triangle(firstPoint, secondPoint, thirdPoint);

            try
            {                
                InfoAboutTriangle(triangle);
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }

            Console.ReadKey(); 
        }

        private static void InfoAboutTriangle(IShape triangle)
        {
            Console.WriteLine(triangle);
            Console.WriteLine("Triangle perimetr is : {0}", triangle.GetPerimetr());
            Console.WriteLine("Triangle area is : {0}", triangle.GetArea());
        }

        private static Point InputCoordinates()
        {
            double x, y;

            Console.Write("Input coordinate x : ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("The value shouldn't contains characters, please try again : ");
            }

            Console.Write("Input coordinate y : ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.Write("The value shouldn't contains characters, please try again : ");
            }

            return new Point(x, y);
        }
    }
}
