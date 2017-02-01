using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;

namespace Wow.Dialogs
{
    public interface IModalWindow
    {
        HtmlControl ModalTitle { get; set; }
        HtmlControl ModalBodyMessage { get; set; }
        HtmlButton ModalButton { get; set; }

        string GetBodyMessage();
        string GetTitle();
        void ClickButton(string buttonTitle);
    }

    public class ModalWindow : IModalWindow
    {
        private readonly HtmlDiv modalDialog;

        public HtmlControl ModalTitle { get; set; }
        public HtmlControl ModalBodyMessage { get; set; }
        public HtmlButton ModalButton { get; set; }

        public ModalWindow(Manager manager)
        {
            this.modalDialog = manager.ActiveBrowser.Find.ByXPath<HtmlDiv>("//div[contains(@class,'modal-content')]");
            this.ModalTitle = this.modalDialog.Find.ByXPath<HtmlControl>("//h3[contains(@class,'modal-title')]");
            this.ModalBodyMessage = this.modalDialog.Find.ByXPath<HtmlControl>("//div[contains(@class,'modal-body')]");
        }

        public string GetBodyMessage()
        {
            return this.ModalBodyMessage.BaseElement.InnerText;
        }

        public string GetTitle()
        {
            return this.ModalTitle.BaseElement.InnerText;
        }

        public void ClickButton(string buttonTitle)
        {
            this.ModalButton = this.modalDialog.Find.ByXPath<HtmlButton>($"//button[contains(text(),'{buttonTitle}')]");
            this.ModalButton.Click();
        }
    }
}
