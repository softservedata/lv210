using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.ObjectModel;
using NUnit.Framework;

namespace Wow.Pages
{
    public class LanguagesPage : HeadPage
    {
        private class DialogWindow
        {
            // Fields
            private Manager manager;

            // Get Data Properties
            public HtmlDiv HeaderName { get; private set; }
            public HtmlDiv BodyMessage { get; private set; }
            public HtmlButton OkButton { get; private set; }

            // Constructor
            public DialogWindow(Manager manager)
            {
                this.manager = manager;
                this.HeaderName = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-header ng-scope bg-primary");
                this.BodyMessage = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-body text-center ng-scope");
                this.OkButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-block btn-primary");
            }
        }

        private class DeleteDialogWindow
        {
            private Manager manager;

            public HtmlDiv HeaderName { get; private set; }
            public HtmlDiv BodyMessage { get; private set; }
            public HtmlButton YesButton { get; private set; }
            public HtmlButton NoButton { get; private set; }

            public DeleteDialogWindow(Manager manager)
            {
                this.manager = manager;
                this.HeaderName = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-header ng-scope bg-primary");
                this.BodyMessage = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-body text-center ng-scope");
                this.YesButton = manager.ActiveBrowser.Find.ByContent<HtmlButton>("Yes");
                this.NoButton = manager.ActiveBrowser.Find.ByContent<HtmlButton>("No");
            }
        }

        // Fields
        private DialogWindow dialogWindow;
        private DeleteDialogWindow deleteDialogWindow;

        // Get Data Properties
        public Element LanguagesLabel { get; private set; }
        public HtmlSelect SelectLanguage { get; private set; }
        public HtmlSpan AddLanguageButton { get; private set; }
        public HtmlButton DeleteLanguageButton { get; private set; }
        public HtmlTable ExistingLanguagesTable { get; private set; }


        public LanguagesPage(Manager manager) : base(manager)
        {
            this.LanguagesLabel = manager.ActiveBrowser.Find.ByContent("Languages");
            this.SelectLanguage = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-options=language.Name for language in languageList");
            this.AddLanguageButton = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=input-group-btn");
            this.ExistingLanguagesTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-quarter");
            this.DeleteLanguageButton = GetLastLanguageRowFromExistingList().Find.ByAttributes<HtmlButton>("class=btn btn-default nomargins");
        }

        // Page object
        public string GetLanguagePageDescription()
        {
            return LanguagesLabel.InnerText;
        }

        private DialogWindow GetDialogWindow()
        {
            return dialogWindow = new DialogWindow(manager);
        }

        //-------
        private DeleteDialogWindow GetDeleteLanguageDialogWindow()
        {
            return deleteDialogWindow = new DeleteDialogWindow(manager);
        }
        //-------

        private string GetDialogWindowTitle()
        {
            return dialogWindow.HeaderName.InnerText;
        }

        private string GetDialogWindowMessage()
        {
            return dialogWindow.BodyMessage.InnerText;
        }

        public HtmlTableRow GetLastLanguageRowFromExistingList()
        {
            return ExistingLanguagesTable.BodyRows.Last();
        }

        //-------
        private string GetDeleteLanguageWindowTitle()
        {
            return deleteDialogWindow.HeaderName.InnerText;
        }

        private string GetDeleteLanguageWindowMessage()
        {
            return deleteDialogWindow.BodyMessage.InnerText;
        }
        //-------

        public void SelectLanguageFromList(string language)
        {
            SelectLanguage.SelectByText(language, true);
        }

        private void ClickAddButton()
        {
            AddLanguageButton.MouseClick();
        }

        private void ClickOkOnDialogWindow()
        {
            dialogWindow.OkButton.Click();
        }

        //-------
        private void ClickDeleteButton()
        {
            DeleteLanguageButton.Click();
        }

        private void ClickNoOnDeleteDialogWindow()
        {
            deleteDialogWindow.NoButton.Click();
        }

        private void ClickYesOnDeleteDialogWindow()
        {
            deleteDialogWindow.YesButton.Click();
        }
        //-------

        public bool IsLanguageInExistingList(string language)
        {
            return ExistingLanguagesTable.BodyRows.Any(item => item.InnerText.ToLower().Equals(language.ToLower()));
        }

        public bool IsAddButtonEnabled()
        {
            AddLanguageButton.Refresh();
            return AddLanguageButton.IsEnabled;
        }

        private bool IsAddLanguageDialogWindowAppear()
        {
            return GetDialogWindowTitle() == "Add language" &&
                GetDialogWindowMessage() == "Language added successfully";
        }

        //-------
        private bool IsDeleteLanguageDialogAppear()
        {
            return GetDialogWindowTitle() == "Delete language" &&
                GetDialogWindowMessage() == "Language deleted successfully";
        }

        private bool IsDeleteLanguageWindowAppear()
        {
            return GetDialogWindowTitle() == "Delete Language" &&
                GetDialogWindowMessage().Contains("Are you sure");
        }
        //-------

        public void AddNewLanguage(string language)
        {
            SelectLanguageFromList(language);
            ClickAddButton();
            GetDialogWindow();
            if (IsAddLanguageDialogWindowAppear())
            {
                ClickOkOnDialogWindow();
            }
            ExistingLanguagesTable.Refresh();
        }

        //-------
        public void DeleteLanguage()
        {
            ClickDeleteButton();
            ClickYesOnDeleteDialogWindow();
            GetDeleteLanguageDialogWindow();
            if (IsDeleteLanguageWindowAppear())
            {
                ClickYesOnDeleteDialogWindow();
            }
            ExistingLanguagesTable.Refresh();
        }
        //-------
    }
}
