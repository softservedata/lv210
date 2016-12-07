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
        public double _size;

        public Square(double size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("\nLength of the side can't be less or equal zero!");
            }

            this._size = size;
        }

        public double Area()
        {
            return this._size * this._size;
        }

        public double Perimeter()
        {
            return 4 * this._size;
        }

        public override string ToString()
        {
            return string.Format("\nSize is {0}, area is {1}, perimeter is {2}.", this._size, this.Area(), this.Perimeter());
        }
    }
}
