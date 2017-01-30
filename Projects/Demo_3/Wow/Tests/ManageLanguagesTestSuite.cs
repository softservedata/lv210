using System;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using Wow.Appl;

namespace Wow.Tests
{
    [TestFixture]
    class ManageLanguagesTestSuite : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().FromXml("Users.xml").GetAdmin(),
                "Afrikaans",                      // Language to add
                "Add language",                 // Dialog window title    // class
                "Language added successfully"   // Dialog window message
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void AddNewLanguageTest(User admin, string languageToAdd, string windowTitle, string windowMessage)
        {
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

            // --- Return to a previous state and check--- //
            languagesPage.DeleteLastAddedLanguage();
            Assert.IsFalse(languagesPage.IsLanguageInExistingList(languageToAdd));

            // --- Logout --- //
            loginPage = languagesPage.GotoLogOut();

            Console.WriteLine("Test Done!");
        }
    }
}
