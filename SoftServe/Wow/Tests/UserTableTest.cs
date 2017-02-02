using System.Collections.Generic;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    class UserTableTest : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        private static readonly object[] TestUsersTableData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
                new List<string>
                {
                    "Name",
                    "Email",
                    "Admin Role",
                    "TeacherRole",
                    "StudentRole",
                    "Click to edit"
                },
                2, 3, 4
            }
        };

        /// <summary>
        /// Verify that Admin sees information about users
        /// </summary>
        /// <param name="admin">User with admin role.</param>
        /// <param name="expectedColumnNames">Column names that are presented in table.</param>
        /// <param name="adminColumnIndex"></param>
        /// <param name="teacherColumnIndex"></param>
        /// <param name="studentColumnIndex"></param>
        [Test, TestCaseSource(nameof(TestUsersTableData))]
        public void TestUsersTable(User admin, List<string> expectedColumnNames, int adminColumnIndex, int teacherColumnIndex, int studentColumnIndex)
        {
            logger.Info("TestUsersTable Start");

            // Step 1. Login in application
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // Step 2. Check whether column names are presented in admin table
            List<string> actualColumnNames = usersPage.GetHeadColumnsText();
            CollectionAssert.AreEqual(expectedColumnNames, actualColumnNames);

            // Step 3. Check whether users in appropriate columns in admin table are checked
            usersPage.ClickAdminsTab();
            Assert.IsTrue(usersPage.IsUserCheckedAsAdmin(adminColumnIndex));
            usersPage.ClickTeachersTab();
            Assert.IsTrue(usersPage.IsUserCheckedAsTeacher(teacherColumnIndex));
            usersPage.ClickStudentsTab();
            Assert.IsTrue(usersPage.IsUserCheckedAsStudent(studentColumnIndex));

            // Step 4. Return to previous state
            usersPage.GotoLogOut();

            logger.Info("TestUsersTable Done");
        }
    }
}
