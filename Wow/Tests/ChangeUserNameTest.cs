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
            new object[]
            {
                UserRepository.Get().Admin(),
                new
                {
                    nameWithDigits = "Blue9456 Moon1278",
                    nameWithSymbols = "Blue/*-) Moon!<@;",
                    correctName = "Blue Moon"
                },
                new
                {
                    messageForNameWithDigits = "Name can't contain digits",
                    messageForNameWittSymbols = "Name can't contain reserved characters"
                }
            },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestChangeName(User admin, dynamic names, dynamic messages)
        {
            // Precondition
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
            yourProfilePage.SetNewName(names.nameWithDigits);
            yourProfilePage = yourProfilePage.ChangeName(admin);
            //Assert.AreEqual(messages.messageForNameWithDigits, yourProfilePage.GetMessageText());

            //Set name with specific symbols and try to change it. Check if appropriate message appears.
            yourProfilePage.SetNewName(names.nameWithSymbols);
            yourProfilePage = yourProfilePage.ChangeName(admin);
            //Assert.AreEqual(messages.messageForNameWittSymbols, yourProfilePage.GetMessageText());

            //Set correct name try to change it. Check if name is really changed.
            yourProfilePage.SetNewName(names.correctName);
            yourProfilePage = yourProfilePage.ChangeName(admin);
            //Assert.AreEqual(admin.Name, yourProfilePage.GetNameValue());
            //TODO ask in which way it is better to check data
            Assert.AreEqual(names.correctName, yourProfilePage.GetNameValue());

            // Return to previous state
            loginPage = yourProfilePage.GotoLogOut();
        }
    }
}
