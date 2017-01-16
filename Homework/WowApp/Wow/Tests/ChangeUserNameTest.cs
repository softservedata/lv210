using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class ChangeUserNameTest: TestRunner
    {
        private static readonly object[] ChangeNameTestData =
        {
            new object[]
            {
                StaticUserRepository.Get().Admin(),
                new []
                {
                    "Blue9456 Moon1278",
                    "Blue/*-) Moon!<@;",
                    "Blue Moon"
                },
            },
        };

        [Test, TestCaseSource(nameof(ChangeNameTestData))]
        public void TestChangeName(User admin, string[] names)
        {
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            var userName = admin.GetName();

            // Test steps
            // Go to EditProfile page and check if this page is really opened
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();

            Assert.IsNotNull(yourProfilePage.YourProfileLabel);

            yourProfilePage.ClickEditName();
            Assert.IsNotNull(yourProfilePage.GetNewNameField());

            // Set name with digits and try to change it. Check if appropriate message appears.
            yourProfilePage.ClickEditName();
            yourProfilePage.SetNewName(names[0]);
            yourProfilePage.ChangeName(admin);

            // This method will fail because it is possible to set name with digits.
            Assert.AreEqual(YourProfilePage.ErrorMessageForNameWithDigits, yourProfilePage.GetMessageText());

            // Set name with specific symbols and try to change it. Check if appropriate message appears.
            yourProfilePage.ClickEditName();
            yourProfilePage.SetNewName(names[1]);
            yourProfilePage.ChangeName(admin);

            // This method will fail because it is possible to set name with symbols.
            Assert.AreEqual(YourProfilePage.ErrorMessageForNameWithSymbols, yourProfilePage.GetMessageText());

            // Set correct name try to change it. Check if name is really changed.
            yourProfilePage.ClickEditName();
            yourProfilePage.SetNewName(names[2]);
            yourProfilePage.ChangeName(admin);

            Assert.AreEqual(names[2], admin.GetName());

            // Return to previous state
            yourProfilePage.ClickEditName();
            yourProfilePage.SetNewName(userName);
            yourProfilePage.ClickChangeName();
            yourProfilePage.ChangeName(admin);
            loginPage = yourProfilePage.GotoLogOut();
        }
    }
}
