using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public class CreateGroupPage: HeadPage
    {
        private HtmlInputText nameField;
        private HtmlButton submitButton;
        private HtmlDiv errorMessage;

        public CreateGroupPage(Manager manager) : base(manager)
        {
            nameField = manager.ActiveBrowser.Find.ById<HtmlInputText>("name");
            submitButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//button[@type='submit']");
        }

        public void ClickSubmitButton()
        {
            submitButton.Click();
        }

        public void SetGroupName(string name)
        {
            nameField.Text = name;
        }

        public string GetErrorMessage()
        {
            errorMessage = manager.ActiveBrowser.Find.ByXPath<HtmlDiv>("//div[@class='alert alert-danger ng-binding']");
            return errorMessage.TextContent;
        }
    }
}