using System;
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
    public class UnregisteredUserLogin : TestRunner
    {

        private static readonly object[] TestSigninData =
        {
            new object[] 
            {
                UserRepository.Get().NewUser(),
                new string []
                {
                    "theabyss@example.com",     // email
                    "phoenixrising"             //password
                }
            },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void CheckIfAnUnregisteredUserCantLoginInToTheSystem(User unregisteredUser, string notExistingEmail, string notExistingPassword)
        {
            // --- Test Steps  ---//
            #region Step 1: Press the 'Login' button in the upper right corner

            LoginPage loginPage = Application.Get().Login();
            loginPage.ClickLoginButton();

            #endregion EndStep 1: A small 'Login' window appears

            #region Step 2: Fill in the 'E-mail' and 'Password' fields

            unregisteredUser.SetEmail(notExistingEmail);
            unregisteredUser.SetPassword(notExistingPassword);

            #endregion EndStep 2: E-mail: theabyss@example.com. Password: theabyss

            #region Step 3: Press the 'Sign In' button

            loginPage.GetSubmitInput().Click();

            #endregion EndStep 3: A red error message appears above the 'Sign In' button: 'Wrong e-mail or password' 


        }
    }
}
