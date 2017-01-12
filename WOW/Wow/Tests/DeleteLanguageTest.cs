using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class DeleteLanguageTest : TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestDelete(User admin)
        {
            // Test Steps
            Application myApp = Application.Get();

            LoginPage loginPage = myApp.Login();

            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            LanguagesPage languagesPage = usersPage.GoToLanguagesPage();
        
            // Check
            Assert.AreEqual("Language is in use and cannot be deleted.", languagesPage.GetErrorMessage());
        }
    }
}
