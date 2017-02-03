using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public class ModalContent
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
