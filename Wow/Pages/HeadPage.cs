using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;

namespace Wow.Pages
{
    /// <summary>
    /// Base class that represents the funcionality of the Head page.
    /// </summary>
    public abstract class HeadPage
    {
        /// <summary>
        /// Themes that are present in Theme state dropdown.
        /// </summary>
        public enum ThemeState
        {
            DarkTheme = 0,
            BlueTheme = 1
        }
        /// <summary>
        /// Class that represents User name dropdown functionality.
        /// </summary>
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

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        protected Manager manager;
        private HtmlDiv navbarCollapse;
        private Element body;

        public HtmlSpan Username { get; private set; }
        public HtmlSelect DefaultTheme { get; private set; }
        public HtmlButton SidebarToggle { get; private set; }
        public Element SelectedThemeBlue { get; private set;}
        public Element SelectedThemeBlack { get; private set; }

        private UsernameDropdown usernameDropdown;

        public HeadPage(Manager manager)
        {
            this.manager = manager;
            this.navbarCollapse = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=collapse navbar-collapse");
            this.body = manager.ActiveBrowser.Find.ByTagIndex("body", 0);

            this.Username = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("ng-model=getName");
            this.DefaultTheme = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=defaultTheme");
            this.SidebarToggle = manager.ActiveBrowser.Find.ById<HtmlButton>("sidebar-toggle");
            this.SelectedThemeBlue = manager.ActiveBrowser.Find.ByXPath("//link[@href = 'dist/styles-concat-blue-theme.css']");
            this.SelectedThemeBlack = manager.ActiveBrowser.Find.ByXPath("//link[@href = 'dist/styles-concat-dark-theme.css']");
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

        public void OpenThemeDropdown()
        {
            this.DefaultTheme.MouseClick();
        }

        public void SelectDefaultTheme(ThemeState theme)
        {
            DefaultTheme.SelectByPartialText(theme.ToString().Substring(0, 4), true);

        }

        public bool IsBlueThemeSelected()
        {
            return this.SelectedThemeBlue.Content.ToLower().Contains("blue");
        }

        public bool IsDarkThemeSelected()
        {
            return this.SelectedThemeBlack.Content.ToLower().Contains("dark");
        }

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
