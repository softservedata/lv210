using System;
using NUnit.Framework;
using System.Drawing;

namespace CreatingClassCar.UnitTests
{
    [TestFixture]
    public class CarTests
    {
        [Test]
        [TestCase(123000, 10, 135300)]
        [TestCase(123000, -10, 110700)]
        public void ChangePricePercentageTest(double price, double percents, double result )
        {
            //Preconditions
            var car = new Car(price);
            //Test steps
            var expected = result;
            car.ChangePricePercentage(percents);
            var actual = car.Price;
            //Check
            Assert.AreEqual(expected, actual, "Error is found");
        }
    }
}
