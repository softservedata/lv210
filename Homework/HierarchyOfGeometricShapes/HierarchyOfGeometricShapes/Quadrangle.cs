using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace HierarchyOfGeometricShapes
{
    /// <summary>
    /// <para>Class Quadrangle is inherited from class Polygon.</para>
    /// <para>It overrides abstract method Area from Polygon class.</para>
    /// <para>It also can inform whether it is possible to incribe circle inside the current quadrangle or
    /// whether it is possible to incribe current quadrangle inside the circle.</para>
    /// <para>Object of the class can validate itself and inform the results.</para>
    /// </summary>

    public class Quadrangle : Polygon
    {
        private const double Tolerance = 0.001;
        public Quadrangle(Point[] points) : base(points) { }

        /// <summary>
        /// <para>This method verifies whether created object is valid.</para>
        /// <para>If it is, method will return empty list of errors.</para>
        /// <para>In other case it returns list with results of validation.</para>
        /// <para>It provides possibility to learn information about occured errors.</para>
        /// </summary>

        public IList<ValidationFailure> Validate()
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

        /// <summary>
        /// <para>Calculates area of quadrangle.</para>
        /// <para>It uses lengths of all sides and diagonals.</para>
        /// </summary>

        public override double Area()
        {
            CheckForCorrectness();

            var a = Line(Points[0], Points[1]);
            var b = Line(Points[1], Points[2]);
            var c = Line(Points[2], Points[3]);
            var d = Line(Points[3], Points[0]);
            var e = Line(Points[0], Points[2]);
            var f = Line(Points[1], Points[3]);

            return Math.Sqrt((4 * e * e * f * f - Math.Pow((b * b + d * d - a * a - c * c), 2)) / 16);
        }

        /// <summary>
        /// <para>This method informs whether it is possible to incribe current quadrangle in a circle.</para>
        /// <para>If sum of opposite angles is equal 180 degrees, then it returns true.</para>
        /// <para>In all other cases - false.</para>
        /// </summary>

        public bool IsAbleToBeInscribedInCircle()
        {
            CheckForCorrectness();

            var cosA = CosOfAngleBetweenSides(Points[0], Points[1], Points[0], Points[3]);
            var cosB = CosOfAngleBetweenSides(Points[1], Points[0], Points[1], Points[2]);
            var cosC = CosOfAngleBetweenSides(Points[2], Points[1], Points[2], Points[3]);
            var cosD = CosOfAngleBetweenSides(Points[3], Points[2], Points[3], Points[0]);

            return (Math.Abs((cosA + cosC) - (cosB + cosD)) < Tolerance);
        }

        /// <summary>
        /// <para>This method informs whether it is possible to incribe circle in a current quadrangle.</para>
        /// <para>If sum of opposite sides is the same, then it returns true.</para>
        /// <para>In all other cases - false.</para>
        /// </summary>

        public bool IsAbleToInscribeCircleInside()
        {
            CheckForCorrectness();

            var ab = Line(Points[0], Points[1]);
            var bc = Line(Points[1], Points[2]);
            var cd = Line(Points[2], Points[3]);
            var da = Line(Points[3], Points[0]);

            return ((Math.Abs(ab - cd) < Tolerance) && (Math.Abs(bc - da) < Tolerance));
        }

        public override string ToString()
        {
            return $"Hi! This is a Quadrangle. Perimeter is {Perimeter()}, area is {Area()}.";
        }

        #region ActionsWithVectors

        private Point Vector(Point a, Point b)
        {
            var resultPoint = new Point
            {
                X = b.X - a.X,
                Y = b.Y - a.Y
            };

            return resultPoint;
        }

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