using System;

namespace Polygons
{
    public class Square : EquilateralTriangle
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

        public new double PerimeterCalculation()
        {
            perimeter = 4 * sideLength;
            return perimeter;
        }

        public new double AreaCalculation()
        {
            area = Math.Pow(sideLength, 2);
            return area;
        }

        public new void Display()
        {
            Console.WriteLine("Square information:\nPerimeter: {0}\nArea: {1}\n", perimeter, area);
        }
    }
}
