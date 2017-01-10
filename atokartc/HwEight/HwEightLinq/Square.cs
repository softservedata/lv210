namespace HwEightLinq
{
    /// <summary>
    /// Class that reprents Square functionality
    /// </summary>
    public class Square : Shape
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
                this.side = value;
            }
        }

        public Square(string name, double side)
            : base(name)
        {
            this.side = side;
        }

        public override double Area()
        {
            return side * side;
        }

        public override double Perimeter()
        {
            return 4 * side;
        }

        public override string ToString()
        {
            return Name + " type: square. Side length = " + this.Side + ". Perimeter = " + this.Perimeter() + ". Area = " +
                   this.Area();
        }
    }
}

