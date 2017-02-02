using System;
using NLog;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class EditGropsTestSuite
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().FromXml("Users.xml").GetTeacher()
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void CreateNewGroup(User teacher)
        {
            logger.Info("Start 'Create New Group' test");
            LoginPage loginPage = Application.Get().Login();
            UserPage usersPage = loginPage.SuccessUserLogin(teacher);
            GroupsPage groupsPage = usersPage.GotoGroupsPage();
            CreateGroupPage createGroupPage = groupsPage.ClickCreateGroup();

            string usedName = groupsPage.GetExistingGroupName();
            createGroupPage.SetGroupName(usedName);
            createGroupPage.ClickSubmitButton();

            StringAssert.Contains($"Group {usedName} already exist!", createGroupPage.GetErrorMessage());
            createGroupPage.GotoLogOut();
            logger.Info("Test done");
        }
    }
}