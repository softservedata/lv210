using NUnit.Framework;
using ShapesProject;
using System.Collections.Generic;

namespace ShapesTests
{
   
    [TestFixture]
    public class FindMaximalPerimeterTests
    {
        [Test]
        public void FindMaximalPerimeterTest()
        {
            Shape[] testData = new Shape[] { new Circle("circle1", 0.01), new Square("square", 1), new Circle("circle1", 0.02) };
            List<Shape> shapes = new List<Shape>(testData);

            Shape actual=ShapesCreator.FindMaxShapeByPerimeter(shapes);
            Shape expected = shapes[1];
            Assert.AreEqual(expected, actual);
        }
    }
}
