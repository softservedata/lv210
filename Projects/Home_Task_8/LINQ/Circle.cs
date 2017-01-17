using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        public double Radius
        {
            get { return _radius; }

            private set
            {
                _radius = value;

                if (_radius <= 0)
                {
                    throw new ArgumentOutOfRangeException("Only positive values allowed for circle radius!");
                }
            }
        }

        protected override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        protected override double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }

        public override string ToString()
        {
            return String.Format($"{Name} with r = {Radius} has  P = {Perimeter:F} S = {Area:F}");
        }
    }
}
