using SumOrProduct;
using NUnit.Framework;

namespace SumOrProduct.Test
{
    [TestFixture]
    public class SumTest
    {
        [Test]
        public void TestSum()
        {
            int[] TestData = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            int count = 10;
            int ExpectedResult = 100;
            int ActualResult = Methods.Sum(TestData, count);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
