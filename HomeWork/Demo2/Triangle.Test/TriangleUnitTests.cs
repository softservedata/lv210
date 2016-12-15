using NUnit.Framework;
using Demo2;

namespace TriangleTest
{
    [TestFixture]
    public class TriangleUnitTests
    {
        private static readonly object[] TestDataForSquare =
       {
            new object[] { new[] { new Dot(1, 1), new Dot(5, 1), new Dot(2.5, 8)}, 14},
            new object[] { new[] { new Dot(1, 2), new Dot(-2, 3), new Dot(4, 4)}, 4.5},
            new object[] { new[] { new Dot(2, 7), new Dot(7, 2), new Dot(-10, 0)}, 47.5},
       };
        private static readonly object[] TestDataForPerimeter =
      {
            new object[] { new[] { new Dot(1, 1), new Dot(5, 1), new Dot(2.5, 8)}, 18.6},
            new object[] { new[] { new Dot(1, 2), new Dot(-2, 3), new Dot(4, 4)}, 12.85},
            new object[] { new[] { new Dot(2, 7), new Dot(7, 2), new Dot(-10, 0)}, 38},
      };
        private static readonly object[] TestDataForDotContainsMethod =
      {
            new object[] { new[] { new Dot(1, 1), new Dot(5, 1), new Dot(2.5, 8)}, new Dot(2.5, 3), true},
            new object[] { new[] { new Dot(4, 2), new Dot(-2, 3), new Dot(8, 4)}, new Dot(20.5, 3), false},
      };
        private static readonly object[] TestDataForValidation =
      {
            new object[] { new[] { new Dot(1, 1), new Dot(5, 1), new Dot(2.5, 8)}, true},
            new object[] { new[] { new Dot(2, 2), new Dot(3, 3), new Dot(4, 4)}, false},
      };

        [Test, TestCaseSource(nameof(TestDataForSquare))]
        public void CalculateSquare(Dot[] dots, double ExpectedResult)
        {
            Triangle triangle = new Triangle(dots);
            double ActualResult = triangle.Square();
            var delta = 0.000001;
            Assert.AreEqual(ExpectedResult, ActualResult, delta);
        }

        [Test, TestCaseSource(nameof(TestDataForPerimeter))]
        public void CalculatePerimeter(Dot[] dots, double ExpectedResult)
        {
            Triangle triangle = new Triangle(dots);
            double ActualResult = triangle.Perimeter();
            var delta = 0.1;
            Assert.AreEqual(ExpectedResult, ActualResult, delta);
        }

        [Test, TestCaseSource(nameof(TestDataForDotContainsMethod))]
        public void CalculateIfDotBelongsToTriangle(Dot[] dots, Dot dot, bool ExpectedResult)
        {
            Triangle triangle = new Triangle(dots);
            bool ActualResult = triangle.DoesContainDot(dot);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [Test, TestCaseSource(nameof(TestDataForValidation))]
        public void CheckForValidation(Dot[] dots, bool ExpectedResult)
        {
            Triangle triangle = new Triangle(dots);
            bool ActualResult = triangle.IsValid();
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
