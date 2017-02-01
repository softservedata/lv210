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
                this.Users = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='admin-tools']//span[text()='Users']");
                this.Languages = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='admin-tools']//span[text()='Languages']");
                this.Profile = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='your-stuff']//span[contains(text(), 'Profile')]");
                this.TeacherManager = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//section[@id='teaching-tools']//a[@id='cursorStyle']");
                this.Groups = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='teaching-tools']//span[text()='Groups']");
            }

            public HtmlSpan Users { get; private set; }  // ---- old value HtmlAnchor
            public HtmlSpan Languages { get; private set; } // ---- old value HtmlAnchor
            public HtmlAnchor TeacherManager { get; private set; }
            public HtmlSpan Groups { get; private set; }
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
            this.Username = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//button[@type='button']/strong/span");
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

        private HtmlSpan GetAdminToolUsers() 
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Users;
        }

        private HtmlSpan GetAdminToolLanguages() 
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Languages;
        }

        private HtmlSpan GetYourStuffProfile() 
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Profile;
        }

        private HtmlAnchor GetTeachingToolsManager() 
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.TeacherManager;
        }

        private HtmlSpan GetTeachingToolsGroups() 
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Groups;
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

        private void ClickTeacherManager()     
        {
            GetTeachingToolsManager().Click();
        }

        private void ClickGroups() 
        {
            GetTeachingToolsGroups().Click();
        }

        public void SelectDefaultTheme(ThemeState theme)
        {
            DefaultTheme.SelectByPartialText(theme.ToString().Substring(0, 4), true);
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

        private bool IsTeacherManagerToolOpened()
        {
            return GetTeachingToolsGroups().BaseElement.GetAttributeValueOrEmpty("class").Contains("active");
        }

        private void OpenManagerTool()
        {
            if (!IsTeacherManagerToolOpened())
            {
                ClickTeacherManager();
            }
        }

        private void CloseManagerTool()
        {
            if (IsTeacherManagerToolOpened())
            {
                ClickTeacherManager();
            }
        }

        // Business Logic

        public YourProfilePage GotoEditProfile()
        {
            ClickEditProfile();
            return new YourProfilePage(manager);
        }

        public LanguagesPage GotoLanguagesPage()
        {
            ClickLanguages();
            return new LanguagesPage(manager);
        }

        public GroupsPage GotoGroupsPage() 
        {
            OpenManagerTool();
            ClickGroups();
            return new GroupsPage(manager);
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