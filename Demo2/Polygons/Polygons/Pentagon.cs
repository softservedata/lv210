using System;

namespace Polygons
{
    public class Pentagon : IPolygon
    {
        private double SideLength;
        private double Perimeter;
        private double Area;
        public Pentagon()
        {
        }
        public Pentagon(double SideLength)
        {
            this.SideLength = SideLength;
        }
        public void PerimeterCalculation()
        {
            Perimeter = 5 * SideLength;
        }
        public void AreaCalculation()
        {
            Area = (Math.Pow(SideLength, 2) * Math.Sqrt(25 + 10 * Math.Sqrt(5))) / 4;
        }
        public void Display()
        {
            Console.WriteLine("Pentagon information:\nPerimeter: {0}\nArea: {1}\n", Perimeter, Area);
        }
    }
}
