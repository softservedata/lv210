using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using Calc;

namespace Calc.UnitTests
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void FirstTest()
        {
            // Precondition
            int expected;
            int actual;
            //
            int initId = 777;
            expected = initId;
            // Test Steps
            //Account account = new Account(initId); // for Integration Test
            //
            IAccount account = Substitute.For<IAccount>();  // for Unit Test
            account.GetAccountId().Returns(initId);
            AccountManager accountManager = new AccountManager(account);
            // Check
            actual = accountManager.AccountInfo();
            Assert.AreEqual(expected, actual, "Error found");
            // Return to Previous State
            //Assert.Fail();
            Console.WriteLine("Test done 3");
        }

    }
}
