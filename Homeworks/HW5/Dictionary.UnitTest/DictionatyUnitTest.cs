using System;
using NUnit.Framework;
using DictionaryTask;

namespace Dictionary.UnitTest
{
    [TestFixture]
    public class DictionatyUnitTest
    {
        /// <summary>
        /// Method checks exception which thorws when inputed data is incorrect:
        /// 1) Inputed data is a string
        /// 2) Inputed data is a negative number
        /// 3) Inputed data is 0
        /// </summary>
        /// <param name="testData"></param>
        [TestCase("qwerty")]
        [TestCase("-8")]
        [TestCase("0")]
        public void ParseAtempt_ThrowsException_WhenInputedDataIsInvalid(string testData)
        {
            Assert.Throws<FormatException>(() =>  Program.ParseAtempt(testData));
        }

        /// <summary>
        /// Method checks returned <int> data when inputed data is correct:
        /// </summary>
        /// <param name="testData"></param>
        [TestCase("8")]
        public void ParseAtempt_ReturnIntData_WhenInputedDataIsValid(string testData)
        {
            int expectedResult = Program.ParseAtempt(testData);
            int actualResult = 8;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
