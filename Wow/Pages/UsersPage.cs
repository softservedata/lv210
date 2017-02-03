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
        private const int HeadRowCount = 1;

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

        private Pagination pagination;
        private BasicTable userTable;
        private UserTableUtils userManagementUtils;

        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teachers = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
            this.TableOfUsers =
                manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-half");
            this.pagination = new Pagination(manager);
            this.userTable = new BasicTable(manager, "class=table table-striped width-half");
            this.userManagementUtils = new UserTableUtils(userTable);
        }

        private class UserTableUtils : IExternalData
        {
            private readonly BasicTable userTable;
            internal IList<HtmlInputCheckBox> AdminRoleCheckBoxes { get; private set; }
            internal IList<HtmlInputCheckBox> TeacherRoleCheckBoxes { get; private set; }
            internal IList<HtmlInputCheckBox> StudentRoleCheckBoxes { get; private set; }
            internal IList<HtmlSpan> EditPencils { get; }
            internal IList<HtmlSpan> CheckMarks { get; set; }

            public UserTableUtils(BasicTable userTable)
            {
                this.userTable = userTable;
                this.AdminRoleCheckBoxes =
                    userTable.Table.Find.AllByXPath<HtmlInputCheckBox>("//input[@ng-model ='user.isAdmin']");
                this.TeacherRoleCheckBoxes =
                    userTable.Table.Find.AllByXPath<HtmlInputCheckBox>("//input[@ng-model ='user.isTeacher']");
                this.StudentRoleCheckBoxes =
                    userTable.Table.Find.AllByXPath<HtmlInputCheckBox>("//input[@ng-model ='user.isStudent']");
                this.EditPencils = userTable.Table.Find.AllByAttributes<HtmlSpan>("class=glyphicon glyphicon-pencil");
            }

            public IList<IList<string>> GetAllCells(string path)
            {
                IList<IList<string>> allCells = new List<IList<string>>();
                IList<IList<HtmlTableCell>> rowsFromTable = this.userTable.GetAllCells();

                // Removing header
                rowsFromTable.RemoveAt(0);

                foreach (var row in rowsFromTable)
                {
                    IList<string> allvalues = new List<string>();

                    allvalues.Add(row[0].InnerText.Trim());
                    allvalues.Add(row[0].InnerText.Trim());
                    allvalues.Add(string.Empty);
                    allvalues.Add(row[1].InnerText);
                    allvalues.Add(string.Empty);
                    allvalues.Add(row[2].ChildNodes[0].As<HtmlInputCheckBox>().Checked.ToString());
                    allvalues.Add(row[3].ChildNodes[0].As<HtmlInputCheckBox>().Checked.ToString());
                    allvalues.Add(row[4].ChildNodes[0].As<HtmlInputCheckBox>().Checked.ToString());

                    allCells.Add(allvalues);
                }

                return allCells;
            }

            public IList<IUser> GetAllUsersFromActiveTablePage()
            {
                IList<IUser> usersFromTable = new List<IUser>();
                IList<IList<HtmlTableCell>> rows = this.userTable.GetAllCellsFromCurrentPage();

                rows.RemoveAt(0);

                foreach (var row in rows)
                {
                    User user =
                        User.Get()
                            .SetFirstName(row[0].InnerText.Trim())
                            .SetLastName(row[0].InnerText.Trim())
                            .SetLanguage(string.Empty)
                            .SetEmail(row[1].InnerText)
                            .SetPassword(string.Empty)
                            .SetIsAdmin(row[2].ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                            .SetIsTeacher(row[3].ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                            .SetIsStudent(row[4].ChildNodes[0].As<HtmlInputCheckBox>().Checked)
                            .Build();

                    usersFromTable.Add(user);
                }

                return usersFromTable;
            }
        }

        internal HtmlControl All { get; private set; }
        internal HtmlControl Admins { get; private set; }
        internal HtmlControl Teachers { get; private set; }
        internal HtmlControl Students { get; private set; }
        internal HtmlInputText Search { get; private set; }
        public HtmlTable TableOfUsers { get; }

        private void RefreshCheckBoxes(int rowNumber)
        {
            userManagementUtils.AdminRoleCheckBoxes[rowNumber].Refresh();
            userManagementUtils.TeacherRoleCheckBoxes[rowNumber].Refresh();
            userManagementUtils.StudentRoleCheckBoxes[rowNumber].Refresh();
        }

        public bool IsAdminRoleEnabled(int rowNumber)
        {
            return userManagementUtils.AdminRoleCheckBoxes[rowNumber].IsEnabled;
        }

        public bool IsTeacherRoleEnabled(int rowNumber)
        {
            return userManagementUtils.TeacherRoleCheckBoxes[rowNumber].IsEnabled;
        }

        public bool IsStudentRoleEnabled(int rowNumber)
        {
            return userManagementUtils.StudentRoleCheckBoxes[rowNumber].IsEnabled;
        }

        public bool IsAdminRoleChecked(int rowNumber)
        {
            return userManagementUtils.AdminRoleCheckBoxes[rowNumber].Checked;
        }

        public bool IsTeacherRoleChecked(int rowNumber)
        {
            return userManagementUtils.TeacherRoleCheckBoxes[rowNumber].Checked;
        }

        public bool IsStudentRoleChecked(int rowNumber)
        {
            return userManagementUtils.StudentRoleCheckBoxes[rowNumber].Checked;
        }

        public bool IsDisplayedEditPencil(int rowNumber)
        {
            return userManagementUtils.EditPencils[rowNumber].IsVisible();
        }

        public bool IsDisplayedCheckMark(int rowNumber)
        {
            return userManagementUtils.CheckMarks[rowNumber].IsVisible();
        }

        public void SetValueToSearch(string userName)
        {
            Search.Text = userName;
            userTable.Refresh();
        }

        public void SetAdminRole(int rowIndex)
        {
            this.userManagementUtils.AdminRoleCheckBoxes[rowIndex].Click();
        }

        public void SetTeacherRole(int rowIndex)
        {
            this.userManagementUtils.TeacherRoleCheckBoxes[rowIndex].Click();
        }

        public void SetStudentRole(int rowIndex)
        {
            this.userManagementUtils.StudentRoleCheckBoxes[rowIndex].Click();
        }

        public void EditRole(int rowIndex)
        {
            this.userManagementUtils.EditPencils[rowIndex].Click();
            this.userManagementUtils.CheckMarks =
                manager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=glyphicon glyphicon-ok");
            RefreshCheckBoxes(rowIndex);
        }

        public void FinishEditing(int rowIndex)
        {
            userManagementUtils.CheckMarks[rowIndex].Click();
            RefreshCheckBoxes(rowIndex);
        }

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
            var xpath =
                $"{GetExpressionUsed(this.pagination.ActiveItem)}/ancestor::li/following-sibling::li[1]/descendant::a";
            return manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(xpath);
        }

        private IList<iAttribute> GetAllAtributesWithAppropriateValue(HtmlControl element)
        {
            return element.Attributes.Where(attribure => (attribure.Name == "class") &&
                                                         (attribure.Value == "ng-scope disabled")).ToList();
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

            return (TableOfUsers.Rows.Count - HeadRowCount) == userIsAdminCount;
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

            return (TableOfUsers.Rows.Count - HeadRowCount) == userIsTeacherCount;
        }

        public IList<IUser> GetUsersFromCurrentTablePage()
        {
            return new UserTableUtils(this.userTable).GetAllUsersFromActiveTablePage();
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

            return (TableOfUsers.Rows.Count - HeadRowCount) == userIsStudentCount;
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
