using System;

namespace Hometask7
{
    public class Circle : Shape
    {
        private double _radius;
        public double Radius
        {
            get { return _radius; }

            private set
            {
                _radius = value;

                if (_radius <= 0)
                {
                    throw new ArgumentException("Circle radius can not be less or equal zero!");
                }               
            }
        }

        public Circle(double radius) : base("Circle")
        {
            this.Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * this.Radius;
        }
    }
}