﻿using System;
using System.Threading;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Collections.Generic;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class LoginTest : TestRunner
    {

        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestSignin(User admin)
        {
            // Precondition
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            //UsersPage usersPage = Application.Get().Login().SuccessAdminLogin(admin);
            //
            // Check
            Assert.AreEqual("LV-204 ISTQB", usersPage.GetUsernameText());
            //
            // Return to previous state
            loginPage = usersPage.GotoLogOut();
            //
            // Check
            Assert.AreEqual("SoftServe Language School", loginPage.GetLoginDescriptionText());
        }

        //[Test]
        public void TestFile()
        {
            foreach (IUser user in UserRepository.Get().FromDefaultCsv())
            {
                Console.WriteLine("Email = " + user.GetEmail());
                Console.WriteLine("Password = " + user.GetPassword());
                Console.WriteLine("IsIsAdmin = " + user.GetIsAdmin());
            }
        }

    }
}
