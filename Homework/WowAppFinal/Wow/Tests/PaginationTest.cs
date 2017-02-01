using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Wow.Data;
using Wow.DataBase;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    /// <summary>
    /// Contains method that verifies pagination on the 'Admin' tab at the 'Users' page.
    /// Contains appropriate data objects.
    /// </summary>
    [TestFixture]
    public class PaginationTest : TestRunner
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] PaginationTestData =
        {
            new object[]
            {
                StaticUserRepository.Get().Admin(),
                GetUsersFromDataBase(),
                GetCountOfUsersFromDataBase()
            },
        };

        private static IList<IUser> GetUsersFromDataBase()
        {
            IRepositorySettings repositorySettingss = new RepositorySettings();
            UserRepository userRepository = new UserRepository(repositorySettingss);

            return userRepository.GetAll();
        }

        private static int GetCountOfUsersFromDataBase()
        {
            IRepositorySettings repositorySettingss = new RepositorySettings();
            UserRepository userRepository = new UserRepository(repositorySettingss);

            return userRepository.FindCountOfUsers();
        }

        private IList<IUser> GetUsersInRange(IList<IUser> users, int pageNumber, int maxUserPerPage)
        {
            var startIndex = maxUserPerPage * (pageNumber - 1);
            var endIndex = startIndex + maxUserPerPage;

            return users.Where(user => ((users.IndexOf(user) >= startIndex) && (users.IndexOf(user) < endIndex))).ToList();
        }

        // Table contains head row
        private int CalcCountOfAllUsers(UsersPage usersPage)
        {
            return usersPage.GetCountOfUsersAtPage() +
                   (UsersPage.MaxUsersPerPage * (int.Parse(usersPage.GetTextFromActiveItem()) - 1));
        }

        private void CheckUsersAtTable(IList<IUser> usersFromDb, UsersPage usersPage)
        {
            var expected = this.GetUsersInRange(usersFromDb, int.Parse(usersPage.GetTextFromActiveItem()), UsersPage.MaxUsersPerPage);
            var actual = usersPage.GetUsersFromCurrentTablePage();
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies pagination on the 'Admin' tab at the 'Users' page.
        /// </summary>
        /// <param name="admin">User that does logging in application.</param>
        /// <param name="usersFromDb">All users from database.</param>
        /// <param name="countOfUsers">Count of all users from database.</param>
        [Test, TestCaseSource(nameof(PaginationTestData))]
        public void TestPagination(IUser admin, IList<IUser> usersFromDb, int countOfUsers)
        {
            logger.Info("Start TestPagination(IUser admin, IList<IUser> usersFromDb, int countOfUsers)");

            // Preconditions
            LoginPage loginPage = Application.Get().Login();
            loginPage.ClickLoginButton();
            loginPage.SetLoginData(admin);
            UsersPage usersPage = loginPage.ClickSubmitLogin();
            usersPage.ClickAdminTab();

            // Check if First and StepBack are disabled
            Assert.IsFalse(usersPage.TableOfUsers.IsFirstItemEnabled());
            Assert.IsFalse(usersPage.TableOfUsers.IsStepBackItemEnabled());

            usersPage.ClickStepForward();

            // Check if First, StepBack, StepForward, Last are enabled
            Assert.IsTrue(usersPage.TableOfUsers.AreAllPaginationElementsEnabled());

            // Check if second page of table is displayed
            CheckUsersAtTable(usersFromDb, usersPage);

            usersPage.ClickLast();

            // Check if Last and StepForward are disabled
            Assert.IsFalse(usersPage.TableOfUsers.IsStepForwardItemEnabled());
            Assert.IsFalse(usersPage.TableOfUsers.IsLastItemEnabled());

            // Check if last page of table is displayed
            CheckUsersAtTable(usersFromDb, usersPage);

            // Check count of users
            Assert.AreEqual(countOfUsers, this.CalcCountOfAllUsers(usersPage));

            usersPage.ClickStepBack();

            // Check if First, StepBack, StepForward, Last are enabled
            Assert.IsTrue(usersPage.TableOfUsers.AreAllPaginationElementsEnabled());

            // Check if last minus one page of table is displayed
            CheckUsersAtTable(usersFromDb, usersPage);

            // Return to previous state
            usersPage.ClickUserName();
            usersPage.GoToLogOut();

            logger.Info("End TestPagination(IUser admin, IList<IUser> usersFromDb, int countOfUsers)");
        }
    }
}