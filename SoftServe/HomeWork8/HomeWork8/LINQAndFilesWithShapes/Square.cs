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
        public Square(string name, double length) : base(name)
        {
            this.sideLength = length;
        }

        public override double GetArea()
        {
            return sideLength * sideLength;
        }

        public override double GetPerimetr()
        {
            return sideLength * 4;
        }

        public override int CompareTo(Shape obj)
        {
            if (GetArea() > obj.GetArea())
            {
                return 1;
            }
            else if (GetArea() < obj.GetArea())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return string.Format("Shape name : {0}, area : {1}, perimetr : {2}", Name, GetArea(), GetPerimetr());
        }
    }
}
