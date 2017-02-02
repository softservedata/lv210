using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;

namespace Wow.Pages
{
    public class MyGroupsPage
    {
        internal const string GROUPSPAGE_DESCRIPTION_TEXT = "My Groups";

        //Componennts
        internal class EditSelectedGroupPage
        {
            internal class SelectDropdownToggle
            {
                private Manager manager;

                public HtmlAnchor CheckAllItem { get; private set; }
                public HtmlAnchor UncheckAllItem { get; private set; }
                public HtmlInputText SearchBox { get; private set; }
                public HtmlAnchor UserName { get; private set; }

                internal SelectDropdownToggle(Manager manager)
                {
                    this.manager = manager;
                    this.CheckAllItem = manager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("data-ng-click=selectAll()");
                    this.UncheckAllItem = manager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("data-ng-click=deselectAll();");
                    this.SearchBox = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=searchFilter");
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

                public bool IsUserPresentInDropdown(string userName)
                {
                    UserName = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>($"//a[contains(text(), '{userName}')]");
                    bool isPresent = (UserName != null);
                    return isPresent;
                }
            }

            private Manager manager;
            internal SelectDropdownToggle selectDropdownToggle;

            public Element SelectedGroupPageDescription { get; private set; }
            public HtmlButton SelectButton { get; private set; }
            public HtmlButton SubmitChangesButton { get; private set; }
            public HtmlInputText SearchBox { get; private set; }

            internal EditSelectedGroupPage(Manager manager)
            {
                this.manager = manager;
                this.SelectedGroupPageDescription = manager.ActiveBrowser.Find.ByAttributes("class=col-md-4 text-left blod-text ng-binding");
                this.SelectButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=dropdown-toggle ng-binding btn btn-default");
                this.SubmitChangesButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-default center-block");
                this.SearchBox = manager.ActiveBrowser.Find.ByXPath<HtmlInputText>("//div[@class='col-md-2']/input");
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

            public void EnterUserNameInSearch(string userName)
            {
                SearchBox.Text = userName;
            }
        }

        private Manager manager;
        internal EditSelectedGroupPage editGroupPage;

        private HtmlAnchor FirstEditIconInTable { get; set; }
        public Element MyGroupsPageDescription { get; private set; }
        public HtmlInputText ByNameSearchBox { get; private set; }

        public MyGroupsPage(Manager manager)
        {
            this.manager = manager;
            this.MyGroupsPageDescription = manager.ActiveBrowser.Find.ByXPath("//div[@class='col-md-12 text-center']/h2");
            this.FirstEditIconInTable = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//tr[@ng-repeat='group in groupsToShow']//a");
            this.ByNameSearchBox = manager.ActiveBrowser.Find.ByXPath<HtmlInputText>("//div[@class='col-md-2']/input");
        }

        public string GetMyGroupsPageDescriptionText()
        {
            return this.MyGroupsPageDescription.TextContent.Trim();
        }

        internal EditSelectedGroupPage ClickFirstEditIconInTable()
        {
            FirstEditIconInTable.Click();
            editGroupPage = new EditSelectedGroupPage(manager);
            return editGroupPage;
        }

        public void FindGroupViaSearchBox(string groupName)
        {
            ByNameSearchBox.Text = groupName;
        }

        internal EditSelectedGroupPage EditSpecificGroup(string groupName)
        {
            FindGroupViaSearchBox(groupName);
            ClickFirstEditIconInTable();
            return new EditSelectedGroupPage(manager);
        }
    }
}
