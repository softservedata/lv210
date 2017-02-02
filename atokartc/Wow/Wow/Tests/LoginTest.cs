using NLog;
using NUnit.Framework;
using System;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class LoginTest : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
        };

        private static readonly object[] TestExternalData =
            ListUtils.ToMultiArray(UserRepository.Get().FromExcel());

        [Test, TestCaseSource(nameof(TestExternalData))]
        public void TestRead(User admin)
        {
            Console.WriteLine("Email = " + admin.GetEmail());
            Console.WriteLine("Password = " + admin.GetPassword());
            Console.WriteLine("IsIsAdmin = " + admin.GetIsAdmin());
        }

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestSignin(IUser admin)
        {
            logger.Info("Start TestSignin(IUser admin), admin = " + admin.GetEmail());
            
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            Assert.AreEqual(admin.GetName(), usersPage.GetUsernameText());
            CollectionAssert.IsNotEmpty(usersPage.GetUsersFromTable());

            // Return to previous state
            loginPage = usersPage.GotoLogOut();

            Assert.AreEqual(LoginPage.LOGIN_DESCRIPTION_TEXT, loginPage.GetLoginDescriptionText());
            logger.Info("Done TestSignin(IUser admin), admin = " + admin.GetEmail());
        }

        private static readonly object[] CheckData =
        {
             new object[] { "111", "info1" },
             new object[] { "222", "info2" },
             new object[] { "333", "info3" },
        };

        private static readonly object[][] TwoDimData =
              { new object[] { "111", "info1" }, new object[] { "222", "info2" }, new object[] { "333", "info3" } };

        [Test, TestCaseSource(nameof(TwoDimData))]
        public void TestFile(string data, string info)
        {
            logger.Info("Start");
            Console.WriteLine("data = " + data);
            Console.WriteLine("info = " + info);
            foreach (IUser user in UserRepository.Get().FromDefaultCsv())
            {
                Console.WriteLine("Email = " + user.GetEmail());
                Console.WriteLine("Password = " + user.GetPassword());
                Console.WriteLine("IsIsAdmin = " + user.GetIsAdmin());
            }
            logger.Info("Done");
        }

    }
}
