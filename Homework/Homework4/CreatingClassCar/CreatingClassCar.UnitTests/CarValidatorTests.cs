using System.Drawing;
using FluentValidation;
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
        [TestCase("B1M2W")]
        [TestCase("O&*pel")]
        public void Should_Return_False_When_NameIsInvalid(string name)
        {
            //Preconditions
            var price = 123000;
            var validator = new CarValidator();
            var person = new Car(name, Color.Chocolate, price);
            //Test steps
            var expected = false;
            var actual = validator.Validate(person).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Nissan", "White", 21)]
        public void Should_Return_True_When_Data_IsValid(string name, string color, double price)
        {
            //Preconditions
            var validator = new CarValidator();
            var person = new Car(name, Color.FromName(color), price);
            //Test steps
            var expected = true;
            var actual = validator.Validate(person).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }
    }
}
