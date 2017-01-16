using System.Collections.Generic;
using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.ObjectModel;
using Wow.Data;

namespace Wow.Pages
{
    public class UsersPage : HeadPage
    {
        public const int MaxUsersPerPage = 5;

        private class Pagination
        {
            private Manager manager;

            public HtmlAnchor FirstItem { get; private set; }
            public HtmlAnchor StepBackItem { get; private set; }
            public HtmlAnchor StepForwardItem { get; private set; }
            public HtmlAnchor LastItem { get; private set; }
            public HtmlAnchor ActiveItem { get; private set; }

            protected internal Pagination(Manager manager)
            {
                this.manager = manager;
                this.FirstItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'First')]");
                this.StepBackItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'‹')]");
                this.StepForwardItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'›')]");
                this.LastItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'Last')]");
                this.ActiveItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//li[@class = 'ng-scope active']/a");
            }
        }

        private Pagination pagination;

        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teacher = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
            this.TableOfUsers = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-half");
            this.pagination = new Pagination(manager);
        }

        public HtmlControl All { get; private set; }
        public HtmlControl Admins { get; private set; }
        public HtmlControl Teacher { get; private set; }
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
            return this.Teacher;
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

        private void RefreshPaganation()
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

        //  -1 because table contains head row
        public int GetCountOfUsersAtPage()
        {
            return this.TableOfUsers.Rows.Count() - 1;
        }

        // i = 1 because table contains head row
        /// <returns>Returns IList collection that contains all users displayed in a table.</returns>
        public IList<User> GetUsersDataForTable()
        {
            var usersAtCurrentPage = new List<User>();
            var rows = GetAllRows();
            var rowCount = GetRowsCountInTable();

            for (var i = 1; i < rowCount; i++)
            {
                usersAtCurrentPage.Add(ReadDataFromRow(rows,i));
            }

            return usersAtCurrentPage;
        }

        #region Setters

        public void ClickAdminTab()
        {
            GetAdminTab().Click();
            RefreshPaganation();
        }

        public void ClickFirst()
        {
            GetFirstItem().Click();
            TableOfUsers.Refresh();
            RefreshPaganation();
        }

        public void ClickStepBack()
        {
            GetStepBackItem().Click();
            TableOfUsers.Refresh();
            RefreshPaganation();
        }

        public void ClickStepForward()
        {
            GetStepForwardItem().Click();
            TableOfUsers.Refresh();
            RefreshPaganation();
        }

        public void ClickLast()
        {
            GetLastItem().Click();
            TableOfUsers.Refresh();
            RefreshPaganation();
        }

        #endregion
    }
}