﻿using System;
using NUnit.Framework;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class EditProfileCancelButtonTest : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().FromXml("Users.xml").GetAdmin(),
                "Supernova",                    // New Name
                "starblack",                    // New Password
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void CancelButtonTest(User admin, string newName, string newPassword)
        {
            // Login
            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // --- Test Steps --- //

            // 1. Go to 'Edit Profile' page
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            Assert.IsNotNull(yourProfilePage.YourProfileLabel);
            //admin.SetName(yourProfilePage.GetNameValue());  // Get Current Name
            Console.WriteLine(admin.GetFullName());
            Assert.AreEqual(yourProfilePage.GetNameValue(), admin.GetFullName());

            // 2. Go to 'Edit Name' form
            yourProfilePage.ClickEditName();
            Assert.IsTrue(yourProfilePage.GetNewNameField().IsEnabled);

            // 3. Set new name
            yourProfilePage.SetNewName(newName);

            // 4. Press 'Cancel' and check if information wasn't saved.
            yourProfilePage.CancelNameChanges();
            Assert.AreNotEqual(newName, admin.GetFullName());

            // 5. Go to 'Edit Password' form
            yourProfilePage.ClickEditPassword();
            Assert.IsTrue(yourProfilePage.ArePasswordFieldsEnabled());

            // 6. Set new password
            yourProfilePage.SetCurrentPassword(admin.GetPassword());
            yourProfilePage.SetNewPassword(newPassword);
            yourProfilePage.SetConfirmPassword(newPassword);

            // 7. Press 'Cancel' and check if information wasn't saved.
            yourProfilePage.CancelPasswordChanges();
            Assert.AreNotEqual(admin.GetPassword(), newPassword);

            // --- Logout --- //
            loginPage = yourProfilePage.GotoLogOut();

            Console.WriteLine("Test Done!");
        }
    }
}
