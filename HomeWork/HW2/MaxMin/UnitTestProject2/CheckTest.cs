using MaxMin;
using NUnit.Framework;

namespace MaxMin.Test
{
    [TestFixture]
    public class CheckTest
    {
        [Test]
        public void TestPositiveCheck()
        {
            int[] TestData = { 2, 2, 2 };
            bool ExpectedResult = false;
            bool ActualResult = Methods.Check(TestData);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [Test]
        public void TestNegativeCheck()
        {
            int[] TestData = { 2, 3, 2 };
            bool ExpectedResult = true;
            bool ActualResult = Methods.Check(TestData);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
