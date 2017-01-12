using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public abstract class EditForm
    {
        protected Manager manager;

        public EditForm(Manager manager)
        {
            this.manager = manager;
        }

        public HtmlInputSubmit ConfirmChanges { get; protected set; }
        public HtmlInputSubmit CancelChanges { get; protected set; }
    }
}
