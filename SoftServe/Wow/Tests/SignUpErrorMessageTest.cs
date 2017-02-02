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
    class SignUpErrorMessageTest : TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[]
            {
                UserRepository.Get().NewUser(),
                "Select a language",
                "Please write your full name and surname",
                "Enter your password",
                "Enter your E-mail address"
            },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestSignin(User user, string expectedBlankLanguageMessage, string expectedBlankNameMessage,
            string expectedBlankPasswordMessage, string expectedBlankEmailMessage)
        {
            // Precondition
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            loginPage.ClickSignupButton();
            user.SetLanguage(string.Empty);
            loginPage.SetSignupData(user);
            loginPage.ClickSubmitSignUpButton();

            string actualErrorMessage = loginPage.GetSignupErrorMessage();
            bool areStringsEqual = expectedBlankLanguageMessage == actualErrorMessage;
            
            Assert.IsFalse(areStringsEqual);

            user.SetLanguage("English");
            user.SetFirstname(string.Empty);

            loginPage.SetSignupData(user);
            loginPage.ClickSubmitSignUpButton();

            actualErrorMessage = loginPage.GetSignupErrorMessage();
            areStringsEqual = expectedBlankNameMessage == actualErrorMessage;

            Assert.IsTrue(areStringsEqual);

            user.SetFirstname("Red");
            user.SetLastname(string.Empty);

            loginPage.SetSignupData(user);
            loginPage.ClickSubmitSignUpButton();

            actualErrorMessage = loginPage.GetSignupErrorMessage();
            areStringsEqual = expectedBlankNameMessage == actualErrorMessage;

            Assert.IsTrue(areStringsEqual);

            user.SetLastname("Sun");
            user.SetPassword(string.Empty);

            loginPage.SetSignupData(user);
            loginPage.ClickSubmitSignUpButton();

            actualErrorMessage = loginPage.GetSignupErrorMessage();
            areStringsEqual = expectedBlankPasswordMessage== actualErrorMessage;

            Assert.IsFalse(areStringsEqual);

            user.SetConfirmPassword("Redsun");
            user.SetEmail(string.Empty);

            loginPage.SetSignupData(user);
            loginPage.ClickSubmitSignUpButton();

            actualErrorMessage = loginPage.GetSignupErrorMessage();
            areStringsEqual = expectedBlankEmailMessage == actualErrorMessage;

            Assert.IsFalse(areStringsEqual);
        }
    }
}
