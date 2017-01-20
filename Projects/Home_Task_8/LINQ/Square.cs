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
            Area = area;
            Perimeter = perimeter;
        }

        public double Side
        {
            get { return _side; }

            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Only positive values allowed for square side!");
                _side = value;
            }
        }

        public override double Perimeter
        {
            get { return perimeter; }

            protected set
            {
                perimeter = 4 * _side;
            }
        }

        public override double Area
        {
            get { return area; }

            protected set
            {
                area = Math.Pow(_side, 2);
            }
        }

        public override string ToString()
        {
            return String.Format($"{Name} with side = {Side} has P = {Perimeter:F} S = {Area:F}");
        }
    }
}
