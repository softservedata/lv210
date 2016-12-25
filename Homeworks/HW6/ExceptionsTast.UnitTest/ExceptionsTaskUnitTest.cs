using System;
using NUnit.Framework;
using ExceptionsTask;

namespace ExceptionsTast.UnitTest
{
    [TestFixture]
    public class ExceptionsTaskUnitTest
    {
        public const int start = 1;
        public const int end = 100;

        [TestCase(-8, false)]
        [TestCase(0, false)]
        [TestCase(200, false)]
        public void IsValueInRange_ShouldReturnFalse_WhenValueOutOfRange(int testValue, bool expectedResult)
        {
            bool actualResult = Program.IsValueInRange(start, end, testValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1, true)]
        [TestCase(100, true)]
        [TestCase(50, true)]
        public void IsValueInRange_ShouldReturnTrue_WhenValueIsInRange(int testValue, bool expectedResult)
        {
            bool actualResult = Program.IsValueInRange(start, end, testValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("string")]
        public void ReadNumber_ShouldThowException_WhenValuesIsInvalid(string inputedData)
        {
            Assert.Throws<FormatException>(() => Program.ReadNumber(inputedData));
        }

        [TestCase("-8")]
        [TestCase("0")]
        [TestCase("200")]
        public void ReadNumber_ShouldThowException_WhenValuesIsOutOfRange(string inputedData)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.ReadNumber(inputedData));
        }
    }
}
