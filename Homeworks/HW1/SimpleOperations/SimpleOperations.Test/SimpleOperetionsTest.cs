using NUnit.Framework;
using System;

namespace SimpleOperations.Test
{
    [TestFixture]
    public class SimpleOperetionsTest
    {
        [Test]
        //Equivalance partition: using 3 ranges for test data
        //Positive numbers
        //Negative numbers
        //NULLs
        /*Test cases with positive numbers*/
        [TestCase]
        public void PositiveAddTest()
        {
            MathOperations MathObject = new MathOperations();
            int ActualResult = MathObject.Add(10, 5);
            Assert.AreEqual(15, ActualResult);           
        }
        [TestCase]
        public void PositiveSubtractTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Subtract(10, 1);
            Assert.AreEqual(9, result);
        }
        [TestCase]
        public void PositiveProductTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Product(5, 4);
            Assert.AreEqual(20, result);
        }
        [TestCase]
        public void PositiveDivisionTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Division(20, 4);
            Assert.AreEqual(5, result);
        }

        /*Test cases with negative numbers*/
        [TestCase]
        public void NegativeAddTest()
        {
            MathOperations MathObject = new MathOperations();
            int ActualResult = MathObject.Add(-10, -5);
            Assert.AreEqual(-15, ActualResult);
        }
        [TestCase]
        public void NegativeSubtractTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Subtract(-10, -1);
            Assert.AreEqual(-9, result);
        }
        [TestCase]
        public void NegativeProductTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Product(-5, -4);
            Assert.AreEqual(20, result);
        }
        [TestCase]
        public void NegativeDivisionTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Division(-20, -4);
            Assert.AreEqual(5, result);
        }
        /*Test cases with NULL numbers*/
        [TestCase]
        public void NullAddTest()
        {
            MathOperations MathObject = new MathOperations();
            int ActualResult = MathObject.Add(0, 5);
            Assert.AreEqual(5, ActualResult);
        }
        [TestCase]
        public void NullSubtractTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Subtract(5, 0);
            Assert.AreEqual(5, result);
        }
        [TestCase]
        public void NullProductTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Product(5, 0);
            Assert.AreEqual(0, result);
        }
        [TestCase]
        public void NullDivisionTest()
        {
            MathOperations MathObject = new MathOperations();
            int result = MathObject.Division(0, 4);
            Assert.AreEqual(0, result);
        }
        /*Exception test cases*/
        [TestCase]
        public void Should_Throw_Exception_When_Division_By_Zero()
        {
            MathOperations MathObject = new MathOperations();
            Assert.Throws<DivideByZeroException>(() => MathObject.Division(4, 0));
        }
    }
}
