using System;

namespace Polygons
{
    public class Square : IPolygon
    {
        private double sideLength;
        private double perimeter;
        private double area;

        public Square()
        {
        }

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double PerimeterCalculation()
        {
            perimeter = 4 * sideLength;
            return perimeter;
        }

        public double AreaCalculation()
        {
            area = Math.Pow(sideLength, 2);
            return area;
        }

        public void Display()
        {
            Console.WriteLine("Square information:\nPerimeter: {0}\nArea: {1}\n", perimeter, area);
        }
    }
}
