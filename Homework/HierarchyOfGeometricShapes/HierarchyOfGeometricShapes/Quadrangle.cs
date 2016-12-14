using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace HierarchyOfGeometricShapes
{
    public class Quadrangle : Polygon
    {
        public Quadrangle(Point[] points) : base(points)
        {
            CheckForCorrectness();
        }

        private IList<ValidationFailure> Validate()
        {
            var validator = new QuadrangleValidator();
            var result = validator.Validate(this);

            return result.Errors;
        }

        private void CheckForCorrectness()
        {
            if (this.Validate().Any())
            {
                throw new ArgumentException();
            }
        }

        public override double Area()
        {
            var a = Line(Points[0], Points[1]);
            var b = Line(Points[1], Points[2]);
            var c = Line(Points[2], Points[3]);
            var d = Line(Points[3], Points[0]);
            var e = Line(Points[0], Points[2]);
            var f = Line(Points[1], Points[3]);

            return Math.Sqrt((4 * e * e * f * f - Math.Pow((b * b + d * d - a * a - c * c), 2)) / 16);
        }

        public bool IsAbleToBeInscribedInCircle()
        {
            var cosA = CosOfAngleBetweenSides(Points[0], Points[1], Points[0], Points[3]);
            var cosB = CosOfAngleBetweenSides(Points[1], Points[0], Points[1], Points[2]);
            var cosC = CosOfAngleBetweenSides(Points[2], Points[1], Points[2], Points[3]);
            var cosD = CosOfAngleBetweenSides(Points[3], Points[2], Points[3], Points[0]);

            return (Math.Abs((cosA + cosC) - (cosB + cosD)) < 0.00001);
        }

        public override string ToString()
        {
            return $"Hi! This is a Quadrangle. Perimeter is {Perimeter()}, area is {Area()}.";
        }

        private Point Vector(Point a, Point b)
        {
            var resultPoint = new Point
            {
                X = b.X - a.X,
                Y = b.Y - a.Y
            };

            return resultPoint;
        }

        #region ActionsWithVectors

        private int ScalarProduct(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        private double LengthOfVector(Point a)
        {
            return Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        private double CosOfAngleBetweenSides(Point firstPoint, Point secondPoint, Point thirdPoint, Point forthPoint)
        {
            var vectorA = Vector(firstPoint, secondPoint);
            var vectorB = Vector(thirdPoint, forthPoint);

            return ScalarProduct(vectorA, vectorB) / (LengthOfVector(vectorA) * LengthOfVector(vectorB));
        }

        #endregion

    }
}
