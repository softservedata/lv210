using System;
using NUnit.Framework;

namespace NumbersInRange.UnitTests
{
    [TestFixture]
    public class NumberTests
    {
        [Test]
        [TestCase(-5, 5, 0, ExpectedResult = true)]
        [TestCase(-5, 5, 9.5f, ExpectedResult = false)]
        [TestCase(-5, 5, 5, ExpectedResult = true)]
        [TestCase(-5, 5, -5, ExpectedResult = true)]
        [TestCase(-5, 5, -5.0001f, ExpectedResult = false)]
        [TestCase(-5, 5, 5.0001f, ExpectedResult = false)]
        public bool Should_Return_True_When_Number_IsInRange(float a, float b, float value)
        {
            //Preconditions
            var number = new Number<float>(value);
            //Check
            return number.IsInRange(a, b);
        }
    }
}
