using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using NLog;
using Wow.Data;

namespace Wow.Pages
{
    public class UsersPage : HeadPage
    {
        // Components
        private class UserTableUtils : IExternalData
        {
            // Fields
            private static Logger logger = LogManager.GetCurrentClassLogger();
            //
            BasicTable userTable;

            // Constructor
            public UserTableUtils(BasicTable userTable)
            {
                this.userTable = userTable;
            }

            public IList<IList<string>> GetAllCells(string path)
            {
                IList<IList<string>> allCells = new List<IList<string>>();
                string lastname;
                string email;
                foreach (var row in userTable.GetAllCells())
                {
                    IList<string> allvalues = new List<string>();
                    email = ((row[1].InnerText != null)
                            && (row[1].InnerText.Trim().Length > 0)) ? row[1].InnerText.Trim() : string.Empty;
                    if (!email.Contains("@"))
                    {
                        continue;
                    }
                    string[] names = row[0].InnerText.Trim().Split(' ');
                    logger.Debug("row[0].InnerText=" + row[0].InnerText);
                    allvalues.Add(((names[0] != null) && (names[0].Length > 0)) ? names[0] : string.Empty);     // Firstname
                    lastname = string.Empty;
                    if (names.Length > 1)
                    {
                        lastname = ((names[1] != null) && (names[1].Length > 0)) ? names[1] : string.Empty;
                    }
                    logger.Debug("Lastname=" + lastname);
                    allvalues.Add(lastname);                                                                    // Lastname
                    allvalues.Add("English");                                                                   // Language
                    allvalues.Add(email);                                                                       // Email
                    allvalues.Add(string.Empty);                                                                // Password
                    //allvalues.Add(row[2].ChildNodes[0].As<HtmlInputCheckBox>().Checked.ToString());             // IsAdmin
                    //allvalues.Add(row[3].ChildNodes[0].As<HtmlInputCheckBox>().Checked.ToString());             // IsTeacher
                    //allvalues.Add(row[4].ChildNodes[0].As<HtmlInputCheckBox>().Checked.ToString());             // IsStudent
                    allvalues.Add("true");
                    allvalues.Add("true");
                    allvalues.Add("true");
                    allCells.Add(allvalues);
                }
                return allCells;
            }
        }

        // Components
        public enum UserTableHeader
        {
            Name = 0,
            Email = 1,
            AdminRole = 2,
            TeacherRole = 3,
            StudentRole = 4,
            ClickToedit = 5
        }

        // Fields
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // get Data
        public HtmlControl All { get; private set; }
        public HtmlControl Admins { get; private set; }
        public HtmlControl Teacher { get; private set; }
        public HtmlControl Students { get; private set; }
        public HtmlInputText Search { get; private set; }
        //
        private BasicTable userTable;

        // Constructor
        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teacher = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
            this.userTable = new BasicTable(manager, "class=table table-striped width-half",
                    "//a[contains(text(),'First')]", "//a[contains(text(),'‹')]", "//a[contains(text(),'›')]",
                    "//a[contains(text(),'Last')]", "//li[@class = 'ng-scope active']/a");
        }

        // Page Object
        // get Data
        // Functional
        public IList<string> GetUserTableEMails()
        {
            logger.Debug("Start List<string> GetUserTableEMails()");
            //
            IList<string> result = new List<string>();
            foreach (var email in userTable.GetAllColumnByIndex((int)UserTableHeader.Email))
            {
                if (!email.InnerText.ToLower().Equals(UserTableHeader.Email.ToString().ToLower()))
                {
                    result.Add(email.InnerText);
                    logger.Debug("Added " + email.InnerText);
                }
            }
            logger.Debug("Done List<string> GetUserTableEMails()");
            return result;
        }

        // set Data

        // Business Logic
        public IList<IUser> GetUsersFromTable()
        {
            return new UserUtils(string.Empty, new UserTableUtils(userTable)).GetAllUsers();
        }

    }
}
