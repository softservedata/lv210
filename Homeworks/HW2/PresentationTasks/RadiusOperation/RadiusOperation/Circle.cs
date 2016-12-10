using System;

namespace RadiusOperation
{
    public class Circle
    {
        private double Radius;
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double CircleLength()
        {
            return 2 * Radius * Math.PI;
        }
        public double CircleArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
