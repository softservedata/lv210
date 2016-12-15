using NUnit.Framework;

namespace HierarchyOfGeometricShapes.UnitTests
{
    /// <summary>
    /// <para>Class QuadrangleValidatorTests contains unit tests for methods of class QuadrangleValidator.</para>
    /// <para>Both positive and negative tests are implemented.</para>
    /// </summary>

    [TestFixture]
    public class QuadrangleValidatorTests
    {
        private static readonly object[] TestDataForCountOfPoints =
        {
            new object[] {new Point[] {}, false},
            new object[] {new[] {new Point(2, 3), new Point(9, 2), new Point(3, 6)}, false},
            new object[] {new[] {new Point(6, 2), new Point(2, 2), new Point(2, 6), new Point(6, 6)}, true},
            new object[] {new[] {new Point(6, 2), new Point(2, 2), new Point(2, 6), new Point(4, 8), new Point(6, 6)}, false},
        };

        private static readonly object[] TestDataForArrayOfPoints =
        {
            new object[] {new[] {new Point(6, 2), new Point(2, 2), new Point(2, 6), new Point(6, 6)}, true},
            new object[] {new[] {new Point(2, 2), new Point(2, 4), new Point(2, 6), new Point(6, 6)}, false},
            new object[] {new[] {new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(8, 2)}, false},
        };

        /// <summary>
        /// <para>This method verifies whether the rule for validation count of points wokrs correctly.</para>
        /// <para>It should return correct result for both valid and invalid data.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForCountOfPoints))]
        public void Should_Verify_Count_Of_Points_Arrray(Point [] points, bool result)
        {
            //Arrange
            var validator = new QuadrangleValidator();
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = validator.Validate(quadrangle).IsValid;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// <para>This method verifies whether the rule for 
        /// validation sequence and possitions of points wokrs correctly.</para>
        /// <para>It should return correct result for both valid and invalid data.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForArrayOfPoints))]
        public void Should_Verify_Arrray_Of_Points(Point[] points, bool result)
        {
            //Arrange
            var validator = new QuadrangleValidator();
            var quadrangle = new Quadrangle(points);
            //Act
            var expected = result;
            var actual = validator.Validate(quadrangle).IsValid;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}