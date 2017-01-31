﻿using NUnit.Framework;
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
                UserRepository.Get().Admin(), 
                "Afrikaans"                    
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void DeleteLanguage(User admin, string language)
        {
            // Precondition
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();
            
            languagesPage.AddNewLanguage(language);
            Assert.IsTrue(languagesPage.IsLanguageInExistingList(language));

            // Test steps
            languagesPage.DeleteLanguage(language);
            Assert.IsFalse(languagesPage.IsLanguageInExistingList(language));

            // Return to previous state
            loginPage = languagesPage.GoToLogOut();
            Assert.AreEqual(LoginPage.loginDescriptionText, 
                            loginPage.GetLoginDescriptionText());
        }
    }
}