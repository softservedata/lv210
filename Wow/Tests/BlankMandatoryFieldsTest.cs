using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    /// <summary>
    /// WoW - 197
    /// This test verifies that the correct error messages
    /// are shown when leaving mandatory fields blank
    /// </summary>
    [TestFixture]
    public class BlankMandatoryFieldsTest : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),   // Admin User
                "",                             // Blank string
                "starblack",                    // New Password
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void BlankMandatoryFieldsMessageTest(User admin, string blankString, string newPassword)
        {
            // Precondition
            admin.SetEmail("sokt@securehost.com.es");
            admin.SetPassword("blackstar");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // Test steps
            // Go to EditProfile page and check if this page is really opened
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            Assert.NotNull(yourProfilePage.YourProfileLabel);

            // Click on Edit Name and check if this page is really opened
            yourProfilePage.ClickEditName();
            Assert.NotNull(yourProfilePage.GetNewNameField());

            // Leave 'New Name' field empty. Check if appropriate message appears.
            yourProfilePage.ChangeName(admin);
            Assert.AreEqual(YourProfilePage.errorMessageForBlankMandatoryFields, yourProfilePage.GetMessageText());

            yourProfilePage.ClickCancelEditName();

            // Go to Edit Password
            yourProfilePage.ClickEditPassword();
            Assert.NotNull(yourProfilePage.YourProfileLabel);

            // Fill in the 'New Password' and 'Confirm Password' fields
            yourProfilePage.SetBlankCurrentPassword();
            yourProfilePage.SetNewPassword(newPassword);
            yourProfilePage.SetConfirmPassword(newPassword);
            yourProfilePage.ClickChangePassword();
            Assert.AreEqual(YourProfilePage.errorMessageForBlankMandatoryFields, yourProfilePage.GetMessageText());

            // Clear the 'New Password' field and fill in the 'Current Password' field
            yourProfilePage.SetCurrentPassword(admin.GetPassword());
            yourProfilePage.SetBlankNewPassword();
            yourProfilePage.SetConfirmPassword(newPassword);
            yourProfilePage.ClickChangePassword();
            Assert.AreEqual(YourProfilePage.errorMessageForBlankMandatoryFields, yourProfilePage.GetMessageText());

            // Clear the 'Confirm Password' field and fill in the 'New Password' field
            yourProfilePage.SetCurrentPassword(admin.GetPassword());
            yourProfilePage.SetNewPassword(newPassword);
            yourProfilePage.SetBlankConfirmPassword();
            yourProfilePage.ClickChangePassword();
            Assert.AreEqual(YourProfilePage.errorMessageForBlankMandatoryFields, yourProfilePage.GetMessageText());

            // Return to previous state
            loginPage = yourProfilePage.GoToLogOut();
        }
    }
}
