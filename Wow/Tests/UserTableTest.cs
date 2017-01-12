using System.Linq;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    class UserTableTest : TestRunner
    {
        // First object is user data from repository
        // Second object is array of strings represents column names for user table
        private static readonly object[] TestUsersTableData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
                new string[]
                {
                    "Name",
                    "Email",
                    "Admin Role",
                    "TeacherRole",
                    "StudentRole",
                    "Click to edit"
                }
            }
        };

        [Test, TestCaseSource(nameof(TestUsersTableData))]
        public void TestUsersTable(User user, string[] columnNames)
        {
            // Test steps
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(user);

            // Check whether column names are presented in user table
            foreach (var columnName in columnNames)
            {
                Assert.IsTrue(usersPage.GetHeadColumnsText().Contains(columnName));
            }

            // Check whether users in appropriate columns in user table are checked
            Assert.IsTrue(usersPage.IsUserCheckedAsAdmin());
            Assert.IsTrue(usersPage.IsUserCheckedAsTeacher());
            Assert.IsTrue(usersPage.IsUserCheckedAsStudent());

            // Return to previous state
            usersPage.GotoLogOut();
        }
    }
}
