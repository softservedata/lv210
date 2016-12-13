using System;

namespace HierarchyOfGeometricShapes
{
    public abstract class Polygon : IShape
    {
        public Point[] Points { get; private set; }

        public Polygon(Point[] points)
        {
            this.Points = points;
            //SortPointsToBuildPoligon();
        }

        public double Line(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }

        public double Perimeter()
        {
            double perimeter = 0;
            for (int i = 0; i < Points.Length - 1; i++)
            {
                perimeter += Line(Points[i], Points[i + 1]);
            }
            return perimeter;
        }

        public abstract double Area();

        #region FunctionToOrganizePoints

        //private void SortPointsToBuildPoligon()
        //{
        //    var indexOfLeftMostPoint = FindIndexOfLeftmostPoint();
        //    Point leftMost = Points[indexOfLeftMostPoint];
        //    Swap(this.Points, 0, indexOfLeftMostPoint);

        //    var indexOfMaxOppositePoint = FindIndexOfMaxOppositePoint(leftMost);
        //    Point maxOpposite = Points[indexOfMaxOppositePoint];

        //    var possitionOfMaxOppositeInArray = FindPositionInArrayOfPointsWhereToSetMaxOppositePoint(leftMost, maxOpposite);
        //    Swap(this.Points, indexOfMaxOppositePoint, possitionOfMaxOppositeInArray);

        //    var upPoints = FindPointsUpBetweenLeftMostAndMaxOpposite(leftMost, maxOpposite).ToArray();
        //    var downPoints = FindPointsDownBetweenLeftMostAndMaxOpposite(leftMost, maxOpposite).ToArray();

        //    SortPointsIncreaseX(ref upPoints);
        //    SortPointsDecreaseX(ref downPoints);

        //    ChangeValues(upPoints, 1, possitionOfMaxOppositeInArray);
        //    ChangeValues(downPoints, possitionOfMaxOppositeInArray + 1, Points.Length);

        //}

        //private void ChangeValues(Point[] listOPoints, int i, int j)
        //{
        //    for (int k = i, l = 0; k < j && l < listOPoints.Length; k++, l++)
        //    {
        //        Points[k] = listOPoints[l];
        //    }
        //}

        //private void SortPointsIncreaseX(ref Point[] points)
        //{
        //    bool wasSwapped = true;
        //    for (int i = 1; (i <= points.Length) && wasSwapped; ++i)
        //    {
        //        wasSwapped = false;
        //        for (int j = 0; j < points.Length - i; ++j)
        //        {
        //            if (points[j].X > points[j + 1].X)
        //            {
        //                Swap(points, j, j + 1);
        //                wasSwapped = true;
        //            }
        //        }
        //    }
        //}

        //private void SortPointsDecreaseX(ref Point[] points)
        //{
        //    bool wasSwapped = true;
        //    for (int i = 1; (i <= points.Length) && wasSwapped; ++i)
        //    {
        //        wasSwapped = false;
        //        for (int j = 0; j < points.Length - i; ++j)
        //        {
        //            if (points[j].X < points[j + 1].X)
        //            {
        //                Swap(points, j, j + 1);
        //                wasSwapped = true;
        //            }
        //        }
        //    }
        //}

        //private void Swap(Point[] points, int i, int j)
        //{
        //    Point point = points[i];
        //    points[i] = points[j];
        //    points[j] = point;
        //}

        protected double LineEquation(Point point, Point p1, Point p2)
        {
            return (p2.X - p1.X) * (point.Y - p1.Y) - (point.X - p1.X) * (p2.Y - p1.Y);
        }


        protected Point PointOfLinesIntersection(Point pointA, Point pointB, Point pointC, Point pointD)
        {
            var point = new Point();
            var coefFirstEquation = CoeficientsOfLinearEquation(pointA, pointB);
            var coefSecondEquation = CoeficientsOfLinearEquation(pointC, pointD);
            point.X = (int)Math.Ceiling((coefSecondEquation[1] - coefFirstEquation[1]) /
                      (coefFirstEquation[0] - coefSecondEquation[0]));
            point.Y = (int)Math.Ceiling(coefSecondEquation[0] * point.X + coefSecondEquation[1]);

            return point;
        }

        private double[] CoeficientsOfLinearEquation(Point pointFirst, Point pointSecond)
        {
            var coef = new double[2];
            coef[0] = ((double)(pointFirst.Y - pointSecond.Y) / (pointFirst.X - pointSecond.X));
            coef[1] = pointFirst.Y - coef[0] * pointFirst.X;

            return coef;
        }

        //private int FindPositionInArrayOfPointsWhereToSetMaxOppositePoint(Point leftMost, Point maxOpposite)
        //{
        //    var countOfPointsUpBetweenLeftMostAndMaxOpposite = 0;
        //    foreach (var point in Points)
        //    {
        //        if (LineEquation(point, leftMost, maxOpposite) > 0)
        //        {
        //            countOfPointsUpBetweenLeftMostAndMaxOpposite++;
        //        }
        //    }

        //    return ++countOfPointsUpBetweenLeftMostAndMaxOpposite;
        //}

        //private List<Point> FindPointsUpBetweenLeftMostAndMaxOpposite(Point leftMost, Point maxOpposite)
        //{
        //    List<Point> listOfUpPoints = new List<Point>();

        //    foreach (var point in Points)
        //    {
        //        if (LineEquation(point, leftMost, maxOpposite) > 0)
        //        {
        //            listOfUpPoints.Add(point);
        //        }
        //    }

        //    return listOfUpPoints;
        //}

        //private List<Point> FindPointsDownBetweenLeftMostAndMaxOpposite(Point leftMost, Point maxOpposite)
        //{
        //    List<Point> listOfDownPoints = new List<Point>();

        //    foreach (var point in Points)
        //    {
        //        if (LineEquation(point, leftMost, maxOpposite) < 0)
        //        {
        //            listOfDownPoints.Add(point);
        //        }
        //    }

        //    return listOfDownPoints;
        //}

        //private int FindIndexOfLeftmostPoint()
        //{
        //    var mixX = Points[0].X;
        //    var minY = Points[0].Y;
        //    var indexMinX = 0;

        //    for (var i = 1; i < Points.Length; i++)
        //    {
        //        if ((mixX > Points[i].X) || ((mixX == Points[i].X) && (minY > Points[i].Y)))
        //        {
        //            mixX = Points[i].X;
        //            minY = Points[i].Y;
        //            indexMinX = i;
        //        }
        //    }

        //    return indexMinX;
        //}

        //private int FindIndexOfMaxOppositePoint(Point currentPoint)
        //{
        //    var max = Line(currentPoint, Points[0]);
        //    int index = 0;

        //    for (int i = 1; i < Points.Length; i++)
        //    {
        //        var length = Line(currentPoint, Points[i]);
        //        if (length > max)
        //        {
        //            max = length;
        //            index = i;
        //        }
        //    }

        //    return index;
        //}
        #endregion
    }
}
