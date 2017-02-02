using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;

namespace Wow.ModalWindow
{
    public class ModalDialog : IModalWindow
    {
        private Manager manager;

        public Element ModalTitle { get; set; }
        public Element ModalBodyMessage { get; set; }
        public HtmlButton Button { get; set; }

        public ModalDialog(Manager manager)
        {
            this.manager = manager;
            this.ModalTitle = manager.ActiveBrowser.Find.ByXPath("//div[@class='modal-content']/div/h3");
            this.ModalBodyMessage = manager.ActiveBrowser.Find.ByXPath("//div[contains(@class, 'modal-body')]");
        }

        public string GetModalTitle()
        {
            return ModalTitle.InnerText;
        }

        public string GetModalBodyMessage()
        {
            return ModalBodyMessage.InnerText;
        }

        public void ClickModalButton(string buttonContent)
        {
            this.Button = manager.ActiveBrowser.Find.ByXPath<HtmlButton>($"//button[contains(text(), '{buttonContent}')]");
            this.Button.Click();
        }
    }
}
