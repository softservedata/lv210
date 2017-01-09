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
    }
}