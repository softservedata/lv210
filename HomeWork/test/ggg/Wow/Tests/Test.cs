using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    class Test : TestRunner
    {
        private static readonly object[] SigninData =
        {
            new object[]
            {
                UserRepository.Get().Admin(),
                new
                {
                    Name = "Admin"
                },
            },
        };
        [Test, TestCaseSource(nameof(SigninData))]
        public void TestChangeName(User admin, dynamic names)
        {

            admin.Name = "Admin";

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);

            YourProfilePage yourProfilePage = usersPage.GotoEditProfile();

            Assert.IsTrue(yourProfilePage.YourProfileLabel != null);

            yourProfilePage.ClickEditName();
            Assert.IsTrue(yourProfilePage.GetNewNameField() != null);

            yourProfilePage.SetNewName(names.nameWithDigits);
            yourProfilePage = yourProfilePage.ChangeName(admin);
      
            Assert.AreEqual(names.correctName, yourProfilePage.GetNameValue());

            loginPage = yourProfilePage.GotoLogOut();
        }
    }
}
