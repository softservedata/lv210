using System;
using NUnit.Framework;
using System.Collections;
using System.Dynamic;

namespace InformationAboutPerson.UnitTests
{
    [TestFixture]
    public class PersonTests
    {
        private static object[] InvalidAge =
        {
            new object[] {"Ivan", -20},
            new object[] {"Ivan", -1},
            new object[] {"Ivan", 0},
        };
        
        [Test, TestCaseSource("InvalidAge")]
        public void Should_ThrowException_When_AgeLessOrEqualZero(string name, int age)
        {
            Assert.Throws<ArgumentException>(delegate { new Person(name, age); });
        }

        [Test]
        [TestCase("", 20)]
        [TestCase("I1go2r", 8)]
        [TestCase("I*&ra", 2)]
        public void Should_ThrowException_When_NameIsInvalid(string name, int age)
        {
            Assert.Throws<ArgumentException>(delegate { new Person(name, age); });
        }

        [Test]
        [TestCase("Uliana",21)]
        [TestCase("Bogdan", 1)]
        public void Should_CreateNewPerson_When_AllDataIsValid(string name, int age)
        {
            //Precondition
            var person = new Person(name, age);

            //Test steps
            var expected = string.Format("\nName is {0}, age is {1}.", name, age);
            var actual = person.ToString();

            //Check
            Assert.AreEqual(expected, actual);
        }
    }
}
