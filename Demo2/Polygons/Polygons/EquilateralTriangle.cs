using System;

namespace Polygons
{
    public class EquilateralTriangle : IPolygon
    {
        private double sideLength;
        private double perimeter;
        private double area;

        public EquilateralTriangle()
        {
        }

        public EquilateralTriangle(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double PerimeterCalculation()
        {
            perimeter = 3 * sideLength;
            return perimeter;
        }

        public double AreaCalculation()
        {
            area = Math.Pow(sideLength, 2) * (Math.Sqrt(3) / 4);
            return area;
        }

        public void Display()
        {
            Console.WriteLine("\nTriangle information:\nPerimeter: {0}\nArea: {1}\n", perimeter, area);
        }

        public void TriangleCalculation()
        {
            PerimeterCalculation();
            AreaCalculation();
            Display();
        }
    }
}
