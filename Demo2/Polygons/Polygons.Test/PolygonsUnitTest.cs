using System;
using NUnit.Framework;

namespace Polygons.Test
{
    [TestFixture]
    public class PolygonsUnitTest
    {
        ///Testing methods naming convention
        ///MethodName_ExpectedBehavior_StateUnderTest
        /// <summary>
        /// Method checks exception which thorws when inputed data is incorrect:
        /// 1) Inputed data is a string
        /// 2) Inputed data is a negative number
        /// 3) Inputed data is 0
        /// </summary>
        /// <param name="testData"></param>
        [TestCase("qwerty")]
        [TestCase("-8")]
        [TestCase("0")]
        public void ParseAtempt_ThrowsException_WhenInputedDataIsInvalid(string testData)
        {
            Assert.Throws<FormatException>(() => PolygonsActions.ParseAtempt(testData));
        }

        /// <summary>
        /// Method checks returned <double> data when inputed data is correct:
        /// </summary>
        /// <param name="testData"></param>
        [TestCase("8")]
        public void ParseAtempt_ReturnDoubleData_WhenInputedDataIsValid(string testData)
        {
            double expectedResult = PolygonsActions.ParseAtempt(testData);
            double actualResult = 8;

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Method check calculated perimeter of equilateral triangle
        /// </summary>
        /// <param name="sideLength"></param>
        /// <param name="testResult"></param>
        [TestCase(5, 15)]
        public void EquilateralTriangle_PerimeterCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double sideLength, double testResult)
        {
            double expectedResult = testResult;

            EquilateralTriangle testTriangle = new EquilateralTriangle(sideLength);
            double actualResult = testTriangle.PerimeterCalculation();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Method check calculated area of equilateral triangle
        /// </summary>
        /// <param name="sideLength"></param>
        /// <param name="testResult"></param>
        [TestCase(5, 10.8253)]
        public void EquilateralTriangle_AreaCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double sideLength, double testResult)
        {
            double precision = 0.0001;
            double expectedResult = testResult;

            EquilateralTriangle testTriangle = new EquilateralTriangle(sideLength);
            double actualResult = testTriangle.AreaCalculation();

            Assert.AreEqual(expectedResult, actualResult, precision);
        }

        /// <summary>
        /// Method check calculated perimeter of square
        /// </summary>
        /// <param name="sideLength"></param>
        /// <param name="testResult"></param>
        [TestCase(5, 20)]
        public void Square_PerimeterCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double sideLength, double testResult)
        {
            double expectedResult = testResult;

            Square testSquare = new Square(sideLength);
            double actualResult = testSquare.PerimeterCalculation();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Method check calculated area of square
        /// </summary>
        /// <param name="sideLength"></param>
        /// <param name="testResult"></param>
        [TestCase(5, 25)]
        public void Square_AreaCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double sideLength, double testResult)
        {
            double expectedResult = testResult;

            Square testSquare = new Square(sideLength);
            double actualResult = testSquare.AreaCalculation();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Method check calculated perimeter of pentagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <param name="testResult"></param>
        [TestCase(5, 25)]
        public void Pentagon_PerimeterCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double sideLength, double testResult)
        {
            double expectedResult = testResult;

            Pentagon testPentagon = new Pentagon(sideLength);
            double actualResult = testPentagon.PerimeterCalculation();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Method check calculated area of pentagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <param name="testResult"></param>
        [TestCase(5, 43.0119)]
        public void Pentagon_AreaCalculation_ReturnCorrectValue_WhenInputedDataIsValid(double sideLength, double testResult)
        {
            double precision = 0.0001;
            double expectedResult = testResult;

            Pentagon testPentagon = new Pentagon(sideLength);
            double actualResult = testPentagon.AreaCalculation();

            Assert.AreEqual(expectedResult, actualResult, precision);
        }
    }
}
