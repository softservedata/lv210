﻿using Wow.Pages;
using Wow.Data;
using NUnit.Framework;
using Wow.Appl;

namespace Wow.Tests
{
    /// <summary>
    /// This test case verifies that Admin can change user's roles.
    /// The role checkboxes are disabled by default.
    /// The Administrator can gain access to check off or uncheck
    /// these text boxes by clicking on the pencil icon next to the user.
    /// </summary>
    [TestFixture]
    class UserRoleTestSuite:TestRunner
    {
        [TestCase("Test V")]
        public void ChangeUserRoleTest(string userName)
        {
            //Preconditions
            LoginPage loginPage = Application.Get(ApplicationSourcesRepository.ChromeByIP()).Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(UserRepository.Get().Admin());
            usersPage.SetValueToSearch(userName);
            
            //Test steps
            //Step 1:Check if checkboxes are disabled and edit button is enabled
            Assert.False(usersPage.IsAdminRoleEnabled());
            Assert.False(usersPage.IsTeacherRoleEnabled());
            Assert.False(usersPage.IsStudentRoleEnabled());
            Assert.IsTrue(usersPage.IsDisplayedEditPencil());
            
            //Step 2:click edit button
            usersPage.EditRole();
            Assert.IsTrue(usersPage.IsDisplayedCheckMark());
            Assert.IsTrue(usersPage.IsAdminRoleEnabled());
            Assert.IsTrue(usersPage.IsTeacherRoleEnabled());
            Assert.IsTrue(usersPage.IsTeacherRoleEnabled());

            //Step 3:Change state of teacher role chekbox
            usersPage.SetTeacherRole();
            Assert.False(usersPage.IsTeacherRoleChecked());
            usersPage.FinishEditing();
            Assert.False(usersPage.IsTeacherRoleChecked());
        
            //Returning to previous state
            usersPage.EditRole();
            usersPage.SetTeacherRole();
            usersPage.FinishEditing();
            loginPage = usersPage.GotoLogOut();
        }

    }
}
