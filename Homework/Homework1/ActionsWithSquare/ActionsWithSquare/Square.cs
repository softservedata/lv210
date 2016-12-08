using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithSquare
{
    public class Square
    {
        public double _sideLength;

        public Square(double side)
        {
            if (side <= 0)
            {
                throw new ArgumentException("\nLength of the side can't be less or equal zero!");
            }

            this._sideLength = side;
        }

        public double Area()
        {
            return this._sideLength * this._sideLength;
        }

        public double Perimeter()
        {
            return 4 * this._sideLength;
        }

        public override string ToString()
        {
            return string.Format("\nSize is {0}, area is {1}, perimeter is {2}.", this._sideLength, this.Area(), this.Perimeter());
        }
    }
}
