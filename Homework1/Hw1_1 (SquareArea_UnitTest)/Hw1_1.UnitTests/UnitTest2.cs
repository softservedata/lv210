using System;
using NUnit.Framework;
using HW1_1;

namespace Hw1_1.UnitTests
{
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void TestArea()
        {
            double length = 10;
            double ExpectedResult = 100;
            double ActualResult = Program.AreaOfSquare(length);
            Assert.AreEqual(ActualResult, ExpectedResult);
        }
    }
}
