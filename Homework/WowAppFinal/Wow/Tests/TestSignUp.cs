using Wow.Data;
using Wow.Pages;
using NUnit.Framework;
using Application = Wow.Pages.Application;

namespace Wow.Tests
{
    [TestFixture]
    public class TestSignUp : TestRunner
    {
        private static readonly object[] TestSigninDataWithInvalidEmail =
        {
            new object[] { StaticUserRepository.Get().UserWithInvalidEmail() },
        };

        [Test, TestCaseSource(nameof(TestSigninDataWithInvalidEmail))]
        public void TestSignUpWithInvalidEmail(User user)
        {
            // Precondition
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            loginPage.ClickSignUpButton();
            loginPage.SetSignUpData(user);
            loginPage.ClickSubmitSignUp();
            // Check
            // Assert will fail because the real error message is differ from expected
            StringAssert.AreEqualIgnoringCase(LoginPage.GetErrorMessageForInvalidEmail(), loginPage.GetErrorMessageText());
        }
    }
}