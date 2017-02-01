using NUnit.Framework;
using Wow.Data;
using Wow.Pages;
using Wow.DataBase;
using NLog;

namespace Wow.Tests
{
    [TestFixture]
    public class CreateCourseTest : TestRunner
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TestSignInData =
            {
                new object[]
                    {
                        StaticUserRepository.Get().Teacher(), "SomeName",
                        "English", "testN work", "Create Course", "Course successfully added"
                    }
            };

        private static bool IsCourseInDataBase(string courseName)
        {
            IRepositorySettings repositorySettings = new RepositorySettings();
            SqlQueriesRunner sqlQueriesRunner = new SqlQueriesRunner(repositorySettings);

            return sqlQueriesRunner.IsCourseWithAppropriateNameInDb(courseName);
        }

        /// <summary>
        /// Verify that new course is created when valid values are entered.
        /// </summary>
        /// <param name="teacher">User with teacher role.</param>
        /// <param name="courseName">Name of a new course.</param>
        /// <param name="courseLanguage">Language of a new course.</param>
        /// <param name="wordSuit">Name of a word suit, which should be added to a new course.</param>
        /// <param name="dialogTitle">Title of a dialog, which informs about successful adding a new course.</param>
        /// <param name="dialogMessage">Message of a dialog, which informs about successful adding a new course.</param>
        [Test, TestCaseSource(nameof(TestSignInData))]
        public void TestCreatingNewCourse(User teacher, string courseName, string courseLanguage,
            string wordSuit, string dialogTitle, string dialogMessage)
        {
            logger.Info(
                "Start TestCreatingNewCourse(User teacher, string courseName, string courseLanguage, string wordSuit,string[] dialogData)");

            // Precondition
            LoginPage loginPage = Application.Get().Login();
            loginPage.ClickLoginButton();
            loginPage.SetLoginData(teacher);
            UsersPage usersPage = loginPage.ClickSubmitLogin();
            usersPage.ClickAdminTab();
            usersPage.OpenSidebarToggle();
            usersPage.SideBarMenu.ClickManagerTool();
            CoursesPage coursesPage = usersPage.SideBarMenu.ClickCoursesItem();

            // Test Steps
            CreateCoursePage createCoursePage = coursesPage.ClickCreateCourse();
            createCoursePage.SetCourseName(courseName);
            createCoursePage.SetCourseLanguage(courseLanguage);
            createCoursePage.DropItem(wordSuit);
            createCoursePage.CreateCourseClick();

            StringAssert.AreEqualIgnoringCase(dialogTitle, createCoursePage.GetDialogTitle());
            StringAssert.AreEqualIgnoringCase(dialogMessage, createCoursePage.GetDialogBodyMessage());

            coursesPage = createCoursePage.CloseDialogWindow();

            // Assert course' presence in table
            Assert.IsNotNull(coursesPage.TableOfCourses.GetRowByValue(courseName));
            // Assert course' presence in DB
            Assert.IsTrue(IsCourseInDataBase(courseName));

            // Post Conditions
            coursesPage.DeleteCourse(courseName);
            coursesPage.ConfirmDeleting();

            // Assert course' absence in DB
            Assert.IsFalse(IsCourseInDataBase(courseName));

            // Return to previous state
            coursesPage.ClickUserName();
            coursesPage.GoToLogOut();

            logger.Info(
               "End TestCreatingNewCourse(User teacher, string courseName, string courseLanguage, string wordSuit, string[] dialogData)");
        }
    }
}