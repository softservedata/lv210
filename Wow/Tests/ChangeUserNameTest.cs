using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class ChangeUserNameTest: TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestChangeName(User admin)
        {
            // Precondition
            admin.SetEmail("mbnur@maildx.com");
            admin.SetPassword("bluemoon");
            admin.Name = "Blue Moon";

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            //Test steps
            //Go to EditProfile page and check if this page is really opened
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            //Assert
            Assert.IsTrue(yourProfilePage.YourProfileLabel != null);

            //????????????
            yourProfilePage.ClickEditName();
            Assert.IsTrue(yourProfilePage.GetNewNameField() != null);

            //Set name with digits and try to change it. Check if appropriate message appears.
            yourProfilePage.SetNewName("Blue9456 Moon1278");
            yourProfilePage = yourProfilePage.ClickChangeName();
            Assert.AreEqual("Name can't contain digits", yourProfilePage.GetMessageText());

            //Set name with specific symbols and try to change it. Check if appropriate message appears.
            yourProfilePage.SetNewName("Blue/*-) Moon!<@;");
            yourProfilePage = yourProfilePage.ClickChangeName();
            Assert.AreEqual("Name can't contain reserved characters", yourProfilePage.GetMessageText());

            //Set correct name try to change it. Check if name is really changed.
            yourProfilePage.SetNewName("Blue Moon");
            yourProfilePage = yourProfilePage.ClickChangeName();
            Assert.AreEqual(admin.Name, yourProfilePage.GetNameValue());

            // Return to previous state
            loginPage = yourProfilePage.GotoLogOut();
        }
    }
}
