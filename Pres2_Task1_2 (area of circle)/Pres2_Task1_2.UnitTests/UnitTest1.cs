using System;
using NUnit.Framework;
using Pres2_Task1_2;

namespace Pres2_Task1_2.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]

        public void CircleLengthTest()
        {
            double delta = 0.001;
            double radius = 4;
            double ExcpectedResult = 25.1327;
            double ActualResult = Program.CircleLength(radius);
            Assert.AreEqual(ExcpectedResult, ActualResult, delta);
        }
        [Test]
        public void CircleAreaTest()
        {
            double delta = 0.001;
            double radius = 4;
            double ExcpectedResult = 50.2654;
            double ActualResult = Program.CircleArea(radius);
            Assert.AreEqual(ExcpectedResult, ActualResult, delta);
        }
        [Test]
        public void SphereVolumeTest()
        {
            double delta = 0.001;
            double radius = 4;
            double ExcpectedResult = 201.0619;
            double ActualResult = Program.SphereVolume(radius);
            Assert.AreEqual(ExcpectedResult, ActualResult, delta);
        }
    }
}
