using System;
using NUnit.Framework;
using Read_Float;

namespace ReadFloat.UnitTest
{
    [TestFixture]
    public class RangeTest
    {
        [Test]
        public void IsNumbersInRangePositiveTest()
        {
            bool expected, actual;

            actual = Program.IsNumbersInRange(-5, 0, 5);
            expected = true;

            Assert.AreEqual(expected, actual, "Test fail!");
            Console.WriteLine("Positive Test Done!");
        }

        [Test]
        public void IsNumbersInRangeNegativeTest()
        {
            bool expected, actual;

            actual = Program.IsNumbersInRange(-6, 0, 5);
            expected = false;

            Assert.AreEqual(expected, actual, "Test fail!");
            Console.WriteLine("Negative Test Done!");
        }

        [Test]
        public void IsNumbersInRangeBoundaryValueTest()
        {
            bool expected, actual;

            actual = Program.IsNumbersInRange(-5, 5, -5);
            expected = true;

            Assert.AreEqual(expected, actual, "Test fail!");
            Console.WriteLine("Boundary Value Test Done!");
        }
    }
}
