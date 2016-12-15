using System;

namespace ComplexTaskAboutShape
{
    /// <summary>
    /// Class Triangle implements interface IShape.
    /// Method DefineRange() defines sides length.
    /// Property IsValid checks that we can create square.
    /// Methods GetArea() and GetPerimetr() calculates area and perimetr.
    /// </summary>
    
    public class Triangle : IShape
    {
        private Point firstPoint;
        private Point secondPoint;
        private Point thirdPoint;

        private double firstSideLength;
        private double secondSideLength;
        private double thirdSideLength;

        public Triangle(Point first, Point second, Point third)
        {
            firstPoint = first;
            secondPoint = second;
            thirdPoint = third;
            
            DefineRange();

            CheckTriangleCorrectness();
        }

        public Triangle(Point[] points) : this(points[0], points[1], points[2]) { }

        private void CheckTriangleCorrectness()
        {
            if (!IsValid)
            {
                throw new ArgumentException("Can't create triangle with that point", "thirdPoint");
            }
        }

        private void DefineRange()
        {
            firstSideLength = Math.Sqrt(Math.Pow((firstPoint.X - secondPoint.X), 2) + Math.Pow((firstPoint.Y - secondPoint.Y), 2));
            secondSideLength = Math.Sqrt(Math.Pow((secondPoint.X - thirdPoint.X), 2) + Math.Pow((secondPoint.Y - thirdPoint.Y), 2));
            thirdSideLength = Math.Sqrt(Math.Pow((thirdPoint.X - firstPoint.X), 2) + Math.Pow((thirdPoint.Y - firstPoint.Y), 2));
        }

        public double GetPerimetr()
        {
            return firstSideLength + secondSideLength + thirdSideLength;
        }

        public double GetArea()
        {
            double halfPerimetr = GetPerimetr() / 2;
            return Math.Sqrt(halfPerimetr * (halfPerimetr - firstSideLength) * (halfPerimetr - secondSideLength) * (halfPerimetr - thirdSideLength));
        }

        public bool IsValid
        {
            get
            {
                return ((firstSideLength + secondSideLength) > thirdSideLength) &&
                    ((secondSideLength + thirdSideLength) > firstSideLength) &&
                    ((firstSideLength + thirdSideLength) > secondSideLength);
            }
        }

        public override string ToString()
        {
            var typeOfShape = string.Format("\nYou've just created a triangle");
            var firstSideLengthStr = string.Format("First side has length : {0}", firstSideLength);
            var secondSideLengthStr = string.Format("Second side has length : {0}", secondSideLength);
            var thirdSideLengthStr = string.Format("Third side has length : {0}", thirdSideLength);

            return typeOfShape + Environment.NewLine + firstSideLengthStr + Environment.NewLine + secondSideLengthStr + 
                Environment.NewLine + thirdSideLengthStr;
        }
    }
}
