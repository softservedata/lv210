using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
       
        public Circle(string name, double radius) : base(name)
        {
            this.Radius = radius;
        }

        public override double Area()
        {
            return Math.Pow(Math.PI*Radius, 2.0);
        }

        public override double Perimeter()
        {
            return 2*Math.PI*Radius;
        }

        public override string ToString()
        {
            return Name + " type: circle. Side length = " + Radius + ". Perimeter = " + this.Perimeter() + ". Area = " +
                   this.Area();
        }

    }
}
