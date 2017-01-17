using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;
using LINQ;
using Shapes;

namespace LINQ.UnitTests
{
    [TestFixture]
    public class ShapesUtilityClassTests
    {
        [Test]
        [TestCase(10, 100)]
        public void GetAllWithAreaInRange_Should_Return_ShapesList_Which_Areas_IsIn_Proper_Range(double lowerLimit, double upperLimit)
        {
            IList<Shape> shapes = new List<Shape> { new Circle(3), new Square(9), new Square(12) };

            IList<Shape> actual = shapes.GetAllWithAreaInRange(lowerLimit, upperLimit).ToList();
            IList<Shape> expected = new List<Shape> { new Circle(3), new Square(9) };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase('a')]
        public void GetAllWithProperCharInName_Should_Return_ShapesList_Which_Names_Has_Proper_Char(char desireChar)
        {
            IList<Shape> shapes = new List<Shape> { new Circle(3), new Square(9), new Square(12) };

            IList<Shape> actual = shapes.GetAllWithProperCharInName(desireChar);
            IList<Shape> expected = new List<Shape> { new Square(9), new Square(12) };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(5)]
        public void RemoveAllWithPerimeterLessThanLimit_Should_Remove_Shapes_With_Perimeter_LessThan_Limit(double limit)
        {
            IList<Shape> shapes = new List<Shape> { new Circle(0.5), new Circle(2), new Square(1), new Square(9) };

            shapes.RemoveAllWithPerimeterLessThanLimit(limit);
            IList<Shape> expected = new List<Shape> { new Circle(2), new Square(9) };

            CollectionAssert.AreEqual(expected, shapes);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void CreateShape_WithIncorrectParameters_Should_Throw_Exeptios_ArgumentOutOfRangeException(double param)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Square(param));
        }
    }
}
