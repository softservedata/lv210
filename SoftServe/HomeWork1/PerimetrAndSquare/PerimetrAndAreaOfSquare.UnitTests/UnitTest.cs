using System;
using NUnit.Framework;
using HomeWork1_Task1;

namespace PerimetrAndAreaOfSquare.UnitTests
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        [TestCase(7,49)]
        [TestCase(1,1)]
        public void SquareArea_CorrectValues_CalculateArea(int sideLength, int result)
        {
            var actual = Program.SquareArea(sideLength);
            var expected = result;

            Assert.AreEqual(expected, actual, "Error is found");

            Console.WriteLine("Test 1 done"); 
        }

        [Test]
        [TestCase(5,20)]
        public void SquarePerimetr_CorrectValues_CalculatePerimetr(int sideLength, int result)
        {
            var actual = Program.SquarePerimetr(sideLength);
            var expected = result;

            Assert.AreEqual(expected, actual, "Error is found");

            Console.WriteLine("Test 2 done");
        }
    }
}
