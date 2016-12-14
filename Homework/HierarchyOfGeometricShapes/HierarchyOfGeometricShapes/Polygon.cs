using System;

namespace HierarchyOfGeometricShapes
{
    public abstract class Polygon : IShape
    {
        public Point[] Points { get; private set; }

        public Polygon(Point[] points)
        {
            this.Points = points;
        }

        public double Line(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }

        public double Perimeter()
        {
            double perimeter = 0;
            for (int i = 0; i < Points.Length - 1; i++)
            {
                perimeter += Line(Points[i], Points[i + 1]);
            }
            return perimeter;
        }

        public abstract double Area();
    }
}