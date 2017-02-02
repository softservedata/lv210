using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    class SignUpErrorMessageTest : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TestSigninData =
        {
            new object[]
            {
                UserRepository.Get().NewUser(),
                "Select a language",
                "Please write your full name and surname",
                "Enter your password",
                "Repeat your password",
                "Enter your E-mail address"
            },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestSignUp(User user, string expectedBlankLanguageMessage, string expectedBlankNameMessage,
            string expectedBlankPasswordMessage, string expectedBlankRepeatPasswordMessage, string expectedBlankEmailMessage)
        {
            logger.Info("Start");
           
            // Precondition
            LoginPage loginPage = Application.Get().Login();

            // Test Steps
            // Step 1. SignUpForm Initialization
            loginPage.ClickSignUpButton();

            // Steps 2-3. Filling all fields except "Language"
            user.SetLanguage(string.Empty);
            loginPage.SetSignUpData(user);
            loginPage.ClickSubmitSignUpButton();
            string actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.AreEqual(expectedBlankLanguageMessage, actualErrorMessage);

            // Steps 4-5. Filling all fields except "Name"
            user.SetLanguage("English");
            user.SetFirstname(string.Empty);
            loginPage.SetSignUpData(user);
            loginPage.ClickSubmitSignUpButton();
            actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.AreEqual(expectedBlankNameMessage, actualErrorMessage);

            // Steps 6-7. Filling all fields except "Surname"
            user.SetFirstname("Red");
            user.SetLastname(string.Empty);
            loginPage.SetSignUpData(user);
            loginPage.ClickSubmitSignUpButton();
            actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.AreEqual(expectedBlankNameMessage, actualErrorMessage);
            logger.Info("Actual message {0}", actualErrorMessage);

            // Steps 8-9. Filling all fields except "Password"
            user.SetLastname("Sun");
            user.SetPassword(string.Empty);
            loginPage.SetSignUpData(user);
            loginPage.ClickSubmitSignUpButton();
            actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.AreEqual(expectedBlankPasswordMessage, actualErrorMessage);

            // Steps 10-11. Filling all fields except "Repeat password"
            user.SetPassword("redsun");
            user.SetConfirmPassword(string.Empty);
            loginPage.SetSignUpData(user);
            loginPage.ClickSubmitSignUpButton();
            actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.AreEqual(expectedBlankRepeatPasswordMessage, actualErrorMessage);
            
            // Steps 12-13. Filling all fields except "Email"
            user.SetConfirmPassword("Redsun");
            user.SetEmail(string.Empty);
            loginPage.SetSignUpData(user);
            loginPage.ClickSubmitSignUpButton();
            actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.AreEqual(expectedBlankEmailMessage, actualErrorMessage);
            logger.Info("Done");
        }
    }
}
