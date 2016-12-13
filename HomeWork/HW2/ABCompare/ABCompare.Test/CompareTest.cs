using ABCompare;
using NUnit.Framework;

namespace ABCompare.Test
{
    [TestFixture]
    public class CompareTest
    {
        [TestCase (10, 20)]
        public void TestPositiveSame(int a, int b)
        {
            bool ExpectedResult = true;
            bool ActualResult = Methods.Compare(a, b);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(9, 20)]
        public void TestPositiveNotSame(int a, int b)
        {
            bool ExpectedResult = false;
            bool ActualResult = Methods.Compare(a, b);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(-10, -20)]
        public void TestNegativeSame(int a, int b)
        {
            bool ExpectedResult = true;
            bool ActualResult = Methods.Compare(a, b);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(-9, -20)]
        public void TestNegativeNotSame(int a, int b)
        {
            bool ExpectedResult = false;
            bool ActualResult = Methods.Compare(a, b);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(-8, 10)]
        public void TestDifferentSame(int a, int b)
        {
            bool ExpectedResult = true;
            bool ActualResult = Methods.Compare(a, b);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(-8, 11)]
        public void TestDifferentNotSame(int a, int b)
        {
            bool ExpectedResult = false;
            bool ActualResult = Methods.Compare(a, b);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
