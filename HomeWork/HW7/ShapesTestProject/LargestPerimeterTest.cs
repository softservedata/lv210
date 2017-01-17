using hw7;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShapesTestProject
{
    [TestFixture]
    public class LargestPerimeterTest
    {
        private static readonly object[] TestDataForPerimeter =
      {
            new object[] { new List<Shape> { new Circle(10), new Square(600), new Circle(13), new Square(20)}, 2},
            new object[] { new List<Shape> { new Circle(600), new Square(6), new Circle(13), new Square(20)}, 1},
            new object[] { new List<Shape> { new Circle(10), new Square(60), new Circle(13), new Square(600)}, 4},
       };

        [Test, TestCaseSource(nameof(TestDataForPerimeter))]
        public void IndexOfLargestPerimeter(List<Shape> shapes, int expectedResult)
        {
            int actualResult = Functions.LargestPerimeter(shapes);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
