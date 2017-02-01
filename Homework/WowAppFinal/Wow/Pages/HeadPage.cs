using ArtOfTest.WebAii.Core;
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

        private UserNameDropdown userNameDropdown;
        private readonly HtmlControl body;

        private class UserNameDropdown
        {
            public HtmlAnchor EditProfile { get; private set; }
            public HtmlAnchor LogOut { get; private set; }

            protected internal UserNameDropdown(Manager manager)
            {
                this.EditProfile = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:Edit Profile");
                this.LogOut = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("p:Log Out");
            }
        }

        protected Manager manager;

        protected HeadPage(Manager manager)
        {
            this.manager = manager;
            this.body = manager.ActiveBrowser.Find.ByTagIndex<HtmlControl>("body", 0);
            this.UserName = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("ng-model=getName");
            this.DefaultTheme = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=defaultTheme");
            this.SidebarToggle = manager.ActiveBrowser.Find.ById<HtmlButton>("sidebar-toggle");
            this.SideBarMenu = new SideBar(manager);
        }

        public HtmlSpan UserName { get; private set; }
        public HtmlSelect DefaultTheme { get; private set; }
        public HtmlButton SidebarToggle { get; private set; }
        public SideBar SideBarMenu { get; private set; }

        // Get Data
        public HtmlAnchor GetEditProfile()
        {
            return this.userNameDropdown.EditProfile;
        }

        public HtmlAnchor GetLogOut()
        {
            return this.userNameDropdown.LogOut;
        }

        // Functional
        public string GetUsernameText()
        {
            return this.UserName.TextContent.Trim();
        }

        public bool IsSidebarToggleMinimized()
        {
            return this.body.BaseElement.GetAttributeValueOrEmpty("class").Contains("sidebar-minimized");
        }

        // Set Data
        private void ClickNavigationBarCollapse()
        {
            this.SideBarMenu.NavigationBarCollapse.Click();
        }

        public void ClickUserName()
        {
            this.ClickNavigationBarCollapse();
            this.UserName.Click();
            userNameDropdown = new UserNameDropdown(manager);
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

        public LoginPage GoToLogOut()
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