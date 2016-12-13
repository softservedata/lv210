using System;
using FluentValidation;

namespace HierarchyOfGeometricShapes
{
    public class QuadrangleValidator : AbstractValidator<Quadrangle>
    {
        public QuadrangleValidator()
        {
            RuleFor(quadrangle => quadrangle.Points.Length)
                .Equal(4)
                .WithMessage("\nQuadrangle always has 4 sides!");
            RuleFor(quadrangle => quadrangle.Points)
                .NotNull()
                .NotEmpty()
                .Must(HasLessThanThreePointsOnTheSameLine)
                .WithMessage("\nThree points cannot lie on the some line!")
                .Must(IsReallyQuadrangle)
                .WithMessage("\nCannot create a quadrangle with such sequence of points!");
        }

        private bool HasLessThanThreePointsOnTheSameLine(Point[] points)
        {
            var valueFirst = IsOnTheSameLine(points[0], points[1], points[2]);
            var valueSecond = IsOnTheSameLine(points[0], points[1], points[3]);
            var valueThird = IsOnTheSameLine(points[0], points[2], points[3]);
            var valueForth = IsOnTheSameLine(points[1], points[2], points[3]);

            return !(valueFirst || valueSecond || valueThird || valueForth);
        }

        private bool IsReallyQuadrangle(Point[] points)
        {
            var haveCorrectIntersectionAwithB = HaveIntersectionInSetPoint(points[0], points[1], points[1], points[2],
                points[1]);
            var haveCorrectIntersectionBwithC = HaveIntersectionInSetPoint(points[1], points[2], points[2], points[3],
                points[2]);
            var haveCorrectIntersectionCwithD = HaveIntersectionInSetPoint(points[2], points[3], points[3], points[0],
                points[3]);
            var haveCorrectIntersectionDwithA = HaveIntersectionInSetPoint(points[3], points[0], points[0], points[1],
                points[0]);

            return haveCorrectIntersectionAwithB && haveCorrectIntersectionBwithC && haveCorrectIntersectionCwithD &&
                   haveCorrectIntersectionDwithA;
        }

        #region SubsidiaryFunctions

        private bool IsOnTheSameLine(Point a, Point b, Point c)
        {
            return ((a.X == b.X) && (b.X == c.X)) || ((a.Y == b.Y) && (b.Y == c.Y));
        }

        private bool HaveIntersectionInSetPoint(Point pointA, Point pointB, Point pointC, Point pointD, Point setPoint)
        {
            return PointOfLinesIntersection(pointA, pointB, pointC, pointD) == setPoint;
        }

        private Point PointOfLinesIntersection(Point pointA, Point pointB, Point pointC, Point pointD)
        {
            var point = new Point();
            var coefFirstEquation = CoeficientsOfLinearEquation(pointA, pointB);
            var coefSecondEquation = CoeficientsOfLinearEquation(pointC, pointD);
            if (coefFirstEquation == null || coefSecondEquation == null)
            {
                point = (((pointA.X == pointB.X) && (pointC.Y == pointD.Y)) ||
                         ((pointA.Y == pointB.Y) && (pointC.X == pointD.X))) ? pointB : point;
            }
            else
            {
                point.X = (int)Math.Ceiling((coefSecondEquation[1] - coefFirstEquation[1]) /
                     (coefFirstEquation[0] - coefSecondEquation[0]));
                point.Y = (int)Math.Ceiling(coefSecondEquation[0] * point.X + coefSecondEquation[1]);
            }

            return point;
        }

        private double[] CoeficientsOfLinearEquation(Point pointFirst, Point pointSecond)
        {
            var coef = new double[2];
            coef[0] = 
                      ((double)(pointFirst.Y - pointSecond.Y) / (pointFirst.X - pointSecond.X));
            coef[1] = pointFirst.Y - coef[0] * pointFirst.X;

            return ((pointFirst.X - pointSecond.X) == 0) ? null : coef;
        }

        #endregion
    }
}