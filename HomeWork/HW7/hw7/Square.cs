using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    public class Square : Shape
    {
        private double side;

        public Square()
        {
            Name = "Square";
        }
        public Square(double side)
        {
            Name = "Square";
            this.side = side;
        }
        public override double Area()
        {
            return side * side;
        }

        public override double Perimeter()
        {
            return 4 * side;
        }
    }
}
