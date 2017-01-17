using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace LINQAndFilesWithShapes.UnitTest
{
    [TestFixture]
    public class ShapeActionsTest
    {
        // First - current list of shapes
        // Second - perimetr
        // Third - list of shapes with perimetr less than appropriate perimetr
        private static readonly object[] TestDataForPerimetr =
        {
            new object[] { new List<Shape> { new Circle("circle1", 4), new Square("square1", 4) }, 10, new List<Shape> { } },
            new object[] { new List<Shape> { new Circle("circle1", 1), new Square("square1", 4) }, 10, new List<Shape> { new Circle("circle1", 1) } },
            new object[] { new List<Shape> { new Circle("circle1", 0.5), new Square("square1", 2) }, 10, new List<Shape> { new Circle("circle1", 0.5), new Square("square1", 2) } }
        };

        [TestCaseSource(nameof(TestDataForPerimetr))]
        public void ShouldRemoveShapesWithPerimetrLessThan(List<Shape> listOfShapes, double perimetr, List<Shape> expectedList)
        {
            ShapeActions shapeActions = new ShapeActions();

            var actualList = shapeActions.GetShapesWithPerimetrLessThan(listOfShapes, perimetr);

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
