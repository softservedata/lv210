using System;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using Wow.Appl;

namespace Wow.Tests
{
    [TestFixture]
    class AddNewLanguageTest : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),   // Admin user
                "Afrikaans",                    // Language to add
                "Add language",                 // Dialog window title 
                "Language added successfully"   // Dialog window message
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void AddAfrikaansLanguageTest(User admin, string languageToAdd, string windowTitle, string windowMessage)
        {
            // --- Precondition --- //

            admin.SetEmail("admin.wow@ukr.net");
            admin.SetPassword("qwerty");

            // Login
            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();
            Assert.IsNotNull(languagesPage.GetLanguagePageDescription());

            // --- Test Steps --- //

            // 1. Check if language is not presented on the list of existing languages
            Assert.IsFalse(languagesPage.IsLanguageInExistingList(languageToAdd));

            // 2. Add Language
            languagesPage.AddNewLanguage(languageToAdd);
            Assert.IsTrue(languagesPage.IsAddLanguageDialogWindowAppear(windowTitle, windowMessage));
            languagesPage.CloseAddLanguageDialogWindow();

            // 3. Check if added language is presented in the list as last language
            Assert.AreEqual(languageToAdd, languagesPage.GetLastLanguageRowFromExistingList().InnerText);

            // --- Return to a previous state --- //
            languagesPage.DeleteLastAddedLanguage();

            // --- Logout --- //
            loginPage = languagesPage.GotoLogOut();

            Console.WriteLine("Test Done!");
        }
    }
}
