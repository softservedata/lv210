using System;
using System.Threading;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Collections.Generic;
using System.IO;
using Wow.Data;
using Wow.Pages;
using static Wow.Pages.MyGroupsPage;

namespace Wow.Tests
{
    [TestFixture]
    public class AddUsersToGroupByTeacher : TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[]
            {
                UserRepository.Get().Teacher(),
                "Test_M",       // group's name
                "Black Cat",    // group's participant 1
                "Ulyana Holub"  // group's participant 2
            },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void AddUsersToGroupByTeacherTest(User teacher, string groupName, string userOneName, string userTwoName)
        {
            // Preconditions
            // 1. World of Words home page is opened ('https://192.168.195.249')
            // 2. Teacher is logged in: e - mail 'mar_yanap@yahoo.de', password 'q2w3e4r5'
            // 3. Users "Black Cat" and "Ulyana Holub" are available partivipants of the group

            LoginPage loginPage = Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessTeacherLogin(teacher);

            // Test Steps

            // Step 1: Click on 'Manager' tab in ‘Teaching tools’ menu. Click on 'Groups'

            MyGroupsPage myGroupsPage = usersPage.OpenMyGroupsPage();
            Assert.AreEqual(MyGroupsPage.GROUPSPAGE_DESCRIPTION_TEXT, myGroupsPage.GetMyGroupsPageDescriptionText());

            // EndStep 1: Page 'My Groups' is opened

            // Step 2: Click on ‘Edit’ pencil icon in the group 'Test_M'

            myGroupsPage.FindGroupViaSearchBox(groupName);
            myGroupsPage.ClickFirstEditIconInTable();
            Assert.AreEqual(groupName, myGroupsPage.editGroupPage.GetSelectedGroupDescriptionText());

            // EndStep 2: The Group 'Test_M' page is opened

            // Step 3: Click on split button ‘Select’ in the right corner of the page

            myGroupsPage.editGroupPage.OpenSelectDropdownToggle();

            Assert.True(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserPresentInDropdown(userOneName));
            Assert.True(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserPresentInDropdown(userTwoName));

            // EndStep 3: Users "Black Cat" and "Ulyana Holub" are present in drop down list.

            // Step 4: Click 'Check All'

            myGroupsPage.editGroupPage.selectDropdownToggle.ClickCheckAllItem();

            // EndStep 4: All users are selected with green check marks

            // Step 5: Click 'Uncheck All'

            myGroupsPage.editGroupPage.selectDropdownToggle.ClickUncheckAllItem();

            // EndStep 5: No one user is selected

            // Step 6: Type 'Mariana Tester' into the text field 'Search'. Check off 'Mariana Tester'.

            myGroupsPage.editGroupPage.selectDropdownToggle.FindUserViaSearchBox(userOneName);

            // EndStep 6: 'Mariana Tester' is found and checked off.

            // Step 7: Press button 'Submit changes'

            myGroupsPage.editGroupPage.ClickSubmitChangesButton();

            // EndStep 7: 

            // Step 8: Enter 'Mariana Tester' into edit field 'Search by Name'

            myGroupsPage.editGroupPage.EnterUserNameInSearch(userOneName);

            // EndStep 8: Student with name 'Mariana Tester' displays in the table

            // Return to previous state
            //loginPage = usersPage.GotoLogOut();
            //
        }
    }
}

