using System;
using System.Drawing;
using System.Linq;
using NUnit.Framework;

namespace CreatingClassCar.UnitTests
{
    [TestFixture]
    public class CarValidatorTests
    {
        private static readonly object[] InvalidPrice =
        {
            new object[] {0},
            new object[] {-200000},
        };

        [Test, TestCaseSource(nameof(InvalidPrice))]
        public void Should_Return_False_When_Price_IsLess_OrEqualZero(double price)
        {
            //Preconditions
            var validator = new CarValidator();
            var car = new Car("Some brand", Color.Aqua, price);
            //Test steps
            var expected = false;
            var actual = validator.Validate(car).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("")]
        [TestCase("I1go2r")]
        [TestCase("I*&ra")]
        public void Should_Return_False_When_NameIsInvalid(string name)
        {
            //Preconditions
            var age = 13;
            var validator = new PersonValidator();
            var person = new Person(name, age);
            //Test steps
            var expected = false;
            var actual = validator.Validate(person).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Uliana", 21)]
        [TestCase("Bogdan", 10)]
        public void Should_Return_True_When_Data_IsValid(string name, int age)
        {
            //Preconditions
            var validator = new PersonValidator();
            var person = new Person(name, age);
            //Test steps
            var expected = true;
            var actual = validator.Validate(person).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }
    }
}
