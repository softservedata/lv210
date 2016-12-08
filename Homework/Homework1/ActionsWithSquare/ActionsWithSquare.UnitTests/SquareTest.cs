using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ActionsWithSquare.UnitTests
{
    [TestFixture]
    public class SquareTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Constructor_ReceivesIncorrectSideValue_Throws(double value)
        {
            Assert.Throws<ArgumentException>(delegate { new Square(value); });
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(10, 100)]
        public void Area_ForSquare_ReturnCorrectValue(double value, double result)
        {
            //Precondition
            Square square = new Square(value);
            double precision = 0.0001;

            //Test steps;
            double expected = result;
            var actual = square.Area();

            //Check
            Assert.AreEqual(expected, actual, precision, "Error is found");
        }

        [Test]
        [TestCase(1, 4)]
        [TestCase(10, 40)]
        public void Perimeter_ForSquare_ReturnCorrectValue(double value, double result)
        {
            //Precondition
            Square square = new Square(value);
            double precision = 0.0001;

            //Test steps;
            double expected = result;
            var actual = square.Perimeter();

            //Check
            Assert.AreEqual(expected, actual, precision, "Error is found");
        }
    }
}
