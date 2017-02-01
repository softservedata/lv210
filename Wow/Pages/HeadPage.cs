using ArtOfTest.WebAii.Core;
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
                this.Users = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/Users");
                this.Languages = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/Languages");
                this.Profile = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/EditUserProfile");
            }

            // 'Admin Tools' Category
            public HtmlAnchor Users { get; private set; }
            public HtmlAnchor Languages { get; private set; }

            // 'Your Stuff' Category
            public HtmlAnchor Profile { get; private set; }
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
            //
            this.Username = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("ng-model=getName");
            this.DefaultTheme = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=defaultTheme");
            this.SidebarToggle = manager.ActiveBrowser.Find.ById<HtmlButton>("sidebar-toggle");
        }

        public HtmlSpan Username { get; private set; }
        public HtmlSelect DefaultTheme { get; private set; }
        public HtmlButton SidebarToggle { get; private set; }

        // Get Data
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

        private HtmlAnchor GetAdminToolUsers()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Users;
        }

        private HtmlAnchor GetAdminToolLanguages()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Languages;
        }

        private HtmlAnchor GetYourStuffProfile()
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

        public void ClickUsername()
        {
            ClickNavbarCollapse();
            this.Username.Click();
            usernameDropdown = new UsernameDropdown(manager);
        }

        public void ClickSidebarToggle()
        {
            SidebarToggle.Click();
        }

        public void ClickEditProfile()
        {
            GetEditProfile().Click();
        }

        public void ClickLogOut()
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
