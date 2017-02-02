using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class AddWordToDictionaryTest : TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
                "Russian",
                "Ukrainian",
                "медведь",
                "Ведмідь"
            },
        };

        [TestCaseSource(nameof(TestSigninData))]
        public void AddNewWordTest(User admin, string originalLanguage, string translationLanguage, string word, string translation)
        {
            Application myApp = Application.Get();
            LoginPage loginPage = myApp.Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GoToLanguagesPage();
            GlobalDictionaryPage globalDictionaryPage = languagesPage.GoToGlobalDictionaryPage();

            globalDictionaryPage.SelectOriginalLanguage(originalLanguage);
            globalDictionaryPage.SelectTranslationLanguage(translationLanguage);
            globalDictionaryPage.AddWord(word, translation);

            globalDictionaryPage.SelectOriginalLanguage(originalLanguage);
            globalDictionaryPage.SelectTranslationLanguage(translationLanguage);

            bool isWordPresent = globalDictionaryPage.IsWordPresentInTable(word);

            Assert.IsTrue(isWordPresent);
        }
    }
}
