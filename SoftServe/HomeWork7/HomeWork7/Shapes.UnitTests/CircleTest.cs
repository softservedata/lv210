using NUnit.Framework;

namespace Shapes.UnitTests
{
    [TestFixture]
    class CircleTest
    {
        // First object - object of type Circle
        // Second - area for this Circle
        private static readonly object[] DataForCircleArea =
        {
            new object[] { new Circle("circle1", 1), 3.1416},
            new object[] { new Circle("circle2", 4), 50.2654},
            new object[] { new Circle("circle3", 9.99), 313.5312}
        };

        // First object - object of type Circle
        // Second - perimetr for this Circle
        private static readonly object[] DataForCirclePerimetr =
        {
            new object[] { new Circle("circle1", 1), 6.2831},
            new object[] { new Circle("circle2", 4), 25.1327},
            new object[] { new Circle("circle3", 9.99), 62.7690}
        };

        [Test, TestCaseSource(nameof(DataForCircleArea))]
        public void ShouldCalculateCircleArea(Shape shape, double expectedArea)
        {
            var actualArea = shape.GetArea();
            var precision = 0.0001;

            Assert.AreEqual(expectedArea, actualArea, precision, "Values are not equal!");
        }

        [Test, TestCaseSource(nameof(DataForCirclePerimetr))]
        public void ShouldCalculateCirclePerimetr(Shape shape, double expectedPerimetr)
        {
            var actualPerimetr = shape.GetPerimetr();
            var precision = 0.0001;

            Assert.AreEqual(expectedPerimetr, actualPerimetr, precision, "Values are not equal!");
        }
    }
}
