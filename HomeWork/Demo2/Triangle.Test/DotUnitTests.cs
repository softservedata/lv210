using Demo2;
using NUnit.Framework;

namespace TriangleTest
{
    [TestFixture]
    public class DotUnitTests
    {
        [Test]
        public void ShouldShowRightCoordinates()
        {
            Dot dot = new Dot(4, 8);
            string ExpextedResult = "(4, 8)";
            string ActualResult = dot.Show();
            Assert.AreEqual(ExpextedResult, ActualResult);
        }
        [Test]
        public void ShouldCheckForEqualDots()
        {
            Dot dot1 = new Dot(1, 5);
            Dot dot2 = new Dot(1, 5);
            bool ExpectedResult = true;
            bool ActualResult = Dot.AreDotsEqual(dot1, dot2);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [Test]
        public void ShouldCloneDot()
        {
            Dot dot0 = new Dot(4, 8);
            Dot dot1 = (Dot)dot0.Clone();
            dot0.x = 1;
            bool ExpectedResult = false;
            bool ActualResult = Dot.AreDotsEqual(dot0, dot1);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
