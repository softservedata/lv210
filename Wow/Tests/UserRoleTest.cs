using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wow.Pages;
using Wow.Data;
using Wow.Appl;
using NUnit.Framework;
using System.Threading;

namespace Wow.Tests
{   [TestFixture]
    class UserRoleTest:TestRunner
    {
        [Test]
        public void ChangeUserRole()
        {
            //Preconditions
            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(UserRepository.Get().Admin());
            usersPage.SetValueToSearch("Test V");
            //Test steps
            Assert.False(usersPage.IsAdminRoleEnabled());
            Assert.False(usersPage.IsTeacherRoleEnabled());
            Assert.False(usersPage.IsStudentRoleEnabled());
            //Assert.IsTrue(usersPage.IsDisplayedEditPencil());
            usersPage.EditRole();

            //Assert.IsTrue(usersPage.IsDisplayedCheckMark());
            usersPage.SetTeacherRole();
             //Assert.False(usersPage.IsTeacherRoleChecked());
            //usersPage.FinishEditing();
            //Assert.IsTrue(usersPage.IsTeacherRoleChecked());

            //Returning to previous state
            //usersPage.EditRole();
            //usersPage.SetTeacherRole();
            //usersPage.FinishEditing();

            //usersPage.EditRole();
            //Assert.IsTrue(usersPage.IsTeacherRoleChecked());


        }

    }
}
