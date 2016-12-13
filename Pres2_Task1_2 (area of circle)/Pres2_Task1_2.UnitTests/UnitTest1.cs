using System;
using NUnit.Framework;
using Pres2_Task1_2;

namespace Pres2_Task1_2.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            double radius = 4;
            double ExcpectedResult = 2 * Math.PI * 4;
            double ActualResult = Program.CircleLength(radius);
            Assert.AreEqual(ExcpectedResult, ActualResult);
        }
    }
}
