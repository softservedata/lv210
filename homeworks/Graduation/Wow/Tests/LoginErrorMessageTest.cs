using System;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    class LoginErrorMessageTest : TestRunner
    {
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
            // Test steps
            LoginPage loginPage = Application.Get().Login();

            // Set empty values into email and password fields
            user.SetEmail(String.Empty);
            user.SetPassword(String.Empty);

            // Check if appropriate message appears
            Assert.AreEqual(errorMessage, loginPage.GetLoginErrorMessageText(user));

            // Set value for email field
            user.SetEmail("bslw@wovz.cu.cc");

            // Check if appropriate message appears
            Assert.AreEqual(errorMessage, loginPage.GetLoginErrorMessageText(user));

            // Set empty value for email and set some value for password field
            user.SetEmail(String.Empty);
            user.SetPassword("phoenixrising");

            // Check if appropriate message appears
            Assert.AreEqual(errorMessage, loginPage.GetLoginErrorMessageText(user));
        }
    }
}
