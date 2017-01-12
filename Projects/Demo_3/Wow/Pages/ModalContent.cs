using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    /// <summary>
    /// For popup window that is displayed on top of the current page
    /// </summary>
    public abstract class ModalContent
    {
        protected Manager manager;

        public ModalContent(Manager manager)
        {
            this.manager = manager;
        }

        public HtmlDiv HeaderName { get; protected set; }
        public HtmlDiv BodyMessage { get; protected set; }
    }
}
