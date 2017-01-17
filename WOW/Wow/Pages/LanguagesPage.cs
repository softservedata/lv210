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
        private class ConfirmModalDialog
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

        private Manager manager;
        private ConfirmModalDialog confirmModalDialog;
        public HtmlButton DeleteLanguageButton { get; private set; }

        public LanguagesPage(Manager manager) : base(manager)
        {
            this.manager = manager;
            this.DeleteLanguageButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//td[h4[contains(text(), 'Russian')]]/following-sibling::td/button[@class='btn btn-default nomargins']");
        }

        private void ClickDeleteLanguage()
        {
            DeleteLanguageButton.Click();
            confirmModalDialog = new ConfirmModalDialog(manager);
        }

        private ConfirmModalDialog.DeleteLanguageModalDialog ConfirmDeletion()
        {
            ClickDeleteLanguage();
            confirmModalDialog.YesButton.Click();
            confirmModalDialog.deleteLanguageModalDialog = new ConfirmModalDialog.DeleteLanguageModalDialog(manager);
            return confirmModalDialog.deleteLanguageModalDialog;
        }

        public string GetErrorMessage()
        {
            ConfirmDeletion();
            return confirmModalDialog.deleteLanguageModalDialog.Message.TextContent;
        }
    }
}
