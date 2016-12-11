using System;
using NUnit.Framework;

namespace NumbersInRange.UnitTests
{
    [TestFixture]
    public class NumberTests
    {
        [Test]
        [TestCase(-1, 1, 0, ExpectedResult = true)]
        [TestCase(-1, 1, 3.5f, ExpectedResult = false)]
        public bool Should_Return_True_When_Number_IsInRange(float a, float b, float value)
        {
            //Preconditions
            var number = new Number<float>(value);
            //Check
            return number.IsInRange(a, b);
        }
    }
}
