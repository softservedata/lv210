using System;

namespace Inheritance
{
    /// <summary>
    /// Class that reprents Circle functionality
    /// </summary>
    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            private set
            {
                this.radius = value;
            }
        }

        public Circle(string name, double radius)
            : base(name)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return Name + " type: circle. Side length = " + this.Radius + ". Perimeter = " + this.Perimeter() + ". Area = " +
                   this.Area();
        }
    }
}