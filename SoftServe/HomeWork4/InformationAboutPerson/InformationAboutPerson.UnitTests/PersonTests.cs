using System;
using NUnit.Framework;
using HomeWork4_Task1;

namespace InformationAboutPerson.UnitTests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void GetAge_SetCorrectData_ReturnAge()
        {
            Person person = new Person("Dima", 1994);

            var actual = person.GetAge();
            var expected = 22;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Person_SetIncorrectAge_ThrowException()
        {
            Assert.Throws<ArgumentException>(delegate { new Person("Jonh", 2017); });
        }
    }
}
