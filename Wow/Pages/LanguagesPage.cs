﻿using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public class LanguagesPage : HeadPage
    {
        public const string ErrorMessageForEnglishExistingLanguage = "English already exists";

        private class DialogWindow : ModalContent
        {
            public DialogWindow(Manager manager) : base(manager)
            {
                this.HeaderName = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-header ng-scope bg-primary");
                this.BodyMessage = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-body text-center ng-scope");
                this.OkButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-block btn-primary");
            }

            public HtmlButton OkButton { get; private set; }
        }

        private class ConfirmWindow : ModalContent
        {
            public ConfirmWindow(Manager manager) : base(manager)
            {
                this.HeaderName = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-header bg-primary ng-scope");
                this.BodyMessage = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-body text-center ng-scope");
                this.YesButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//button[contains(text(),'Yes')]");
                this.NoButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//button[contains(text(),'No')]");
            }

            public HtmlButton NoButton { get; private set; }
            public HtmlButton YesButton { get; private set; }
        }

        private DialogWindow dialogWindow;
        private ConfirmWindow confirmWindow;

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

        public string GetLanguageAlreadyExistMessage()
        {
            return manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=tile-large").InnerText;
        }

        public HtmlTableRow GetRowByValueInColumn(string value, int columnIndex)
        {
            HtmlTableRow result = null;
            foreach (var row in ExistingLanguagesTable.Rows)
            {
                if (row.Cells[columnIndex].InnerText.ToLower().Contains(value.ToLower()))
                {
                    result = row;
                    break;
                }
            }
            return result;
        }

        public HtmlButton GetDeleteLanguageButton(string language)
        {
            return GetRowByValueInColumn(language, 0).Find.ByAttributes<HtmlButton>("class=btn btn-default nomargins");
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

        private void ClickOkOnDialogWindow()
        {
            GetDialogWindow().OkButton.Click();
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

        public bool IsAddLanguageDialogWindowAppear(string title, string message)
        {
            return GetDialogWindowTitle().ToLower().Equals(title.ToLower()) &&
                GetDialogWindowMessage().ToLower().Equals(message.ToLower());
        }

        public LanguagesPage CloseAddLanguageDialogWindow()
        {
            ClickOkOnDialogWindow();
            return this;
        }

        private void ConfirmLanguageDeletion()
        {
            GetConfirmWindow().YesButton.Click();
            ClickOkOnDialogWindow();
        }

        private void CancelLanguageDeletion()
        {
            GetConfirmWindow().NoButton.Click();
        }

        private void ClickDeleteLanguageButton(string language)
        {
            GetDeleteLanguageButton(language).Click();
        }

        // Business Logic
        public void AddNewLanguage(string language)
        {
            SelectLanguageFromList(language);
            if (IsAddButtonEnabled())
            {
                ClickAddButton();               
                GetDialogWindow();
                CloseAddLanguageDialogWindow();
                ExistingLanguagesTable.Refresh();
            }
        }

        public void DeleteLanguage(string language)
        {
            ClickDeleteLanguageButton(language);
            ConfirmLanguageDeletion();
            ExistingLanguagesTable.Refresh();
        }

        public void CancelDeletingOfLanguage(string language)
        {
            ClickDeleteLanguageButton(language);
            CancelLanguageDeletion();
            ExistingLanguagesTable.Refresh();
        }
    }
}