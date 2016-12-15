using System;
using NUnit.Framework;
using TestApp;

namespace SmartCalc.UnitTests
{
    [TestFixture]
    public class SmartCalcTests
    {
        // Test for method FibonacciNumber
        [TestCase(8, 21)]
        [TestCase(1, 1)]
        public void ShouldCalculateFibonacciNumber(int fibonacciNumber, int result)
        {
            SmartCalculator calc = new SmartCalculator();
            var actual = calc.FibonacciNumber(fibonacciNumber);
            var expected = result;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldThrowException()
        {
            SmartCalculator calc = new SmartCalculator();
            Assert.Throws<ArgumentException>(delegate { calc.FibonacciNumber(-1); });
        }

        // Test for method Factorial
        [TestCase(3, 6)]
        [TestCase(1, 1)]
        public void ShouldCalculateNumberFactorial(int number, int result)
        {
            SmartCalculator calc = new SmartCalculator();
            var actual = calc.Factorial(number);
            var expected = result;
            Assert.AreEqual(expected, actual);
        }

        // Test for method Pow
        [TestCase(2, 5, 32)]
        [TestCase(2, 0, 1)]
        public void ShouldCalculateNumberPow(double number, int pow, int result)
        {
            SmartCalculator calc = new SmartCalculator();
            var actual = calc.Pow(number, pow);
            var expected = result;
            Assert.AreEqual(expected, actual);
        }

        // Test for method MaxOfThreeNumbers
        [TestCase(2, 5, 10, 10)]
        [TestCase(15, 5, 2, 15)]
        [TestCase(2, 12, 10, 12)]
        public void ShouldFindMaxOfThreeDigits(double number1, double number2, double number3, double result)
        {
            SmartCalculator calc = new SmartCalculator();
            var actual = calc.MaxOfThreeNumbers(number1, number2, number3);
            var expected = result;
            Assert.AreEqual(expected, actual);
        }

        // Test for method IsNumberInRange
        [TestCase(2, 4, 7, false)]
        [TestCase(5, 4, 7, true)]
        [TestCase(-2, 4, 7, false)]
        public void ShouldVerifyNumberIsInRange(double number, int low, int high, bool result)
        {
            SmartCalculator calc = new SmartCalculator();
            bool actual = calc.IsNumberInRange(number, low, high);
            bool expected = result;
            Assert.AreEqual(expected, actual);
        }
    }
}
