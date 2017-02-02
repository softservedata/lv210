using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.ObjectModel;

namespace Wow.Pages
{
    public class LanguagesPage : HeadPage
    {
        internal class ConfirmModalDialog
        {
            internal class DeleteLanguageModalDialog
            {
                private Manager manager;
                internal Element Message { get; private set; }
                public Element OkButton { get; private set; }

                public DeleteLanguageModalDialog(Manager manager)
                {
                    this.manager = manager;
                    this.OkButton = manager.ActiveBrowser.Find.ByAttributes("class=btn btn-block btn-primary");
                    this.Message = manager.ActiveBrowser.Find.ByXPath("//strong[contains(text(), 'Language deleted successfully')]");
                }
            }

            private Manager manager;
            internal DeleteLanguageModalDialog deleteLanguageModalDialog;
            public HtmlButton YesButton { get; private set; }

            public ConfirmModalDialog(Manager manager)
            {
                this.manager = manager;
                this.YesButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=yes()");
            }
        }

        internal class AddLanguageModalDialog
        {
            private Manager manager;
            public HtmlButton OkButton { get; set; }

            public AddLanguageModalDialog(Manager manager)
            {
                this.manager = manager;
                OkButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-block btn-primary");
            }
        }

        private Manager manager;
        private ConfirmModalDialog confirmModalDialog;
        private AddLanguageModalDialog addLanguageModalDialog;
        private HtmlTable LanguagesTable { get; set; }
        public HtmlButton DeleteLanguageButton { get; private set; }
        public HtmlSelect LanguageSelect { get; set; }
        public HtmlButton AddLanguageButton { get; set; }
        public HtmlAnchor ManagerMenu { get; set; }

        public LanguagesPage(Manager manager) : base(manager)
        {
            this.manager = manager;
            this.LanguageSelect = manager.ActiveBrowser.Find.ByXPath<HtmlSelect>("//select[@ng-model='selectedLanguage']");
            this.AddLanguageButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-default btn-block");
            this.LanguagesTable = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>("class=table table-striped width-quarter");
            this.ManagerMenu = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//section[@id='teaching-tools']/li/a");
        }

        private void ClickManagerMenu()
        {
            ManagerMenu.Click();
        }

        public GlobalDictionaryPage GoToGlobalDictionaryPage()
        {
            ClickManagerMenu();
            HtmlAnchor globalDictionary = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[@href='Index#/GlobalDictionary']");
            globalDictionary.Click();
            return new GlobalDictionaryPage(manager);
        }

        private void SelectLanguage(string language)
        {
            LanguageSelect.SelectByText(language, true);
        }

        internal AddLanguageModalDialog AddLanguage(string language)
        {
            SelectLanguage(language);
            AddLanguageButton.Click();
            addLanguageModalDialog = new AddLanguageModalDialog(manager);
            return addLanguageModalDialog;
        }

        public LanguagesPage ClickOkButton()
        {
            addLanguageModalDialog.OkButton.Click();
            return new LanguagesPage(manager);
        }

        public bool IsLanguageAdded(string language)
        {
            LanguagesTable.Refresh();
            return LanguagesTable.BodyRows.Any(item => item.InnerText.ToLower().Equals(language.ToLower()));
        }

        private void ClickDeleteLanguage()
        {
            this.DeleteLanguageButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//td[h4[contains(text(), 'Russian')]]/following-sibling::td/button[@class='btn btn-default nomargins']");
            DeleteLanguageButton.Click();
            confirmModalDialog = new ConfirmModalDialog(manager);
        }

        internal ConfirmModalDialog.DeleteLanguageModalDialog ConfirmDeletion()
        {
            ClickDeleteLanguage();
            confirmModalDialog.YesButton.Click();
            confirmModalDialog.deleteLanguageModalDialog = new ConfirmModalDialog.DeleteLanguageModalDialog(manager);
            return confirmModalDialog.deleteLanguageModalDialog;
        }

        public string GetMessage()
        {
            return confirmModalDialog.deleteLanguageModalDialog.Message.TextContent;
        }
    }
}
