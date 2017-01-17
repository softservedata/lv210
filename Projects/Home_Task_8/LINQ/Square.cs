using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shape
    {
        private double _side;

        public Square(double side) : base("Square")
        {
            Side = side;
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        public double Side
        {
            get { return _side; }

            private set
            {
                _side = value;

                if (_side <= 0)
                {
                    throw new ArgumentOutOfRangeException("Only positive values allowed for square side!");
                }
            }
        }

        protected override double GetArea()
        {
            return Math.Pow(_side, 2);
        }

        protected override double GetPerimeter()
        {
            return 4 * _side;
        }

        public override string ToString()
        {
            return String.Format($"{Name} with side = {Side} has P = {Perimeter:F} S = {Area:F}");
        }
    }
}
