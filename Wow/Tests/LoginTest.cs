using System;
using System.Threading;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Collections.Generic;
using Wow.Data;
using Wow.Pages;
using NLog;

namespace Wow.Tests
{
    [TestFixture]
    public class LoginTest : TestRunner
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
            //new object[] { UserRepository.Get().Student() },
        };

        private static readonly object[] TestExternalData =
            //ListUtils.ToMultiArray(UserRepository.Get().FromDefaultCsv());
            ListUtils.ToMultiArray(UserRepository.Get().FromExcel());

        //[Test, TestCaseSource(nameof(TestExternalData))]
        public void TestRead(User admin)
        {
            Console.WriteLine("Email = " + admin.GetEmail());
            Console.WriteLine("Password = " + admin.GetPassword());
            Console.WriteLine("IsIsAdmin = " + admin.GetIsAdmin());
        }

        [Test, TestCaseSource(nameof(TestSigninData))]
        //[Test, TestCaseSource(nameof(TestExternalData))]
        public void TestSignin(IUser admin)
        {
            logger.Info("Start TestSignin(IUser admin), admin = " + admin.GetEmail());
            // Precondition
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            //UsersPage usersPage = Application.Get().Login().SuccessAdminLogin(admin);
            //
            // Check
            Assert.AreEqual(admin.GetName(), usersPage.GetUsernameText());
            CollectionAssert.IsNotEmpty(usersPage.GetUserTableEMails());
            //
            // Return to previous state
            loginPage = usersPage.GotoLogOut();
            //
            // Check
            Assert.AreEqual(LoginPage.LOGIN_DESCRIPTION_TEXT, loginPage.GetLoginDescriptionText());
            logger.Info("Done TestSignin(IUser admin), admin = " + admin.GetEmail());
        }

        private static readonly object[] CheckData =
        {
             //new object[] { { "111", "info1" }, { "222", "info2" }, { "333", "info3" } },
             new object[] { "111", "info1" },
             new object[] { "222", "info2" },
             new object[] { "333", "info3" },
        };

        private static readonly object[][] TwoDimData =
              { new object[] { "111", "info1" }, new object[] { "222", "info2" }, new object[] { "333", "info3" } };

        //[Test, TestCaseSource(nameof(TwoDimData))]
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
