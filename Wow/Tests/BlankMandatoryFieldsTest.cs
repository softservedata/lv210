using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class BlankMandatoryFieldsTest : TestRunner
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(), // Admin User
                "", // Blank string
                "starblack", // New Password
                "All fields are mandatory" //Error message
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void BlankMandatoryFieldsMessageTest(User admin, string blankString, string newPassword, string errorMessage)
        {
            // Precondition
            admin.SetEmail("sokt@securehost.com.es");
            admin.SetPassword("blackstar");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            //Test steps
            //Go to EditProfile page and check if this page is really opened
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            //Assert
            Assert.NotNull(yourProfilePage.YourProfileLabel);

            //Click on Edit Name. Check
            yourProfilePage.ClickEditName();
            //Assert
            Assert.NotNull(yourProfilePage.GetNewNameField());

            //Leave 'New Name' field empty. Check if appropriate message appears.
            yourProfilePage = yourProfilePage.ChangeName(admin);
            //Assert.AreEqual(errorMessage, yourProfilePage.GetMessageText());

            yourProfilePage.ClickCancel();

            //go to edit password
            yourProfilePage.ClickEditPassword();
            Assert.NotNull(yourProfilePage.YourProfileLabel);

            //leave password
            yourProfilePage.SetNewPassword(newPassword);
            yourProfilePage.SetConfirmPassword(newPassword);

            yourProfilePage.ClickChangePassword();

            //Assert.AreEqual(errorMessage, yourProfilePage.GetMessageText());

            //leave password
            yourProfilePage.SetCurrentPassword(admin.GetPassword());
            yourProfilePage.SetNewPassword(blankString);
            yourProfilePage.SetConfirmPassword(newPassword);

            yourProfilePage.ClickChangePassword();

            Assert.AreEqual(errorMessage, yourProfilePage.GetMessageText());

            //leave password
            yourProfilePage.SetCurrentPassword(admin.GetPassword());
            yourProfilePage.SetNewPassword(newPassword);
            yourProfilePage.SetConfirmPassword(blankString);

            yourProfilePage.ClickChangePassword();

            Assert.AreEqual(errorMessage, yourProfilePage.GetMessageText());

            // Return to previous state
            loginPage = yourProfilePage.GotoLogOut();
        }
    }
}
