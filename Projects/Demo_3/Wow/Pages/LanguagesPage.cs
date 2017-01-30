using System;
using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using NUnit.Framework;

namespace Wow.Pages
{
    public class LanguagesPage : HeadPage
    {
        /// <summary>
        /// Appears after adding or deleting language
        /// </summary>
        private class DialogWindow : ModalContent
        {
            public DialogWindow(Manager manager) : base(manager)
            {
                //this.OkButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-block btn-primary");
                this.OkButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//button[text()='Ok']");
            }

            public HtmlButton OkButton { get; private set; }
        }

        /// <summary>
        /// Appears to confirm or cancel deleting language
        /// </summary>
        private class ConfirmWindow : ModalContent
        {
            public ConfirmWindow(Manager manager) : base(manager)
            {
                this.YesButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//button[text()='Yes']");
                this.NoButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//button[text()='No']");
            }

            public HtmlButton NoButton { get; private set; }
            public HtmlButton YesButton { get; private set; }
        }

        private DialogWindow dialogWindow;
        private ConfirmWindow confirmWindow;

        public LanguagesPage(Manager manager) : base(manager)
        {
            //this.LanguageHeader = manager.ActiveBrowser.Find.ByAttributes("class=text-center ng-scope");
            this.LanguageHeader = manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//h2");

            //this.LanguageSelect = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=selectedLanguage");
            this.LanguageSelect = manager.ActiveBrowser.Find.ByXPath<HtmlSelect>("//select[contains(@class, 'form-control')]");

            //this.AddLanguageButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-default btn-block");
            this.AddLanguageButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//span[contains(@class, 'input-group-btn')]/button");

            //this.ExistingLanguagesTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-quarter");
            this.ExistingLanguagesTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=~table");
        }

        public HtmlControl LanguageHeader { get; private set; }
        public HtmlSelect LanguageSelect { get; private set; }
        public HtmlButton AddLanguageButton { get; private set; }
        public HtmlTable ExistingLanguagesTable { get; private set; }

        // Get Data
        public string GetLanguagePageDescription()
        {
            return LanguageHeader.ChildNodes[0].InnerText;
        }

        public HtmlTableRow GetLastLanguageRowFromExistingList()
        {
            return ExistingLanguagesTable.BodyRows.Last();
        }

        public HtmlButton GetDeleteLanguageButtonByRow(HtmlTableRow languageRow)
        {
            //return languageRow.Find.ByAttributes<HtmlButton>("class=btn btn-default nomargins");
            return languageRow.Find.ByAttributes<HtmlButton>("class=~btn");
        }

        private DialogWindow GetDialogWindow()
        {
            return dialogWindow = new DialogWindow(manager);
        }

        private string GetDialogWindowTitle()
        {
            return dialogWindow.HeaderName.InnerText;
        }

        private string GetDialogWindowMessage()
        {
            return dialogWindow.BodyMessage.InnerText;
        }

        private ConfirmWindow GetConfirmWindow()
        {
            return confirmWindow = new ConfirmWindow(manager);
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

        private void ClickOkButton()
        {
            GetDialogWindow().OkButton.Click();
        }

        // Functional
        public bool IsLanguageInExistingList(string language)
        {
            // TODO wloop while()

            bool con = ExistingLanguagesTable.BodyRows.Any(item => item.InnerText.ToLower().Equals(language.ToLower()));
            if (con)
                throw new Exception("sdsdassdas");
            return false;
        }

        private bool IsAddButtonEnabled()
        {
            AddLanguageButton.Refresh();
            return AddLanguageButton.IsEnabled;
        }

        public bool IsAddLanguageDialogWindowAppear(string title, string message)
        {
            return GetDialogWindowTitle().ToLower().Equals(title.ToLower()) &&
                GetDialogWindowMessage().ToLower().Equals(message.ToLower());
        }

        public void CloseAddLanguageDialogWindow()
        {
            ClickOkButton();
        }

        private void ConfirmLanguageDeletion()
        {
            GetConfirmWindow().YesButton.Click();
            ClickOkButton();
        }

        private void CancelLanguageDeletion()
        {
            GetConfirmWindow().NoButton.Click();
        }

        // Business Logic
        public void AddNewLanguage(string language)
        {
            SelectLanguageFromList(language);
            if (IsAddButtonEnabled())
            {
                ClickAddButton();
                ExistingLanguagesTable.Refresh();
                GetDialogWindow();
            }
        }

        public void DeleteLastAddedLanguage()
        {
            GetDeleteLanguageButtonByRow(GetLastLanguageRowFromExistingList()).Click();
            ConfirmLanguageDeletion();
            ExistingLanguagesTable.Refresh();
        }
    }
}
