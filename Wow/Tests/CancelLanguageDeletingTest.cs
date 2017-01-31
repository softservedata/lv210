using NUnit.Framework;
using NLog;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class CancelLanguageDeletingTest : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
            logger.Info("Start CancelLanguageDeleting(IUser admin, string language), admin = " + admin.GetEmail());

            // Precondition
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();

            languagesPage.AddNewLanguage(language);
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Test steps
            languagesPage.CancelDeletingOfLanguage(language);
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Return to previous state
            languagesPage.DeleteLanguage(language);
            loginPage = languagesPage.GoToLogOut();
            Assert.AreEqual(LoginPage.loginDescriptionText, 
                            loginPage.GetLoginDescriptionText());

            logger.Info("Done CancelLanguageDeleting(IUser admin, string language), admin = " + admin.GetEmail());
        }
    }
}
