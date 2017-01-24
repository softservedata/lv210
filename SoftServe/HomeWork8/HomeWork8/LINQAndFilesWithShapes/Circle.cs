using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius) : base("Circle")
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

        public override string ToString()
        {
            return string.Format("Shape name : {0}, area : {1}, perimetr : {2}", Name, GetArea(), GetPerimetr());
        }
    }
}
