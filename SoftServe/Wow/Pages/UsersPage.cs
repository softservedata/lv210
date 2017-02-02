using System.Collections.Generic;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public class UsersPage : HeadPage
    {
        private const int HeadRowCount = 1;
        private const int HeadRowIndex = 0;
        
        private class UserTable
        {
            private Manager manager;
            public HtmlTable Table { get; private set; }

            public UserTable(Manager manager)
            {
                this.manager = manager;
                this.Table = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-half");
            }
        }

        private UserTable userTable;
        public HtmlControl All { get; private set; }
        public HtmlControl Admins { get; private set; }
        public HtmlControl Teachers { get; private set; }
        public HtmlControl Students { get; private set; }
        public HtmlInputText Search { get; private set; }

        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teachers = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
            userTable = new UserTable(manager);
        }

        public void ClickAdminsTab()
        {
            this.Admins.Click();
        }

        public void ClickTeachersTab()
        {
            this.Teachers.Click();
        }

        public void ClickStudentsTab()
        {
            this.Students.Click();
        }

        public bool IsUserCheckedAsAdmin(int columnIndex)
        {
            int userIsAdminCount = 0;
            
            userTable.Table.Refresh();

            for (int i = 1; i < userTable.Table.BodyRows.Count; i++)
            {
                if (userTable.Table.BodyRows[i].Cells[columnIndex].BaseElement.Children[0].Content.Contains("user.isAdmin"))
                {
                    userIsAdminCount += 1;
                }
            }

            return (userTable.Table.Rows.Count - HeadRowCount) == userIsAdminCount;
        }

        public bool IsUserCheckedAsTeacher(int columnIndex)
        {
            int userIsTeacherCount = 0;
            
            userTable.Table.Refresh();

            for (int i = 1; i < userTable.Table.BodyRows.Count; i++)
            {
                if (userTable.Table.BodyRows[i].Cells[columnIndex].BaseElement.Children[0].Content.Contains("user.isTeacher"))
                {
                    userIsTeacherCount += 1;
                }
            }

            return (userTable.Table.Rows.Count - HeadRowCount) == userIsTeacherCount;
        }

        public bool IsUserCheckedAsStudent(int columnIndex)
        {
            int userIsStudentCount = 0;
            
            userTable.Table.Refresh();

            for (int i = 1; i < userTable.Table.BodyRows.Count; i++)
            {
                if (userTable.Table.BodyRows[i].Cells[columnIndex].BaseElement.Children[0].Content.Contains("user.isStudent"))
                {
                    userIsStudentCount += 1;
                }
            }

            return (userTable.Table.Rows.Count - HeadRowCount) == userIsStudentCount;
        }

        public List<string> GetHeadColumnsText()
        {
            List<string> headColumnsTextContent = new List<string>();

            for (int i = 0; i < userTable.Table.ColumnCount; i++)
            {
                headColumnsTextContent.Add(userTable.Table.Rows[HeadRowIndex].Cells[i].TextContent);
            }

            return headColumnsTextContent;
        }
    }
}
