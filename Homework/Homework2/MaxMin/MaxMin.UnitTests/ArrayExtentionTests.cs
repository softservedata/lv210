using System;
using NUnit.Framework;

namespace MaxMin.UnitTests
{
    [TestFixture]
    public class ArrayExtentionsTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
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
        [TestCase(new string[] { "ab", "abcd", "abc", "abcdef" }, "abcdef")]
        public void Should_Return_Max_Value_Of_AnArray_OfReferenceType(string[] array, string result)
        {
            //Test steps
            var expected = result;
            var actual = ArrayExtentions<string>.Max(array);      
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_MaxFunction_Return_Zero_If_ArrayOfValueType_IsNotInitialized()
        {
            //Precondition
            var array = new int[10];
            //Test steps
            var expected = 0;
            var actual = ArrayExtentions<int>.Max(array);
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_MaxFunction_Return_Zero_If_ArrayOfReferenceType_IsNotInitialized()
        {
            //Precondition
            var array = new string[10];
            //Check
            Assert.Throws<ArgumentException>(() => ArrayExtentions<string>.Max(array));
        }

        [Test]
        [TestCase(new int[] { })]
        public void Should_MaxFunction_Thrown_Exception_When_ArrayOfValueTypes_IsEmpty(int[] array)
        {
            //Check
            Assert.Throws<ArgumentException>(() => ArrayExtentions<int>.Max(array));
        }

        [Test]
        public void Should_MaxFunction_Thrown_Exception_When_ArrayOfReferenceTypes_IsEmpty()
        {
            //Preconditions
            var array = new string[] { };
            //Check
            Assert.Throws<ArgumentException>(() => ArrayExtentions<string>.Max(array));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
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
        [TestCase(new string[] { "ab", "abcd", "abc", "acb" }, "ab")]
        public void Should_Return_Min_Value_Of_AnArray_OfReferenceType(string[] array, string result)
        {
            //Test steps
            var expected = result;
            var actual = ArrayExtentions<string>.Min(array);
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_MinFunction_Return_Zero_If_Array_IsNotInitialized()
        {
            //Precondition
            var array = new int[10];
            //Test steps
            var expected = 0;
            var actual = ArrayExtentions<int>.Min(array);
            //Check
            Assert.AreEqual(expected, actual);
        }

        public void Should_MinFunction_Return_Zero_If_ArrayOfReferenceType_IsNotInitialized()
        {
            //Precondition
            var array = new string[10];
            //Check
            Assert.Throws<ArgumentException>(() => ArrayExtentions<string>.Min(array));
        }

        [Test]
        [TestCase(new int[] { })]
        public void Should_MinFunction_Thrown_Exception_When_ArrayOfValueTypes_IsEmpty(int[] array)
        {
            //Check
            Assert.Throws<ArgumentException>(() => ArrayExtentions<int>.Min(array));
        }

        public void Should_MinFunction_Thrown_Exception_When_ArrayOfReferenceTypes_IsEmpty()
        {
            //Preconditions
            var array = new string[] { };
            //Check
            Assert.Throws<ArgumentException>(() => ArrayExtentions<string>.Min(array));
        }
    }
}
