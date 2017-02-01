using System.Collections.Generic;
using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Data;

namespace Wow.Pages
{
    public class UsersPage : HeadPage
    {
        public const int MaxUsersPerPage = 5;
        private const int HEAD_ROW_COUNT = 1;

        private class Pagination
        {
            private Manager manager;

            public HtmlAnchor FirstItem { get; private set; }
            public HtmlAnchor StepBackItem { get; private set; }
            public HtmlAnchor StepForwardItem { get; private set; }
            public HtmlAnchor LastItem { get; private set; }
            public HtmlAnchor ActiveItem { get; private set; }

            public Pagination(Manager manager)
            {
                this.manager = manager;
                this.FirstItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'First')]");
                this.StepBackItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'‹')]");
                this.StepForwardItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'›')]");
                this.LastItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'Last')]");
                this.ActiveItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//li[@class = 'ng-scope active']/a");
            }
        }

        private class UserRoleManagement
        {
            private Manager manager;

            public UserRoleManagement(Manager manager)
            {
                this.manager = manager;
                this.AdminRole = manager.ActiveBrowser.Find.ByAttributes<HtmlInputCheckBox>("ng-model=user.isAdmin");
                this.TeacherRole = manager.ActiveBrowser.Find.ByAttributes<HtmlInputCheckBox>("ng-model=user.isTeacher");
                this.StudentRole = manager.ActiveBrowser.Find.ByAttributes<HtmlInputCheckBox>("ng-model=user.isStudent");
                this.EditPencil = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=glyphicon glyphicon-pencil");
            }

            //Role checkboxes
            public HtmlInputCheckBox AdminRole { get; private set; }
            public HtmlInputCheckBox TeacherRole { get; private set; }
            public HtmlInputCheckBox StudentRole { get; private set; }

            //Edit button
            public HtmlSpan EditPencil { get; private set; }
            public HtmlSpan CheckMark { get;  set; }
        }

        private Pagination pagination;
        private UserRoleManagement userRoles;

        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teachers = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
            this.TableOfUsers = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-half");
            this.pagination = new Pagination(manager);
            this.userRoles = new UserRoleManagement(manager);
        }

        public HtmlControl All { get; private set; }
        public HtmlControl Admins { get; private set; }
        public HtmlControl Teachers { get; private set; }
        public HtmlControl Students { get; private set; }
        public HtmlInputText Search { get; private set; }
        public HtmlTable TableOfUsers { get; }

        #region Getters

        private HtmlListItem GetFirstItemParent()
        {
            return this.pagination.FirstItem.Parent<HtmlListItem>();
        }

        private HtmlListItem GetStepBackItemParent()
        {
            return this.pagination.StepBackItem.Parent<HtmlListItem>();
        }

        private HtmlListItem GetStepForwardItemParent()
        {
            return this.pagination.StepForwardItem.Parent<HtmlListItem>();
        }

        private HtmlListItem GetLastItemParent()
        {
            return this.pagination.LastItem.Parent<HtmlListItem>();
        }

        private HtmlListItem GetActiveItemParent()
        {
            return this.pagination.ActiveItem.Parent<HtmlListItem>();
        }

        private HtmlControl GetTeacherTab()
        {
            return this.Teachers;
        }

        private HtmlControl GetAdminTab()
        {
            return this.Admins;
        }

        private HtmlAnchor GetFirstItem()
        {
            return this.pagination.FirstItem;
        }

        private HtmlAnchor GetStepBackItem()
        {
            return this.pagination.StepBackItem;
        }

        private HtmlAnchor GetStepForwardItem()
        {
            return this.pagination.StepForwardItem;
        }

        private HtmlAnchor GetLastItem()
        {
            return this.pagination.LastItem;
        }

        private HtmlAnchor GetActiveItem()
        {
            return this.pagination.ActiveItem;
        }

        private HtmlTable GetTableOfUsers()
        {
            return this.TableOfUsers;
        }

        #endregion

        #region PrivateFunctional

        private string GetExpressionUsed(HtmlControl element)
        {
            var expression = GetActiveItem().BaseElement.FindExpressionUsed.StringRepresentation;
            return expression.Substring(expression.IndexOf('/'));
        }

        private void RefreshPagination()
        {
            this.pagination.ActiveItem.Refresh();
            this.pagination.FirstItem.Refresh();
            this.pagination.StepBackItem.Refresh();
            this.pagination.StepForwardItem.Refresh();
            this.pagination.LastItem.Refresh();
        }

        private HtmlAnchor MoveToNext()
        {
            var xpath = $"{GetExpressionUsed(this.pagination.ActiveItem)}/ancestor::li/following-sibling::li[1]/descendant::a";
            return manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(xpath);
        }

        private IList<iAttribute> GetAllAtributesWithAppropriateValue(HtmlControl element)
        {
            return element.Attributes.Where(attribure => (attribure.Name == "class") &&
                                                         (attribure.Value == "ng-scope disabled")).ToList();
        }

        // Functional : work with table

        private User ReadDataFromRow(IList<HtmlTableRow> rows, int rowIndex)
        {
            return User.Get().SetEmail(rows[rowIndex].Cells[1].InnerText)
                .SetPassword(null)
                .SetName(rows[rowIndex].Cells[0].InnerText)
                .SetIsAdmin(rows[rowIndex].Cells[2].ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                .SetIsTeacher(rows[rowIndex].Cells[3].ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                .SetIsStudent(rows[rowIndex].Cells[4].ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                .Build();
        }

        private HtmlTableRow GetRow(int index)
        {
            return this.TableOfUsers.Rows.ElementAt(index);
        }

        private IList<HtmlTableRow> GetAllRows()
        {
            return this.TableOfUsers.Rows;
        }

        private HtmlTableCell GetCell(HtmlTableRow row, int cellIndex)
        {
            return row.Cells[cellIndex];
        }

        private int GetRowsCountInTable()
        {
            return this.TableOfUsers.Rows.Count();
        }

        #endregion

        /// <returns>Returns inner text of active item of pagination.</returns>
        public string GetTextFromActiveItem()
        {
            return this.GetActiveItem().InnerText;
        }

        public bool IsLastItemEnabled()
        {
            var arrayOfAppropriateAttributes = GetAllAtributesWithAppropriateValue(GetLastItemParent());

            return arrayOfAppropriateAttributes.Count == 0;
        }

        public bool IsStepBackItemEnabled()
        {
            var arrayOfAppropriateAttributes = GetAllAtributesWithAppropriateValue(GetStepBackItemParent());

            return arrayOfAppropriateAttributes.Count == 0;
        }

        public bool IsStepForwardItemEnabled()
        {
            var arrayOfAppropriateAttributes = GetAllAtributesWithAppropriateValue(GetStepForwardItemParent());

            return arrayOfAppropriateAttributes.Count == 0;
        }

        public bool IsFirstItemEnabled()
        {
            var arrayOfAppropriateAttributes = GetAllAtributesWithAppropriateValue(GetFirstItemParent());

            return arrayOfAppropriateAttributes.Count == 0;
        }

        public bool AreAllPaginationElementsEnabled()
        {
            return IsFirstItemEnabled() && IsStepBackItemEnabled() && IsLastItemEnabled() && IsStepForwardItemEnabled();
        }

        public int GetCountOfUsersAtPage()
        {
            return this.TableOfUsers.Rows.Count() - 1;
        }

        public string GetUserSearchBoxText()
        {
            return this.Search.Placeholder;
        }

        /// <returns>Returns IList collection that contains all users displayed in a table.</returns>
        public IList<User> GetUsersDataForTable()
        {
            var usersAtCurrentPage = new List<User>();
            var rows = GetAllRows();

            for (var i = 1; i < GetRowsCountInTable(); i++)
            {
                usersAtCurrentPage.Add(ReadDataFromRow(rows, i));
            }

            return usersAtCurrentPage;
        }

        public bool IsAdminRoleEnabled()
        {
            return userRoles.AdminRole.IsEnabled;
        }

        public bool IsTeacherRoleEnabled()
        {
            return userRoles.TeacherRole.IsEnabled;
        }

        public bool IsStudentRoleEnabled()
        {
            return userRoles.StudentRole.IsEnabled;
        }

        public bool IsAdminRoleChecked()
        {
            return userRoles.AdminRole.Checked;
        }

        public bool IsTeacherRoleChecked()
        {
            return userRoles.TeacherRole.Checked;
        }

        public bool IsStudentRoleChecked()
        {
            return userRoles.StudentRole.Checked;
        }

        public bool IsDisplayedEditPencil()
        {
            return userRoles.EditPencil.IsVisible();
        }

        public bool IsDisplayedCheckMark()
        {
            return userRoles.CheckMark.IsVisible();
        }

        // Set Data
        public void ClickAdminTab()
        {
            GetAdminTab().Click();
            RefreshPagination();
        }

        public void ClickFirst()
        {
            GetFirstItem().Click();
            TableOfUsers.Refresh();
            RefreshPagination();
        }

        public void ClickStepBack()
        {
            GetStepBackItem().Click();
            TableOfUsers.Refresh();
            RefreshPagination();
        }

        public void ClickStepForward()
        {
            GetStepForwardItem().Click();
            TableOfUsers.Refresh();
            RefreshPagination();
        }

        public void ClickLast()
        {
            GetLastItem().Click();
            TableOfUsers.Refresh();
            RefreshPagination();
        }


        public void SetValueToSearch(string userName)
        {
            Search.Text = userName;
            TableOfUsers.Refresh();
        }

        public void SetAdminRole()
        {
            this.userRoles.AdminRole.Click();
        }

        public void SetTeacherRole()
        {
            this.userRoles.TeacherRole.Click();

        }

        public void SetStudentRole()
        {
            this.userRoles.StudentRole.Click();
        }

        public void EditRole()
        {
            this.userRoles.EditPencil.Click();
            this.userRoles.CheckMark = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=glyphicon glyphicon-ok");
        }

        public void FinishEditing()
        {
            userRoles.CheckMark.Click();
        }

        public bool IsUserCheckedAsAdmin()
        {
            int userIsAdminCount = 0;

            ClickAdminsTab();
            TableOfUsers.Refresh();

            for (int i = 1; i < TableOfUsers.BodyRows.Count; i++)
            {
                if (TableOfUsers.BodyRows[i].Cells[2].BaseElement.Children[0].Content.Contains("user.isAdmin"))
                {
                    userIsAdminCount += 1;
                }
            }

            return (TableOfUsers.Rows.Count - HEAD_ROW_COUNT) == userIsAdminCount;
        }

        public bool IsUserCheckedAsTeacher()
        {
            int userIsTeacherCount = 0;

            ClickTeachersTab();
            TableOfUsers.Refresh();

            for (int i = 1; i < TableOfUsers.BodyRows.Count; i++)
            {
                if (TableOfUsers.BodyRows[i].Cells[3].BaseElement.Children[0].Content.Contains("user.isTeacher"))
                {
                    userIsTeacherCount += 1;
                }
            }

            return (TableOfUsers.Rows.Count - HEAD_ROW_COUNT) == userIsTeacherCount;
        }

        public bool IsUserCheckedAsStudent()
        {
            int userIsStudentCount = 0;

            ClickStudentsTab();
            TableOfUsers.Refresh();

            for (int i = 1; i < TableOfUsers.BodyRows.Count; i++)
            {
                if (TableOfUsers.BodyRows[i].Cells[4].BaseElement.Children[0].Content.Contains("user.isStudent"))
                {
                    userIsStudentCount += 1;
                }
            }

            return (TableOfUsers.Rows.Count - HEAD_ROW_COUNT) == userIsStudentCount;
        }

        private void ClickAdminsTab()
        {
            this.Admins.Click();
        }

        private void ClickTeachersTab()
        {
            this.Teachers.Click();
        }

        private void ClickStudentsTab()
        {
            this.Students.Click();
        }

        public string[] GetHeadColumnsText()
        {
            string[] headColumnsTextContent = new string[TableOfUsers.ColumnCount];

            for (int i = 0; i < TableOfUsers.ColumnCount; i++)
            {
                headColumnsTextContent[i] = TableOfUsers.Rows[0].Cells[i].TextContent;
            }

            return headColumnsTextContent;
        }
    }
}
