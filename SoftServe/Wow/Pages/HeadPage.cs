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
            public HtmlAnchor EditProfile { get; private set; }
            public HtmlAnchor LogOut { get; private set; }
            
            public UsernameDropdown(Manager manager)
            {
                this.manager = manager;
                this.EditProfile = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:Edit Profile");
                this.LogOut = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("p:Log Out");
            }
        }
        protected Manager manager;
        private HtmlDiv navbarCollapse;
        private UsernameDropdown usernameDropdown;
        private Element body;
        
        public HtmlSpan Username { get; private set; }
        public HtmlSelect DefaultTheme { get; private set; }
        public HtmlButton SidebarToggle { get; private set; }
        public HtmlAnchor Languages { get; private set; }
        public HtmlAnchor ManagerMenu { get; set; }
        
        public HeadPage(Manager manager)
        {
            this.manager = manager;
            this.navbarCollapse = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=collapse navbar-collapse");
            this.body = manager.ActiveBrowser.Find.ByTagIndex("body", 0);
            this.Username = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("ng-model=getName");
            this.DefaultTheme = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=defaultTheme");
            this.SidebarToggle = manager.ActiveBrowser.Find.ById<HtmlButton>("sidebar-toggle");
            this.Languages = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(@href, 'Index#/Languages')]");
            this.ManagerMenu = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//section[@id='teaching-tools']/li/a");
        }
        
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
        
        public string GetUsernameText()
        {
            return this.Username.TextContent.Trim();
        }

        public bool IsSidebarToggleMinimized()
        {
            return body.GetAttributeValueOrEmpty("class").Contains("sidebar-minimized");
        }
        
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

        public void ClickLanguages()
        {
            Languages.Click();
        }

        private void ClickManagerMenu()
        {
            ManagerMenu.Click();
        }

        public GlobalDictionaryPage GoToGlobalDictionaryPage()
        {
            ClickManagerMenu();
            HtmlAnchor globalDictionary = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[@href='Index#/GlobalDictionary']");
            globalDictionary.Click();
            return new GlobalDictionaryPage(manager);
        }

        public void SelectDefaultTheme(ThemeState theme)
        {
            DefaultTheme.SelectByPartialText(theme.ToString().Substring(0, 4), true);
        }
        
        public YourProfilePage GotoEditProfile()
        {
            ClickEditProfile();
            return new YourProfilePage(manager);
        }

        public LanguagesPage GoToLanguagesPage()
        {
            ClickLanguages();
            return new LanguagesPage(manager);
        }

        public HeadPage OpenSidebarToggle()
        {
            if (IsSidebarToggleMinimized())
            {
                ClickSidebarToggle();
            }
            return this;
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
            return this;
        }

        public HeadPage SelectBlueTheme()
        {
            SelectDefaultTheme(ThemeState.BlueTheme);
            return this;
        }

    }
}
