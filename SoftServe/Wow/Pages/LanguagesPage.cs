using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.ModalWindow;

namespace Wow.Pages
{
    public class LanguagesPage : HeadPage
    {
        private const string Yes = "Yes";
        private const string No = "No";
        private const string Ok = "Ok";

        internal ModalDialog modalDialog;
        private HtmlTable LanguagesTable { get; set; }
        public HtmlButton DeleteLanguageButton { get; private set; }
        public HtmlSelect LanguageSelect { get; set; }
        public HtmlButton AddLanguageButton { get; set; }

        public LanguagesPage(Manager manager) : base(manager)
        {
            this.LanguageSelect = manager.ActiveBrowser.Find.ByXPath<HtmlSelect>("//select[@ng-model='selectedLanguage']");
            this.AddLanguageButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-default btn-block");
            this.LanguagesTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-quarter");
        }

        private void SelectLanguage(string language)
        {
            LanguageSelect.SelectByText(language, true);
        }

        private void ClickAddLanguageButton()
        {
            AddLanguageButton.Click();
        }

        public void AddLanguage(string language)
        {
            if (!IsLanguagePresent(language))
            {
                SelectLanguage(language);
                ClickAddLanguageButton();
                modalDialog = new ModalDialog(manager);
            }
        }
        
        public bool IsLanguagePresent(string language)
        {
            LanguagesTable.Refresh();
            return LanguagesTable.BodyRows.Any(item => item.InnerText.ToLower().Equals(language.ToLower()));
        }

        private void ClickDeleteLanguage(string language)
        {
            string deleteButtonXpath = $"//td[h4[contains(text(), '{language}')]]/following-sibling::td/button[@class='btn btn-default nomargins']";
            this.DeleteLanguageButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>(deleteButtonXpath);
            DeleteLanguageButton.Click();
        }

        public void DeleteLanguage(string language)
        {
            ClickDeleteLanguage(language);
            modalDialog = new ModalDialog(manager);
        }

        public void ConfirmLanguageDeletion() 
        {
            modalDialog.ClickModalButton(Yes);
            modalDialog = new ModalDialog(manager);
        }

        public void CancelLanguageDeletion()
        {
            modalDialog.ClickModalButton(No);
            modalDialog = new ModalDialog(manager);
        }

        public LanguagesPage CloseModalWindow()
        {
            modalDialog.ClickModalButton(Ok);
            return new LanguagesPage(manager);
        }

        public string GetMessage()
        {
            return modalDialog.GetModalBodyMessage();
        }
    }
}
