using FullHomeWork1;
using NUnit.Framework;

namespace HomeWork1.Tests
{
    [TestFixture]
    public class PerimeterTest
    {
        [Test]
        public void TestPerimeter()
        {
            double side = 5;
            double ExpectedResult = 20;
            double ActualResult = Methods.Perimetr(side);
            Assert.AreEqual(ActualResult, ExpectedResult);
        }
    }
}
