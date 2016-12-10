using System;

namespace RadiusOperation
{
    public class Sphere: Circle
    {
        private double Radius;
        public Sphere(double radius) : base(radius)
        {
            Radius = radius;
        }
        public double SphereVolume()
        {
            return (4 / 3) * Math.PI * Math.Pow(Radius, 3);
        }
    }
}
