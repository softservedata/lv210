using MaxMin;
using System;
using NUnit.Framework;

namespace MaxMin.Test
{
    [TestFixture]
    public class MaxTest
    {
        [Test]
        public void TestMax()
        {
            int[] TestData = { 0, 2, 4 };
            int ExpectedResult = TestData[2];
            int ActualResult = Methods.Max(TestData);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
