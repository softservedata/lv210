using NUnit.Framework;

namespace CalculateCountOfAppropriateSymbols.UnitTests
{
    [TestFixture]
    public class StringExtentionsTests
    {
        private static readonly object[] TestData =
        {
            new object[] {("aoie"), new char[] {'a','o','e','i'}, 4},
            new object[] {("UpUpUp"), new char[] {'a','o','e','i'}, 0},
            new object[] {("Unit test"), new char[] {'a','o','e','i'}, 2},
        }; 

        [Test, TestCaseSource(nameof(TestData))]
        public void Should_Return_CountOfSymbols_FromSpecifiedCollection(string inputedString,
                char[] collectionOfChars, int count)
        {
            //Test steps
            int expected = count;
            int actual = inputedString.FindCountOf(collectionOfChars);
            //Check
            Assert.AreEqual(expected, actual);
        }
    }
}
