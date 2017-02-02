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

            // 'Study tools' Category
            public HtmlAnchor Courses { get; private set; }
            public HtmlAnchor PublicGroups { get; private set; }

            // 'Teaching tools' category
            public ManagerDropdown Manager { get; private set; }

            // 'Admin Tools' Category
            public HtmlAnchor Users { get; private set; }
            public HtmlAnchor Languages { get; private set; }
            public HtmlAnchor Tickets { get; private set; }

            // 'Your Stuff' Category
            public HtmlAnchor Profile { get; private set; }

            public SidebarMenu(Manager manager)
            {
                this.manager = manager;
                this.Courses = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//section[@id='study-tools']/li/a[@id='cursorStyle']");
                this.PublicGroups = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/PublicGroups");
                this.Users = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/Users");
                this.Languages = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/Languages");
                this.Tickets = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/Tickets");
                this.Profile = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/EditUserProfile");
                this.Manager = new ManagerDropdown(manager);
            }
        }

        private class ManagerDropdown
        {
            private Manager manager;

            public HtmlAnchor Manager { get; private set; }
            public HtmlAnchor GlobalDictionary { get; private set; }
            public HtmlAnchor WordSuites { get; private set; }
            public HtmlAnchor Courses { get; private set; }
            public HtmlAnchor Groups { get; private set; }
            public HtmlAnchor SubscriptionRequests { get; private set; }

            public ManagerDropdown(Manager manager)
            {
                this.manager = manager;
                this.Manager = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//section[@id='teaching-tools']/li/a[@id='cursorStyle']");
                this.GlobalDictionary = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/GlobalDictionary");
                this.WordSuites = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/WordSuites");
                this.Courses = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/UserCourses");
                this.Groups = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/Groups");
                this.SubscriptionRequests = manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("tagname=a", "href=Index#/RequestsToSubscribe");
            }
        }

        protected Manager manager;
        private HtmlDiv navbarCollapse;
        private Element body;
        private UsernameDropdown usernameDropdown;
        private SidebarMenu sidebarMenu;
        private ManagerDropdown managerDropdown;

        private string studyToolCoursesContent = "Courses";
        private string studyToolPublicGroupsContent = "Public Groups";
        private string teachingToolManagerContent = "Manager";
        private string teachingToolGlobalDictionaryContent = "Global Dictionary";
        private string teachingToolWordSuitesContent = "Word Suites";
        private string teachingToolCoursesContent = "Courses";
        private string teachingToolGroupsContent = "Groups";
        private string teachingToolSubscriptionRequestContent = "Subscription requests";
        private string adminToolUsersContent = "Users";
        private string adminToolLanguagesContent = "Languages";
        private string adminToolTicketsContent = "Tickets";
        private string yourStuffProfileContent = "Profile";

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

        private HtmlAnchor GetStudyToolCourses()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Courses;
        }

        private HtmlAnchor GetStudyToolPublicGroups()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.PublicGroups;
        }

        private HtmlAnchor GetTeachingToolManager()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.Manager;
        }

        private HtmlAnchor GetTeachingToolGlobalDictionary()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.GlobalDictionary;
        }

        private HtmlAnchor GetTeachingToolWordSuites()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.WordSuites;
        }

        private HtmlAnchor GetTeachingToolCourses()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.Courses;
        }

        private HtmlAnchor GetTeachingToolGroups()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.Groups;
        }

        private HtmlAnchor GetTeachingToolSubscriptionRequest()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.SubscriptionRequests;
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

        private HtmlAnchor GetAdminToolTickets()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Tickets;
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

        public bool IsStudyToolCoursesVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Courses.IsVisible();
        }

        public bool IsStudyToolPublicGroupsVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.PublicGroups.IsVisible();
        }

        public bool IsTeachingToolManagerVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.Manager.IsVisible();
        }

        public bool IsTeachingToolGlobalDictionaryVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.GlobalDictionary.IsVisible();
        }

        public bool IsTeachingToolWordSuitesVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.WordSuites.IsVisible();
        }

        public bool IsTeachingToolCoursesVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.Courses.IsVisible();
        }

        public bool IsTeachingToolGroupsVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.Groups.IsVisible();
        }

        public bool IsTeachingToolSubscriptionRequestsVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Manager.SubscriptionRequests.IsVisible();
        }

        public bool IsAdminToolUsersVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Users.IsVisible();
        }

        public bool IsAdminToolLanguagesVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Languages.IsVisible();
        }

        public bool IsAdminToolTicketsVisible()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Tickets.IsVisible();
        }

        public bool IsYourStuffUsersProfile()
        {
            sidebarMenu = new SidebarMenu(manager);
            return sidebarMenu.Profile.IsVisible();
        }

        public bool CheckStudyToolCoursesContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Courses.InnerText.Replace(" ", "");

            if (innerText == studyToolCoursesContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckStudyToolPublicGroupsContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.PublicGroups.InnerText;

            if (innerText == studyToolPublicGroupsContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckTeachingToolManagerContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Manager.Manager.InnerText.Replace(" ", "");

            if (innerText == teachingToolManagerContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckTeachingToolGlobalDictionaryContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Manager.GlobalDictionary.InnerText;

            if (innerText == teachingToolGlobalDictionaryContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckTeachingToolWordSuitesContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Manager.WordSuites.InnerText;

            if (innerText == teachingToolWordSuitesContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckTeachingToolCoursesContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Manager.Courses.InnerText;

            if (innerText == teachingToolCoursesContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckTeachingToolGroupsContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Manager.Groups.InnerText;

            if (innerText == teachingToolGroupsContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckTeachingToolSubscriptionRequestContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Manager.SubscriptionRequests.InnerText;

            if (innerText == teachingToolSubscriptionRequestContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckAdminToolUsersContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Users.InnerText;

            if (innerText == adminToolUsersContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckAdminToolLanguagesContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Languages.InnerText;

            if (innerText == adminToolLanguagesContent)
            {
                result = true;
            }

            return result;
        }

        public bool CheckAdminToolTicketsContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Tickets.InnerText;

            if (innerText.Contains(adminToolTicketsContent))
            {
                result = true;
            }

            return result;
        }

        public bool CheckYourStuffProfileContent()
        {
            bool result = false;
            sidebarMenu = new SidebarMenu(manager);
            string innerText = sidebarMenu.Profile.InnerText;

            if (innerText.Contains(yourStuffProfileContent))
            {
                result = true;
            }

            return result;
        }


        public void ClickEditProfile()
        {
            GetEditProfile().Click();
        }

        public void ClickStudyToolsCourses()
        {
            GetStudyToolCourses().Click();
        }

        public void ClickStudyToolsPublicGroups()
        {
            GetStudyToolPublicGroups().Click();
        }

        public void ClickManager()
        {
            GetTeachingToolManager().Click();
        }

        public void ClickManagerGlobalDictionary()
        {
            GetTeachingToolGlobalDictionary().Click();
        }

        public void ClickManagerWordSuites()
        {
            GetTeachingToolWordSuites().Click();
        }

        public void ClickManagerCourses()
        {
            GetTeachingToolCourses().Click();
        }

        public void ClickManagerGroups()
        {
            GetTeachingToolGroups().Click();
        }

        public void ClickManagerSubscriptionRequests()
        {
            GetTeachingToolSubscriptionRequest().Click();
        }

        public void ClickAdminToolsUsers()
        {
            GetAdminToolUsers().Click();
        }

        public void ClickAdminToolsLanguages()
        {
            GetAdminToolLanguages().Click();
        }

        public void ClickAdminToolsTickets()
        {
            GetAdminToolTickets().Click();
        }

        public void ClickYourStuffProfile()
        {
            GetYourStuffProfile().Click();
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

        public UsersPage GotoUsersPage()
        {
            ClickAdminToolsUsers();
            return new UsersPage(manager);
        }

        public LanguagesPage GotoLanguagesPage()
        {
            ClickAdminToolsLanguages();
            return new LanguagesPage(manager);
        }

        public YourProfilePage GotoProfilePage()
        {
            ClickYourStuffProfile();
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
