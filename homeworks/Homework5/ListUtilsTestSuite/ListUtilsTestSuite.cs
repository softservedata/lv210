using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Task2;

namespace ListUtilsTestSuite
{
    [TestFixture]
    public class ListUtilsTestSuite
    {
        [Test]
        public void FindAllPositionsOfElementTest()
        {
            List<int> numbers = new List<int>(new[] {1, 2, 2, 5, 7, 2});
            List<int> expected = new List<int>(new[] {1, 2, 5});
            List<int> actual = ListUtils.FindPositions(numbers, 2);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindAllPositionsOfElementNegativeTest()
        {
            List<int> testNumbers = new List<int>(new[] {1, 2, 3, 1, 5});
            List<int> actual = ListUtils.FindPositions(testNumbers, 6);

            CollectionAssert.IsEmpty(actual);
        }

        [TestCase(null, 1)]
        public void FindAllPositionsInvalidArgumentsTest(List<int> testNumbers, int value)
        {
            Assert.Throws<ArgumentNullException>(() => ListUtils.FindPositions(testNumbers, value));
        }
    }
}
