using System;

namespace ShapesApplication
{
    public class Circle : ITwoDimensionalShape
    {
        public Point2D Center { get; set; }

        public double Radius { get; set; }

        public Color Color { get; set; }

        public Circle(Point2D center, double radius, Color color = Color.White)
        {
            Center = center;
            Radius = radius;
            Color = color;
        }

        public virtual double CalculateArea()
        {
            return Math.PI*(Math.Pow(Radius, 2.0));
        }

        public IShape Draw()
        {
            if (Radius <= 0 || Center == null)
            {
                throw new ArgumentException("Radius can not be < 0");
            }
            return this;
        }

        public double CalculatePerimeter()
        {
            return 2*Math.PI*Radius;
        }
    }
}
