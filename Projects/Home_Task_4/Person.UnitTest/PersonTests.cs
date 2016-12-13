using System;
using NUnit.Framework;

namespace Person.UnitTest
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        [TestCase(1992, 9, 27, ExpectedResult = 24)]
        [TestCase(1, 1, 27, ExpectedResult = 2015)]
        [TestCase(2016, 9, 27, ExpectedResult = 0)]
        public int AgeOfPersonTest(int year, int month, int day)
        {
            Person testPerson = new Person("John", new DateTime(year, month, day));
            return testPerson.AgeOfPerson();
        }

        [Test]
        [TestCase(1992, 9, 27, "John")]
        [TestCase(2000, 1, 27, "John")]
        [TestCase(2001, 9, 27, "Very Young")]
        [TestCase(2016, 9, 27, "Very Young")]
        public void ChangeNameTest(int year, int month, int day, string expectedResult)
        {
            Person testPerson = new Person("John", new DateTime(year, month, day));
            testPerson.ChangeName();
            string actualResult = testPerson.NameOfPerson;
            StringAssert.AreEqualIgnoringCase(expectedResult, actualResult, "FAIL!");
            Console.WriteLine("Test Done!");
        }

    }
}
