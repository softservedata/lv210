using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using Wow.Pages;

namespace Wow.Components
{
    public class SideBar
    {
        private Manager manager;

        public SideBar(Manager manager)
        {
            this.manager = manager;
            this.Users = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='admin-tools']//span[text()='Users']");
            this.Languages = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='admin-tools']//span[text()='Languages']");
            this.Profile = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='your-stuff']//span[contains(text(), 'Profile')]");
            this.TeacherManagerTool = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//section[@id='teaching-tools']//a[@id='cursorStyle']");
            this.Groups = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//section[@id='teaching-tools']//span[text()='Groups']");
        }

        // 'Admin Tools' Category
        public HtmlSpan Users { get; private set; }  // ---- old value HtmlAnchor
        public HtmlSpan Languages { get; private set; } // ---- old value HtmlAnchor

        // 'Teaching Tools' Category
        public HtmlAnchor TeacherManagerTool { get; private set; }
        public HtmlSpan Groups { get; private set; }

        // 'Your Stuff' Category
        public HtmlSpan Profile { get; private set; } // ---- old value HtmlAnchor

        // Setters

        public void ClickTeacherManagerTool()
        {
            this.TeacherManagerTool.Click();
        }

        public void ClickGroupsItem()
        {
            this.Groups.Click();
        }

        public SideBar OpenTeacherManagerTool()
        {
            if (this.IsTeacherManagerToolMinimized())
            {
                this.ClickTeacherManagerTool();
            }
            return this;
        }

        public SideBar CloseTeacherManagerTool()
        {
            if (!this.IsTeacherManagerToolMinimized())
            {
                this.ClickTeacherManagerTool();
            }
            return this;
        }

        private bool IsTeacherManagerToolMinimized()
        {
            return !this.TeacherManagerTool.BaseElement.GetAttributeValueOrEmpty("class").Contains("active");
        }
    }
}
