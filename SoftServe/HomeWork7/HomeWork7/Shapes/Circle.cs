using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : Shape
    {
        private double radius;

        public Circle(string name, double radius) : base(name)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override double GetPerimetr()
        {
            return 2 * Math.PI * radius;
        }

        public override int CompareTo(Shape obj)
        {
            return GetArea().CompareTo(obj.GetArea());
        }

        public override string ToString()
        {
            return string.Format("Shape name : {0}, area : {1}, perimetr : {2}", Name, GetArea(), GetPerimetr());
        }
    }
}
