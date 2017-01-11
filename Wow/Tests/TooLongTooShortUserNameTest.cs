﻿using NUnit.Framework;
using Wow.Data;
using Wow.Pages;


namespace Wow.Tests
{
    /// <summary>
    /// WoW-191
    /// This test verifies that the correct messages are shown if the entered data 
    /// in the 'New Name' field is too short (less than 7 characters) 
    /// or too long (more than 31 characters).
    /// </summary>
    class TooLongTooShortUserNameTest : TestRunner
    {
        private static readonly object[] TestSigninData =
           {
            new object[]
            {
                UserRepository.Get().Admin(),
                new
                {
                    tooShortName = "Blu Mo",
                    tooLongName = "Blueblueblueblue Moonmoonmoonmoo",
                    correctName = "Blue Moon"
                },
                new
                {
                    tooShortNameErrorMessage = "Name can't be shorter than 7 characters",
                    tooLongNameErrorMessage = "Name can't be longer than 31 characters"
                }
            },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void ShortLongUserNameTest(User admin, dynamic names, dynamic messages)
        {
            // Precondition
            admin.SetName("Blue Moon");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // Test steps
            // Go to EditProfile page and check if this page is really opened
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            Assert.IsTrue(yourProfilePage.YourProfileLabel != null);

            //Click on Edit Name check if this page is really opened
            yourProfilePage.ClickEditName();
            Assert.IsTrue(yourProfilePage.GetNewNameField() != null);

            //Fill 'New Name' field with too short name. Check if appropriate message appears.
            yourProfilePage.SetNewName(names.tooShortName);
            yourProfilePage = yourProfilePage.ChangeName(admin);
            Assert.AreEqual(messages.tooShortNameErrorMessage, yourProfilePage.GetMessageText());

            //Fill 'New Name' field with too long name. Check if appropriate message appears.
            yourProfilePage.SetNewName(names.tooLongName);
            yourProfilePage = yourProfilePage.ChangeName(admin);
            Assert.AreEqual(messages.tooLongNameErrorMessage, yourProfilePage.GetMessageText());

            //Fill 'New Name' field with correct name. Check if name is really changed.
            yourProfilePage.SetNewName(names.correctName);
            yourProfilePage = yourProfilePage.ChangeName(admin);
            Assert.AreEqual(names.correctName, yourProfilePage.GetNameValue());

            // Return to previous state
            loginPage = yourProfilePage.GotoLogOut();
        }
    }
}
