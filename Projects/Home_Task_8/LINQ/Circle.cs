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
            Area = area;
            Perimeter = perimeter;
        }

        public double Radius
        {
            get { return _radius; }

            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Only positive values allowed for circle radius!");
                _radius = value;
            }
        }

        public override double Perimeter
        {
            get { return perimeter; }

            protected set
            {
                perimeter = 2 * Math.PI * _radius;
            }
        }

        public override double Area
        {
            get { return area; }

            protected set
            {
                area = Math.PI * _radius * _radius;
            }
        }

        public override string ToString()
        {
            return String.Format($"{Name} with r = {Radius} has  P = {Perimeter:F} S = {Area:F}");
        }
    }
}
