using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Dialogs;

namespace Wow.Pages
{
    public class LanguagesPage : HeadPage
    {
        public const string ErrorMessageForEnglishExistingLanguage = "English already exists";
        private ModalWindow dialogWindow;

        public LanguagesPage(Manager manager) : base(manager)
        {
            this.LanguageHeader = manager.ActiveBrowser.Find.ByAttributes("class=text-center ng-scope");
            this.LanguageSelect = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=selectedLanguage");
            this.AddLanguageButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-default btn-block");
            this.ExistingLanguagesTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-quarter");
        }

        public Element LanguageHeader { get; private set; }
        public HtmlSelect LanguageSelect { get; private set; }
        public HtmlButton AddLanguageButton { get; private set; }
        public HtmlTable ExistingLanguagesTable { get; private set; }

        // Get Data
        public string GetLanguagePageDescription()
        {
            return LanguageHeader.InnerText;
        }

        public HtmlTableRow GetLastLanguageRowFromExistingList()
        {
            return ExistingLanguagesTable.BodyRows.Last();
        }

        private void GetDialogWindow()
        {
            dialogWindow = new ModalWindow(manager);
        }

        public string GetLanguageAlreadyExistMessage()
        {
            return manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=tile-large").InnerText;
        }

        // Set Data
        public void SelectLanguageFromList(string language)
        {
            LanguageSelect.SelectByText(language, true);
        }

        private void ClickAddButton()
        {
            AddLanguageButton.Click();
        }

        private void CloseDialogWindow()
        {
            dialogWindow.ClickButton(Button.Ok);
        }

        private void ConfirmLanguageDetetion()
        {
            dialogWindow.ClickButton(Button.Yes);
            dialogWindow.ClickButton(Button.Ok);
        }

        private void CancelLanguageDeletion()
        {
            dialogWindow.ClickButton(Button.No);
        }

        // Functional
        public bool IsLanguageInExistingList(string language)
        {
            return ExistingLanguagesTable.BodyRows.Any(item => item.InnerText.Equals(language));
        }

        public bool IsAddButtonEnabled()
        {
            AddLanguageButton.Refresh();
            return AddLanguageButton.IsEnabled;
        }

        private HtmlButton GetDeleteLastLanguageButton()
        {
            return GetLastLanguageRowFromExistingList().Find.ByAttributes<HtmlButton>("class=btn btn-default nomargins");
        }

        // Business Logic
        public void AddNewLanguage(string language)
        {
            SelectLanguageFromList(language);
            if (IsAddButtonEnabled())
            {
                ClickAddButton();
                GetDialogWindow();
                CloseDialogWindow();
                ExistingLanguagesTable.Refresh();
            }
        }

        public void DeleteLastAddedLanguage()
        {
            GetDeleteLastLanguageButton().Click();
            ConfirmLanguageDetetion();
            ExistingLanguagesTable.Refresh();
        }

        public void CancelDeletingOfLastAddedLanguage()
        {
            GetDeleteLastLanguageButton().Click();
            CancelLanguageDeletion();
            ExistingLanguagesTable.Refresh();
        }
    }
}