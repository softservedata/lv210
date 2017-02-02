using NLog;
using NUnit.Framework;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    internal class AddUsersToGroupByTeacher : TestRunner
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

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
            logger.Info(
                "Start test AddUsersToGroupByTeacherTest(User teacher, string groupName, string userOneName, string userTwoName");

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
            ;
            Assert.AreEqual(groupName, myGroupsPage.editGroupPage.GetSelectedGroupDescriptionText());

            // EndStep 2: The Group 'Test_M' page is opened

            // Step 3: Click on split button ‘Select’ in the right corner of the page

            myGroupsPage.editGroupPage.OpenSelectDropdownToggle();

            Assert.IsTrue(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserPresentInDropdown(userOneName));
            Assert.IsTrue(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserPresentInDropdown(userTwoName));

            // EndStep 3: Users "Black Cat" and "Ulyana Holub" are present in drop down list.

            // Step 4: Click 'Check All'

            myGroupsPage.editGroupPage.selectDropdownToggle.ClickCheckAllItem();

            Assert.IsTrue(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserChecked(userOneName));
            Assert.IsTrue(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserChecked(userTwoName));

            // EndStep 4: Users "Black Cat" and "Ulyana Holub" are selected with green check marks

            // Step 5: Click 'Uncheck All'

            myGroupsPage.editGroupPage.selectDropdownToggle.ClickUncheckAllItem();

            Assert.IsTrue(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserUnChecked(userOneName));
            Assert.IsTrue(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserUnChecked(userTwoName));

            // EndStep 5: Users "Black Cat" and "Ulyana Holub" are unmarked

            // Step 6: Type 'Black Cat' into the text field 'Search'. Check off 'Black Cat'.

            myGroupsPage.editGroupPage.selectDropdownToggle.FindUserViaSearchBox(userOneName);
            myGroupsPage.editGroupPage.selectDropdownToggle.MarkUserInDropdown(userOneName);

            Assert.IsTrue(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserPresentInDropdown(userOneName));
            Assert.IsTrue(myGroupsPage.editGroupPage.selectDropdownToggle.IsUserChecked());

            // EndStep 6: 'Black Cat' is found and checked off.

            // Step 7: Press button 'Submit changes'

            myGroupsPage.editGroupPage.ClickSubmitChangesButton();

            // EndStep 7: 

            // Step 8: Enter 'Black Cat' into edit field 'Search by Name'

            myGroupsPage.editGroupPage.EnterUserNameInSearch(userOneName);

            Assert.IsTrue(myGroupsPage.editGroupPage.IsUserPresentInGrid(userOneName));

            // EndStep 8: Student with name 'Black Cat' displays in the table

            // Return to previous state
            loginPage = usersPage.GotoLogOut();

            logger.Info(
               "End test AddUsersToGroupByTeacherTest(User teacher, string groupName, string userOneName, string userTwoName)");
        }
    }
}

