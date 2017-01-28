using System;
using System.Threading;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Collections.Generic;
using System.IO;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class LoginTest : TestRunner
    {

        private static readonly object[] ExternalData =
            ListUtils.ToMultiArray(UserRepository.Get().FromCsv("Users.csv"));

        [Test, TestCaseSource(nameof(ExternalData))]
        public void TestSignin(IUser admin)
        {
            // Precondition
            // Test Steps
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
           
            // Check
            Assert.AreEqual(admin.GetFullName(), usersPage.GetUsernameText());
            //
            // Return to previous state
            loginPage = usersPage.GotoLogOut();
            //
            // Check
            Assert.AreEqual("SoftServe Language School", loginPage.GetLoginDescriptionText());
        }

        //[Test]
        public void Beta()
        {
            string STORAGE_DIR = @"\FileStorage\";
            string _storagePath;
            string fileName = "nn";
            _storagePath = $"{STORAGE_DIR}{fileName}";

            string appDirPath = Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase));
            string fullPath = $"{appDirPath}{_storagePath}";

            Console.WriteLine(appDirPath);
        }
    }
}
