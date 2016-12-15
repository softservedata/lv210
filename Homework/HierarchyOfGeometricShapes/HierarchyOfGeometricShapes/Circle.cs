using System;

namespace HierarchyOfGeometricShapes
{
    /// <summary>
    /// <para>Class Circle implements interface IShape.</para>
    /// <para>It has properties CenterPoint and RadiusPoint
    /// (this point helps to define direction and length of radius) to set a circle.</para>
    /// <para>There are methods Area(), Perimeter() and Radius() to calculate appropriate values.</para>
    /// <para>Method Validate() can inform whether created class is valid.</para>
    /// </summary>

    public class Circle : IShape
    {
        private Point _radiusPoint;
        public Point CenterPoint { get; private set; }

        public Point RadiusPoint
        {
            get
            {
                return _radiusPoint;
            }
            set
            {
                if (value == CenterPoint)
                {
                    throw new ArgumentException();
                }

                _radiusPoint = value;
            }
        }

        public Circle(Point centerPoint, Point radiusPoint)
        {
            this.CenterPoint = centerPoint;
            this.RadiusPoint = radiusPoint;
        }

        /// <summary>
        /// <para>This method verifies whether appropriate point is inside current circle
        /// or it is placed on the border of the circle.</para>
        /// <para>If it is, method will return true.</para>
        /// <para>In other case it returns false.</para>
        /// </summary>

        public bool IsInsideCircle(Point point)
        {
            var result = Math.Pow((point.X - CenterPoint.X), 2) + Math.Pow((point.Y - CenterPoint.Y), 2);
            return result <= Math.Pow(Radius(), 2) ? true : false;
        }

        public double Radius()
        {
            return Math.Sqrt(Math.Pow((CenterPoint.X - RadiusPoint.X), 2) +
                   Math.Pow((CenterPoint.Y - RadiusPoint.Y), 2));
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius();
        }

        public double Area()
        {
            return Math.PI * Math.Pow(Radius(), 2);
        }

        public override string ToString()
        {
            return $"Hi! This is a Circle. Perimeter is {Perimeter()}, area is {Area()}";
        }
    }
}