using System;

namespace TaskWithShapes
{
    public class Square : Shape
    {
        private double _side;

        public double Side
        {
            get { return _side; }

            private set
            {
                _side = value;

                if (_side <= 0)
                {
                    throw new ArgumentException("Side of square can not be less or equal zero!");
                }
            }
        }

        public Square(double side) : base("Square")
        {
            this.Side = side;
        }

        public override double Area()
        {
            return this.Side * this.Side;
        }

        public override double Perimeter()
        {
            return 4 * this.Side;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Circle return false.
            var square = obj as Square;
            if ((object)square == null)
            {
                return false;
            }

            return (this.Name == square.Name) && (Math.Abs(this.Side - square.Side) < Tolerance);
        }

        public bool Equals(Square square)
        {
            if ((object)square == null)
            {
                return false;
            }

            return (this.Name == square.Name) && (Math.Abs(this.Side - square.Side) < Tolerance);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Side.GetHashCode();
        }
    }
}