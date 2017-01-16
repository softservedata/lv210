using System;

namespace ShapesProject
{
   public class Circle:Shape
    {
        private double radius;

       
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public Circle(string name,double radius) : base(name)
        {
           this.radius = radius;
        }

        public override double Area()
        {
            return Math.Pow(Math.PI*radius,2.0);
        }

        public override double Perimeter()
        {
            return 2*Math.PI*radius;
        }
        public override string ToString()
        {
            return Name + " type: circle. Side length = " + Radius + ". Perimeter = " + this.Perimeter() + ". Area = " +
                   this.Area();
        }
    }
}
