using FullHomeWork1;
using NUnit.Framework;

namespace HomeWork1.Tests
{
    [TestFixture]
    public class SquareTest
    {
        [Test]
        public void TestSquare()
        {
            double side = 5;
            double ExpectedResult = 25;
            double ActualResult = Methods.Square(side);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
