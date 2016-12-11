using System;

namespace Polygons
{
    public class EquilateralTriangle : IPolygon
    {
        private double SideLength;
        private double Perimeter;
        private double Area;
        public EquilateralTriangle()
        {
        }
        public EquilateralTriangle(double SideLength)
        {
            this.SideLength = SideLength;
        }
        public void PerimeterCalculation()
        {
            Perimeter = 3 * SideLength;
        }
        public void AreaCalculation()
        {
            Area = Math.Pow(SideLength, 2) * (Math.Sqrt(3) / 4);
        }
        public void Display()
        {
            Console.WriteLine("Triangle information:\nPerimeter: {0}\nArea: {1}\n", Perimeter, Area);
        }
    }
}
