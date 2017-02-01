using System.Collections.Generic;
using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public class GroupsPage : HeadPage
    {
        private enum UserTableHeader
        {
            Name,
            Course,
            Edit,
            Delete
        }

        private BasicTable userTable;

        public GroupsPage(Manager manager) : base(manager)
        {
            this.GroupsHeader = manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//div[contains(@class, 'container')]//h2[contains(text(), 'My Groups')]");
            this.CreateGroupButton = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(@class, 'btn') and contains(text(), 'Create Group')]");
            userTable = new BasicTable(manager, "class=table");
        }

        public HtmlControl GroupsHeader { get; private set; }
        public HtmlAnchor CreateGroupButton { get; private set; }

        public CreateGroupPage ClickCreateGroup()
        {
            CreateGroupButton.Click();
            return new CreateGroupPage(manager);
        }

        private IList<string> GetExistingGroupNames()
        {
            IList<string> result = new List<string>();
            foreach (var name in userTable.GetAllColumnByIndex((int)UserTableHeader.Name))
            {
                if (!name.InnerText.ToLower().Equals(UserTableHeader.Name.ToString().ToLower()))
                {
                    result.Add(name.InnerText);
                }
            }
            return result;
        }

        public string GetExistingGroupName()
        {
            return GetExistingGroupNames().First();
        }
    }
}