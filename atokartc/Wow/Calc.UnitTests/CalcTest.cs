using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
//using Calc;

namespace Calc.UnitTests
{
    [TestFixture]
    public class CalcTest
    {
        [Test]
        public void addCalcTest()
        {
            // Precondition
            double expected;
            double actual;
            Numeric numeric = new Numeric();
            // Test Steps
            actual = numeric.add(1, 1);
            expected = 2;
            // Check
            Assert.AreEqual(expected, actual, 0.0001, "Error found");
            // Return to Previous State
            //Assert.Fail();
            Console.WriteLine("Test done 2");
        }
    }
}
