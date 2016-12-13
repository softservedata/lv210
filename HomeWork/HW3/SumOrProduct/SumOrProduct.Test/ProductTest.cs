using SumOrProduct;
using NUnit.Framework;

namespace SumOrProduct.Test
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void TestProduct()
        {
            int[] TestData = { 10, 10, 10, 10, 10, 10, 10, 0, 10, 10 };
            int count = 5;
            int ExpectedResult = 0;
            int ActualResult = Methods.Product(TestData, count);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
