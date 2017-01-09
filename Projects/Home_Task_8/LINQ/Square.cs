using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : Shape
    {
        // Field

        private double _side;

        // Ctor

        public Square(string name, double side) : base(name)
        {
            _side = side;
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        // Methods

        public override double GetArea()
        {
            return Math.Pow(_side, 2);
        }

        public override double GetPerimeter()
        {
            return 4 * _side;
        }
    }
}
