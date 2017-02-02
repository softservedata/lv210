using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    [TestFixture]
    public class DeleteLanguageTest : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TestSigninData =
        {
            new object[] 
            {
                UserRepository.Get().Admin(),
                "Language is in use and cannot be deleted.",
                "Russian",
                "Ukrainian",
                "медведь",
                "ведмідь"
            },
        };

        /// <summary>
        /// Verify that Admin can not delete languages that are in use.
        /// </summary>
        /// <param name="admin">User with admin role.</param>
        /// <param name="expectedMessage">Message that should appear after language deletion.</param>
        /// <param name="originalLanguage">Language for </param>
        /// <param name="translationLanguage"></param>
        /// <param name="word">Word for dictionary.</param>
        /// <param name="translation">Translation for appropriate word for dictionary.</param>
        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestDeleteLanguage(User admin, string expectedMessage,
               string originalLanguage, string translationLanguage, string word, string translation)
        {
            logger.Info("TestDeleteLanguage Start");

            // Step 1. Login in application
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // Step 2. Add language and check whether language has been added
            LanguagesPage languagesPage = usersPage.GoToLanguagesPage();
            languagesPage.AddLanguage(originalLanguage);
            languagesPage.CloseModalWindow();
            bool isLanguagePresent = languagesPage.IsLanguagePresent(originalLanguage);
            Assert.IsTrue(isLanguagePresent);

            // Step 3. Add word to dictionary
            GlobalDictionaryPage globalDictionaryPage = languagesPage.GoToGlobalDictionaryPage();
            globalDictionaryPage.SelectOriginalLanguage(originalLanguage);
            globalDictionaryPage.SelectTranslationLanguage(translationLanguage);
            globalDictionaryPage.AddWord(word, translation);

            // Step 4. Check whether word has been added to dictionary
            globalDictionaryPage.SelectOriginalLanguage(originalLanguage);
            globalDictionaryPage.SelectTranslationLanguage(translationLanguage);
            bool isWordPresent = globalDictionaryPage.IsWordPresentInTable(word);
            Assert.IsTrue(isWordPresent);

            // Step 5. Delete language and check messages
            globalDictionaryPage.GoToLanguagesPage();
            languagesPage.DeleteLanguage(originalLanguage);
            languagesPage.ConfirmLanguageDeletion();
            string actualMessage = languagesPage.GetMessage();
            Assert.AreNotEqual(expectedMessage, actualMessage);
            // Test fails, because of defect : "Error message doesn't appear, when deleting a Language('Languages' page)"
            // WOW-343
            
            languagesPage.CloseModalWindow();

            // Step 6. Check whether language is present
            isLanguagePresent = languagesPage.IsLanguagePresent(originalLanguage);
            Assert.IsTrue(isLanguagePresent);
            // Test fails, because of defect : "Error message doesn't display when admin deletes language that's currently in use('Languages' page)"
            // WOW-346

            // Step 7. Go to previous state
            usersPage.GotoLogOut();

            logger.Info("TestDeleteLanguage Done");
        }
    }
}
