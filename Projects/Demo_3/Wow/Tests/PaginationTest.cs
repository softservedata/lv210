using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Wow.Data;
using Wow.DataBase;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class PaginationTest : TestRunner
    {
        private static readonly object[] PaginationTestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
                GetUsersFromDataBase(),
                GetCountOfUsersFromDataBase()
            },
        };

        private static IList<User> GetUsersFromDataBase()
        {
            IRepositorySettings repositorySettingss = new RepositorySettings();
            DbUserRepository userRepository = new DbUserRepository(repositorySettingss);

            return userRepository.GetAll();
        }

        private static int GetCountOfUsersFromDataBase()
        {
            IRepositorySettings repositorySettingss = new RepositorySettings();
            DbUserRepository userRepository = new DbUserRepository(repositorySettingss);

            return userRepository.FindCountOfUsers();
        }

        private IList<User> GetUsersInRange(IList<User> users, int pageNumber, int maxUserPerPage)
        {
            var startIndex = maxUserPerPage * (pageNumber - 1);
            var endIndex = startIndex + maxUserPerPage;

            return users.Where(user => ((users.IndexOf(user) >= startIndex) && (users.IndexOf(user) < endIndex))).ToList();
        }

        private int CalcCountOfAllUsers(UsersPage usersPage)
        {
            return usersPage.GetCountOfUsersAtPage() +
                   (UsersPage.MaxUsersPerPage * (int.Parse(usersPage.GetTextFromActiveItem()) - 1));
        }

        private void CheckUsersAtTable(IList<User> usersFromDb, UsersPage usersPage)
        {
            var expected = GetUsersInRange(usersFromDb, int.Parse(usersPage.GetTextFromActiveItem()), UsersPage.MaxUsersPerPage);
            var actual = usersPage.GetUsersDataForTable();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(nameof(PaginationTestData))]
        public void TestPagination(User admin, IList<User> usersFromDb, int countOfUsers)
        {
            // Preconditions
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            usersPage.ClickAdminTab();

            // Check if First and StepBack are disabled
            Assert.IsFalse(usersPage.IsFirstItemEnabled());
            Assert.IsFalse(usersPage.IsStepBackItemEnabled());

            usersPage.ClickStepForward();

            // Check if First, StepBack, StepForward, Last are enabled
            Assert.IsTrue(usersPage.AreAllPaginationElementsEnabled());

            // Check if second page of table is displayed
            CheckUsersAtTable(usersFromDb, usersPage);

            usersPage.ClickLast();

            // Check if Last and StepForward are disabled
            Assert.IsFalse(usersPage.IsStepForwardItemEnabled());
            Assert.IsFalse(usersPage.IsLastItemEnabled());

            // Check if last page of table is displayed
            CheckUsersAtTable(usersFromDb, usersPage);

            //Check count of users
            Assert.AreEqual(countOfUsers, CalcCountOfAllUsers(usersPage));

            usersPage.ClickStepBack();

            //Check if First, StepBack, StepForward, Last are enabled
            Assert.IsTrue(usersPage.AreAllPaginationElementsEnabled());

            //Check if last minus one page of table is displayed
            CheckUsersAtTable(usersFromDb, usersPage);

            // Return to previous state
            usersPage.GotoLogOut();
        }
    }
}