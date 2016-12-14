using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace HierarchyOfGeometricShapes.UnitTests
{
    [TestFixture]
    public class QuadrangleTests
    {
        private static readonly object[] TestDataForArea =
        {
            new object[] {new[] {new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(6, 7)}, 5.5},
            new object[] {new[] {new Point(3, 2), new Point(5, 6), new Point(9, 6), new Point(11, 2)}, 24},
        };

        private static readonly object[] TestDataForPerimeter =
        {
            new object[] {new[] {new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(6, 7)}, 11.10},
            new object[] {new[] {new Point(3, 2), new Point(5, 6), new Point(9, 6), new Point(11, 2)}, 12.94},
        };

        private static readonly object[] TestDataForInscribedQuadrangle =
        {
            new object[] {new[] {new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(6, 7)}, false},
            new object[] {new[] {new Point(3, 2), new Point(5, 6), new Point(9, 6), new Point(11, 2)}, true},
        };

        private static readonly object[] IncorrectTestDataForQuadrangle =
        {
            new object[] {new[] {new Point(10, 5), new Point(4, 4), new Point(7, 1), new Point(4, 11)}},
        };

        [Test, TestCaseSource(nameof(TestDataForArea))]
        public void Should_Calculate_Correct_Area_Of_Quadrangle(Point[] points, double result)
        {
            //Arrange
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = quadrangle.Area();
            //Assert
            Assert.AreEqual(expected, actual, 0.001, $"Values {expected} and {actual} are not equal!");
        }

        [Test, TestCaseSource(nameof(TestDataForPerimeter))]
        public void Should_Calculate_Correct_Perimeter_Of_Quadrangle(Point[] points, double result)
        {
            //Arrange
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = quadrangle.Perimeter();
            //Assert
            Assert.AreEqual(expected, actual, 0.01, $"Values {expected} and {actual} are not equal!");
        }

        [Test, TestCaseSource(nameof(TestDataForInscribedQuadrangle))]
        public void Should_Defined_Whether_Quadrangle_Can_Be_Inscribed_In_Circle(Point[] points, bool result)
        {
            //Arrange
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = quadrangle.IsAbleToBeInscribedInCircle();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(nameof(IncorrectTestDataForQuadrangle))]
        public void Should_Throw_Exeption_When_Test_Data_Is_NotValid(Point[] points)
        {
            //Arrange
            var quadratangle = new Quadrangle(points);
            //Assert
            Assert.Throws<ArgumentException>(() => quadratangle.Area());
        }
    }
}
