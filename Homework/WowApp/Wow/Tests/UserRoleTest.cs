using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wow.Pages;
using Wow.Data;
using Wow.Appl;
using NUnit.Framework;

namespace Wow.Tests
{   [TestFixture]
    class UserRoleTest:TestRunner
    {
        [Test]
        public void ChangeUserRole()
        {
            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(StaticUserRepository.Get().Admin());
            //usersPage.ChangeTeacherRole("Test V");
        }

    }
}
