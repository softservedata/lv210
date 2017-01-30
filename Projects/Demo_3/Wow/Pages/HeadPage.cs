﻿using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public abstract class HeadPage
    {
        public enum ThemeState
        {
            DarkTheme = 0,
            BlueTheme = 1
        }

        private class UsernameDropdown
        {
            private Manager manager;

            public UsernameDropdown(Manager manager)
            {
                this.manager = manager;
                this.EditProfile = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:Edit Profile");
                this.LogOut = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("p:Log Out");
            }

            public HtmlAnchor EditProfile { get; private set; }
            public HtmlAnchor LogOut { get; private set; }
        }

        private class SidebarMenu 
        {
            private Manager manager;

            public SidebarMenu(Manager manager)
            {
                this.manager = manager;
                this.Users = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='admin-tools']//span[contains(text(), 'Users')]");
                this.Languages = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='admin-tools']//span[contains(text(), 'Languages')]");
                this.Profile = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='your-stuff']//span[contains(text(), 'Profile')]");
            }

            // 'Admin Tools' Category
            public HtmlSpan Users { get; private set; }  // ---- old value HtmlAnchor
            public HtmlSpan Languages { get; private set; } // ---- old value HtmlAnchor

            // 'Your Stuff' Category
            public HtmlSpan Profile { get; private set; } // ---- old value HtmlAnchor
        }

        protected Manager manager;
        private HtmlDiv navbarCollapse;
        private Element body;
        private UsernameDropdown usernameDropdown;
        private SidebarMenu sidebarMenu;

        public HeadPage(Manager manager)
        {
            this.manager = manager;
            this.navbarCollapse = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=collapse navbar-collapse");
            this.body = manager.ActiveBrowser.Find.ByTagIndex("body", 0);
            
            //this.Username = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("ng-model=getName"); // ------ old
            this.Username = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//button[@type='button']/strong/span");
            
            //this.DefaultTheme = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=defaultTheme"); // ------ old
            this.DefaultTheme = manager.ActiveBrowser.Find.ByXPath<HtmlSelect>("//span[@class='custom-dropdown']/select");

            this.SidebarToggle = manager.ActiveBrowser.Find.ById<HtmlButton>("sidebar-toggle");
        }

        public HtmlSpan Username { get; private set; }
        public HtmlSelect DefaultTheme { get; private set; }
        public HtmlButton SidebarToggle { get; private set; }

        // Get Data
        private HtmlAnchor GetEditProfile()
        {
            ClickUsername();
            return this.usernameDropdown.EditProfile;
        }

        private HtmlAnchor GetLogOut()
        {
            ClickUsername();
            return this.usernameDropdown.LogOut;
        }

        private HtmlSpan GetAdminToolUsers() // ------- old value HtmlAnchor
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Users;
        }

        private HtmlSpan GetAdminToolLanguages() // edit HtmlAnchor old
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Languages;
        }

        private HtmlSpan GetYourStuffProfile() // ------- old value HtmlAnchor
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Profile;
        }

        // Functional
        public string GetUsernameText()
        {
            return this.Username.TextContent.Trim();
        }

        public bool IsSidebarMenuMinimized()
        {
            return body.GetAttributeValueOrEmpty("class").Contains("sidebar-minimized");
        }

        // Set Data
        private void ClickNavbarCollapse()
        {
            this.navbarCollapse.Click();
        }

        private void ClickUsername()
        {
            ClickNavbarCollapse();
            this.Username.Click();
            usernameDropdown = new UsernameDropdown(manager);
        }

        private void ClickSidebarToggle()
        {
            SidebarToggle.Click();
        }

        private void ClickEditProfile()
        {
            GetEditProfile().Click();
        }

        private void ClickLogOut()
        {
            GetLogOut().Click();
        }

        private void ClickUsers()
        {
            GetAdminToolUsers().Click();
        }

        private void ClickLanguages()
        {
            GetAdminToolLanguages().Click();
        }

        private void ClickProfile()
        {
            GetYourStuffProfile().Click();
        }

        public void SelectDefaultTheme(ThemeState theme)
        {
            DefaultTheme.SelectByPartialText(theme.ToString().Substring(0, 4), true);
        }

        // Business Logic
        public YourProfilePage GotoEditProfile()
        {
            ClickEditProfile();
            return new YourProfilePage(manager);
        }

        public UsersPage GotoUsersPage()
        {
            ClickUsers();
            return new UsersPage(manager);
        }

        public LanguagesPage GotoLanguagesPage()
        {
            ClickLanguages();
            return new LanguagesPage(manager);
        }

        public YourProfilePage GotoProfilePage()
        {
            ClickProfile();
            return new YourProfilePage(manager);
        }

        public HeadPage OpenSidebarMenu()
        {
            if (IsSidebarMenuMinimized())
            {
                ClickSidebarToggle();
            }
            return this;
        }

        public HeadPage CloseSidebarMenu()
        {
            if (!IsSidebarMenuMinimized())
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
            return this;
        }

        public HeadPage SelectBlueTheme()
        {
            SelectDefaultTheme(ThemeState.BlueTheme);
            return this;
        }
    }
}
