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
    public abstract class HeadPage
    {
        // Components
        public enum ThemeState
        {
            DarkTheme = 0,
            BlueTheme = 1
        }

        // Components
        private class UsernameDropdown
        {
            // Fields
            private Manager manager;

            // get Data
            public HtmlAnchor EditProfile { get; private set; }
            public HtmlAnchor LogOut { get; private set; }

            // Constructor
            public UsernameDropdown(Manager manager)
            {
                this.manager = manager;
                this.EditProfile = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:Edit Profile");
                this.LogOut = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("p:Log Out");
            }
        }

        private class ManagerDropdown
        {
            // Fields
            private Manager manager;

            // get Data
            public HtmlAnchor GroupsSubItem { get; private set; }

            // Constructor
            protected internal ManagerDropdown(Manager manager)
            {
                this.manager = manager;
                this.GroupsSubItem = manager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=Index#/Groups");
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // Fields
        protected Manager manager;
        private HtmlDiv navbarCollapse;
        private Element body;

        // get Data
        public HtmlSpan Username { get; private set; }
        public HtmlSelect DefaultTheme { get; private set; }
        public HtmlButton SidebarToggle { get; private set; }
        public Element SelectedThemeBlue { get; private set; }
        public Element SelectedThemeBlack { get; private set; }
        public HtmlAnchor ManagerSubMenu { get; private set; }

        //
        private UsernameDropdown usernameDropdown;
        private ManagerDropdown managerDropdown;

        // Constructor
        public HeadPage(Manager manager)
        {
            this.manager = manager;
            this.navbarCollapse = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=collapse navbar-collapse");
            this.body = manager.ActiveBrowser.Find.ByTagIndex("body", 0);
            //
            this.Username = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("ng-model=getName");
            this.DefaultTheme = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=defaultTheme");
            this.SidebarToggle = manager.ActiveBrowser.Find.ById<HtmlButton>("sidebar-toggle");
            this.ManagerSubMenu = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//section[@id='teaching-tools']/li/a");
            this.SelectedThemeBlue = manager.ActiveBrowser.Find.ByXPath("//link[@href ='dist/styles-concat-blue-theme.css']");
    }

        // Page Object
        // get Data
        public HtmlAnchor GetEditProfile()
        {
            ClickUsername();
            return this.usernameDropdown.EditProfile;
        }

        public HtmlAnchor GetLogOut()
        {
            ClickUsername();
            return this.usernameDropdown.LogOut;
        }

        public HtmlAnchor GetGroupsSubItem()
        {
            ClickManagerSubmenu();
            return this.managerDropdown.GroupsSubItem;
        }

        // Functional
        public string GetUsernameText()
        {
            return this.Username.TextContent.Trim();
        }

        public bool IsSidebarToggleMinimized()
        {
            return body.GetAttributeValueOrEmpty("class").Contains("sidebar-minimized");
        }

        // set Data
        private void ClickNavbarCollapse()
        {
            this.navbarCollapse.Click();
        }

        public void ClickUsername()
        {
            ClickNavbarCollapse();
            this.Username.Click();
            usernameDropdown = new UsernameDropdown(manager);
        }

        public void ClickManagerSubmenu()
        {
            if (IsSidebarToggleMinimized())
            {
                ClickSidebarToggle();
            }

            this.ManagerSubMenu.Click();
            managerDropdown = new ManagerDropdown(manager);
        }

        public void ClickSidebarToggle()
        {
            SidebarToggle.Click();
        }

        public void ClickEditProfile()
        {
            GetEditProfile().Click();
        }
        public void ClickGroupsSubItem()
        {
            GetGroupsSubItem().Click();
        }

        public void ClickLogOut()
        {
            GetLogOut().Click();
        }

        public void OpenThemeDropdown()
        {
            this.DefaultTheme.MouseClick();
        }

        public void SelectDefaultTheme(ThemeState theme)
        {
            //DefaultTheme.SelectByIndex((int)theme);
            DefaultTheme.SelectByPartialText(theme.ToString().Substring(0, 4), true);
        }

        public bool IsBlueThemeSelected()
        {
            return this.SelectedThemeBlue.Content.ToLower().Contains("blue");
        }

        public bool IsDarkThemeSelected()
        {
            //this.SelectedThemeBlack.Refresh();
            return this.SelectedThemeBlack.Content.ToLower().Contains("dark");
        }

        // Business Logic
        public YourProfilePage GotoEditProfile()
        {
            ClickEditProfile();
            // Return a new page object representing the destination.
            return new YourProfilePage(manager);
        }

        public HeadPage OpenSidebarToggle()
        {
            if (IsSidebarToggleMinimized())
            {
                ClickSidebarToggle();
            }
            return this;
        }

        public MyGroupsPage OpenMyGroupsPage()
        {
            ClickGroupsSubItem();
            return new MyGroupsPage(manager);
        }

        public HeadPage CloseSidebarToggle()
        {
            if (!IsSidebarToggleMinimized())
            {
                ClickSidebarToggle();
            }
            return this;
        }

        public LoginPage GotoLogOut()
        {
            ClickLogOut();
            return new LoginPage(manager);
        }

        public HeadPage SelectDarkTheme()
        {
            SelectDefaultTheme(ThemeState.DarkTheme);
            this.SelectedThemeBlack = manager.ActiveBrowser.Find.ByXPath("//link[@href ='dist/styles-concat-dark-theme.css']");
            return this;
        }

        public HeadPage SelectBlueTheme()
        {
            SelectDefaultTheme(ThemeState.BlueTheme);
            return this;
        }
    }
}
