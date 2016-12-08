using System;
using NUnit.Framework;

namespace InformationAboutPerson.UnitTests
{
    [TestFixture]
    public class DataParserTests
    {
        //[Test]
        //[TestCase("1", 1)]
        //[TestCase("3,5", 3.5)]
        //public void Should_Return_Result_When_Parsing_Is_Successful(string value, double result)
        //{
        //    //Precondition
        //    DataParser parser = new DataParser();

        //    //Test steps
        //    var expected = result;
        //    var actual = parser.Parse(value);

        //    //Check
        //    Assert.AreEqual(expected, actual, "Parsing error");
        //}

        [Test]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("-10", ExpectedResult = -10)]
        public double Should_Return_Result_When_Parsing_Is_Successful(string value)
        {
            //Precondition
            var parser = new DataParser();

            //Check
            return parser.Parse(value);
        }


        [Test]
        [TestCase("abc")]
        [TestCase("1&2*3")]
        [TestCase("-3,5")]
        public void Should_ThrowException_When_StringCannotBeParsed(string value)
        {
            //Precondition
            DataParser parser = new DataParser();

            //Check
            Assert.Throws<FormatException>(() => parser.Parse(value));
        }
    }
}
