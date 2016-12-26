using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Task2;

namespace ListUtilsTests
{
    [TestFixture]
    class ArrayListUtilsTestSuite
    {
        [Test]
        public void FindAllPositionsOfElementTest()
        {
            ArrayList numbers = new ArrayList(new []{1,2,2,5,7,2});
            List<int> expected = new List<int>(new[] {2, 3, 6});
            List<int> actual = ArrayListUtils.FindPositions(numbers, 2);

            CollectionAssert.AreEqual(expected,actual);

        }

        [Test]
        public void FindAllPositionsOfElementNegativeTest()
        {
            ArrayList testNumbers = new ArrayList(new[] { 1, 2, 3, 1, 5 });
            List<int> actual = ArrayListUtils.FindPositions(testNumbers, 6);

            CollectionAssert.IsEmpty(actual);

        }
        
        [TestCase(null, 1)]
        public void FindAllPositionsInvalidArgumentsTest(ArrayList testNumbers, int value)
        {
            Assert.Throws<ArgumentNullException>(() => ArrayListUtils.FindPositions(testNumbers, value));
        }

        [TestCase(new[] { 0, 1, 2, 3, 5 }, 2,new []  { 0, 1, 2})]
        [TestCase(new[] { -1, -1, -2, -3, -5 }, -2,new[] { -2,-3,-5 })]
        [TestCase(new[] { -1, -1, -2, 3, -5 }, 0, new[] { -1, -1, -2, -5 })]
        public void RemoveAllGreaterThanTest(int[] data, int upperBound,int[] result)
        {
            ArrayList testNumbers = new ArrayList(data);
            ArrayListUtils.RemoveAllGreaterThan(testNumbers,upperBound);
            ArrayList expected= new ArrayList(result);

            CollectionAssert.AreEqual(expected,testNumbers);

        }

        [TestCase(new[] { 0, 1, 2, 3, 5 }, 6)]
        [TestCase(new[] { -1, -1, -2, -3, -5 }, 0)]
        [TestCase(new[] { -1, -1, -2, 3, -5 }, 4)]
        public void RemoveAllGreaterThanNegativeTest(int[] list,int value)
        {
            ArrayList testNumbers = new ArrayList(list);
            ArrayListUtils.RemoveAllGreaterThan(testNumbers,value);
            ArrayList expected = testNumbers;

            CollectionAssert.AreEqual(expected, testNumbers);

        }
        
    }


   
}





