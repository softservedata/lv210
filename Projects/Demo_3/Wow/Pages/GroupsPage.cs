using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using NUnit.Framework;

namespace Wow.Pages
{
    public class GroupsPage : HeadPage
    {
        public GroupsPage(Manager manager) : base(manager)
        {
            this.GroupsHeader = manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//div[contains(@class, 'container')]//h2[contains(text(), 'My Groups')]");
            this.CreateGroupButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//a[contains(@class, 'btn') and contains(text(), 'Create Group')]");
            this.ExistingGroupsTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=~table");
        }

        public HtmlControl GroupsHeader { get; private set; }
        public HtmlButton CreateGroupButton { get; private set; }
        public HtmlTable ExistingGroupsTable { get; private set; }
    }
}
