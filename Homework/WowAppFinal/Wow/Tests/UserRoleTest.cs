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
{
    [TestFixture]
    public class UserRoleTest:TestRunner
    {
        [Test]
        public void ChangeUserRole()
        {
            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIp()).Login();
            UsersPage usersPage = loginPage.SuccessUserLogin(StaticUserRepository.Get().Admin());
            //usersPage.ChangeTeacherRole("Test V");
        }

    }
}
