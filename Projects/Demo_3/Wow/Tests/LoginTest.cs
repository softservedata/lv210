using System;
using System.Threading;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Collections.Generic;
using System.IO;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class LoginTest : TestRunner
    {

        private static readonly object[] ExternalData =
            //UserRepository.Get().FromCsv("Users.csv").GetAllUsers();
            {UserRepository.Get().FromJson("Users.json").GetAdmin()};
            //UserRepository.Get().FromXml("Users.xml").GetAllUsers();
            //UserRepository.Get().FromExcel("Users.xlsx").GetAllUsers();

        //[Test, TestCaseSource(nameof(ExternalData))]
        public void TestSignin(IUser admin)
        {
            // Precondition
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // Check
            Assert.AreEqual(admin.GetFullName(), usersPage.GetUsernameText());
            //
            // Return to previous state
            loginPage = usersPage.GotoLogOut();
            //
            // Check
            Assert.AreEqual("SoftServe Language School", loginPage.GetLoginDescriptionText());
        }

        [Test, TestCaseSource(nameof(ExternalData))]
        public void Beta(IUser admin)
        {
            LoginPage loginPage = Application.Get().Login(); // change chrome by IP
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            LanguagesPage languagesPage = usersPage.GotoLanguagesPage();
            Assert.IsNotNull(languagesPage.GetLanguagePageDescription());

            languagesPage.GetAddedLanguages();
            Manager m = Manager.Current;
            m.Dispose();
        }
    }
}
