using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class CancelLanguageDeletingTest : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
                "Afrikaans"
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void CancelLanguageDeleting(User admin, string language)
        {
            // Precondition
            admin.SetEmail("admin.wow@ukr.net");
            admin.SetPassword("qwerty");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();

            languagesPage.AddNewLanguage(language);
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Test steps
            languagesPage.CancelDeletingOfLastAddedLanguage();
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Return to previous state
            loginPage = languagesPage.GoToLogOut();
        }
    }
}
