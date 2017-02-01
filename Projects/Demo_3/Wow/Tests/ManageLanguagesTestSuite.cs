using System;
using System.Threading;
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
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void AddNewLanguageTest(User admin)
        {
            // Login
            LoginPage loginPage = Application.Get().Login(); // change chrome by IP
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();
            Assert.IsNotNull(languagesPage.GetLanguagePageDescription());

            // --- Test Steps --- //

            // 1. Check if language is not presented on the list of existing languages
            string languageToAdd = languagesPage.GetNewLanguage();
            Assert.IsFalse(languagesPage.IsLanguageInExistingList(languageToAdd));
            
            // 2. Add Language
            languagesPage.AddNewLanguage(languageToAdd);
            Assert.IsTrue(languagesPage.IsDialogWindowAppears(DialogWindowTitle.AddLanguage, DialogWindowMessage.AddLanguage));
            languagesPage.CloseDialogWindow();

            // 3. Check if added language is presented in the list as last language
            Assert.AreEqual(languageToAdd, languagesPage.GetLastLanguage());

            // --- Return to a previous state and check--- //
            languagesPage.DeleteLanguage(languageToAdd);
            Assert.IsFalse(languagesPage.IsLanguageInExistingList(languageToAdd));

            // --- Logout --- //
            languagesPage.GotoLogOut();

            Console.WriteLine("Test Done!");
        }
    }
}
