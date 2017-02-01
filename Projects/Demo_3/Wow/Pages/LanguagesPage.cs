using System;
using System.Collections.Generic;
using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using NUnit.Framework;

namespace Wow.Pages
{
    public class LanguagesPage : HeadPage
    {
        private DialogWindow dialogWindow;

        public LanguagesPage(Manager manager) : base(manager)
        {
            this.LanguagePageDescription = manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//h2");
            this.LanguageSelect = manager.ActiveBrowser.Find.ByXPath<HtmlSelect>("//select[contains(@class, 'form-control')]");
            this.AddLanguageButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//span[contains(@class, 'input-group-btn')]/button");
            this.LanguagesTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=~table");
        }

        public HtmlControl LanguagePageDescription { get; private set; }
        public HtmlSelect LanguageSelect { get; private set; }
        public HtmlButton AddLanguageButton { get; private set; }
        public HtmlTable LanguagesTable { get; private set; }

        enum TableHeader
        {
            Name,
            Delete
        }

        // Get Data

        public string GetLanguagePageDescription()
        {
            return LanguagePageDescription.BaseElement.InnerText;
        }

        public HtmlTableRow GetLastLanguageRowFromExistingList() // rework delition and remove cos this is sparta !!!
        {
            return LanguagesTable.BodyRows.Last();
        }

        public HtmlButton GetDeleteLanguageButtonByRow(HtmlTableRow languageRow)
        {
            return languageRow.Find.ByAttributes<HtmlButton>("class=~btn");
        }

        private string GetDialogWindowTitle()
        {
            return dialogWindow.GetTitle();
        }

        private string GetDialogWindowMessage()
        {
            return dialogWindow.GetBodyMessage();
        }

        public IList<string> GetAllLanguages()  // <----------------------- private
        {
            return LanguageSelect.Options
                .Select(option => option.Text).Skip(1).ToList();
        }

        public IList<string> GetAddedLanguages()  // <----------------------- private
        {
            IList<string> languages = new List<string>();
            int index = (int)TableHeader.Name;

            foreach (var row in LanguagesTable.BodyRows)
                languages.Add(row.Cells[index].InnerText);

            languages.Remove(TableHeader.Name.ToString());
            return languages;
        }

        public string GetNewLanguage()
        {
            string newLanguage = GetAllLanguages().Except(GetAddedLanguages()).First();

            if (newLanguage == null)
                throw new InvalidOperationException("All languages added !");

            return newLanguage;
        }

        public string GetLastLanguage()
        {
            return LanguagesTable.Rows.Last().Cells[(int)TableHeader.Name].InnerText;
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

        // Functional

        private void InitializeDialogWindow()
        {
            dialogWindow = new DialogWindow(manager);
        }

        public bool IsLanguageInExistingList(string language)
        {
            // TODO loop while()

            bool condition = LanguagesTable.BodyRows.Any(row => row.InnerText.Equals(language));
            if (condition)
                throw new Exception($"{language} present in language list");
            return false;
        }

        private bool IsAddButtonEnabled()
        {
            AddLanguageButton.Refresh();
            return AddLanguageButton.IsEnabled;
        }

        public bool IsDialogWindowAppears(string title, string message)
        {
            return GetDialogWindowTitle().Equals(title) &&
                GetDialogWindowMessage().Equals(message);
        }

        public void CloseDialogWindow()
        {
            dialogWindow.ClickButton(Button.Ok);
        }

        private void ConfirmLanguageDeletion()
        {
            dialogWindow.ClickButton(Button.Yes);
            dialogWindow.ClickButton(Button.Ok);
        }

        private void CancelLanguageDeletion()
        {
            dialogWindow.ClickButton(Button.No);
        }

        // Business Logic

        public void AddNewLanguage(string language)
        {
            SelectLanguageFromList(language);
            if (IsAddButtonEnabled())
            {
                ClickAddButton();
                LanguagesTable.Refresh();
                InitializeDialogWindow();
            }
        }

        public void DeleteLastAddedLanguage()
        {
            GetDeleteLanguageButtonByRow(GetLastLanguageRowFromExistingList()).Click();
            ConfirmLanguageDeletion();
            LanguagesTable.Refresh();
        }

        public void DeleteLanguage(string language)
        {
            int index = GetAddedLanguages().IndexOf(language);
            LanguagesTable.Rows[++index].Cells[(int)TableHeader.Delete]    // try click on cell
                .Find.ByAttributes<HtmlButton>("class=~btn").Click();
            ConfirmLanguageDeletion();
            LanguagesTable.Refresh();
        }
    }
}
