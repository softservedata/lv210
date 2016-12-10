using NUnit.Framework;

namespace MaxMin.UnitTests
{
    [TestFixture]
    public class ArrayExtentionsTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        public void Should_Return_Max_Value_Of_AnArray_OfValueType(int[] array, int result)
        {
            //Test steps
            var expected = result;
            var actual = ArrayExtentions<int>.Max(array);
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new string[] { "ab", "abcd", "abc" }, "abcd")]
        public void Should_Return_Max_Value_Of_AnArray_OfReferenceType(string[] array, string result)
        {
            //Test steps
            var expected = result;
            var actual = ArrayExtentions<string>.Max(array);      
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 1)]
        public void Should_Return_Min_Value_Of_AnArray_OfValueType(int[] array, int result)
        {
            //Test steps
            var expected = result;
            var actual = ArrayExtentions<int>.Min(array);
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new string[] { "ab", "abcd", "abc" }, "ab")]
        public void Should_Return_Min_Value_Of_AnArray_OfReferenceType(string[] array, string result)
        {
            //Test steps
            var expected = result;
            var actual = ArrayExtentions<string>.Min(array);
            //Check
            Assert.AreEqual(expected, actual);
        }
    }
}
