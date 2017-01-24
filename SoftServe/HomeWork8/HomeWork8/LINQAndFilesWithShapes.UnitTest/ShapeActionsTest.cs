using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace LINQAndFilesWithShapes.UnitTest
{
    [TestFixture]
    public class ShapeActionsTest
    {
        // First - current list of shapes.
        // Second - appropriate symbol.
        // Third - list of shapes which contains appropriate symbol in name. 
        private static readonly object[] TestDataForSymbol =
        {
            new object[] { new List<Shape> { new Circle(4), new Square(4) }, 'C', new List<Shape> { new Circle(4) } },
            new object[] { new List<Shape> { new Circle(1), new Square(4) }, 't', new List<Shape> { } },
            new object[] { new List<Shape> { new Circle(0.5), new Square(2) }, 'e', new List<Shape> { new Circle(0.5), new Square(2) } }
        };

        // First - current list of shapes.
        // Second - lower boundary.
        // Third - upper boundary.
        // Fourth - list of shapes which areas belongs to range. 
        private static readonly object[] TestDataForShapesAreaInRange =
        {
            new object[] { new List<Shape> { new Circle(4), new Square(4) }, 10, 100, new List<Shape> { new Circle(4), new Square(4) } },
            new object[] { new List<Shape> { new Circle(1), new Square(3) }, 20, 50, new List<Shape> { } },
            new object[] { new List<Shape> { new Circle(0.2), new Square(5) }, 5, 30, new List<Shape> { new Square(2) } }
        };

        [TestCaseSource(nameof(TestDataForSymbol))]
        public void ShouldFindShapesWithAppropriateSymbolInName(List<Shape> listOfShapes, char appropriateChar, List<Shape> expectedList)
        {
            var actualList = ShapeActions.FindShapesWithSymbol(listOfShapes, appropriateChar);

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestCaseSource(nameof(TestDataForShapesAreaInRange))]
        public void ShouldFindShapesInRangeByArea(List<Shape> listOfShapes, double lowerBoundary, double upperBoundary, List<Shape> expectedList)
        {
            var actualList = ShapeActions.FindShapesFromRange(listOfShapes, lowerBoundary, upperBoundary);

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
