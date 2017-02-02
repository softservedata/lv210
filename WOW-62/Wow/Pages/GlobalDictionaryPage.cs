using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Pages
{
    public class GlobalDictionaryPage
    {
        internal class AddNewWordForm
        {
            private Manager manager;
            public HtmlInputText WordTextBox { get; set; }
            public HtmlInputText WordDescription { get; set; }
            public HtmlInputText WordSynonym { get; set; }
            public HtmlInputText WordTag { get; set; }
            public HtmlInputText WordComment { get; set; }
            public HtmlInputText TranslationTextBox { get; set; }
            public HtmlButton AddTranslationButton { get; set; }
            public HtmlButton AddSynonymButton { get; set; }
            public HtmlButton AddTagButton { get; set; }
            public HtmlButton AddWordButton { get; set; }
            public HtmlDiv ModalHeader { get; set; }
            public HtmlTable KeyboardMaster { get; set; }

            public AddNewWordForm(Manager manager)
            {
                this.manager = manager;
                this.WordTextBox = manager.ActiveBrowser.Find.ById<HtmlInputText>("word");
                this.TranslationTextBox = manager.ActiveBrowser.Find.ById<HtmlInputText>("translation");
                this.WordDescription = manager.ActiveBrowser.Find.ById<HtmlInputText>("description");
                this.WordSynonym = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=selectedSyn");
                this.WordTag = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=selectedTag");
                this.WordComment = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=commentOfWordToAdd");
                this.AddTranslationButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=addTran()");
                this.AddSynonymButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=addSyn()");
                this.AddTagButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=addTag()");
                this.AddWordButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=ManipulateData()");
                this.ModalHeader = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=modal-header bg-primary ng-scope");
            }
        }

        Manager manager;
        private AddNewWordForm addNewWordForm;
        public HtmlSelect OriginalLanguage { get; set; }
        public HtmlSelect TranslationlLanguage { get; set; }
        public HtmlButton AddButton { get; set; }
        public HtmlTable WordsTable { get; set; }

        public GlobalDictionaryPage(Manager manager)
        {
            this.manager = manager;
            OriginalLanguage = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=selectedOriginalLanguage");
        }

        public void SelectOriginalLanguage(string language)
        {
            OriginalLanguage.SelectByText(language, true);
            TranslationlLanguage = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=selectedTranslationLanguage");
        }

        public void SelectTranslationLanguage(string language)
        {
            TranslationlLanguage.SelectByText(language, true);
            AddButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=open()");
            WordsTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-hover width-half ng-scope");
        }

        internal AddNewWordForm ClickAddButton()
        {
            AddButton.Click();
            return new AddNewWordForm(manager);
        }

        internal void AddWord(string word, string wordTranslation)
        {
            addNewWordForm = ClickAddButton();

            addNewWordForm.WordTextBox.Focus();
            addNewWordForm.WordTextBox.Text = word;
            ////manager.Desktop.KeyBoard.TypeText(word);
            //addNewWordForm.WordDescription.Focus();
            //addNewWordForm.WordDescription.Text = "stepler";
            addNewWordForm.TranslationTextBox.Focus();
            addNewWordForm.TranslationTextBox.Text = wordTranslation;
            addNewWordForm.AddTranslationButton.Focus();
            addNewWordForm.AddTranslationButton.Click();
            //addNewWordForm.TranslationTextBox.Focus();
            //addNewWordForm.TranslationTextBox.Text = wordTranslation;
            //addNewWordForm.WordSynonym.Focus();
            //addNewWordForm.WordSynonym.Text = "stepler";
            //addNewWordForm.WordTag.Focus();
            //addNewWordForm.WordTag.Text = "stepler";
            //addNewWordForm.WordComment.Focus();
            //addNewWordForm.WordComment.Text = "stepler";
            //manager.Desktop.KeyBoard.TypeText(wordTranslation, 15);
            addNewWordForm.AddWordButton.Refresh();
            addNewWordForm.AddWordButton.Focus();
            addNewWordForm.AddWordButton.Click();

            //addNewWordForm.WordTextBox.Text = word;
            //addNewWordForm.WordDescription.Text = "stepler";
            //addNewWordForm.TranslationTextBox.Text = wordTranslation;
            //addNewWordForm.AddTranslationButton.Click();
            //addNewWordForm.TranslationTextBox.Text = wordTranslation;
            //addNewWordForm.WordSynonym.Text = "stepler";
            //addNewWordForm.AddSynonymButton.Click();
            //addNewWordForm.WordSynonym.Text = "stepler";
            //addNewWordForm.WordTag.Text = "stepler";
            //addNewWordForm.AddTagButton.Click();
            //addNewWordForm.WordTag.Text = "stepler";
            //addNewWordForm.WordComment.Text = "stepler";
            //addNewWordForm.ModalHeader.Click();
            //addNewWordForm.AddWordButton.Focus();
            //addNewWordForm.AddWordButton.Click();
            //manager.Desktop.KeyBoard.TypeText("", 10);

            //addNewWordForm.KeyboardMaster = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=keyboardInputMaster relativeKeyboard keyboardInputSize1");
            //HtmlControl closeKeyboard = manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//strong[@title='Close the keyboard']");
            ////closeKeyboard.Click();

            //while (addNewWordForm.KeyboardMaster != null)
            //{
            //    closeKeyboard.Click();
            //    //addNewWordForm.ModalHeader.MouseClick();
            //    addNewWordForm.AddWordButton.Click();
            //    closeKeyboard.Refresh();
            //}

            //return new GlobalDictionaryPage(manager); 
            manager.ActiveBrowser.Refresh();
            //WordsTable.Refresh();
        }

        public bool IsWordPresentInTable(string word)
        {
            return WordsTable.AllRows.Any(x => x.InnerText.ToLower().Equals(word.ToLower()));
        }
    }
}
