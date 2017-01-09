using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    /// <summary>
    /// WoW-191
    /// This test verifies that the correct messages are shown if the entered data 
    /// in the 'New Name' field is too short (less than 7 characters) 
    /// or too long (more than 31 characters).
    /// </summary>
    [TestFixture]
    public class TooShortTooLongUserNameTest : TestRunner
    {
        private static readonly object[] TestSigninData =
           {
            new object[]
            {
                UserRepository.Get().Admin(),
                new
                {
                    tooShortName = "Blu Mo",
                    tooLongName = "Blueblueblueblue Moonmoonmoonmoo",
                    correctName = "Blue Moon"
                },
                new
                {
                    errorMessageForTooShortName = "Name can't be shorter than 7 characters",
                    errorMessageForTooLongName = "Name can't be longer than 31 characters"
                }
            },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TooShortUserNameTest(User admin, dynamic names, dynamic messages)
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

            //Click on Edit Name. Check
            yourProfilePage.ClickEditName();
            //Assert
            Assert.IsTrue(yourProfilePage.GetNewNameField() != null);

            //Fill 'New Name' field with too short name. Check if appropriate message appears.
            yourProfilePage.SetNewName(names.tooShortName);
            yourProfilePage = yourProfilePage.ChangeName(admin);
            Assert.AreEqual(messages.errorMessageForTooShortName, yourProfilePage.GetMessageText());

            // Return to previous state
            loginPage = yourProfilePage.GotoLogOut();
        }

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TooLongUserNameTest(User admin, dynamic names, dynamic messages)
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

            //Click on Edit Name. Check
            yourProfilePage.ClickEditName();
            //Assert
            Assert.IsTrue(yourProfilePage.GetNewNameField() != null);

            //Fill 'New Name' field with too long name. Check if appropriate message appears.
            yourProfilePage.SetNewName(names.tooLongName);
            yourProfilePage = yourProfilePage.ChangeName(admin);
            Assert.AreEqual(messages.errorMessageForTooLongName, yourProfilePage.GetMessageText());

            // Return to previous state
            loginPage = yourProfilePage.GotoLogOut();
        }


        [Test, TestCaseSource(nameof(TestSigninData))]
        public void CorrectUserNameTest(User admin, dynamic names, dynamic messages)
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

            //Click on Edit Name. Check
            yourProfilePage.ClickEditName();
            //Assert
            Assert.IsTrue(yourProfilePage.GetNewNameField() != null);

            //Fill 'New Name' field with correct name. Check if name is really changed.
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
