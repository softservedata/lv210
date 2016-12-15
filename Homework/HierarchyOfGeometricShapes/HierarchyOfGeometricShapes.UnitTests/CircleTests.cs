using System;
using NUnit.Framework;

namespace HierarchyOfGeometricShapes.UnitTests
{
    /// <summary>
    /// <para>Class CircleTests contains unit tests for methods of class Circle.</para>
    /// <para>Both positive and negative tests are implemented.</para>
    /// </summary>

    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CircleTests
    {
        #region TestData

        private static readonly object[] TestDataForArea =
        {
            new object[] {new Point(2, 2), new Point(0, 2), 12.56, 0.01},
        };

        private static readonly object[] TestDataForPerimeter =
        {
            new object[] {new Point(2, 3), new Point(0, 2), 14.04, 0.01},
        };

        private static readonly object[] TestDataForRadius =
        {
            new object[] {new Point(2, 2), new Point(0, 2), 2, 0.01},
        };

        private static readonly object[] TestDataForPointInsideCircle =
        {
            new object[] {new Point(2, 3), new Point(0, 2), new Point(1, 3), true},
            new object[] {new Point(2, 3), new Point(0, 2), new Point(10, 10), false},
            new object[] {new Point(2, 3), new Point(0, 2), new Point(2, 5), true},
        };

        private static readonly object[] IncorrectTestDataForCircle =
        {
            new object[] {new Point(), new Point()},
        };

        private static readonly object[] IncorrectTestDataForIsInsideCircle =
        {
            new object[] {new Point(), new Point(), new Point()},
        };

        #endregion

        /// <summary>
        /// <para>This test method verifies whether method Area() 
        /// returns correct area of circle when input data in correct.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForArea))]
        public void Should_Calculate_Area_Of_Circle(Point centerPoint, Point radiusPoint,
            double result, double tolerance)
        {
            //Arrange
            var circle = new Circle(centerPoint, radiusPoint);
            //Act
            var expected = result;
            var actual = circle.Area();
            //Assert
            Assert.AreEqual(expected, actual, tolerance, $"Values {expected} and {actual} are not equal!");
        }

        /// <summary>
        /// <para>This test method verifies whether method Perimeter() 
        /// returns correct perimeter of circle when input data in correct.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForPerimeter))]
        public void Should_Calculate_Perimeter_Of_Circle(Point centerPoint, Point radiusPoint,
            double result, double tolerance)
        {
            //Arrange
            var circle = new Circle(centerPoint, radiusPoint);
            //Act
            var expected = result;
            var actual = circle.Perimeter();
            //Assert
            Assert.AreEqual(expected, actual, tolerance, $"Values {expected} and {actual} are not equal!");
        }

        /// <summary>
        /// <para>This test method verifies whether method Radius() 
        /// returns correct radius of circle when input data in correct.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForRadius))]
        public void Should_Calculate_Radius_Of_Circle(Point centerPoint, Point radiusPoint,
            double result, double tolerance)
        {
            //Arrange
            var circle = new Circle(centerPoint, radiusPoint);
            //Act
            var expected = result;
            var actual = circle.Radius();
            //Assert
            Assert.AreEqual(expected, actual, tolerance, $"Values {expected} and {actual} are not equal!");
        }

        /// <summary>
        /// <para>This test method verifies whether method IsInsideCircle()
        /// returns correct bool value when input data in correct.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForPointInsideCircle))]
        public void Should_Define_Whether_Point_IsInside_Of_Circle(Point centerPoint, Point radiusPoint,
            Point searchingPoint, bool result)
        {
            //Arrange
            var circle = new Circle(centerPoint, radiusPoint);
            //Act
            var expected = result;
            var actual = circle.IsInsideCircle(searchingPoint);
            //Assert
            Assert.AreEqual(expected, actual, $"Values {expected} and {actual} are not equal!");
        }

        /// <summary>
        /// <para>This test method verifies whether method Area()
        /// throw exption when input data in not valid.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(IncorrectTestDataForCircle))]
        public void Should_ThrowExeption_When_TestDataForAreaIsInvalid(Point centerPoint, Point radiusPoint)
        {
            Assert.Throws<ArgumentException>(() => new Circle(centerPoint, radiusPoint).Area());
        }

        /// <summary>
        /// <para>This test method verifies whether method Perimeter()
        /// throw exption when input data in not valid.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(IncorrectTestDataForCircle))]
        public void Should_ThrowExeption_When_TestDataForPerimeterIsInvalid(Point centerPoint, Point radiusPoint)
        {
            Assert.Throws<ArgumentException>(() => new Circle(centerPoint, radiusPoint).Perimeter());
        }

        /// <summary>
        /// <para>This test method verifies whether method Radius()
        /// throw exption when input data in not valid.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(IncorrectTestDataForCircle))]
        public void Should_ThrowExeption_When_TestDataForRadiusIsInvalid(Point centerPoint, Point radiusPoint)
        {
            Assert.Throws<ArgumentException>(() => new Circle(centerPoint, radiusPoint).Radius());
        }

        /// <summary>
        /// <para>This test method verifies whether method IsInsideCircle()
        /// throw exption when input data in not valid.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(IncorrectTestDataForIsInsideCircle))]
        public void Should_ThrowExeption_When_IsInsideCircle_TakesInvalidData(Point centerPoint,
            Point radiusPoint, Point pointToVerify)
        {
            Assert.Throws<ArgumentException>(() => new Circle(centerPoint, radiusPoint).IsInsideCircle(pointToVerify));
        }
    }
}
