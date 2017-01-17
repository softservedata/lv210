using System;
using System.IO;
using NUnit.Framework;

namespace String.UnitTest
{
    [TestFixture]
    public class StringUtilityClassTestSuite
    {
        [Test]
        public void GetEachLineLength_Should_Return_Correct_LengthInfo_OfEachLine()
        {
            string[] textContent = File.ReadAllLines(StringUtilityClass.GetFilePathFromDesktop("stringTestData.txt"));

            string[] actual = textContent.GetEachLineLengthInfo();
            string[] expected =
            {
                "Line #1 has 15 symbols.",
                "Line #2 has 14 symbols.",
                "Line #3 has 35 symbols.",
                "Line #4 has 14 symbols.",
                "Line #5 has 26 symbols."
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLongestLines_Should_Return_Longest_Line()
        {
            string[] textContent = File.ReadAllLines(StringUtilityClass.GetFilePathFromDesktop("stringTestData.txt"));

            string[] actual = textContent.GetLongestLines();
            string[] expected = { "it is the longest line in this file" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetShortestLines_Should_Return_Shortest_Lines()
        {
            string[] textContent = File.ReadAllLines(StringUtilityClass.GetFilePathFromDesktop("stringTestData.txt"));

            string[] actual = textContent.GetShortestLines();
            string[] expected = { "short line one", "short line two" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLinesContainsSubstring_Should_Return_Lines_With_ProperSubstring_IgnoringCase()
        {
            string[] textContent = File.ReadAllLines(StringUtilityClass.GetFilePathFromDesktop("stringTestData.txt"));

            string[] actual = textContent.GetLinesContainsSubstring("hello");
            string[] expected = { "line consisting word Hello" };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
