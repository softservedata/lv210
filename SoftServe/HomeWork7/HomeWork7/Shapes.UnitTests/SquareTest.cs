using NUnit.Framework;

namespace Shapes.UnitTests
{
    [TestFixture]
    public class SquareTest
    {
        // First object - object of type Square
        // Second - area for this Square
        private static readonly object[] DataForSquareArea =
        {
            new object[] { new Square("square1", 1), 1},
            new object[] { new Square("square2", 4), 16},
            new object[] { new Square("square3", 7.77), 60.3729}

        };

        // First object - object of type Square
        // Second - perimetr for this Square
        private static readonly object[] DataForSquarePerimetr =
        {
            new object[] { new Square("square1", 1), 4},
            new object[] { new Square("square2", 4), 16},
            new object[] { new Square("square3", 7.77), 31.08}

        };

        [Test, TestCaseSource(nameof(DataForSquareArea))]
        public void ShouldCalculateSquareAreaTest(Shape shape, double expectedArea)
        {
            var actualArea = shape.GetArea();
            var precision = 0.0001;

            Assert.AreEqual(expectedArea, actualArea, precision, "Values are not equal!");
        }

        [Test, TestCaseSource(nameof(DataForSquareArea))]
        public void ShouldCalculateSquarePerimetrTest(Shape shape, double expectedPerimetr)
        {
            var actualPerimetr = shape.GetArea();
            var precision = 0.0001;

            Assert.AreEqual(expectedPerimetr, actualPerimetr, precision, "Values are not equal!");
        }
    }
}
