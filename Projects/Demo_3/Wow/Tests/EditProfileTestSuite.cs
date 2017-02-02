using NLog;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class EditProfileTestSuite : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TestData =
            UserRepository.Get().FromXml("Users.xml").GetAllUsers();

        [Test, TestCaseSource(nameof(TestData))]
        public void CancelButtonTest(User user)
        {
            logger.Info("Start 'Cancel button test'");
            string newName = "Supernova";
            string newPassword = "q^&$$fds12>&";

            // Precondition
            LoginPage loginPage = Application.Get().Login();
            UserPage usersPage = loginPage.SuccessUserLogin(user);
            logger.Info($"User {user.GetFullName()} sing in");
            logger.Info($"User role: {user.IsStudent()}/{user.IsTeacher()}/{user.IsAdmin()}");

            // 1. Go to 'Edit Profile' page
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            Assert.IsNotNull(yourProfilePage.YourProfileLabel);
            Assert.AreEqual(user.GetFullName(), yourProfilePage.GetNameValue());

            // 2. Go to 'Edit Name' form
            int a = 2;
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
            yourProfilePage.SetCurrentPassword(user.GetPassword());
            yourProfilePage.SetNewPassword(newPassword);
            yourProfilePage.SetConfirmPassword(newPassword);

            // 7. Press 'Cancel' and check if information wasn't saved.
            yourProfilePage.CancelPasswordChanges();
            Assert.AreNotEqual(newPassword, user.GetPassword());

            yourProfilePage.GotoLogOut();
            logger.Info($"User {user.GetFullName()} log out");
            logger.Info("Test done");
        }
    }
}