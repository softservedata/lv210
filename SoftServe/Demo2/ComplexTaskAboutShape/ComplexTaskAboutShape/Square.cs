using System;

namespace ComplexTaskAboutShape
{
    /// <summary>
    /// Class Square implements interface IShape.
    /// Method DefineRange() defines sides length.
    /// Property IsValid checks that we can create square.
    /// Methods GetArea() and GetPerimetr() calculates area and perimetr.
    /// </summary>
    
    public class Square : IShape
    {
        private const int CountOfSides = 4;

        private Point firstPoint;
        private Point secondPoint;
        private Point thirdPoint;
        private Point fourthPoint;

        private double firstSideLength;
        private double secondSideLength;
        private double thirdSideLength;
        private double fourthSideLength;

        public Square(Point first, Point second, Point third, Point fourth)
        {
            firstPoint = first;
            secondPoint = second;
            thirdPoint = third;
            fourthPoint = fourth;

            DefineRange();

            CheckSquareCorrectness();
        }

        public Square(Point[] points) : this(points[0], points[1], points[2], points[3]) { }

        private void DefineRange()
        {
            firstSideLength = Math.Sqrt(Math.Pow((firstPoint.X - secondPoint.X), 2) + Math.Pow((firstPoint.Y - secondPoint.Y), 2));
            secondSideLength = Math.Sqrt(Math.Pow((secondPoint.X - thirdPoint.X), 2) + Math.Pow((secondPoint.Y - thirdPoint.Y), 2));
            thirdSideLength = Math.Sqrt(Math.Pow((thirdPoint.X - fourthPoint.X), 2) + Math.Pow((thirdPoint.Y - fourthPoint.Y), 2));
            fourthSideLength = Math.Sqrt(Math.Pow((fourthPoint.X - firstPoint.X), 2) + Math.Pow((fourthPoint.Y - firstPoint.Y), 2));
        }

        private void CheckSquareCorrectness()
        {
            if (!IsValid)
            {
                throw new ArgumentException("Can't create square with these points");
            }
        }

        public bool IsValid
        {
            get
            {
                return ((firstSideLength == secondSideLength) && (thirdSideLength == fourthSideLength) && (firstSideLength == thirdSideLength));
            }
        }

        public double GetArea()
        {
            return firstSideLength * secondSideLength;
        }

        public double GetPerimetr()
        {
            return firstSideLength * CountOfSides;
        }

        public override string ToString()
        {
            var typeOFShape = string.Format("\nYou've just created a square");
            var firstSideLengthStr = string.Format("First side has length : {0}", firstSideLength);
            var secondSideLengthStr = string.Format("Second side has length : {0}", secondSideLength);
            var thirdSideLengthStr = string.Format("Third side has length : {0}", thirdSideLength);
            var fourthSideLengthStr = string.Format("Fourth side has length : {0}", fourthSideLength);
            
            return typeOFShape + Environment.NewLine + firstSideLengthStr + Environment.NewLine + secondSideLengthStr +
                Environment.NewLine + thirdSideLengthStr + Environment.NewLine + fourthSideLengthStr;
        }
    }
}
