
using Homework_8;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShapesOperationsTests
{
    [TestFixture]
    public class ShapesOperationsTestSuite
    {
        [TestCase(10.0, 100.0)]
        public void GetShapesInRangeTest(double lowerBound, double upperBound)
        {
            List<Shape> shapesList = new List<Shape>(new Shape[] { new Circle("circle1", 0.5), new Circle("circle2", 3), new Square("square 1", 5) });

            List<Shape> actual = ShapesOperations.GetShapesInRange(lowerBound, upperBound, shapesList);
            List<Shape> expected = new List<Shape>(new Shape[] { new Circle("circle2", 3), new Square("square 1", 5) });

            CollectionAssert.AreEqual(expected,actual);
        }

        [Test]
        public void RemoveAllByPerimeterTest()
        {
            List<Shape> shapesList = new List<Shape>(new Shape[] { new Circle("circle1", 0.5), new Circle("circle2", 3), new Square("square 1", 5) });

            ShapesOperations.RemoveAllByPerimeter(shapesList, 15.0);
            List<Shape> subset = new List<Shape>(new Shape[] { new Circle("circle2", 3), new Square("square 1", 5) });

            CollectionAssert.DoesNotContain(subset, shapesList);
        }

        [TestCase("a")]
        public void GetShapesWithSubstringTest(string searchString)
        {
            List<Shape> shapesList = new List<Shape>(new Shape[] { new Circle("circle1", 0.5), new Circle("circle2", 3), new Square("square 1", 5) });

            List<Shape> actual = ShapesOperations.GetShapesWithSubstring(searchString, shapesList);
            List<Shape> expected = new List<Shape>(new Shape[] { new Square("square 1", 5) });
                      
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

