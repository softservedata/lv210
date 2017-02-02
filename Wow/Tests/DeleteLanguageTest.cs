using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    /// <summary>
    /// WOW-297
    /// This test case verifies that Admin can delete language 
    /// from the application which is not in use.
    /// </summary>
    [TestFixture]
    public class DeleteLanguageTest : TestRunner
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
        public void DeleteLanguage(User admin, string language)
        {
            Logger.Info("Start DeleteLanguageTest");

            // Precondition
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();
            Assert.AreEqual(LanguagesPage.LanguagePageDescription, languagesPage.GetLanguagePageDescription());

            languagesPage.AddNewLanguage(language);
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Test steps
            languagesPage.DeleteLastAddedLanguage();
            Assert.IsFalse(languagesPage.IsLanguageInExistingList(language));

            // Return to previous state
            loginPage = languagesPage.GoToLogOut();
            Assert.AreEqual(LoginPage.loginDescriptionText, 
                            loginPage.GetLoginDescriptionText());

            Logger.Info("Done DeleteLanguageTest");
        }
    }
}
