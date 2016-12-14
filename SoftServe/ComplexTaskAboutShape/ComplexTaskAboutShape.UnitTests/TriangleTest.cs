using System;
using NUnit.Framework;
using NSubstitute;

namespace ComplexTaskAboutShape.UnitTests
{
    [TestFixture]
    public class TriangleTest
    {
        private static readonly object[] TestDataForPerimetr =
        {
            new object[] { new[] { new Point(1,1), new Point(1,4), new Point(5,1)}, 12},
            new object[] { new[] { new Point(-1,-1), new Point(-1,-4), new Point(-5,-1)}, 12},
            new object[] { new[] { new Point(0,0), new Point(0,3), new Point(4,0)}, 12},
        };

        private static readonly object[] TestDataForArea =
        {
            new object[] { new[] { new Point(1,1), new Point(1,4), new Point(5,1)}, 6},
            new object[] { new[] { new Point(-1,-1), new Point(-1,-4), new Point(-5,-1)}, 6},
            new object[] { new[] { new Point(0,0), new Point(0,3), new Point(4,0)}, 6},
        };

        private static readonly object[] TestDataForTriangleConstructor =
        {
            new object[] { new[] { new Point(1,1), new Point(1,2), new Point(1,3)}},
            new object[] { new[] { new Point(-1,-1), new Point(-1,-4), new Point(-1,-7)}},
            new object[] { new[] { new Point(0,0), new Point(0,3), new Point(0,4)}},
        };

        [Test, TestCaseSource(nameof(TestDataForPerimetr))]
        public void ShouldCalculatePerimetrWithCorrectData(Point[] points, double result)
        {
            Triangle triangle = new Triangle(points[0], points[1], points[2]);

            var actual = triangle.GetPerimetr();
            var expected = result;

            Assert.AreEqual(expected, actual, "Test fails");
        }

        [Test, TestCaseSource(nameof(TestDataForArea))]
        public void ShouldCalculateAreaWithCorrectData(Point[] points, double result)
        {
            Triangle triangle = new Triangle(points[0], points[1], points[2]);

            var actual = triangle.GetArea();
            var expected = result;

            Assert.AreEqual(expected, actual, "Test fails");
        }

        [Test, TestCaseSource(nameof(TestDataForTriangleConstructor))]
        public void Triangle_CannotInitializeObject_ThrowException(Point[] points)
        {
            Assert.Throws<ArgumentException>(delegate { new Triangle(points[0], points[1], points[2]); });
        }
    }
}
