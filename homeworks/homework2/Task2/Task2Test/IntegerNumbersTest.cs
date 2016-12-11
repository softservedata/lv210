using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;
namespace Task2.Tests
 {
    [TestFixture]
    public class IntegerNumbersTest
    {
        
        [Test]
        [TestCase(new int[] { 0, 5, 6})]

                public void FindMaxPositiveNumbersTest(int[] array)
        {
            int expected = 6;
            int actual=IntegerNumbers.FindMax(array);
            Assert.AreEqual(expected, actual);

        }

        [Test]
        [TestCase(new int[] { -1, -5, -2 })]
        public void FindMaxWithNegativeNumbersTest(int[] array)
        {
            int expected = -1;
            int actual = IntegerNumbers.FindMax(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -1, 5, -2 })]
        public void FindMaxWithPositiveAndNegativeNumbersTest(int[] array)
        {
            int expected = 5;
            int actual = IntegerNumbers.FindMax(array);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(new int[] { 1, 5, 2 })]
        public void FindMinWithPositiveNumbersTest(int[] array)
        {
            int expected = 1;
            int actual=IntegerNumbers.FindMin(array);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(new int[] { -1, -5, -2 })]
        public void FindMinWithNegativeNumbersTest(int[] array)
        {
            int expected = -5;
            int actual = IntegerNumbers.FindMin(array);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(new int[] {1, -5, 2})]
        public void FindMinWithPositiveAndNegativeNumbersTest(int[] array)
        {
            int expected = -5;
            int actual = IntegerNumbers.FindMin(array);
            Assert.AreEqual(actual, expected);
        }
    }
}
