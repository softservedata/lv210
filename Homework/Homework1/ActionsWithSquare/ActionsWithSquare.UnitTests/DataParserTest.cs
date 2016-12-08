using System;
using System;
using NUnit.Framework;



namespace ActionsWithSquare.UnitTests
{
    /// <summary>
    /// This class tests whether data is correctly parsed from string to string.
    /// </summary>
    
    [TestFixture]
    public class DataParserTest
    {
        [Test]
        [TestCase("1", 1)]
        [TestCase("3,5", 3.5)]
        public void Parse_ForDataParser_WithCorrectInputs_ReturnsCorrectResults(string value, double result)
        {
            //Precondition
            DataParser parser = new DataParser();

            //Test steps
            var expected = result;
            var actual = parser.Parse(value);

            //Check
            Assert.AreEqual(expected, actual, "Parsing error");
        }

        [Test]
        [TestCase("abc")]
        [TestCase("1&2*3")]
        public void Parse_ForDataParser_WithIncorrectInputs_ReturnsException(string value)
        {
            //Precondition
            DataParser parser = new DataParser();

            //Check
            Assert.Throws<FormatException>(delegate { parser.Parse(value); });
        }
    }
}
