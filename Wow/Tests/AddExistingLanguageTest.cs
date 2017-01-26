using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class AddExistingLanguageTest
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
            admin.SetEmail("admin.wow@ukr.net");
            admin.SetPassword("qwerty");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();

            // Test steps
            // Verify is language displays on page
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Select language from list. Verify
            languagesPage.SelectLanguageFromList(language);
            Assert.IsFalse(languagesPage.IsAddButtonEnabled());
            Assert.AreEqual(LanguagesPage.errorMessageForExistingLanguage, languagesPage.GetLanguageAlreadyExistMessage());

            // Return to previous state
            loginPage = languagesPage.GoToLogOut();
        }
    }
}
