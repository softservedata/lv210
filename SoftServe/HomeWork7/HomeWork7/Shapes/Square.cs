namespace Shapes
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
            return GetArea().CompareTo(obj.GetArea());
        }

        public override string ToString()
        {
            return string.Format("Shape name : {0}, area : {1}, perimetr : {2}", Name, GetArea(), GetPerimetr());
        }
    }
}
