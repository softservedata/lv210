using System;

namespace ComplexTaskAboutShape
{
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
            var firstPointStr = string.Format("First point has coordinates x : {0}, y : {1}", firstPoint.X, firstPoint.Y);
            var secondPointStr = string.Format("First point has coordinates x : {0}, y : {1}", secondPoint.X, secondPoint.Y);
            var thirdPointStr = string.Format("First point has coordinates x : {0}, y : {1}", thirdPoint.X, thirdPoint.Y);

            return firstPointStr + Environment.NewLine + secondPointStr + Environment.NewLine + thirdPointStr;
        }
    }
}
