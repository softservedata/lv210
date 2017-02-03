using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using NLog;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
   [TestFixture]
    public class UserSearchTestSuite
    {
        private const string DefaultSearchPlaceholderValue = "Search users";
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// This test case verifies that Admin can can search the users
        /// which matches the entered criteria.
        /// A search box is displayed next to the tabs.It allows searching users by their name.
        /// </summary>
        [TestCase("Test V", new string[] {"Test V"})]
        [TestCase("Test", new string[] {"Test TicherI", "Test V"})]
        public void UserSearchTest(string userName, string[] expectedResult)
        {
            Log.Info("Test started");

            // Preconditions
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(UserRepository.Get().Admin());

            // Test Steps
            // Step 1: Check default value of search box Input users name into search field
            Assert.AreEqual(DefaultSearchPlaceholderValue, usersPage.GetUserSearchBoxText());

            // Step 2: Enter user name into search box
            usersPage.SetValueToSearch(userName);

            // Step 3: Check if user name from test data are equal with user from table
            IList<string> actual = usersPage.GetUsersFromCurrentTablePage().Select(user => user.GetFirstName()).ToList();
            IList<string> expected = new List<string>(expectedResult);
            Assert.AreEqual(expected, actual);

            // Return to previous state
            loginPage = usersPage.GotoLogOut();
            Log.Info("Test passed");
        }

        [TestCase("Undefined user")]
        public void UserSearchNegativeTest(string userName)
        {
            Log.Info("Test started");
            
            // Preconditions
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(UserRepository.Get().Admin());

            // Test Steps
            // Step 1: Check default value of search box Input users name into search field
            Assert.AreEqual(DefaultSearchPlaceholderValue, usersPage.GetUserSearchBoxText());

            // Step 2: Enter user name into search box
            usersPage.SetValueToSearch(userName);

            // Step 3: Check if users list of usernames is empty
            IList<string> actual = usersPage.GetUsersFromCurrentTablePage().Select(user => user.GetFirstName()).ToList();
            CollectionAssert.IsEmpty(actual);

            // Return to previous state
            loginPage = usersPage.GotoLogOut();

            Log.Info("Test passed");
        }
    }
}

