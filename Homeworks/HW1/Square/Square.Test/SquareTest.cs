using NUnit.Framework;

namespace Square.Test
{
    [TestFixture]
    public class SquareTest
    {
        [Test]
        [TestCase(5, 20)]
        public void Perimeter_Calculation_Test(int length, int result)
        {
            int ExpectedResult = result;
            Square TestSquare = new Square(length);
            int ActualResult = TestSquare.Perimeter();
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(5, 25)]
        public void Area_Calculation_Test(int length, int result)
        {
            int ExpectedResult = result;
            Square TestSquare = new Square(length);
            int ActualResult = TestSquare.Area();
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
