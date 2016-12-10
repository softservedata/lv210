using System;
using NUnit.Framework;
using System.Collections;
using System.Dynamic;

namespace InformationAboutPerson.UnitTests
{
    [TestFixture]
    public class PersonBuilderTests
    {
        private static readonly object[] InvalidAge =
        {
            new object[] {-20},
            new object[] {-1},
            new object[] {0},
        };
        
        [Test, TestCaseSource(nameof(InvalidAge))]
        public void Should_ThrowException_When_AgeLessOrEqualZero(int age)
        {
            Assert.Throws<ArgumentException>(delegate { PersonBuilder.AgeValidation(age); });
        }
        
        [Test]
        [TestCase("")]
        [TestCase("I1go2r")]
        [TestCase("I*&ra")]
        public void Should_ThrowException_When_NameIsInvalid(string name)
        {
            Assert.Throws<ArgumentException>(delegate { PersonBuilder.NameValidation(name); });
        }

        [Test]
        [TestCase("Uliana")]
        [TestCase("Bogdan")]
        public void Should_ReturnName_When_ItIsValid(string name)
        {
            //Test steps
            var expected = name;
            var actual = PersonBuilder.NameValidation(name);

            //Check
            Assert.AreEqual(expected, actual);
        }
    }
}
