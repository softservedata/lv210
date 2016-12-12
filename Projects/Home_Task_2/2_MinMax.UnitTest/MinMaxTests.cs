using System;
using NUnit.Framework;
using MinMax;

namespace _2_MinMax.UnitTest
{
    [TestFixture]
    public class MinMaxTests
    {
        [Test]
        public void MaxValueTest()
        {
            int[] arrayInts = new[] { -57, 44, 87 };

            int expected = 87;
            int actual = Program.MaxValue(arrayInts);

            Assert.AreEqual(expected, actual, "Test Fails!");
            Console.WriteLine("Test for Max Value Done!");
        }

        [Test]
        public void MinValueTest()
        {
            int[] arrayInts = new[] { -57, 44, 87 };

            int expected = -57;
            int actual = Program.MinValue(arrayInts);

            Assert.AreEqual(expected, actual, "Test Fails!");
            Console.WriteLine("Test for Min Value Done!");
        }

        [Test]
        public void ConvertStringToIntTest()
        {
            int[] arrayInts = new int[2];
            string[] arrayStrings = new[] { "13", "15" };

            int[] expected = { 13, 15 };
            int[] actual = Program.ConvertStringToInt(arrayStrings, arrayInts);

            Assert.AreEqual(expected, actual, "Test Fails!");
            Console.WriteLine("Test for Converting String To Int Done!");
        }
    }
}
