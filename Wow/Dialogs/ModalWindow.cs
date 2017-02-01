using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;

namespace Wow.Dialogs
{
    /// <summary>
    /// For popup window that is displayed on top of the current page
    /// </summary>
    public class ModalWindow
    {
        private HtmlDiv dialogWindow;

        public ModalWindow(Manager manager)
        {
            this.dialogWindow = manager.ActiveBrowser.Find.ByXPath<HtmlDiv>("//div[contains(@class, 'modal-content')]");
            this.TitleName = dialogWindow.Find.ByXPath<HtmlControl>("//h3[contains(@class,'modal-title')]");
            this.BodyMessage = dialogWindow.Find.ByXPath<HtmlDiv>("//div[contains(@class,'modal-body')]");
        }

        public HtmlControl TitleName { get; protected set; }
        public HtmlDiv BodyMessage { get; protected set; }
        public HtmlButton Button { get; set; }

        public string GetBodyMessage()
        {
            return this.BodyMessage.BaseElement.InnerText;
        }

        public string GetTitle()
        {
            return this.TitleName.BaseElement.InnerText;
        }

        public void ClickButton(string buttonName)
        {
            dialogWindow.Refresh();
            this.Button = dialogWindow.Find.ByXPath<HtmlButton>($"//button[text()='{buttonName}']");
            this.Button.Click();
        }
    }

    public static class Button
    {
        public static string Ok { get; } = "Ok";
        public static string Yes { get; } = "Yes";
        public static string No { get; } = "No";
    }

    public static class DialogWindowTitle
    {
        public static string AddLanguage { get; } = "Add language";
    }

    public static class DialogWindowMessage
    {
        public static string AddLanguage { get; } = "Language added successfully";
    }
}
