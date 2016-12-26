using System;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dictionary.UnitTests
{
    [TestFixture]
    public class PersonUtilityTests
    {
        Dictionary<uint, string> persons = new Dictionary<uint, string>()
            {
                {0,"Taras" },
                {1,"Ivan" },
                {2,"Marta" },
                {3,"Petro" },
            };

        // TESTS

        [Test]
        [TestCase("4", ExpectedResult = 4)]
        [TestCase("5", ExpectedResult = 5)]
        [TestCase("6", ExpectedResult = 6)]
        public uint GetID_Positive_Test_Should_Return_Valid_UInt_ID(string id)
        {
            uint actual = PersonUtility.GetID(id, persons.Keys);
            Console.WriteLine($"Result: {actual}");
            return actual;
        }

        [Test]
        [TestCase("-1")]
        [TestCase("")]
        [TestCase("dsd")]
        [TestCase("12&*")]
        public void GetID_Negative_Test_Should_Throw_Format_Exeption(string id)
        {
            Assert.Throws<FormatException>(() => PersonUtility.GetID(id, persons.Keys));
        }

        [Test]
        [TestCase("0")]
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void GetID_Negative_Test_Should_Throw_Argument_Exeption(string id)
        {
            Assert.Throws<ArgumentException>(() => PersonUtility.GetID(id, persons.Keys));
        }

        [Test]
        [TestCase("0", ExpectedResult = "Taras")]
        [TestCase("1", ExpectedResult = "Ivan")]
        [TestCase("2", ExpectedResult = "Marta")]
        [TestCase("3", ExpectedResult = "Petro")]
        public string GetValueByID_Positive_Test_Should_Return_Corresponding_Value(string id)
        {
            string actual = PersonUtility.GetValueByID(persons, id);
            Console.WriteLine($"Result: {actual}");
            return actual;
        }

        [Test]
        [TestCase("-1")]
        [TestCase("-5")]
        [TestCase("6")]
        [TestCase("7")]
        [TestCase("ffdfs")]
        [TestCase("")]
        public void GetValueByID_Negative_Test_Should_Return_Corresponding_Message(string id)
        {
            string expected = "Fail! Can't find this ID.";
            string actual = PersonUtility.GetValueByID(persons, id);

            Console.WriteLine($"Result: {actual}");
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
    }
}
