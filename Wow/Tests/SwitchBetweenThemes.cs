using ArtOfTest.WebAii.Controls.HtmlControls;
using NUnit.Framework;
using System.Threading;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;
using System;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Collections.Generic;
using ArtOfTest.WebAii.Win32.Dialogs;

namespace Wow.Tests
{
    [TestFixture]
    class SwitchBetweenThemes : TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void IfUserCanSwitchBetweenThemes(User admin)
        {
            // Precondition
            admin.SetEmail("bslw@wovz.cu.cc");
            admin.SetPassword("phoenixrising");

            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // --- Test Steps --- //

            #region Step 1: Click on the theme selection drop-down list on top of the page

            usersPage.OpenThemeDropdown();
            Manager manager;
            Settings mySettings = new Settings();
            manager = new Manager(mySettings);
            HtmlInputUrl link = manager.ActiveBrowser.Find.ByTagIndex<HtmlInputUrl>("//link[@href = 'dist/styles-concat-blue-theme.css']", 0);
            Assert.IsTrue(link.Text.ToLower().Contains("blue"));
            #endregion EndStep 1: The Blue theme is selected by default

            loginPage = usersPage.GotoLogOut();
        }
    }
}