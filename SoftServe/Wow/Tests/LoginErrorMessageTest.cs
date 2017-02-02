using System;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    class LoginErrorMessageTest : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // First object is user data from repository
        // Second object is error message that should appear on login form
        private static readonly object[] TestErrorMessageOnLoginFormData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
                "Wrong e-mail or password",
            }
        };

        [Test, TestCaseSource(nameof(TestErrorMessageOnLoginFormData))]
        public void TestLoginErrorMessage(User user, string errorMessage)
        {
            logger.Info("Start");
            // Test steps
            LoginPage loginPage = Application.Get().Login();

            // Set empty values into email and password fields
            user.SetEmail(string.Empty);
            user.SetPassword(string.Empty);
            loginPage.SetLoginData(user);

            // Check if appropriate message appears
            Assert.AreEqual(errorMessage, loginPage.GetLoginErrorMessageText(user));

            // Set value for email field
            user.SetEmail("bslw@wovz.cu.cc");
            loginPage.SetLoginData(user);
            //loginPage.SubmitLogin();

            // Check if appropriate message appears
            Assert.AreEqual(errorMessage, loginPage.GetLoginErrorMessageText(user));

            // Set empty value for email and set some value for password field
            user.SetEmail(string.Empty);
            user.SetPassword("phoenixrising");
            loginPage.SetLoginData(user);
            //loginPage.SubmitLogin();

            // Check if appropriate message appears
            Assert.AreEqual(errorMessage, loginPage.GetLoginErrorMessageText(user));

            logger.Info("Done");
        }
    }
}
