using MaxMin;
using NUnit.Framework;

namespace MaxMin.Test
{
    [TestFixture]
    public class MinTest
    {
        [Test]
        public void TestMin()
        {
            int[] TestData = { -2, 2, 4 };
            int ExpectedResult = TestData[0];
            int ActualResult = Methods.Min(TestData);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
