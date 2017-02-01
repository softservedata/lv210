﻿using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class LoginTest : TestRunner
    {

        private static readonly object[] TestSigninData =
        {
            new object[] { StaticUserRepository.Get().Admin() },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestSignin(User admin)
        {
            // Precondition
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessUserLogin(admin);
            //UsersPage usersPage = Application.Get().Login().SuccessAdminLogin(admin);
            // Check
            Assert.AreEqual(admin.GetName(), usersPage.GetUsernameText());
            // Return to previous state
            loginPage = usersPage.GoToLogOut();
            // Check
            Assert.AreEqual("SoftServe Language School", loginPage.GetLoginDescriptionText());
        }
    }
}
