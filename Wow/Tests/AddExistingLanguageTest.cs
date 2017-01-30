using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class AddExistingLanguageTest : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
                "English"
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void AddExistingLanguage(User admin, string language)
        {
            // Precondition
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();

            // Test steps
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            languagesPage.SelectLanguageFromList(language);
            Assert.IsFalse(languagesPage.IsAddButtonEnabled());
            Assert.AreEqual(LanguagesPage.errorMessageForEnglishExistingLanguage, 
                            languagesPage.GetLanguageAlreadyExistMessage());

            // Return to previous state
            loginPage = languagesPage.GoToLogOut();
            Assert.AreEqual(LoginPage.loginDescriptionText, 
                            loginPage.GetLoginDescriptionText());
        }
    }
}
