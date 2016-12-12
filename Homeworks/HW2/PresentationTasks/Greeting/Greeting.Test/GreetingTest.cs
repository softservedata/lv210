using System;
using NUnit.Framework;

namespace Greeting.Test
{
    [TestFixture]
    public class GreetingTest
    {
        [Test]
        [TestCase(8, "Good morning!")]
        public void Good_Morning_Test(int hour, string result)
        {
            string ExpectedResult = result;
            string ActualResult = Program.GreetingChoise(hour);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(14, "Good afternoon!")]
        public void Good_Afternoon_Test(int hour, string result)
        {
            string ExpectedResult = result;
            string ActualResult = Program.GreetingChoise(hour);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(20, "Good evening!")]
        public void Good_Evening_Test(int hour, string result)
        {
            string ExpectedResult = result;
            string ActualResult = Program.GreetingChoise(hour);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(24, "Good night!")]
        public void Good_Night_Test(int hour, string result)
        {
            string ExpectedResult = result;
            string ActualResult = Program.GreetingChoise(hour);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestCase(-2)]
        public void Throw_Exception_Test(int hour)
        {
            Assert.Throws<FormatException>(() => Program.GreetingChoise(hour)); 
        }
        [TestCase(0)]
        public void Throw_Exception_When_Zero_Test(int hour)
        {
            Assert.Throws<FormatException>(() => Program.GreetingChoise(hour));
        }
        [TestCase(25)]
        public void Throw_Exception_When_Data_Out_Of_Range_Test(int hour)
        {
            Assert.Throws<FormatException>(() => Program.GreetingChoise(hour));
        }
    }
}
