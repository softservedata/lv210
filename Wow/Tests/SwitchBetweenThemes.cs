using NUnit.Framework;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class SwitchBetweenThemes : TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void IfUserCanSwitchBetweenThemes(User admin)
        {
            // --- Precondition ---//
            admin.SetEmail("bslw@wovz.cu.cc");
            admin.SetPassword("phoenixrising");

            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // --- Test Steps --- //

            #region Step 1: Click on the theme selection drop-down list on top of the page

            usersPage.OpenThemeDropdown();
            bool isBlueThemeSelcted = usersPage.IsBlueThemeSelected();

            Assert.IsTrue(isBlueThemeSelcted);

            #endregion EndStep 1: The Blue theme is selected by default

            #region Step 2: Select the Dark theme from the drop-down list

            usersPage.SelectDarkTheme();
            bool isdarkThemeSelcted = usersPage.IsDarkThemeSelected();

            Assert.IsTrue(isdarkThemeSelcted);

            #endregion EndStep 2: The theme changed to the Dark one

            #region Return to default state

            loginPage = usersPage.GotoLogOut();

            #endregion
        }
    }
}