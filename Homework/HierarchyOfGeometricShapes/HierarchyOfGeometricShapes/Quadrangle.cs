using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace HierarchyOfGeometricShapes
{
    public class Quadrangle : Polygon
    {
        public Quadrangle(Point[] points) : base(points) { }

        #region FunctionToVerifyConvexity

        private bool IsConvex()
        {
            Point point = PointOfLinesIntersection(Points[0], Points[2], Points[1], Points[3]);
            return !((LineEquation(point, Points[1], Points[2]) > 0) && (LineEquation(point, Points[2], Points[3]) > 0));
        }

        #endregion

        #region FunctionsToCalcArea

        private double CalculateAreaForConvexQuardangle()
        {
            var a = Line(Points[0], Points[1]);
            var b = Line(Points[1], Points[2]);
            var c = Line(Points[2], Points[3]);
            var d = Line(Points[3], Points[0]);
            var e = Line(Points[0], Points[2]);
            var f = Line(Points[1], Points[3]);

            return Math.Sqrt((4 * e * e * f * f - Math.Pow((b * b + d * d - a * a - c * c), 2)) / 16);
        }

        private double CalculateAreaForNotConvexQuardangle()
        {
            var a = Line(Points[0], Points[1]);
            var b = Line(Points[1], Points[3]);
            var c = Line(Points[3], Points[0]);
            var p = (a + b + c) / 2;
            var areaOfBigTriangle = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            var e = Line(Points[2], Points[1]);
            var d = Line(Points[3], Points[2]);
            p = (e + b + d) / 2;
            var areaOfSmallTriangle = Math.Sqrt(p * (p - e) * (p - b) * (p - d));

            return areaOfBigTriangle - areaOfSmallTriangle;
        }

        #endregion

        public IList<ValidationFailure> Validate()
        {
            var validator = new QuadrangleValidator();
            var result = validator.Validate(this);

            return result.Errors;
        }

        public override double Area()
        {
            var area = IsConvex() ? CalculateAreaForConvexQuardangle() : CalculateAreaForNotConvexQuardangle();
            return area;
        }

        public override string ToString()
        {
            return $"Hi! This is a Quadrangle. Perimeter is {Perimeter()}, area is {Area()}.";
        }
    }
}
