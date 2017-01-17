using System;

namespace TaskWithShapes
{
    public class Circle : Shape
    {
        private double radius;
        public double Radius
        {
            get { return radius; }

            private set
            {
                if (radius <= 0)
                {
                    throw new ArgumentException("Circle radius can not be less or equal zero!");
                }

                radius = value;                              
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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Circle return false.
            var circle = obj as Circle;
            if ((object)circle == null)
            {
                return false;
            }

            return (this.Name == circle.Name) && (Math.Abs(this.Radius - circle.Radius) < Tolerance);
        }

        public bool Equals(Circle circle)
        {
            if ((object)circle == null)
            {
                return false;
            }

            return (this.Name == circle.Name) && (Math.Abs(this.Radius - circle.Radius) < Tolerance);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Radius.GetHashCode();
        }
    }
}