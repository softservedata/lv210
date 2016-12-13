using SumOrProduct;
using NUnit.Framework;

namespace SumOrProduct.Test
{
    [TestFixture]
    public class IsPosotiveTest
    {
        [Test]
        public void TestIsPositive()
        {
            int[] TestData = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int count = 5;
            bool ExpectedResult = true;
            bool ActualResult = Methods.IsPositive(TestData, count);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [Test]
        public void TestNotPositive()
        {
            int[] TestData = { 1, 2, -3, 4, 5, 6, 7, 8, 9, 10 };
            int count = 5;
            bool ExpectedResult = false;
            bool ActualResult = Methods.IsPositive(TestData, count);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
