using NLog;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class LoginTest : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] ExternalData =
            UserRepository.Get().FromJson("Users.json").GetAllUsers();

        [Test, TestCaseSource(nameof(ExternalData))]
        public void TestSignin(IUser user)
        {
            logger.Info("Start 'Sign in test'");

            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            UserPage userPage = loginPage.SuccessUserLogin(user);
            logger.Info($"User {user.GetFullName()} sign in");
            logger.Info($"User login: {user.GetEmail()}");
            logger.Info($"User role (student/teacher/admin): {user.IsStudent()}/{user.IsTeacher()}/{user.IsAdmin()}");
            Assert.AreEqual(user.GetFullName(), userPage.GetUsernameText());

            userPage.GotoLogOut();
            logger.Info($"User {user.GetFullName()} log out");
            logger.Info("Test done");
        }
    }
}