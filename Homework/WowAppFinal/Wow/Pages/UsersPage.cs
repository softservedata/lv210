using System.Collections.Generic;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Data;
using Wow.Helpers;

namespace Wow.Pages
{
    public class UsersPage : HeadPage
    {
        public const int MaxUsersPerPage = 5;

        private enum UserTableHeader
        {
            Name = 0,
            Email = 1,
            AdminRole = 2,
            TeacherRole = 3,
            StudentRole = 4,
            ClickToEdit = 5
        }

        private class UserTableUtils : IExternalData
        {
            private readonly BasicTable userTable;

            protected internal UserTableUtils(BasicTable userTable)
            {
                this.userTable = userTable;
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

                    allvalues.Add(row[0].InnerText.GetMatch(User.FirstNameRegex).Trim());
                    allvalues.Add(row[0].InnerText.GetMatch(User.LastNameRegex).Trim());
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

                // Removing header
                rows.RemoveAt(0);

                foreach (var row in rows)
                {
                    User user =
                        User.Get()
                            .SetFirstName(row[0].InnerText.GetMatch(User.FirstNameRegex).Trim())
                            .SetLastName(row[0].InnerText.GetMatch(User.LastNameRegex).Trim())
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

        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teacher = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
            this.TableOfUsers = new BasicTable(
                manager,
                "class=table table-striped width-half",
                "//a[contains(text(),'First')]",
                "//a[contains(text(),'‹')]",
                "//a[contains(text(),'›')]",
                "//a[contains(text(),'Last')]",
                "//li[@class = 'ng-scope active']/a");
        }

        public HtmlControl All { get; private set; }
        public HtmlControl Admins { get; private set; }
        public HtmlControl Teacher { get; private set; }
        public HtmlControl Students { get; private set; }
        public HtmlInputText Search { get; private set; }
        public BasicTable TableOfUsers { get; }

        #region Getters

        private HtmlControl GetAdminTab()
        {
            return this.Admins;
        }

        public BasicTable GetTableOfUsers()
        {
            return this.TableOfUsers;
        }

        #endregion

        public string GetTextFromActiveItem()
        {
            return this.TableOfUsers.GetActiveItem().InnerText;
        }

        //  -1 because table contains head row
        public int GetCountOfUsersAtPage()
        {
            return this.TableOfUsers.GetRowCount() - 1;
        }

        public IList<IUser> GetUsersFromTable()
        {
            return new UserUtils(string.Empty, new UserTableUtils(this.TableOfUsers)).GetAllUsers();
        }

        public IList<IUser> GetUsersFromCurrentTablePage()
        {
            return new UserTableUtils(this.TableOfUsers).GetAllUsersFromActiveTablePage();
        }

        public IList<string> GetUserTableEMails()
        {
            IList<string> result = new List<string>();
            IList<HtmlTableCell> allColumns = this.TableOfUsers.GetAllColumnByIndex((int)UserTableHeader.Email);

            foreach (var email in allColumns)
            {
                if (!email.InnerText.ToLower().Equals(UserTableHeader.Email.ToString().ToLower()))
                {
                    result.Add(email.InnerText);
                }
            }

            return result;
        }

        #region Setters

        public void ClickAdminTab()
        {
            GetAdminTab().Click();
        }

        public void ClickFirst()
        {
            this.TableOfUsers.ClickFirstItem();
        }

        public void ClickStepBack()
        {
            this.TableOfUsers.ClickStepBackItem();
        }

        public void ClickStepForward()
        {
            this.TableOfUsers.ClickStepForwardItem();
        }

        public void ClickLast()
        {
            this.TableOfUsers.ClickLastItem();
        }

        #endregion
    }
}