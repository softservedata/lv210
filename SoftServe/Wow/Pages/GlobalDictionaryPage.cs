using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System.Linq;

namespace Wow.Pages
{
    public class GlobalDictionaryPage : HeadPage
    {
        internal class AddNewWordForm
        {
            private Manager manager;
            public HtmlInputText WordTextBox { get; set; }
            public HtmlInputText TranslationTextBox { get; set; }
            public HtmlButton AddTranslationButton { get; set; }
            public HtmlButton AddWordButton { get; set; }

            public AddNewWordForm(Manager manager)
            {
                this.manager = manager;
                this.WordTextBox = manager.ActiveBrowser.Find.ById<HtmlInputText>("word");
                this.TranslationTextBox = manager.ActiveBrowser.Find.ById<HtmlInputText>("translation");
                this.AddTranslationButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=addTran()");
                this.AddWordButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=ManipulateData()");
            }
        }
        
        private AddNewWordForm addNewWordForm;
        public HtmlSelect OriginalLanguage { get; set; }
        public HtmlSelect TranslationlLanguage { get; set; }
        public HtmlButton AddButton { get; set; }
        public HtmlTable WordsTable { get; set; }

        public GlobalDictionaryPage(Manager manager) : base(manager)
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
            addNewWordForm.TranslationTextBox.Focus();
            addNewWordForm.TranslationTextBox.Text = wordTranslation;
            addNewWordForm.AddTranslationButton.Focus();
            addNewWordForm.AddTranslationButton.Click();
            addNewWordForm.AddWordButton.Refresh();
            addNewWordForm.AddWordButton.Focus();
            addNewWordForm.AddWordButton.Click();
 
            manager.ActiveBrowser.Refresh();
        }

        public bool IsWordPresentInTable(string word)
        {
            return WordsTable.AllRows.Any(x => x.InnerText.ToLower().Equals(word.ToLower()));
        }
    }
}
