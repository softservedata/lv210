using System;
using NUnit.Framework;

namespace ComplexTaskAboutShape.UnitTests
{
    [TestFixture]
    public class TriangleTest
    {
        private static readonly object[] TestDataForPerimetr =
        {
            new object[] { new[] { new Point(1, 1), new Point(1, 4), new Point(5, 1)}, 12},
            new object[] { new[] { new Point(0, 2), new Point(3, 3), new Point(5, 0)}, 12.152},
            new object[] { new[] { new Point(0, 0), new Point(0, -5), new Point(4, 0)}, 15.403},
        };

        private static readonly object[] TestDataForArea =
        {
            new object[] { new[] { new Point(1, 1), new Point(1, 4), new Point(5, 1)}, 6},
            new object[] { new[] { new Point(0, 2), new Point(3, 3), new Point(5, 0) }, 5.5},
            new object[] { new[] { new Point(0, 0), new Point(0, -5), new Point(4, 0)}, 10},
        };

        private static readonly object[] IncorrectTestDataForTriangleConstructor =
        {
            new object[] { new[] { new Point(1, 1), new Point(1, 2), new Point(1, 3)}},
            new object[] { new[] { new Point(-1, -1), new Point(-1, -4), new Point(-1, -7)}},
            new object[] { new[] { new Point(0, 0), new Point(0, 3), new Point(0, 4)}},
        };

        /// <summary>
        /// This method verifies that GetPerimetr() method for Triangle
        /// calculate perimetr correctly with correct data. 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="result"></param>

        [Test, TestCaseSource(nameof(TestDataForPerimetr))]
        public void ShouldCalculatePerimetrOfTriangle(Point[] points, double result)
        {
            Triangle triangle = new Triangle(points);

            var precision = 0.001;
            var actual = triangle.GetPerimetr();
            var expected = result;

            Assert.AreEqual(expected, actual, precision);
        }

        /// <summary>
        /// This method verifies that GetArea() method for Triangle
        /// calculate area correctly with correct data. 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="result"></param>

        [Test, TestCaseSource(nameof(TestDataForArea))]
        public void ShouldCalculateAreaOfTriangle(Point[] points, double result)
        {
            Triangle triangle = new Triangle(points);

            var precision = 0.001;
            var actual = triangle.GetArea();
            var expected = result;

            Assert.AreEqual(expected, actual, precision);
        }

        /// <summary>
        /// This method verifies that Triangle() constructor
        /// throw exception with incoorect data.
        /// </summary>
        /// <param name="points"></param>

        [Test, TestCaseSource(nameof(IncorrectTestDataForTriangleConstructor))]
        public void ShouldThrowExceptionInTriangleConstructor(Point[] points)
        {
            Assert.Throws<ArgumentException>(delegate { new Triangle(points); });
        }
    }
}
