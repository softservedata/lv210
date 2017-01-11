using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class DeleteLanguageTest : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),   // Admin User
                "Afrikaans"                     // Language to delete
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void DeleteLanguage(User admin, string language)
        {
            // Precondition
            admin.SetEmail("admin.wow@ukr.net");
            admin.SetPassword("qwerty");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();

            languagesPage.AddNewLanguage(language);

            // Test steps
            languagesPage.DeleteLanguage();

            Assert.IsFalse(languagesPage.IsLanguageInExistingList(language));   
        }
    }
}
