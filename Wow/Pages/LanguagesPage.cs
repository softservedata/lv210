using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Data;

namespace Wow.Pages
{
    class LanguagesPage : HeadPage
    {
        // Fields
        private Manager manager;
        private string language;

        // get Data
        //html TODO
        public Element LanguagesLabel { get; private set; }
        public HtmlSelect SelectLanguageList { get; private set; }
        public HtmlSpan Add { get; private set; }
        public Element Language { get; private set; }

        //Constuctor
        public LanguagesPage(Manager manager) : base(manager)
        {
            this.manager = manager;
            LanguagesLabel = manager.ActiveBrowser.Find.ByContent("Languages");
            SelectLanguageList = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-options=language.Name for language in languageList");
            Add = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=input-group-btn");
            Language = manager.ActiveBrowser.Find.ByContent(language);
        }
    }
}
