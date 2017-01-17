using hw7;
using NUnit.Framework;

namespace ShapesTestProject
{
    [TestFixture]
    public class SquareTests
    {
        private static readonly object[] TestDataForArea =
       {
            new object[] {20, 400},
            new object[] {50, 2500},
            new object[] {70, 4900},
       };

        private static readonly object[] TestDataForPerimeter =
       {
            new object[] {20, 80},
            new object[] {50, 200},
            new object[] {70, 280},
       };

        [Test, TestCaseSource(nameof(TestDataForArea))]
        public void CalculateArea(double side, double expectedResult)
        {
            Shape shape = new Square(side);
            double actualResult = shape.Area();
            var delta = 0.1;
            Assert.AreEqual(expectedResult, actualResult, delta);
        }

        [Test, TestCaseSource(nameof(TestDataForPerimeter))]
        public void CalculatePerimeter(double side, double expectedResult)
        {
            Shape shape = new Square(side);
            double actualResult = shape.Perimeter();
            var delta = 0.1;
            Assert.AreEqual(expectedResult, actualResult, delta);
        }
    }
}
