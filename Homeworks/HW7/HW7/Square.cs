using System;

namespace HW7
{
    class Square : Shape
    {
        private double side;

        public double Side
        {
            get
            {
                return side;
            }
            set
            {
                side = value;
                if (side < 0)
                {
                    throw new ArgumentException("Side should be greater then 0");
                }
            }
        }

        public Square(double side) : base("Square")
        {
            this.side = side;
        }

        public override double Area()
        {
            return Math.Pow(side, 2);
        }

        public override double Perimeter()
        {
            return side * 4;
        }
    }
}
