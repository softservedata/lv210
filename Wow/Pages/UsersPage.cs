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
        private class UserTable //: BaseTable
        {
            // Fields
            private Manager manager;

            // get Data
            //public HtmlAnchor EditProfile { get; private set; }
            //public HtmlAnchor LogOut { get; private set; }

            // Constructor
            public UserTable(Manager manager)
            {
                this.manager = manager;
                //this.EditProfile = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:Edit Profile");
                //this.LogOut = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("p:Log Out");
            }
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
            All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            Teacher = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
        }

        // Page Object
        // get Data
        // Functional

        // set Data

        // Business Logic

    }
}
