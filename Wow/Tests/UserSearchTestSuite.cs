using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    /// This test case verifies that Admin can can search the users
    /// which matches the entered criteria.
    /// A search box is displayed next to the tabs.It allows searching users by their name.

    [TestFixture]
    class UserSearchTestSuite
    {
        [TestCase("Test V")]
        [TestCase("Test")]
        public void UserSearchTest(string userName)
        {
            const string DEFAULT_TEXT = "Search users";
            
            // Preconditions
            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(UserRepository.Get().Admin());

            // Test Steps
            // Step 1: Check default value of search box Input users name into search field
            Assert.AreEqual(DEFAULT_TEXT, usersPage.GetUserSearchBoxText());

            // Step 2: Enter user name into sezrch box
            usersPage.SetValueToSearch(userName);
            
            // Step 3: Check if user name from test data are equal with user from table
            IList<User> actual = usersPage.GetUsersDataForTable();
            IList<User> expected = actual.Where(item => item.GetName().Contains(userName)).ToList();
            Assert.AreEqual(expected,actual);
            
            // Return to previous state
            loginPage = usersPage.GotoLogOut();
        }
    }
}

