using System;
using NUnit.Framework;

namespace Cars.UnitTest
{
    [TestFixture]
    public class CarsTests
    {
        [Test]
        [TestCase(10, ExpectedResult = 900)]
        [TestCase(5, ExpectedResult = 950)]
        [TestCase(90, ExpectedResult = 100)]
        public double ChangePriceForCarPositiveTest(double percent)
        {
            Car testCar = new Car("BMW", "Black", 1000);
            Console.WriteLine("Price = {0}", testCar.CarPrice);

            double newPrice = testCar.ChangePriceForCar(percent);
            Console.WriteLine("Discount {0}%. New Price = {1}", percent, newPrice);

            return newPrice;
        }

        [Test]
        [TestCase(110)]
        [TestCase(-10)]
        public void ChangePriceForCarNegativeTest(double percent)
        {
            Car testCar = new Car("BMW", "Black", 1000);

            var ex = Assert.Throws<Exception>(() => testCar.ChangePriceForCar(percent));
            Assert.AreEqual("Incorrect percentage", ex.Message, "Fail!");

            Console.WriteLine("Test Done! Ex.Message: {0}", ex.Message);
        }

        [Test]
        [TestCase(0, ExpectedResult = 1000)]
        [TestCase(100, ExpectedResult = 0)]
        public double ChangePriceForCarBoundaryValueTest(double percent)
        {
            Car testCar = new Car("BMW", "Black", 1000);
            Console.WriteLine("Price = {0}",testCar.CarPrice);

            double newPrice = testCar.ChangePriceForCar(percent);
            Console.WriteLine("Discount {0}%. New Price = {1}",percent, newPrice);

            return newPrice;
        }

        [Test]
        [TestCase("BMW", "Black", 1000, "Blue", ExpectedResult = "Black")]
        [TestCase("Mercedes", "White", 1000, "Blue", ExpectedResult = "Blue")]
        [TestCase("Ferrari", "white", 1000, "Red", ExpectedResult = "Red")]
        public string ChangeColorForWhiteCarsTest(string model, string currentColor, double price, string newColor)
        {
            Car testCar = new Car(model, currentColor, price);

            string carColor = testCar.ChangeColorForWhiteCars(newColor);
            Console.WriteLine("Old color: {0}\nNew color: {1}", currentColor, carColor);

            return carColor;
        }

        [Test]
        public void PrintInfoAboutCarTest()
        {
            Car testCar = new Car("BMW E30", "Black", 1000);

            string actualResult = testCar.PrintInfoAboutCar();
            string expectedResult = String.Format("Model: {0}. Color: {1}. Price {2:C}",testCar.CarModel,testCar.CarColor,testCar.CarPrice);

            StringAssert.AreEqualIgnoringCase(expectedResult,actualResult,"FAIL!");
            Console.WriteLine("Test Done!");
        }
    }
}
