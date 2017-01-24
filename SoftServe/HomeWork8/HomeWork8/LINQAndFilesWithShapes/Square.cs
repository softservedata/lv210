using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    public class Square : Shape
    {
        private double sideLength;

        public Square(double sideLength) : base("Square")
        {
            this.sideLength = sideLength;
        }

        public override double GetArea()
        {
            return sideLength * sideLength;
        }

        public override double GetPerimetr()
        {
            return sideLength * 4;
        }

        public override string ToString()
        {
            return string.Format("Shape name : {0}, area : {1}, perimetr : {2}", Name, GetArea(), GetPerimetr());
        }
    }
}
