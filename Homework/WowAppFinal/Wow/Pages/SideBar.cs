using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public class SideBar
    {
        private Manager manager;

        public SideBar(Manager manager)
        {
            this.manager = manager;
            this.ManagerTool =
                manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//section[@id='teaching-tools']//a[@id='cursorStyle']");
            this.Courses =
                manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(
                    "//ul[@class='sub']//span[contains(text(),'Courses')]/parent::a");
            this.NavigationBarCollapse = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=collapse navbar-collapse");
        }

        public HtmlAnchor ManagerTool { get; private set; }
        public HtmlAnchor Courses { get; private set; }
        public HtmlDiv NavigationBarCollapse { get; private set; }

        public void ClickManagerTool()
        {
            this.ManagerTool.Click();
        }

        public CoursesPage ClickCoursesItem()
        {
            this.Courses.Click();
            return new CoursesPage(this.manager);
        }

        public SideBar OpenManagerTool()
        {
            if (this.IsManagerToolMinimized())
            {
                this.ClickManagerTool();
            }
            return this;
        }

        public SideBar CloseManagerTool()
        {
            if (!this.IsManagerToolMinimized())
            {
                this.ClickManagerTool();
            }
            return this;
        }

        private bool IsManagerToolMinimized()
        {
            return !this.ManagerTool.BaseElement.GetAttributeValueOrEmpty("class").Contains("active");
        }
    }
}
