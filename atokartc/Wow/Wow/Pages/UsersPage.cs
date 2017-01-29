using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;


namespace Wow.Pages
{
    public class UsersPage : HeadPage
    {
        // Components
        private class UserTable
        {
            // Fields
            private Manager manager;

            // get Data
            public HtmlTable Table { get; private set; }
            public HtmlAnchor Next { get; private set; }
            //public HtmlControl DirectionItem { get; private set; }
            //
            // TODO First
            // Header
            private List<Element> header;
            private List<List<Element>> cells;

            // Constructor
            public UserTable(Manager manager)
            {
                this.manager = manager;
                this.Table = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-half");
                //this.Next = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'›')]");
                this.Next = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("›");
                //this.DirectionItem = manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//a[contains(text(),'›')]/ancestor::li");
            }

            // Page Object
            // get Data
            // Functional
            private List<List<Element>> GetAllCells()
            {
                return null;
            }

            public bool IsItemPresent(string text)
            {
                return true;
            }

            public bool IsItemPresent(int columnNumber, string text)
            {
                // Searching
                return true;
            }

            public bool IsItemPresent(string columnName, string text)
            {
                return true;
            }

            public List<String> GetAllEMails()
            {
                return null;
            }

            // set Data

            // Business Logic

        }

        // Fields

        // get Data
        public HtmlControl All { get; private set; }
        public HtmlControl Admins { get; private set; }
        public HtmlControl Teacher { get; private set; }
        public HtmlControl Students { get; private set; }
        public HtmlInputText Search { get; private set; }
        //
        private UserTable userTable;

        // Constructor
        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teacher = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
        }

        // Page Object
        // get Data
        // Functional
        public List<string> GetUserTableEMails()
        {
            return null;
        }

        // set Data

        // Business Logic

    }
}
