using hw7;
using NUnit.Framework;

namespace ShapesTestProject
{
    [TestFixture]
    public class CircleTests
    {
        private static readonly object[] TestDataForArea =
       {
            new object[] {20, 1256.636},
            new object[] {50, 7853.975},
            new object[] {75, 17671.44375},
       };

        private static readonly object[] TestDataForPerimeter =
       {
            new object[] {20, 125.6636},
            new object[] {50, 314.159},
            new object[] {75, 471.2385},
       };

        [Test, TestCaseSource(nameof(TestDataForArea))]
        public void CalculateArea(double radius, double expectedResult)
        {
            Shape shape = new Circle(radius);
            double actualResult = shape.Area();
            var delta = 0.1;
            Assert.AreEqual(expectedResult, actualResult, delta);
        }

        [Test, TestCaseSource(nameof(TestDataForPerimeter))]
        public void CalculatePerimeter(double radius, double expectedResult)
        {
            Shape shape = new Circle(radius);
            double actualResult = shape.Perimeter();
            var delta = 0.1;
            Assert.AreEqual(expectedResult, actualResult, delta);
        }
    }
}
