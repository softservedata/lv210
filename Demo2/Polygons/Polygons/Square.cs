using System;

namespace Polygons
{
    public class Square : IPolygon
    {
        private double SideLength;
        private double Perimeter;
        private double Area;
        public Square()
        {
        }
        public Square(double SideLength)
        {
            this.SideLength = SideLength;
        }
        public void PerimeterCalculation()
        {
            Perimeter = 4 * SideLength;
        }
        public void AreaCalculation()
        {
            Area = Math.Pow(SideLength, 2);
        }
        public void Display()
        {
            Console.WriteLine("Square information:\nPerimeter: {0}\nArea: {1}\n", Perimeter, Area);
        }
    }
}
