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
    class EditProfileCancelButtonTest : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),   // Admin User
                "Supernova",                    // New Name
                "starblack",                    // New Password
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void CancelButtonTest(User admin, string newName, string newPassword)
        {
            // --- Precondition --- //

            admin.SetEmail("sokt@securehost.com.es");
            admin.SetPassword("blackstar");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // --- Test Steps --- //

            // Go to Edit Profile Page
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            Assert.IsNotNull(yourProfilePage.YourProfileLabel);
            admin.SetName(yourProfilePage.GetNameValue());  // Get Current Name

            // Go to Edit Name Form
            yourProfilePage.ClickEditName();
            Assert.IsNotNull(yourProfilePage.GetNewNameField());

            // Set New Name
            yourProfilePage.SetNewName(newName);

            // Press 'Cancel' and check if information wasn't saved.
            yourProfilePage.ClickCancel();
            Assert.AreNotEqual(admin.GetName(), newName);

            // Go to Edit Password Form
            yourProfilePage.ClickEditPassword();
            Assert.IsNotNull(yourProfilePage.YourProfileLabel);

            // Set New Password
            yourProfilePage.SetCurrentPassword(admin.GetPassword());
            yourProfilePage.SetNewPassword(newPassword);
            yourProfilePage.SetConfirmPassword(newPassword);

            // Press 'Cancel' and check if information wasn't saved.
            yourProfilePage.ClickCancelPassword();
            Assert.AreNotEqual(admin.GetPassword(), newPassword);

            // Logout
            loginPage = yourProfilePage.GotoLogOut();

            Console.WriteLine("Test Done!");
        }
    }
}
