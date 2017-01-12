using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Tests
{
    [TestClass()]
    public class NumericTests
    {
        [TestMethod()]
        public void add1Test()
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
        }

        [TestMethod()]
        public void add2Test()
        {
            // Precondition
            double expected;
            double actual;
            Numeric numeric = new Numeric();
            // Test Steps
            actual = numeric.add(1, 2);
            expected = 3;
            // Check
            Assert.AreEqual(expected, actual, 0.0001, "Error found");
            // Return to Previous State
            //Assert.Fail();
        }

        [TestMethod()]
        public void div1Test()
        {
            // Precondition
            double expected;
            double actual;
            Numeric numeric = new Numeric();
            // Test Steps
            actual = numeric.div(10, 5);
            expected = 2;
            // Check
            Assert.AreEqual(expected, actual, 0.0001, "Error found");
            // Return to Previous State
            //Assert.Fail();
        }

        [TestMethod()]
        public void div2Test()
        {
            // Precondition
            double expected;
            double actual;
            Numeric numeric = new Numeric();
            // Test Steps
            actual = numeric.div(1, 0);
            expected = Double.PositiveInfinity;
            // Check
            Assert.AreEqual(expected, actual, 0.0001, "Error found");
            // Return to Previous State
            //Assert.Fail();
        }

    }
}