using System;
using NUnit.Framework;

namespace ComplexTaskAboutShape.UnitTests
{
    [TestFixture]
    public class SquareTest
    {
        private static readonly object[] TestDataForPerimetr =
        {
            new object[] { new[] { new Point(1, 1), new Point(1, 4), new Point(4, 4), new Point(4, 1) }, 12},
            new object[] { new[] { new Point(0, 2), new Point(-2, 2), new Point(-2, 0), new Point(0, 0) }, 8},
            new object[] { new[] { new Point(-5, -5), new Point(-5, -10), new Point(-10, -10), new Point(-10, -5) }, 20},
        };

        private static readonly object[] TestDataForArea =
        {
            new object[] { new[] { new Point(1, 1), new Point(1, 4), new Point(4, 4), new Point(4, 1) }, 9},
            new object[] { new[] { new Point(0, 2), new Point(-2, 2), new Point(-2, 0), new Point(0, 0) }, 4},
            new object[] { new[] { new Point(-5, -5), new Point(-5, -10), new Point(-10, -10), new Point(-10, -5) }, 25},
        };

        private static readonly object[] IncorrectTestDataForSquareConstructor =
        {
            new object[] { new[] { new Point(1, 1), new Point(1, 4), new Point(2, 4), new Point(3, 1) }},
            new object[] { new[] { new Point(0, 2), new Point(-2, 5), new Point(-2, 0), new Point(0, -10) }},
            new object[] { new[] { new Point(-5, -5), new Point(-5, 0), new Point(0, -10), new Point(-10, -5) }},
        };

        /// <summary>
        /// This method verifies that GetPerimetr() method for Square
        /// calculate perimetr correctly with correct data. 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="result"></param>
        
        [Test, TestCaseSource(nameof(TestDataForPerimetr))]
        public void ShouldCalculatePerimetrOfSquare(Point[] points, double result)
        {
            Square square = new Square(points);

            var precision = 0.001;
            var actual = square.GetPerimetr();
            var expected = result;

            Assert.AreEqual(expected, actual, precision);
        }

        /// <summary>
        /// This method verifies that GetArea() method for Square
        /// calculate area correctly with correct data. 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="result"></param>
        
        [Test, TestCaseSource(nameof(TestDataForArea))]
        public void ShouldCalculateAreaOfSquare(Point[] points, double result)
        {
            Square square = new Square(points);

            var precision = 0.001;
            var actual = square.GetArea();
            var expected = result;

            Assert.AreEqual(expected, actual, precision);
        }

        /// <summary>
        /// This method verifies that Square() constructor
        /// throw exception with incoorect data.
        /// </summary>
        /// <param name="points"></param>

        [Test, TestCaseSource(nameof(IncorrectTestDataForSquareConstructor))]
        public void ShouldThrowExceptionInSquareConstructor(Point[] points)
        {
            Assert.Throws<ArgumentException>(delegate { new Square(points); });
        }
    }
}
