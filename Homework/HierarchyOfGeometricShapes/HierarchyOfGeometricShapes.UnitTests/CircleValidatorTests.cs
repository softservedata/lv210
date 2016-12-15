using NUnit.Framework;

namespace HierarchyOfGeometricShapes.UnitTests
{
    /// <summary>
    /// <para>Class CircleValidatorTests contains unit tests for methods of class CircleValidator.</para>
    /// <para>Both positive and negative tests are implemented.</para>
    /// </summary>

    [TestFixture]
    public class CircleValidatorTests
    {
        private static readonly object[] TestDataForMainPointsOfCircle =
        {
            new object[] {new Point(3, 2), new Point(5, 6), true},
            new object[] {new Point(3, 2), new Point(0, 0), true},
            new object[] {new Point(3, 3), new Point(3, 3), false},
        };

        /// <summary>
        /// <para>This method verifies whether rules for validation work correctly</para>
        /// <para>It should return correct result for both valid and invalid data.</para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForMainPointsOfCircle))]
        public void Should_Verify_Points_Of_Circle(Point circlePoint, Point radiusPoint, bool result)
        {
            //Preconditions
            var validator = new CircleValidator();
            var circle = new Circle(circlePoint, radiusPoint);
            //Test steps
            var expected = result;
            var actual = validator.Validate(circle).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }
    }
}