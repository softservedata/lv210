using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_C;

namespace Task_C.Tests
{
   [TestFixture]
   public class IntegerNumbersTest
    {
        [Test]
        [TestCase(new int[] { 1,2,3,4,5,6,7,8,9,1},5)]
        public void IsPositiveTest(int [] array,int elementsToCheck)
        {
            bool actual = IntegerNumbers.IsPositive(array, elementsToCheck);
            Assert.IsTrue(actual);
        }

        [Test]
        [TestCase(new int[] { -1, 2, 3, 4, 5, 6, 7, 8, 9, 1 }, 5)]
        public void IsPositiveNegativeTest(int[] array, int elementsToCheck)
        {
            bool actual = IntegerNumbers.IsPositive(array, elementsToCheck);
            Assert.IsFalse(actual);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 }, 1, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 }, 5,ExpectedResult = 15)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 }, 10, ExpectedResult = 46)]
        public int CalcSumOfElementsTest(int[] array, int elementsToCalc)
        {
         
            return  IntegerNumbers.CalcSumOfElements(elementsToCalc,array);
            
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 2, 2, 3, 2, 1 }, 1,ExpectedResult =2880)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 2, 2, 3, 2, 1 }, 5, ExpectedResult =24)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 2, 2, 3, 2, 1 }, 10, ExpectedResult = 1)]
        public int CalcLastElementsProductTest(int[] array, int elementsToCalc)
        {
        
            return IntegerNumbers.CalcLastElementsProduct(elementsToCalc, array);
          
        }

        [Test]
        [TestCase("1,2,3,4,5,6,7,8,9,0")]
        public void ConvertToIntegerArray(string input)
        {
            int[] expected = { 1, 2, 3, 4, 5,6,7,8,9,0 };
            int[] actual = IntegerNumbers.ConvertToIntegerArray(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
