namespace HomeWorkSeven
{
    /// <summary>
    /// Class that reprents Square functionality
    /// </summary>
    public class Square : Shape
    {
        public double Side { get; set; }

        public Square(string name, double side)
            : base(name)
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

        public override string ToString()
        {
            return Name + " type: square. Side length = " + this.Side + ". Perimeter = " + this.Perimeter() + ". Area = " +
                   this.Area();
        }
    }
}
