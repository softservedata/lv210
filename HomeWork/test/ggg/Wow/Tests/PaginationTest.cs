using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class PaginationTest: TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestPagination(User admin)
        {
            // Precondition
            admin.SetEmail("admin.wow@ukr.net");
            admin.SetPassword("qwerty");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            //Check if First and StepBack are disabled
            Assert.IsFalse(usersPage.IsFirstEnabled());
            Assert.IsFalse(usersPage.IsStepBackEnabled());

            usersPage = usersPage.ClickStepForward();

            //Check if First, StepBack, StepForward, Last are enabled
            Assert.IsTrue(usersPage.IsFirstEnabled());
            Assert.IsTrue(usersPage.IsStepBackEnabled());
            Assert.IsTrue(usersPage.IsStepForwardEnabled());
            Assert.IsTrue(usersPage.IsLastEnabled());

            usersPage = usersPage.ClickLast();

            //Check if Last and StepForward are disabled
            Assert.IsFalse(usersPage.IsStepForwardEnabled());
            Assert.IsFalse(usersPage.IsLastEnabled());

            usersPage = usersPage.ClickStepBack();

            //Check if First, StepBack, StepForward, Last are enabled
            Assert.IsTrue(usersPage.IsFirstEnabled());
            Assert.IsTrue(usersPage.IsStepBackEnabled());
            Assert.IsTrue(usersPage.IsStepForwardEnabled());
            Assert.IsTrue(usersPage.IsLastEnabled());

            // Return to previous state
            loginPage = usersPage.GotoLogOut();
        }
        
    }
}
