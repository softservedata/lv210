using hw8;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShapeOperationsTest
{
    [TestFixture]
    public class ShapeOperationsTestSuite
    {
        [TestCase(10.0, 100.0)]
        public void ShapesInRangeTest(double leftBoundary, double rightBoundary)
        {
            List<Shape> shapesList = new List<Shape>(new Shape[] { new Circle(3), new Square(5), new Circle(0.5) });

            List<Shape> actualResult = Functions.FindShapesWithAreaRange(shapesList, leftBoundary, rightBoundary);
            List<Shape> expectedResult = shapesList;
            expectedResult.RemoveAt(2);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestCase('a')]
        public void ShapesWithAppropriateSymbol(char symbol)
        {
            List<Shape> shapesList = new List<Shape>(new Shape[] { new Circle(3), new Square(5), new Square(0.5) });

            List<Shape> actualResult = Functions.FindShapesWithAppropriateSymbol(shapesList, symbol);
            List<Shape> expectedResult = shapesList;
            expectedResult.RemoveAt(0);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
