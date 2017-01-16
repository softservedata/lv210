using System;
using NUnit.Framework;
using HW7;

namespace Shapes.Test
{
    [TestFixture]
    public class ShapeOperationsUnitTest
    {
        private const double precision = 0.0001;
        //private const double PRECISION = 0.0001;

        [TestCase("qwerty")]
        [TestCase("-8")]
        [TestCase("0")]
        public void ParseAtempt_ThrowsException_WhenInputedDataIsInvalid(string testData)
        {
            Assert.Throws<FormatException>(() => ShapeOperations.ParseAtempt(testData));
        }

        [TestCase("8", 8)]
        public void ParseAtempt_ReturnDoubleData_WhenInputedDataIsValid(string testData, double expectedResult)
        {
            double actualResult = ShapeOperations.ParseAtempt(testData);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(5, 20)]
        public void Square_PerimeterCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double sideLength, double expectedResult)
        {
            var testSquare = new Square(sideLength);
            var actualResult = testSquare.Perimeter();

            Assert.AreEqual(expectedResult, actualResult, precision);
        }

        [TestCase(5, 25)]
        public void Square_AreaCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double sideLength, double expectedResult)
        {
            var testSquare = new Square(sideLength);
            var actualResult = testSquare.Area();

            Assert.AreEqual(expectedResult, actualResult, precision);
        }

        [TestCase(5, 31.4159)]
        public void Circle_PerimeterCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double radius, double expectedResult)
        {
            var testCircle = new Circle(radius);
            var actualResult = testCircle.Perimeter();

            Assert.AreEqual(expectedResult, actualResult, precision);
        }

        [TestCase(5, 78.5398)]
        public void Circle_AreaCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double radius, double expectedResult)
        {
            var testCircle = new Circle(radius);
            var actualResult = testCircle.Area();

            Assert.AreEqual(expectedResult, actualResult, precision);
        }
    }
}
