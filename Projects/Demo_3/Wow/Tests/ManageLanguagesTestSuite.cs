using NLog;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class ManageLanguagesTestSuite : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TestData =
        {
            new object[] { UserRepository.Get().FromCsv("Users.csv").GetAdmin() }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void AddNewLanguageTest(User admin)
        {
            logger.Info("Start add new language test");
            
            // Preconditions
            LoginPage loginPage = Application.Get().Login();
            UserPage usersPage = loginPage.SuccessUserLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();
            Assert.IsNotNull(languagesPage.GetLanguagePageDescription());

            // 1. Check if language is not presented on the list of existing languages
            string languageToAdd = languagesPage.GetNewLanguage();
            Assert.IsFalse(languagesPage.IsLanguageInExistingList(languageToAdd));

            // 2. Add Language
            languagesPage.AddNewLanguage(languageToAdd);
            Assert.IsTrue(languagesPage.IsDialogWindowAppears(DialogWindowTitle.AddLanguage, DialogWindowMessage.AddLanguage));
            languagesPage.CloseDialogWindow();

            // 3. Check if added language is presented in the list as last language
            Assert.AreEqual(languageToAdd, languagesPage.GetLastLanguage());

            // Return to a previous state and check
            languagesPage.DeleteLanguage(languageToAdd);
            Assert.IsFalse(languagesPage.IsLanguageInExistingList(languageToAdd));
            languagesPage.GotoLogOut();
            logger.Info("Test done");
        }
    }
}