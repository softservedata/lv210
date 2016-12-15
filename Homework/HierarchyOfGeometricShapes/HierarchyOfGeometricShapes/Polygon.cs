using System;

namespace HierarchyOfGeometricShapes
{
    /// <summary>
    /// <para>Class Polygon implements interface IShape.</para>
    /// <para>It is an abstract class with abstract method Area().</para>
    /// <para>Class Polygon has an array of points as a auto property.</para>
    /// <para>Using these points it can create a polygon and calculates it's perimeter.</para>
    /// </summary>

    public abstract class Polygon : IShape
    {
        public Point[] Points { get; private set; }

        public Polygon(Point[] points)
        {
            this.Points = points;
        }

        /// <summary>
        /// <para>This method calculates distance between any two points.</para>
        /// </summary>

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

            perimeter += Line(Points[Points.Length - 1], Points[0]);

            return perimeter;
        }

        public abstract double Area();
    }
}