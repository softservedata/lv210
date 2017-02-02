using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    /// <summary>
    /// WOW-181
    /// This test case verifies that Admin can cancel the language deleting
    /// from the application which is not in use. 
    /// </summary>
    [TestFixture]
    public class CancelLanguageDeletingTest : TestRunner
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
            Logger.Info("Start CancelLanguageDeletingTest");

            // Precondition
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();
            Assert.AreEqual(LanguagesPage.LanguagePageDescription, languagesPage.GetLanguagePageDescription());

            languagesPage.AddNewLanguage(language);
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Test steps
            languagesPage.CancelDeletingOfLastAddedLanguage();
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Return to previous state
            languagesPage.DeleteLastAddedLanguage();
            loginPage = languagesPage.GoToLogOut();
            Assert.AreEqual(LoginPage.loginDescriptionText, 
                            loginPage.GetLoginDescriptionText());

            Logger.Info("Done CancelLanguageDeletingTest");
        }
    }
}
