using System;

namespace ShapesApplication
{
    public class Sphere : Circle, IThreeDimensionalShape
    {
        public double CalculateVolume()
        {
            return 4*Math.Pow(Radius, 3.0)*Math.PI;
        }

        public override double CalculateArea()
        {
            return 4*Math.Pow(Radius, 2.0)*Math.PI;
        }

        public Sphere(Point3D center, double radius, Color color = Color.White) : base(center, radius, color)
        {
        }
    }
}
