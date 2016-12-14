using System;

namespace Polygons
{
    public class Pentagon : IPolygon
    {
        private double sideLength;
        private double perimeter;
        private double area;

        public Pentagon()
        {
        }

        public Pentagon(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double PerimeterCalculation()
        {
            perimeter = 5 * sideLength;
            return perimeter;
        }

        public double AreaCalculation()
        {
            area = (Math.Pow(sideLength, 2) * Math.Sqrt(25 + 10 * Math.Sqrt(5))) / 4;
            return area;
        }

        public void Display()
        {
            Console.WriteLine("Pentagon information:\nPerimeter: {0}\nArea: {1}\n", perimeter, area);
        }

        public void PentagonCalculation()
        {
            PerimeterCalculation();
            AreaCalculation();
            Display();
        }
    }
}
