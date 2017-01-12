using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    class ChangeUserNameTest : TestRunner
    {
        private static readonly object[] ChangeNameTestData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
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

            // Test steps
            // Go to EditProfile page and check if this page is really opened
            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();

            Assert.IsNotNull(yourProfilePage.YourProfileLabel);

            yourProfilePage.ClickEditName();
            Assert.IsNotNull(yourProfilePage.GetNewNameField());

            // Set name with digits and try to change it. Check if appropriate message appears
            yourProfilePage.SetNewName(names[0]);
            yourProfilePage.ChangeName(admin);

            Assert.AreEqual(YourProfilePage.errorMessageForNameWithDigits, yourProfilePage.GetMessageText());

            // Set name with specific symbols and try to change it. Check if appropriate message appears
            yourProfilePage.SetNewName(names[1]);
            yourProfilePage.ChangeName(admin);

            Assert.AreEqual(YourProfilePage.errorMessageForNameWithSymbols, yourProfilePage.GetMessageText());

            // Set correct name try to change it. Check if name is really changed
            yourProfilePage.SetNewName(names[2]);
            yourProfilePage.ChangeName(admin);

            Assert.AreEqual(names[2], admin.GetName());

            // Return to previous state
            loginPage = yourProfilePage.GoToLogOut();
        }
    }
}
