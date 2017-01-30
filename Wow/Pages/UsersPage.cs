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
            BasicTable userTable;

            // Constructor
            public UserTableUtils(BasicTable userTable)
            {
                this.userTable = userTable;
            }

            public IList<IList<string>> GetAllCells(string path)
            {
                IList<IList<string>> allCells = new List<IList<string>>();
                foreach (var row in userTable.GetAllCells())
                {
                    IList<string> allvalues = new List<string>();
                    foreach (var cell in row)
                    {
                        allvalues.Add(cell.InnerText);
                    }
                }
                //
                //using (StreamReader streamReader = new StreamReader(path))
                //{
                //    while ((row = streamReader.ReadLine()) != null)
                //    {
                //        allCells.Add(row.Split(CSV_SPLIT_BY).ToList());
                //    }
                //}
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

    }
}
