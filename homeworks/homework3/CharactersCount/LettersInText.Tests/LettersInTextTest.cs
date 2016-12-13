
using NUnit.Framework;
using CharactersCount;

namespace CharactersCount.Tests
{
    [TestFixture]
    class LettersInTextTest
    {
        [Test]
        [TestCase("This is test data",'t',ExpectedResult =4)]
        [TestCase("This is test data", 'b', ExpectedResult = 0)]
        [TestCase("", 'b', ExpectedResult = 0)]
        [TestCase("", '\0', ExpectedResult = 0)]
        [TestCase("This is test data", '\0', ExpectedResult = 0)]
        public int FindCharacterCountTest(string text, char letter)
        {
            return LettersInText.FindCharacterCount(text, letter);
        }


    }
}
