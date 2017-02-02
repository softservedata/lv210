using NUnit.Framework;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class SwitchingBetweenThemes : TestRunner
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

            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.DefaultBrowser()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // --- Test Steps --- //

            // Step 1: Click on the theme selection drop-down list on top of the page

            usersPage.OpenThemeDropdown();

            Assert.IsTrue(usersPage.IsBlueThemeSelected());

            // EndStep 1: The Blue theme is selected by default

            // Step 2: Select the Dark theme from the drop-down list

            usersPage.SelectDarkTheme();

            Assert.IsTrue(usersPage.IsDarkThemeSelected());

            // EndStep 2: The theme changed to the Dark one
           
            // Return to default state
            loginPage = usersPage.GotoLogOut();
        }
    }
}