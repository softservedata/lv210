using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace HierarchyOfGeometricShapes.UnitTests
{
    /// <summary>
    /// <para>Class QuadrangleTests contains unit tests for methods of class Quadrangle.</para>
    /// <para>Both positive and negative tests are implemented.</para>
    /// </summary>

    [TestFixture]
    public class QuadrangleTests
    {
        #region TestData
        private static readonly object[] TestDataForArea =
        {
            new object[] {new[] {new Point(3, 2), new Point(5, 6), new Point(9, 6), new Point(11, 2)}, 24},
        };

        private static readonly object[] TestDataForPerimeter =
        {
            new object[] {new[] {new Point(6, 2), new Point(2, 2), new Point(2, 6), new Point(6, 6)}, 16}
        };

        private static readonly object[] TestDataForInscribedQuadrangle =
        {
            new object[] {new[] {new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(6, 7)}, false},
            new object[] {new[] {new Point(3, 2), new Point(5, 6), new Point(9, 6), new Point(11, 2)}, true},
        };

        private static readonly object[] TestDataForQuadrangleToInscribeCircle =
        {
            new object[] {new[] {new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(6, 7)}, false},
            new object[] {new[] {new Point(6, 2), new Point(2, 2), new Point(2, 6), new Point(6, 6)}, true},
        };

        private static readonly object[] IncorrectTestDataForQuadrangle =
        {
            new object[] {new Point[] {}},
            new object[] {new[] {new Point(2, 3), new Point(9, 2), new Point(3, 6)}},
            new object[] {new[] {new Point(2, 3), new Point(2, 6), new Point(2, 8), new Point(9, 2)}},
            new object[] {new[] {new Point(2, 7), new Point(5, 1), new Point(3, 2), new Point(10, 10)}},
        };

        #endregion

        /// <summary>
        /// <para>This test method verifies whether method Area() 
        /// returns correct area of quadrangle when input data in correct.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForArea))]
        public void Should_Calculate_Area_Of_Quadrangle(Point[] points, double result)
        {
            //Arrange
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = quadrangle.Area();
            //Assert
            Assert.AreEqual(expected, actual, 0.001, $"Values {expected} and {actual} are not equal!");
        }

        /// <summary>
        /// <para>This test method verifies whether method Perimeter() 
        /// returns correct perimeter of quadrangle when input data in correct.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForPerimeter))]
        public void Should_Calculate_Perimeter_Of_Quadrangle(Point[] points, double result)
        {
            //Arrange
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = quadrangle.Perimeter();
            //Assert
            Assert.AreEqual(expected, actual, 0.01, $"Values {expected} and {actual} are not equal!");
        }

        /// <summary>
        /// <para>This test method verifies whether method IsAbleToBeInscribedInCircle() 
        /// returns correct bool value when input data in correct.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForInscribedQuadrangle))]
        public void Should_Define_Whether_QuadrangleCanBeInscribedInCircle(Point[] points, bool result)
        {
            //Arrange
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = quadrangle.IsAbleToBeInscribedInCircle();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// <para>This test method verifies whether method IsAbleToInscribeCircleInside() 
        /// returns correct bool value when input data in correct.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForQuadrangleToInscribeCircle))]
        public void Should_Define_Whether_QuadrangleCanInscribeCircleIntoItself(Point[] points, bool result)
        {
            //Arrange
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = quadrangle.IsAbleToInscribeCircleInside();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// <para>This test method verifies whether method Area()
        /// throw exption when input data in not valid.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(IncorrectTestDataForQuadrangle))]
        public void Should_ThrowExeption_When_TestDataForAreaIsInvalid(Point[] points)
        {
            Assert.Throws<ArgumentException>(() => new Quadrangle(points).Area());
        }

        /// <summary>
        /// <para>This test method verifies whether method IsAbleToBeInscribedInCircle()
        /// throw exption when input data in not valid.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(IncorrectTestDataForQuadrangle))]
        public void Should_ThrowExeption_When_IsAbleToBeInscribedInCircle_TakesInvalidData(Point[] points)
        {
            Assert.Throws<ArgumentException>(() => new Quadrangle(points).IsAbleToBeInscribedInCircle());
        }

        /// <summary>
        /// <para>This test method verifies whether method IsAbleToInscribeCircleInside()
        /// throw exption when input data in not valid.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(IncorrectTestDataForQuadrangle))]
        public void Should_ThrowExeption_When_IsAbleToInscribeCircleInside_TakesInvalidData(Point[] points)
        {
            Assert.Throws<ArgumentException>(() => new Quadrangle(points).IsAbleToInscribeCircleInside());
        }
    }
}