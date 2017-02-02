using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    /// <summary>
    /// WOW-287
    /// This test case verifies additing language 
    /// (already existing in the application) to the application.
    /// </summary>
    [TestFixture]
    public class AddExistingLanguageTest : TestRunner
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
            Logger.Info("Start AddExistingLanguageTest");

            // Precondition
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();
            Assert.AreEqual(LanguagesPage.LanguagePageDescription, languagesPage.GetLanguagePageDescription());

            // Test steps
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            languagesPage.SelectLanguageFromList(language);
            Assert.IsFalse(languagesPage.IsAddButtonEnabled());
            Assert.AreEqual(LanguagesPage.ErrorMessageForEnglishExistingLanguage, 
                            languagesPage.GetLanguageAlreadyExistMessage());

            // Return to previous state
            loginPage = languagesPage.GoToLogOut();
            Assert.AreEqual(LoginPage.loginDescriptionText, 
                            loginPage.GetLoginDescriptionText());

            Logger.Info("Done AddExistingLanguageTest");
        }
    }
}
