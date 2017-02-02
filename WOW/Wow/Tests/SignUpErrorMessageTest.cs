using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wow.Data;
using Wow.Pages;
using NUnit.Framework;

namespace Wow.Tests
{
    class SignUpErrorMessageTest: TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[] 
            {
                UserRepository.Get().NewUser(),
                "Select a language"
            },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestSignin(IUser user, string expectedErrorMessage)
        {
            // Precondition
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            loginPage.ClickSignButton();
            loginPage.SetSignupData(user);

            string actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

    }
}
