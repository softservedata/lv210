using NLog;
using Wow.Pages;
using Wow.Data;
using NUnit.Framework;

namespace Wow.Tests
{
    
    [TestFixture]
    class UserRoleTestSuite : TestRunner
    {
        private const int UserIndex = 0;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// This test case verifies that Admin can change user's roles.
        /// The role checkboxes are disabled by default.
        /// The Administrator can gain access to check off or uncheck
        /// these text boxes by clicking on the pencil icon next to the user.
        /// </summary>
        [TestCase("Test V")]
        public void ChangeUserRoleTest(string userName)
        {
            Log.Info("Test started");
           
            // Preconditions
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(UserRepository.Get().Admin());
            usersPage.SetValueToSearch(userName);

            // Test steps
            // Step 1:Check if checkboxes are disabled and edit button is displayed
            Assert.False(usersPage.IsAdminRoleEnabled(UserIndex));
            Assert.False(usersPage.IsTeacherRoleEnabled(UserIndex));
            Assert.False(usersPage.IsStudentRoleEnabled(UserIndex));
            Assert.IsTrue(usersPage.IsDisplayedEditPencil(UserIndex));

            // Step 2: Click edit user role button, check if checkboxes are enabled
            usersPage.EditRole(UserIndex);

            Assert.IsTrue(usersPage.IsDisplayedCheckMark(UserIndex));
            Assert.IsTrue(usersPage.IsAdminRoleEnabled(UserIndex));
            Assert.IsTrue(usersPage.IsTeacherRoleEnabled(UserIndex));
            Assert.IsTrue(usersPage.IsStudentRoleEnabled(UserIndex));

            // Step 3: Change state of teacher role chekbox
            usersPage.SetTeacherRole(UserIndex);
            Assert.False(usersPage.IsTeacherRoleChecked(UserIndex));
            usersPage.FinishEditing(UserIndex);
            Assert.False(usersPage.IsTeacherRoleChecked(UserIndex));

            // Return to previous state
            usersPage.EditRole(UserIndex);
            usersPage.SetTeacherRole(UserIndex);
            usersPage.FinishEditing(UserIndex);
            loginPage = usersPage.GotoLogOut();
            Log.Info("Test passed");
        }
    }
}
