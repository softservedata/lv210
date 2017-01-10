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

        public HtmlElement LanguagesLabel { get; private set; }
        public HtmlSelect SelectLanguage { get; private set; }
        public HtmlSpan AddLanguage { get; private set; }
        public 

        public LanguagesPage(Manager manager) : base(manager)
        {
        }
    }
}
