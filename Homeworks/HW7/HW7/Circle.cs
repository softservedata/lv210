using System;

namespace HW7
{
    class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
                if (radius < 0)
                {
                    throw new ArgumentException("Radius should be greater then 0");
                }
            }
        }

        public Circle(double radius) : base("Circle")
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}
