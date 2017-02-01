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
    class TooLongTooShortUserNameTest : TestRunner
    {
        private static readonly object[] TestData =
           {
            new object[]
            {
                UserRepository.Get().Admin(),
                new string[]
                {
                    "Blu Mo",
                    "Blueblueblueblue Moonmoonmoonmoo",
                    "Blue Moon"
                },
            },
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void ShortLongUserNameTest(User admin, string[] names)
        {
            // Precondition
            admin.SetEmail("mbnur@maildx.com");
            admin.SetPassword("bluemoon");

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            // Test steps
            // Go to EditProfile page and check if this page is really opened
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();
            Assert.NotNull(yourProfilePage.YourProfileLabel);

            //Click on Edit Name check if this page is really opened
            yourProfilePage.ClickEditName();
            Assert.NotNull(yourProfilePage.GetNewNameField());

            //Fill 'New Name' field with too short name. Check if appropriate message appears.
            yourProfilePage.SetNewName(names[0]);
            yourProfilePage.ChangeName(admin);
            Assert.AreEqual(YourProfilePage.ErrorMessageForTooShortName, yourProfilePage.GetMessageText());

            //Fill 'New Name' field with too long name. Check if appropriate message appears.
            yourProfilePage.SetNewName(names[1]);
            yourProfilePage.ChangeName(admin);
            Assert.AreEqual(YourProfilePage.ErrorMessageForTooLongName, yourProfilePage.GetMessageText());

            //Fill 'New Name' field with correct name. Check if name is really changed.
            yourProfilePage.SetNewName(names[2]);
            yourProfilePage.ChangeName(admin);
            Assert.AreEqual(names[2], admin.GetName());

            // Return to previous state
            loginPage = yourProfilePage.GoToLogOut();
        }
    }
}
