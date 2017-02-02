using NLog;
using NUnit.Framework;
using Wow.Appl;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{

    [TestFixture]
    class SidebarInterfaceTestSuite : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void SidebarInterfaceTest()
        {
            logger.Info("Start SidebarInterfaceTest");
            
            // --- Precondition --- //

            // Login
            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(UserRepository.Get().Admin());

            // --- Test Steps --- //

            // Checking 'Study Tools'.section interface
            AssertStudyTools(usersPage, true);

            // Checking 'Teaching Tools' section interface
            AssertTeachingTools(usersPage, true);

            // Checking 'Admin Tools' section interface
            AssertAdminTools(usersPage, true);

            // Checking 'Your Stuff' section interface
            AssertYourStuff(usersPage, true);

            loginPage = usersPage.GotoLogOut();

            logger.Info("Done SidebarInterfaceTest");        
        }
        
        private void AssertStudyTools(UsersPage usersPage, bool expectedResult)
        {
            logger.Info("Start testing 'Study tools' section");

            // Checking visibility and inner text of 'Courses' button            
            Assert.AreEqual(expectedResult, usersPage.IsStudyToolCoursesVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckStudyToolCoursesContent());

            // Checking visibility and inner text of 'Public Groups' button
            Assert.AreEqual(expectedResult, usersPage.IsStudyToolPublicGroupsVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckStudyToolPublicGroupsContent());

            logger.Info("Done testing 'Study tools' section");
        }

        private void AssertTeachingTools(UsersPage usersPage, bool expectedResult)
        {
            logger.Info("Start testing 'Teaching tools' section");

            // Checking visibility and inner text of 'Manager' button
            Assert.AreEqual(expectedResult, usersPage.IsTeachingToolManagerVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckTeachingToolManagerContent());

            // --- Checking Manager dropdown --- //

            // Opening 'Manager' dropdown
            usersPage.ClickManager();

            // Checking visibility and inner text of 'Global Dictionary' button
            Assert.AreEqual(expectedResult, usersPage.IsTeachingToolGlobalDictionaryVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckTeachingToolGlobalDictionaryContent());

            // Checking visibility and inner text of 'Word Suites' button
            Assert.AreEqual(expectedResult, usersPage.IsTeachingToolWordSuitesVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckTeachingToolWordSuitesContent());

            // Checking visibility and inner text of 'Courses' button
            Assert.AreEqual(expectedResult, usersPage.IsTeachingToolCoursesVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckTeachingToolCoursesContent());

            // Checking visibility and inner text of 'Groups' button
            Assert.AreEqual(expectedResult, usersPage.IsTeachingToolGroupsVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckTeachingToolGroupsContent());

            // Checking visibility and inner text of 'Subscription Requests' button
            Assert.AreEqual(expectedResult, usersPage.IsTeachingToolSubscriptionRequestsVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckTeachingToolSubscriptionRequestContent());

            logger.Info("Done testing 'Teaching tools' section");
        }

        private void AssertAdminTools(UsersPage usersPage, bool expectedResult)
        {
            logger.Info("Start testing 'Admin tools' section");

            // Checking visibility and inner text of 'User' button
            Assert.AreEqual(expectedResult, usersPage.IsAdminToolUsersVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckAdminToolUsersContent());

            // Checking visibility and inner text of 'Languages' button
            Assert.AreEqual(expectedResult, usersPage.IsAdminToolLanguagesVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckAdminToolLanguagesContent());

            // Checking visibility and inner text of 'Tickets' button
            Assert.AreEqual(expectedResult, usersPage.IsAdminToolTicketsVisible());
            Assert.AreEqual(expectedResult, usersPage.CheckAdminToolTicketsContent());

            logger.Info("Done testing 'Admin tools' section");
        }

        private void AssertYourStuff(UsersPage usersPage, bool expectedResult)
        {
            logger.Info("Start testing 'Your stuff' section");

            // Checking visibility and inner text of 'Profile' button
            Assert.AreEqual(expectedResult, usersPage.IsYourStuffUsersProfile());
            Assert.AreEqual(expectedResult, usersPage.CheckYourStuffProfileContent());

            logger.Info("Done testing 'Your stuff' section");
        }
    }
}
