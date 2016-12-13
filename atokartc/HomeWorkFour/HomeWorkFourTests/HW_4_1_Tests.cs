using NUnit.Framework;
using HomeWorkFour;
using NSubstitute;
using System;

namespace HomeWorkFourTests
{
    [TestFixture]
    public class HW_4_1_Tests
    {
        [Test]
        public void CorrecrAgeTest()
        {
            int expected;
            int actual;

            Person person = new Person("Andrii", 1988);

            expected = 28;
            actual = person.Age();

            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //public void CorrectOutputTest()
        //{
        //    string expected;
        //    int actual;

        //    string name = "Andrii";
        //    int birthYear = 1988;
        //    int age = 28;

        //    Person person = Substitute.For<Person>();
        //    person.Age().Returns(age);

        //    expected = person.Output();
        //    actual = Console.WriteLine("Person's name is: {0}, birth year is: {1}, age is {2}", name, birthYear, age);

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
