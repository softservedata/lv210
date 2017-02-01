using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wow.Pages.MyGroupsPage.EditSelectedGroupPage;

namespace Wow.Pages
{
    public class MyGroupsPage
    {
        public static readonly string GROUPSPAGE_DESCRIPTION_TEXT = "My Groups";
        // Fields
        private Manager manager;
        internal EditSelectedGroupPage editGroupPage;

        public Element MyGroupsPageDescription { get; private set; }
        public HtmlAnchor FirstEditIconInTable { get; private set; }
        public HtmlInputText ByNameSearchBox { get; private set; }

        internal class EditSelectedGroupPage
        {
            // Fields
            private Manager manager;
            internal SelectDropdownToggle selectDropdownToggle;

            internal class SelectDropdownToggle
            {
                // Fields
                private Manager manager;

                // get Data
                public HtmlAnchor CheckAllItem { get; private set; }
                public HtmlAnchor UncheckAllItem { get; private set; }
                public HtmlInputText SearchBox { get; private set; }

                // Constructor
                internal SelectDropdownToggle(Manager manager)
                {
                    this.manager = manager;
                    this.CheckAllItem = manager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("data-ng-click=selectAll()");
                    this.UncheckAllItem = manager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("data-ng-click=deselectAll();");
                    this.SearchBox = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=searchFilter");
                    // //div[@class='dropdown-header']/input     // $x("//input[@ng-model='searchFilter']")
                }

                public void ClickCheckAllItem()
                {
                    this.CheckAllItem.Click();
                }

                public void ClickUncheckAllItem()
                {
                    this.UncheckAllItem.Click();
                }

                public void FindUserViaSearchBox(string userName)
                {
                    SearchBox.Text = userName;
                }
            }

            // get Data
            public Element SelectedGroupPageDescription { get; private set; }
            public HtmlButton SelectButton { get; private set; }
            public HtmlButton SubmitChangesButton { get; private set; }

            // Constructor
            internal EditSelectedGroupPage(Manager manager)
            {
                this.manager = manager;
                this.SelectedGroupPageDescription = manager.ActiveBrowser.Find.ByAttributes("class=col-md-4 text-left blod-text ng-binding");
                this.SelectButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=dropdown-toggle ng-binding btn btn-default");
                this.SubmitChangesButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-default center-block");
            }

            public string GetSelectedGroupDescriptionText()
            {
                return this.SelectedGroupPageDescription.TextContent.Trim();
            }

            public void ClickSelectButton()
            {
                SelectButton.Click();
            }

            public void ClickSubmitChangesButton()
            {
                SubmitChangesButton.Click();
            }

            public SelectDropdownToggle OpenSelectDropdownToggle()
            {
                ClickSelectButton();
                selectDropdownToggle = new SelectDropdownToggle(manager);
                return selectDropdownToggle;
            }
        }

        // Constructor
        public MyGroupsPage(Manager manager)
        {
            this.manager = manager;
            this.MyGroupsPageDescription = manager.ActiveBrowser.Find.ByXPath("//div[@class='col-md-12 text-center']/h2");
            this.FirstEditIconInTable = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//*[@id='myJum']/div/div[3]/div[4]/table/tbody/tr/td[3]/a");    //            ("//*[@id='myJum']/div/div[3]/div[4]/table/tbody/tr[2]/td[3]/a");
            this.ByNameSearchBox = manager.ActiveBrowser.Find.ByXPath<HtmlInputText>("//div[@class='col-md-2']/input");
        }

        // Page Object
        // get Data

        public string GetMyGroupsPageDescriptionText()
        {
            return this.MyGroupsPageDescription.TextContent.Trim();
        }
        
        // Functional
        public void FindGroupViaSearchBox(string groupName)
        {
            ByNameSearchBox.Text = groupName;
        }

        // set Data
        internal EditSelectedGroupPage ClickFirstEditIconInTable()
        {
            FirstEditIconInTable.Click();
            editGroupPage = new EditSelectedGroupPage(manager);
            return editGroupPage;
        }
        
        // Business Logic
        internal EditSelectedGroupPage EditSpecificGroup(string groupName)
        {
            FindGroupViaSearchBox(groupName);
            ClickFirstEditIconInTable();
            return new EditSelectedGroupPage(manager);
        }        
    }
}
