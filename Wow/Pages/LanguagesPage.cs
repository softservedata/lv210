using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    class LanguagesPage : HeadPage
    {
        private Manager manager;
        private HtmlButton DeleteLanguageButton;

        public HtmlControl LanguagesLabel { get; private set; }
        public HtmlSelect SelectLanguage { get; private set; }
        public HtmlSpan AddLanguage { get; private set; }
        

        public LanguagesPage(Manager manager) : base(manager)
        {
            LanguagesLabel = manager.ActiveBrowser.Find.ByContent<HtmlControl>("Languages");
            SelectLanguage = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-options=language.Name for language in languageList");
            AddLanguage = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=input-group-btn");
        }

        //methods
        public void DeleteLanguage()
        {
            DeleteLanguageButton = manager.ActiveBrowser.Find.ByXPath<HtmlButton>("//td[h4[contains(text(), 'Afrikaans')]]/following-sibling::td/button[@class='btn btn-default nomargins']");
            DeleteLanguageButton.Click();
        }
    }
}
