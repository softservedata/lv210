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

        private class Pagination
        {
            private Manager manager;

            public Pagination(Manager manager)
            {
                this.manager = manager;
                this.First = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'First')]");
                this.StepBack = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'‹')]");
                this.StepForward = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'›')]");
                this.Last = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'Last')]");
                this.Active = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//li[@class = 'ng-scope active']/a");
            }

            // Get Data
            public HtmlAnchor First { get; private set; }
            public HtmlAnchor StepBack { get; private set; }
            public HtmlAnchor StepForward { get; private set; }
            public HtmlAnchor Last { get; private set; }
            public HtmlAnchor Active { get; private set; }
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
            public HtmlSpan EditPencil { get; set; }
            public HtmlSpan CheckMark { get; set; }           
        }

        private Pagination pagination;
        private UserRoleManagement userRoles;

        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teacher = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
            this.TableOfUsers = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-half");
            this.pagination = new Pagination(manager);
            this.userRoles = new UserRoleManagement(manager);
        }

        public HtmlControl All { get; private set; }
        public HtmlControl Admins { get; private set; }
        public HtmlControl Teacher { get; private set; }
        public HtmlControl Students { get; private set; }
        public HtmlInputText Search { get; private set; }
        public HtmlTable TableOfUsers { get; }

        #region PrivateFunctions

        private HtmlListItem GetFirstParent()
        {
            return this.pagination.First.Parent<HtmlListItem>();
        }

        private HtmlListItem GetStepBackParent()
        {
            return this.pagination.StepBack.Parent<HtmlListItem>();
        }

        private HtmlListItem GetStepForwardParent()
        {
            return this.pagination.StepForward.Parent<HtmlListItem>();
        }

        private HtmlListItem GetLastParent()
        {
            return this.pagination.Last.Parent<HtmlListItem>();
        }

        private HtmlListItem GetActiveParent()
        {
            return this.pagination.Active.Parent<HtmlListItem>();
        }

        private HtmlControl GetTeacherTab()
        {
            return this.Teacher;
        }

        private HtmlControl GetAdminTab()
        {
            return this.Admins;
        }

        private HtmlAnchor GetFirst()
        {
            return this.pagination.First;
        }

        private HtmlAnchor GetStepBack()
        {
            return this.pagination.StepBack;
        }

        private HtmlAnchor GetStepForward()
        {
            return this.pagination.StepForward;
        }

        private HtmlAnchor GetLast()
        {
            return this.pagination.Last;
        }

        private HtmlAnchor GetActive()
        {
            return this.pagination.Active;
        }

        private HtmlTable GetTableOfUsers()
        {
            return this.TableOfUsers;
        }

        // Functional

        private string GetExpressionUsed(HtmlControl element)
        {
            var expression = GetActive().BaseElement.FindExpressionUsed.StringRepresentation;
            return expression.Substring(expression.IndexOf('/'));
        }

        private void RefreshPaganation()
        {
            this.pagination.Active.Refresh();
            this.pagination.First.Refresh();
            this.pagination.StepBack.Refresh();
            this.pagination.StepForward.Refresh();
            this.pagination.Last.Refresh();
        }

        private HtmlAnchor MoveToNext()
        {
            var xpath = $"{GetExpressionUsed(this.pagination.Active)}/ancestor::li/following-sibling::li[1]/descendant::a";
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

        public string GetTextFromActive()
        {
            return this.GetActive().InnerText;
        }

        /// <returns>Returns whether 'Last' item of pagination is enabled.</returns>
        public bool IsLastEnabled()
        {
            var arrayOfAppropriateAttributes = GetAllAtributesWithAppropriateValue(GetLastParent());

            return arrayOfAppropriateAttributes.Count == 0;
        }

        /// <returns>Returns whether 'StepBack' item of pagination is enabled.</returns>
        public bool IsStepBackEnabled()
        {
            var arrayOfAppropriateAttributes = GetAllAtributesWithAppropriateValue(GetStepBackParent());

            return arrayOfAppropriateAttributes.Count == 0;
        }

        /// <returns>Returns whether 'StepForward' item of pagination is enabled.</returns>
        public bool IsStepForwardEnabled()
        {
            var arrayOfAppropriateAttributes = GetAllAtributesWithAppropriateValue(GetStepForwardParent());

            return arrayOfAppropriateAttributes.Count == 0;
        }

        /// <returns>Returns whether 'First' item of pagination is enabled.</returns>
        public bool IsFirstEnabled()
        {
            var arrayOfAppropriateAttributes = GetAllAtributesWithAppropriateValue(GetFirstParent());

            return arrayOfAppropriateAttributes.Count == 0;
        }

        /// <returns>Returns whether 'First', 'Last', 'StepBack', 'StepForward' items of pagination are enabled.</returns>
        public bool AreAllPaginationElementsEnabled()
        {
            return IsFirstEnabled() && IsStepBackEnabled() && IsLastEnabled() && IsStepForwardEnabled();
        }

        public int GetCountOfUsersAtPage()
        {
            return this.TableOfUsers.Rows.Count() - 1;
        }

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
        public UsersPage ClickAdminTab()
        {
            GetAdminTab().Click();
            return new UsersPage(manager);
        }

        public void ClickFirst()
        {
            GetFirst().Click();
            TableOfUsers.Refresh();
            RefreshPaganation();
        }

        public void ClickStepBack()
        {
            GetStepBack().Click();
            TableOfUsers.Refresh();
            RefreshPaganation();
        }

        public void ClickStepForward()
        {
            GetStepForward().Click();
            TableOfUsers.Refresh();
            RefreshPaganation();
        }

        public void ClickLast()
        {
            GetLast().Click();
            TableOfUsers.Refresh();
            RefreshPaganation();
        }

        //
        public void SetValueToSearch(string userName)
        {
            Search.Text = userName;
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

        // Business Logic
    }
}
