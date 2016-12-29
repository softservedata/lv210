using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    class Square:Shape
    {
        public double Side { get; set; }
        public Square(string name,double side) : base(name)
        {
            Side = side;
        }

        public override double Area()
        {
            return Side*Side;
        }

        public override double Perimeter()
        {
            return 4 * Side;
        }

        public override string ToString()
        {
            return Name + " type: square. Side length = " + Side + ". Perimeter = " + this.Perimeter() + ". Area = " +
                   this.Area();
        }
    }
}
