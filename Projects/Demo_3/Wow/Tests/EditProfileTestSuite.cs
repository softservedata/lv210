using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class EditProfileTestSuite : TestRunner
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
            // Precondition
            LoginPage loginPage = Application.Get().Login();
            UserPage usersPage = loginPage.SuccessUserLogin(admin);

            // 1. Go to 'Edit Profile' page
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            Assert.IsNotNull(yourProfilePage.YourProfileLabel);
            Assert.AreEqual(admin.GetFullName(), yourProfilePage.GetNameValue());

            // 2. Go to 'Edit Name' form
            yourProfilePage.ClickEditName();
            Assert.IsTrue(yourProfilePage.GetNewNameField().IsEnabled);

            // 3. Set new name
            yourProfilePage.SetNewName(newName);

            // 4. Press 'Cancel' and check if information wasn't saved.
            yourProfilePage.CancelNameChanges();
            Assert.AreNotEqual(newName, yourProfilePage.GetNameValue());

            // 5. Go to 'Edit Password' form
            yourProfilePage.ClickEditPassword();
            Assert.IsTrue(yourProfilePage.ArePasswordFieldsEnabled());

            // 6. Set new password
            yourProfilePage.SetCurrentPassword(admin.GetPassword());
            yourProfilePage.SetNewPassword(newPassword);
            yourProfilePage.SetConfirmPassword(newPassword);

            // 7. Press 'Cancel' and check if information wasn't saved.
            yourProfilePage.CancelPasswordChanges();
            Assert.AreNotEqual(newPassword, admin.GetPassword());

            yourProfilePage.GotoLogOut();
        }
    }
}