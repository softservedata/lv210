using System;
using NUnit.Framework;
using ReadNumberExceptions;

namespace ReadNumberExceptions.UnitTest
{
    [TestFixture]
    public class ReadNumberUnitTest
    {
        [TestCase(100)]
        public void ReadNumber_ShouldThrowException_WhenDataIsOutOfRange(double testData)
        {
            Assert.Throws<ArgumentOutOfRangeException> (() => Program.ReadNumber(testData, 1, 10));
        }
        [Test]
        public void ReadNumber_ShouldThrowException_WhenDataIsInvali()
        {
            Assert.Throws<FormatException>(() => Program.IsEnteredNumber("str"));
        }
    }
}
