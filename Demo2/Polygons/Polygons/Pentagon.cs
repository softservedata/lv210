using System;

namespace Polygons
{
    public class Pentagon : Square
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

        public new double PerimeterCalculation()
        {
            perimeter = 5 * sideLength;
            return perimeter;
        }

        public new double AreaCalculation()
        {
            area = (Math.Pow(sideLength, 2) * Math.Sqrt(25 + 10 * Math.Sqrt(5))) / 4;
            return area;
        }

        public new void Display()
        {
            Console.WriteLine("Pentagon information:\nPerimeter: {0}\nArea: {1}\n", perimeter, area);
        }
    }
}
