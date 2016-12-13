using System;
using NUnit.Framework;
using Pres2_Task1;

namespace Pres2_Task1_1.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void ParityVerifyingTrueTest()
        {
            string ExcpectedResult = "true";
            string ActualResult = Program.ParityVerifying(2, 4);
            Assert.AreEqual(ExcpectedResult, ActualResult);
        }

        [Test]
        public void ParityVerifyingFalseTest()
        {
            string ExcpectedResult = "false";
            string ActualResult = Program.ParityVerifying(9, 4);
            Assert.AreEqual(ExcpectedResult, ActualResult);
        }
    }
}
