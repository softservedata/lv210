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
        [TestCase(1990, 1, 1, ExpectedResult = 26)]
        [TestCase(1990, 1, 31, ExpectedResult = 26)] //boundary for month with 31 days
        [TestCase(1990, 2, 1, ExpectedResult = 26)]
        [TestCase(1990, 2, 28, ExpectedResult = 26)] //for regular February
        [TestCase(2012, 2, 29, ExpectedResult = 4)] //for leap February
        [TestCase(1992, 9, 30, ExpectedResult = 24)] //for month with 30 days
        public int AgeOfPersonBoundaryValueTest(int year, int month, int day)
        {
            Person testPerson = new Person("John", new DateTime(year, month, day));
            return testPerson.AgeOfPerson();
        }

        [Test]
        [TestCase(1990, 2, 29)] //90' february is not leap
        [TestCase(2016, 9, 31)] //september has 30 days
        [TestCase(2016, 1, 32)]
        [TestCase(0, 9, 27)]
        [TestCase(1990, 0, 30)]
        [TestCase(1990, 11, 0)]
        [TestCase(1990, 13, 27)]
        [TestCase(1990, -1, 3)]
        public void DateTimeExeptionTest(int year, int month, int day)
        {
            Person testPerson;
            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testPerson = new Person(
                   "John", new DateTime(year, month, day)));
            Console.WriteLine(exeption.Message);
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
