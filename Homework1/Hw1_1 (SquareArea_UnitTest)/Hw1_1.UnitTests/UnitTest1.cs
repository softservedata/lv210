using System;
using NUnit.Framework;
using HW1_1;

namespace Hw1_1.UnitTests
{
    [TestFixture]
    public class PerimeterTesting
    {
        [Test]
        public void PerimeterTest ()
        {
            double length = 10;
            double ExpectedResult = 40;
            double ActualResult = Program.PerimeterOfSquare(length);
            Assert.AreEqual(ActualResult, ExpectedResult);
        }
    }
}
