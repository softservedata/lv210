using System;
using NUnit.Framework;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class EditGropsTestSuite
    {
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
            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UserPage usersPage = loginPage.SuccessUserLogin(teacher);
            GroupsPage groupsPage = usersPage.GotoGroupsPage();
            CreateGroupPage createGroupPage = groupsPage.ClickCreateGroup();

            string usedName = groupsPage.GetExistingGroupName();
            createGroupPage.SetGroupName(usedName);
            createGroupPage.ClickSubmitButton();

            StringAssert.Contains($"Group {usedName} already exist!", createGroupPage.GetErrorMessage());
            createGroupPage.GotoLogOut();
            Console.WriteLine("Test Done!");
        }
    }
}