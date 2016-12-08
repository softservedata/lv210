﻿using System;
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
        [TestCase("3,5", ExpectedResult =3.5)]
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
        public void Should_ThrowException_When_StringCannotBeParsed(string value)
        {
            //Precondition
            DataParser parser = new DataParser();

            //Check
            Assert.Throws<FormatException>(() => parser.Parse(value));
        }
    }
}
