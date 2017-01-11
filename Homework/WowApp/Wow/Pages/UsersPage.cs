using System.Collections.Generic;
using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Data;

namespace Wow.Pages
{
    public class UsersPage : HeadPage
    {
        public const int MaxUsersPerPage = 5;

        private class Pagination
        {
            //Fields
            private Manager manager;

            // get Data
            public HtmlAnchor First { get; private set; }
            public HtmlAnchor StepBack { get; private set; }
            public HtmlAnchor StepForward { get; private set; }
            public HtmlAnchor Last { get; private set; }
            public HtmlAnchor Active { get; private set; }

            public Pagination(Manager manager)
            {
                this.manager = manager;
                this.First = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:First");
                this.StepBack = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:‹");
                this.StepForward = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:›");
                this.Last = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:Last");
                this.Active = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//li[@class = 'ng-scope active']/a");
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

        private User ReadDataFromRow(int rowIndex)
        {
            return User.Get().SetEmail(GetCellText(GetCell(rowIndex, 1)))
                .SetPassword(null)
                .SetName(GetCellText(GetCell(rowIndex, 0)))
                .SetIsAdmin(GetCell(rowIndex, 2).ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                .SetIsTeacher(GetCell(rowIndex, 3).ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                .SetIsStudent(GetCell(rowIndex, 4).ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                .Build();
        }

        private HtmlTableRow GetRow(int index)
        {
            return this.TableOfUsers.Rows.ElementAt(index);
        }

        private HtmlTableCell GetCell(int rowIndex, int cellIndex)
        {
            return this.TableOfUsers.Rows.ElementAt(rowIndex).Cells[cellIndex];
        }

        private string GetCellText(HtmlTableCell cell)
        {
            return cell.InnerText;
        }

        private int GetRowsCountInTable()
        {
            return this.TableOfUsers.Rows.Count();
        }

        public bool IsActiveTheLastPage()
        {
            var xpath = $"{GetExpressionUsed(this.pagination.Active)}/ancestor::li/following-sibling::li[1]/descendant::a";
            return manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(xpath) == GetStepForward();
        }

        public bool IsLastEnabled()
        {
            var arrayOfAppropriateAttributes = GetLastParent().Attributes.Where(attribure => (attribure.Name == "class") &&
            (attribure.Value == "ng-scope disabled")).ToArray();

            return arrayOfAppropriateAttributes.Length == 0;
        }

        public bool IsStepBackEnabled()
        {
            var arrayOfAppropriateAttributes = GetStepBackParent().Attributes.Where(attribure => (attribure.Name == "class") &&
            (attribure.Value == "ng-scope disabled")).ToArray();

            return arrayOfAppropriateAttributes.Length == 0;
        }

        public bool IsStepForwardEnabled()
        {
            var arrayOfAppropriateAttributes = GetStepForwardParent().Attributes.Where(attribure => (attribure.Name == "class") &&
            (attribure.Value == "ng-scope disabled")).ToArray();

            return arrayOfAppropriateAttributes.Length == 0;
        }

        public bool IsFirstEnabled()
        {
            var arrayOfAppropriateAttributes = GetFirstParent().Attributes.Where(attribure => (attribure.Name == "class") &&
            (attribure.Value == "ng-scope disabled")).ToArray();

            return arrayOfAppropriateAttributes.Length == 0;
        }

        public int GetCountOfUsersAtPage()
        {
            return this.TableOfUsers.Rows.Count() - 1;
        }

        public IList<User> GetUsersDataForTable()
        {
            var usersAtCurrentPage = new List<User>();
            for (var i = 1; i < GetRowsCountInTable(); i++)
            {
                usersAtCurrentPage.Add(ReadDataFromRow(i));
            }
            return usersAtCurrentPage;
        }

        public string GetActiveText()
        {
            return this.GetActive().InnerText;
        }

        // set Data
        public UsersPage ClickAdminTab()
        {
            GetAdminTab().Click();
            return new UsersPage(manager);
        }

        public UsersPage ClickFirst()
        {
            GetFirst().Click();
            return new UsersPage(manager);
        }

        public UsersPage ClickStepBack()
        {
            GetStepBack().Click();
            return new UsersPage(manager);
        }

        public UsersPage ClickStepForward()
        {
            GetStepForward().Click();
            return new UsersPage(manager);
        }

        public UsersPage ClickLast()
        {
            GetLast().Click();
            return new UsersPage(manager);
        }
    }
}
